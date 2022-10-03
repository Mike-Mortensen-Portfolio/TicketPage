using Microsoft.EntityFrameworkCore;
using SKP.TicketPage.Domain;
using SKP.TicketPage.Domain.Entities;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SKP.TicketPage.Services
{
    internal sealed class TicketRepository : RepositoryBase<Ticket>, ITicketRepository
    {
        public TicketRepository(TicketPageContext context) : base(context) { }

        public async Task<bool> AddAsync(ITicket entity)
        {
            return await AddAsync(entity.MapToInternal());
        }

        public async Task<ITicket> GetByIDAsync(int id)
        {
            return await Task.Run(() =>
            {
                var tickets = GetByAsync(t => t.ID == id).Result;

                if (tickets != null && tickets.Any())
                {
                    return tickets
                    .SingleOrDefault()
                    .MapToPublic();
                }

                return null;
            });
        }

        public async Task<bool> RemoveAsync(ITicket entity)
        {
            return await RemoveAsync(entity.MapToInternal());
        }

        public async Task<bool> UpdateAsync(ITicket entity)
        {
            return await UpdateAsync(entity.MapToInternal());
        }

        new public async Task<IReadOnlyList<ITicket>> GetAllAsync()
        {
            return await Task.Run(() =>
            {
                var tickets = base.GetAllAsync().Result;

                if (tickets != null && tickets.Any())
                {
                    return tickets
                    .MapToPublic()
                    .OrderBy(t => t.TicketNumber)
                    .ToList();
                }

                return new List<ITicket>();
            });
        }

        public async Task<IReadOnlyList<ITicket>> GetByDepartmentAsync(int departmentID)
        {
            return await Task.Run(() =>
            {
                var tickets = base.GetByAsync(t => t.DepartmentID == departmentID).Result;

                if (tickets != null && tickets.Any())
                {
                    return tickets
                    .MapToPublic()
                    .ToList();
                }

                return new List<ITicket>();
            });
        }

        public async Task<IReadOnlyList<ITicket>> GetAssignedAsync(int employeeID)
        {
            return await context.Set<EmployeeTicket>()
            .Where(et => et.AssignedEmployeeID == employeeID)
            .Include(et => et.Ticket)
            .Select(et => et.Ticket.MapToPublic())
            .ToListAsync();
        }

        public async Task<IReadOnlyList<ITicket>> GetByEmployeeAsync(int employeeID)
        {
            var tickets = context.Set<Ticket>()
                .Where(t => t.AuthorID == employeeID);

            if (await tickets.AnyAsync())
            {
                return await tickets
                .MapToPublic()
                .ToListAsync();
            }

            return new List<ITicket>();
        }

        public async Task<IReadOnlyList<ITicket>> FilterAsync(TicketFilterOptions _options)
        {
            var tickets = ((_options.EmployeeID == -1) ? (await GetAllAsync()) : (await GetAssignedAsync(_options.EmployeeID)));

            return tickets.Where(ticket =>
            {
                if (_options.AuthorID != -1 && ticket.AuthorID != _options.AuthorID)
                {
                    return false;
                }

                if (_options.DepartmentID != -1 && ticket.DepartmentID != _options.DepartmentID)
                {
                    return false;
                }

                if (_options.Priority != -1 && ticket.Priority != (ITicket.TicketPriority)_options.Priority)
                {
                    return false;
                }

                if (_options.Status != -1 && ticket.Status != (ITicket.TicketStatus)_options.Status)
                {
                    return false;
                }

                //  Checks if the title or the ticketnumber contains the searh key. If a key is present.
                if (_options.SearchKey != null && !(ticket.Title.ToLower().Contains(_options.SearchKey.ToLower()) || ticket.TicketNumber.ToLower().Contains(_options.SearchKey.ToLower().Replace("-", string.Empty))))
                {
                    return false;
                }

                return true;
            })
           .ToList();
        }
    }
}
