using Microsoft.EntityFrameworkCore;
using SKP.TicketPage.Domain;
using SKP.TicketPage.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SKP.TicketPage.Services
{
    public static class EmployeeExtensions
    {
        /// <summary>
        /// Maps a <see langword="public"/> <see cref="IEmployee"/> instance to an <see langword="internal"/> <see cref="Employee"/> entity
        /// </summary>
        /// <param name="employee"></param>
        /// <returns>The <see cref="Employee"/> instance if the mapping was succesfull</returns>
        /// <exception cref="ArgumentNullException"></exception>
        internal static Employee MapToInternal(this IEmployee employee)
        {
            if (employee == null) throw new ArgumentNullException(nameof(employee), "Cannot map NULL value");

            return new Employee
            {
                Id = employee.ID,
                Active = employee.Active,
                DepartmentID = ((employee.DepartmentID == -1) ? (null) : (employee.DepartmentID)),
                Email = employee.Email,
                FirstName = employee.FirstName,
                LastName = employee.LastName,
                UserName = employee.Username
            };
        }

        /// <summary>
        /// Maps the <see langword="internal"/> <see cref="Employee"/> entity to a <see langword="public"/> <see cref="EmployeeDTO"/> masked as an <see cref="IEmployee"/> instance
        /// </summary>
        /// <param name="employee"></param>
        /// <returns>The <see cref="IEmployee"/> instance if the mapping was succesfull</returns>
        /// <exception cref="ArgumentNullException"></exception>
        internal static IEmployee MapToPublic(this Employee employee)
        {
            if (employee == null) throw new ArgumentNullException(nameof(employee), "Cannot map NULL value");

            return new EmployeeDTO
            {
                ID = employee.Id,
                Active = employee.Active,
                DepartmentID = employee.DepartmentID ?? -1,
                Email = employee.Email,
                FirstName = employee.FirstName,
                LastName = employee.LastName,
                Username = employee.UserName
            };
        }

        /// <summary>
        /// Maps a queryable range of <see langword="public"/> <see cref="IEmployee"/> entities to a queryable collection of <see langword="internal"/> <see cref="Employee"/> instances
        /// </summary>
        /// <param name="employee"></param>
        /// <returns>The collection of <see cref="Employee"/> instances if the mapping was succesfull</returns>
        /// <exception cref="ArgumentNullException"></exception>
        internal static IQueryable<Employee> MapToInternal(this IQueryable<IEmployee> employee)
        {
            if (employee == null) throw new ArgumentNullException(nameof(employee), "Cannot map NULL value");

            return employee
                .Select(d => new Employee
                {
                    Id = d.ID,
                    Active = d.Active,
                    DepartmentID = ((d.DepartmentID == -1) ? (null) : (d.DepartmentID)),
                    Email = d.Email,
                    FirstName = d.FirstName,
                    LastName = d.LastName,
                    UserName = d.Username
                });
        }

        /// <summary>
        /// Maps a queryable range of <see langword="internal"/> <see cref="Employee"/> entities to a queryable collection of <see langword="public"/> <see cref="EmployeeDTO"/> <see langword="objects"/> masked as <see cref="IEmployee"/> instances
        /// </summary>
        /// <param name="employee"></param>
        /// <returns>The collection of <see cref="IEmployee"/> instances if the mapping was succesfull</returns>
        /// <exception cref="ArgumentNullException"></exception>
        internal static IQueryable<IEmployee> MapToPublic(this IQueryable<Employee> employee)
        {
            if (employee == null) throw new ArgumentNullException(nameof(employee), "Cannot map NULL value");

            return employee
                .Select(d => new EmployeeDTO
                {
                    ID = d.Id,
                    Active = d.Active,
                    DepartmentID = d.DepartmentID ?? -1,
                    Email = d.Email,
                    FirstName = d.FirstName,
                    LastName = d.LastName,
                    Username = d.UserName
                });
        }

        /// <summary>
        /// Pulls the associated <see cref="IDepartment"/> <see langword="object"/> from DB
        /// </summary>
        /// <param name="employee"></param>
        /// <returns>An the associated <see cref="IDepartment"/> <see langword="object"/> if it exists. Otherwise, if not, <see langword="null"/></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public static async Task<IDepartment> GetDepartment(this IEmployee employee)
        {
            if (employee == null) throw new ArgumentNullException(nameof(employee), "Source can't be NULL");

            var service = new TicketPageService();

            return await service.Department.GetByIDAsync(employee.DepartmentID);
        }

        /// <summary>
        /// Pulls all assigned <see cref="ITicket"/> <see langword="objects"/> from DB
        /// </summary>
        /// <param name="employee"></param>
        /// <returns>An <see cref="IReadOnlyList{T}"/> containing all associated <see cref="ITicket"/> <see langword="objects"/> if they exist. Otherwise, if not, <see langword="null"/></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public static async Task<IReadOnlyList<ITicket>> GetAssignedTicketsAsync(this IEmployee employee)
        {
            if (employee == null) throw new ArgumentNullException(nameof(employee), "Source can't be NULL");

            var service = new TicketPageService();

            var tickets = await service.Ticket.GetAssignedAsync(employee.ID);

            return ((tickets.Count == 0) ? (null) : (tickets));
        }

        /// <summary>
        /// Pulls all <see cref="ITicket"/> <see langword="objects"/> owned by <paramref name="employee"/> from DB
        /// </summary>
        /// <param name="employee"></param>
        /// <returns>An <see cref="IReadOnlyList{T}"/> containing all owned <see cref="ITicket"/> <see langword="objects"/> if any exist. Otherwise, if not, <see langword="null"/></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public static async Task<IReadOnlyList<ITicket>> GetOwnedTicketsAsync(this IEmployee employee)
        {
            if (employee == null) throw new ArgumentNullException(nameof(employee), "Source can't be NULL");

            var service = new TicketPageService();

            var tickets = await service.Ticket.GetByEmployeeAsync(employee.ID);

            return ((tickets.Count == 0) ? (null) : (tickets));
        }

        /// <summary>
        /// Pulls all associated <see cref="IComment"/> <see langword="objects"/> from DB
        /// </summary>
        /// <param name="employee"></param>
        /// <returns>An <see cref="IReadOnlyList{T}"/> containing all associated <see cref="IComment"/> <see langword="objects"/> if they exist. Otherwise, if not, <see langword="null"/></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public static async Task<IReadOnlyList<IComment>> GetCommentsAsync(this IEmployee employee)
        {
            if (employee == null) throw new ArgumentNullException(nameof(employee), "Source can't be NULL");

            var service = new TicketPageService();

            var comments = await service.Comment.GetByEmployeeAsync(employee.ID);

            return ((comments.Count == 0) ? (null) : (comments));
        }

        /// <summary>
        /// Gets the first role that exists for <paramref name="employee"/>. This method assumes that <paramref name="employee"/> only has one single role.
        /// </summary>
        /// <param name="employee"></param>
        /// <returns>A <see langword="string"/> representing the name of the role</returns>
        public static async Task<string> GetRoleNameAsync(this IEmployee employee)
        {
            if (employee == null) throw new ArgumentNullException(nameof(employee), "Source can't be NULL");

            using var context = new TicketPageContext();
            var employeeRole = context.UserRoles.SingleOrDefault(er => er.UserId == employee.ID);

            if (employeeRole == null)
            {
                return null;
            }

            return (await context.Set<Role>().SingleOrDefaultAsync(r => r.Id == employeeRole.RoleId)).Name;
        }

        /// <summary>
        /// Applies to the role of admin, instructor and developer. This returns <see langword="false"/> if <paramref name="employee"/> does not have a role
        /// </summary>
        /// <param name="employee"></param>
        /// <returns><see langword="True"/> if the user has admin privileges; Otherwise, if not, <see langword="false"/></returns>
        public static async Task<bool> IsAdminAsync(this IEmployee employee)
        {
            if (employee == null) return false;

            string role = await employee.GetRoleNameAsync();

            if (role == null) return false;

            return (role.ToLower() == "admin" || await employee.IsSuperUserAsync());
        }

        /// <summary>
        /// Applies to the role of instructor and developer. This returns <see langword="false"/> if <paramref name="employee"/> does not have a role
        /// </summary>
        /// <param name="employee"></param>
        /// <returns><see langword="True"/> if the user has super user privileges; Otherwise, if not, <see langword="false"/></returns>
        public static async Task<bool> IsSuperUserAsync(this IEmployee employee)
        {
            if (employee == null) return false;

            string role = await employee.GetRoleNameAsync();

            if (role == null) return false;

            role = role.ToLower();

            return (role == "instructor" || role == "developer");
        }

        /// <summary>
        /// Applies to the role of system and defines a non-functional, deactivated user without login information. This returns <see langword="false"/> if <paramref name="employee"/> does not have a role.
        /// </summary>
        /// <param name="employee"></param>
        /// <returns><see langword="True"/> if the 'user' is a system account; Otherwise, if not, <see langword="false"/></returns>
        public static async Task<bool> IsSystemAsync(this IEmployee employee)
        {
            if (employee == null) return false;

            string role = await employee.GetRoleNameAsync();

            if (role == null) return false;

            role = role.ToLower();

            return (role == "system");
        }

        /// <summary>
        /// Validates if <paramref name="employee"/> has at least one <see cref="IRole"/>
        /// </summary>
        /// <param name="employee"></param>
        /// <returns><see langword="True"/> if <paramref name="employee"/> has at least one <see cref="IRole"/>; otherwise, if not, <see langword="false"/></returns>
        public static async Task<bool> HasRole(this Employee employee)
        {
            using var context = new TicketPageContext();
            var employeeRole = await context.UserRoles.FirstOrDefaultAsync(er => er.UserId == employee.Id);

            if (employeeRole == null) { return false; }

            return true;
        }

        /// <summary>
        /// Validates if <paramref name="employee"/> has at least one <see cref="IRole"/>
        /// </summary>
        /// <param name="employee"></param>
        /// <returns><see langword="True"/> if <paramref name="employee"/> has at least one <see cref="IRole"/>; otherwise, if not, <see langword="false"/></returns>
        public static async Task<bool> HasRole(this IEmployee employee)
        {
            using var context = new TicketPageContext();
            var employeeRole = await context.UserRoles.FirstOrDefaultAsync(er => er.UserId == employee.ID);

            if (employeeRole == null) { return false; }

            return true;
        }
    }
}
