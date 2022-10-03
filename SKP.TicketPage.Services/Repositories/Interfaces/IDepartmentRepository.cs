using System.Collections.Generic;
using System.Threading.Tasks;

namespace SKP.TicketPage.Services
{
    public interface IDepartmentRepository : ICrudRepository<IDepartment>
    {
        Task<IReadOnlyList<IDepartment>> FilterAsync(DepartmentFilterOptions options);
    }
}
