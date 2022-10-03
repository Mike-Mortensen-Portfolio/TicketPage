using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;

namespace SKP.TicketPage.Services
{
    public interface IIdentityCRUDRepository<T, TID>
    {
        Task<IReadOnlyList<T>> GetAllAsync();
        Task<T> GetByIDAsync(int id);
        Task<int> GetUserIDAsync(ClaimsPrincipal principal);
        Task<IdentityResult> AddAsync(IEmployee _entity, string _password);
        Task<IdentityResult> UpdateAsync(T entity);
        Task<IdentityResult> RemoveAsync(TID id);
    }
}
