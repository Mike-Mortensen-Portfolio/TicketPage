using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;

namespace SKP.TicketPage.Services
{
    public interface IEmployeeManager : IIdentityCRUDRepository<IEmployee, int>
    {
        Task<IReadOnlyList<IEmployee>> GetByDepartmentAsync(int _departmentID);
        Task<IReadOnlyList<IEmployee>> GetByTicketAsync(int _ticketID);
        Task<bool> IsExternalUser(ClaimsPrincipal principal);

        Task<SignInResult> SignInAsync(string _userName, string _password, bool _rememberMe = false, bool _lockoutOnFail = true);
        Task SignOutAsync();
        bool IsSignedIn(ClaimsPrincipal _principal);

        Task<IReadOnlyList<IRole>> GetAllRolesAsync();
        Task<IRole> GetRoleByNameAsync(string name);
        Task<bool> IsInRoleAsync(int id, string role);
        Task<IdentityResult> AddToRoleAsync(int employeeID, string role);
        Task<IdentityResult> RemoveFromRoleAsync(int employeeID, string role);

        Task<IReadOnlyList<IEmployee>> FilterAsync(EmployeeFilterOptions options);
    }
}
