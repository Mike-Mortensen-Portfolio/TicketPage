using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace SKP.TicketPage.Services
{
    public interface IRepositoryBase<T>
    {
        Task<IQueryable<T>> GetAllAsync();
        Task<IQueryable<T>> GetByAsync(Expression<Func<T, bool>> _condition);
    }
}
