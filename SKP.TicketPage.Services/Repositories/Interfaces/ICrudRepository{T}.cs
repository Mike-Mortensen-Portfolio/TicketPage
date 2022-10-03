using System.Collections.Generic;
using System.Threading.Tasks;

namespace SKP.TicketPage.Services
{
    /// <summary>
    /// Provides an <see langword="async"/> contract for common CRUD behavior
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface ICrudRepository<T>
    {
        Task<IReadOnlyList<T>> GetAllAsync();
        Task<T> GetByIDAsync(int id);
        Task<bool> AddAsync(T entity);
        Task<bool> UpdateAsync(T entity);
        Task<bool> RemoveAsync(T entity);
    }
}