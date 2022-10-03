using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using SKP.TicketPage.Domain;
using SKP.TicketPage.Domain.Entities;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace SKP.TicketPage.Services
{
    internal sealed class EmployeeManager : IEmployeeManager
    {
        public EmployeeManager(UserManager<Employee> userManager, SignInManager<Employee> signInManager, RoleManager<Role> roleManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _roleManager = roleManager;
        }

        private readonly UserManager<Employee> _userManager;
        private readonly SignInManager<Employee> _signInManager;
        private readonly RoleManager<Role> _roleManager;

        public async Task<IdentityResult> AddAsync(IEmployee entity, string password)
        {
            return await _userManager.CreateAsync(entity.MapToInternal(), password);
        }

        public async Task<IEmployee> GetByIDAsync(int id)
        {
            Employee employee = await _userManager.FindByIdAsync(id.ToString());

            return employee?.MapToPublic();
        }

        public async Task<IdentityResult> RemoveAsync(int id)
        {
            Employee employee = await _userManager.FindByIdAsync(id.ToString());

            using var context = new TicketPageContext();
            var employeeTickets = await context.Set<EmployeeTicket>()   //  Decoupling employee from assgined tickets
                .Where(t => t.AssignedEmployeeID == id)
                .ToListAsync();
            context.RemoveRange(employeeTickets);

            var tickets = await context.Set<Ticket>()   //  Removing owned tickets
                .Where(t => t.AuthorID == id)
                .Include(t => t.Comments)
                .ToListAsync();
            context.RemoveRange(tickets);

            var comments = await context.Set<Comment>() //  Removing owned comments
                 .Where(c => c.AuthorID == id)
                 .ToListAsync();
            context.RemoveRange(comments);

            await context.SaveChangesAsync();

            return await _userManager.DeleteAsync(employee);
        }

        public async Task<IdentityResult> UpdateAsync(IEmployee entity)
        {
            var toUpdate = await _userManager.FindByIdAsync(entity.ID.ToString());

            toUpdate.Active = entity.Active;
            toUpdate.DepartmentID = entity.DepartmentID;
            toUpdate.Email = entity.Email;
            toUpdate.FirstName = entity.FirstName;
            toUpdate.LastName = entity.LastName;

            return await _userManager.UpdateAsync(toUpdate);
        }

        public async Task<IReadOnlyList<IEmployee>> GetAllAsync()
        {
            var users = _userManager.Users;

            if (await users.AnyAsync())
            {
                return await users
                    .MapToPublic()
                    .ToListAsync();
            }

            return new List<IEmployee>();
        }

        public async Task<IReadOnlyList<IEmployee>> GetByDepartmentAsync(int departmentID)
        {
            var users = _userManager.Users.Where(e => e.DepartmentID == departmentID);

            if (await users.AnyAsync())
            {
                return await users
                    .MapToPublic()
                    .ToListAsync();
            }

            return new List<IEmployee>();
        }

        public async Task<IReadOnlyList<IEmployee>> GetByTicketAsync(int ticketID)
        {
            using var context = new TicketPageContext();
            return await context.Set<EmployeeTicket>()
            .Where(et => et.TicketID == ticketID)
            .Include(et => et.AssignedEmployee)
            .Select(et => et.AssignedEmployee.MapToPublic())
            .ToListAsync();
        }

        public async Task<SignInResult> SignInAsync(string userName, string password, bool rememberMe = false, bool lockoutOnFail = true)
        {
            return await _signInManager.PasswordSignInAsync(userName, password, rememberMe, lockoutOnFail);
        }

        public async Task<bool> IsExternalUser(ClaimsPrincipal principal)
        {
            Employee employee = await _userManager.GetUserAsync(principal);

            var result = await _userManager.GetLoginsAsync(employee);

            return result.Count > 0;
        }
        public async Task<bool> IsExternalUser(int id)
        {
            Employee employee = await _userManager.FindByIdAsync(id.ToString());

            var result = await _userManager.GetLoginsAsync(employee);

            return result.Count > 0;
        }

        public async Task SignOutAsync()
        {
            await _signInManager.SignOutAsync();
        }

        public bool IsSignedIn(ClaimsPrincipal principal)
        {
            return _signInManager.IsSignedIn(principal);
        }

        public async Task<int> GetUserIDAsync(ClaimsPrincipal principal)
        {
            return await Task.Run(() =>
            {
                if (int.TryParse(_userManager.GetUserId(principal), out int id))
                {
                    return id;
                }

                return -1;
            });
        }

        public async Task<IReadOnlyList<IRole>> GetAllRolesAsync()
        {
            return await _roleManager.Roles
                .MapToPublic()
                .ToListAsync();
        }
        public async Task<IRole> GetRoleByNameAsync(string name)
        {
            return (await _roleManager.Roles.SingleOrDefaultAsync(r => r.Name == name))?
                .MapToPublic();
        }

        public async Task<bool> IsInRoleAsync(int id, string role)
        {
            var employee = await _userManager.FindByIdAsync(id.ToString());

            return await _userManager.IsInRoleAsync(employee, role);
        }

        /// <summary>
        /// Applies to the role of <see cref="RoleHelper.ADMIN"/>, <see cref="RoleHelper.INSTRUCTOR"/> and <see cref="RoleHelper.DEVELOPER"/>
        /// </summary>
        /// <param name="id"></param>
        /// <returns><see langword="True"/> if the user has admin privileges; Otherwise, if not, <see langword="false"/></returns>
        public async Task<bool> IsAdminAsync(int id)
        {
            return (await IsInRoleAsync(id, RoleHelper.ADMIN) || await IsSuperUserAsync(id));
        }

        /// <summary>
        /// Applies to the role of <see cref="RoleHelper.INSTRUCTOR"/> and <see cref="RoleHelper.DEVELOPER"/>
        /// </summary>
        /// <param name="id"></param>
        /// <returns><see langword="True"/> if the user has super user privileges; Otherwise, if not, <see langword="false"/></returns>
        public async Task<bool> IsSuperUserAsync(int id)
        {
            return (await IsInRoleAsync(id, RoleHelper.INSTRUCTOR) || await IsInRoleAsync(id, RoleHelper.DEVELOPER));
        }

        /// <summary>
        /// Add an <see cref="IRole"/> <paramref name="role"/> to <see cref="IEmployee"/> with <paramref name="id"/>
        /// </summary>
        /// <param name="id">The ID of the <see cref="IEmployee"/></param>
        /// <param name="role">The name of the <see cref="IRole"/></param>
        /// <returns><see langword="Null"/> if <paramref name="role"/> is <see langword="null"/>. Othwerwise returns the <see cref="IdentityResult"/></returns>
        public async Task<IdentityResult> AddToRoleAsync(int id, string role)
        {
            if (role == null) { return null; }

            var employee = await _userManager.FindByIdAsync(id.ToString()); ;

            return await _userManager.AddToRoleAsync(employee, role);
        }

        /// <summary>
        /// Remove an <see cref="IRole"/> <paramref name="role"/> from <see cref="IEmployee"/> with <paramref name="id"/>
        /// </summary>
        /// <param name="id">The ID of the <see cref="IEmployee"/></param>
        /// <param name="role">The name of the <see cref="IRole"/></param>
        /// <returns><see langword="Null"/> if <paramref name="role"/> is <see langword="null"/>. Othwerwise returns the <see cref="IdentityResult"/></returns>
        public async Task<IdentityResult> RemoveFromRoleAsync(int id, string role)
        {
            if (role == null) { return null; }

            var employee = await _userManager.FindByIdAsync(id.ToString());

            return await _userManager.RemoveFromRoleAsync(employee, role);
        }

        public async Task<IReadOnlyList<IEmployee>> FilterAsync(EmployeeFilterOptions options)
        {
            IReadOnlyList<IEmployee> employees = ((options.TicketID == -1) ? (await GetAllAsync()) : (await GetByTicketAsync(options.TicketID)));

            return employees.Where(employee =>
            {
                if (options.DepartmentID != -1 && employee.DepartmentID != options.DepartmentID)
                {
                    return false;
                }

                if (options.Active != "Invalid" && bool.Parse(options.Active) != employee.Active)
                {
                    return false;
                }

                if (!string.IsNullOrWhiteSpace(options.SearchKey) && !$"{employee.FirstName.ToLower()} {employee.LastName.ToLower()}".Contains(options.SearchKey.ToLower()))
                {
                    return false;
                }

                return true;
            })
            .ToList();
        }
    }
}
