using System.Collections.Generic;
using System.Threading.Tasks;

namespace SKP.TicketPage.Services
{
    public interface ITicketRepository : ICrudRepository<ITicket>
    {
        Task<IReadOnlyList<ITicket>> GetByDepartmentAsync(int _departmentID);
        Task<IReadOnlyList<ITicket>> GetAssignedAsync(int _employeeID);
        Task<IReadOnlyList<ITicket>> GetByEmployeeAsync(int _employeeID);
        Task<IReadOnlyList<ITicket>> FilterAsync(TicketFilterOptions _options);
    }
}
