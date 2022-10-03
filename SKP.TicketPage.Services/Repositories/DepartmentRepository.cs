using Microsoft.EntityFrameworkCore;
using SKP.TicketPage.Domain;
using SKP.TicketPage.Domain.Entities;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SKP.TicketPage.Services
{
    internal sealed class DepartmentRepository : RepositoryBase<Department>, IDepartmentRepository
    {
        public DepartmentRepository(TicketPageContext context) : base(context) { }

        public async Task<bool> AddAsync(IDepartment entity)
        {
            return await AddAsync(entity.MapToInternal());
        }

        public async Task<IDepartment> GetByIDAsync(int id)
        {
            return await Task.Run(() =>
            {
                var departments = GetByAsync(d => d.ID == id).Result;

                if (departments != null && departments.Any())
                {
                    return departments
                    .SingleOrDefault()
                    .MapToPublic();
                }

                return null;
            });
        }

        public async Task<bool> RemoveAsync(IDepartment entity)
        {
            await Task.Run(() =>
            {
                var tickets = context.Set<Ticket>()
                .Where(t => t.DepartmentID == entity.ID)
                .Include(t => t.Comments)
                .ToList();

                context.RemoveRange(tickets);
            });

            return await RemoveAsync(entity.MapToInternal());
        }

        public async Task<bool> UpdateAsync(IDepartment entity)
        {
            return await UpdateAsync(entity.MapToInternal());
        }

        new public async Task<IReadOnlyList<IDepartment>> GetAllAsync()
        {
            var departments = await base.GetAllAsync();

            if (departments != null && await departments.AnyAsync())
            {
                return await departments
                .MapToPublic()
                .ToListAsync();
            }

            return new List<IDepartment>();
        }

        public async Task<IReadOnlyList<IDepartment>> FilterAsync(DepartmentFilterOptions options)
        {
            IReadOnlyList<IDepartment> departments = await GetAllAsync();

            return departments.Where(department =>
            {
                if (!string.IsNullOrWhiteSpace(options.SearchKey) && !department.Name.ToLower().Contains(options.SearchKey.ToLower()))
                {
                    return false;
                }

                return true;
            })
            .ToList();
        }
    }
}
