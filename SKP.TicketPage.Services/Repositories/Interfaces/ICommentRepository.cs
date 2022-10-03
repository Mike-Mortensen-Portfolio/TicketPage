using System.Collections.Generic;
using System.Threading.Tasks;

namespace SKP.TicketPage.Services
{
    public interface ICommentRepository : ICrudRepository<IComment>
    {
        Task<IReadOnlyList<IComment>> GetByEmployeeAsync(int _employeeID);
        Task<IReadOnlyList<IComment>> GetByTicketAsync(int _ticketID);
    }
}
