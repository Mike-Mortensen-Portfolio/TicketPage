using SKP.TicketPage.Domain;
using SKP.TicketPage.Domain.Entities;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace SKP.TicketPage.Services
{
    internal sealed class CommentRepository : RepositoryBase<Comment>, ICommentRepository
    {
        public CommentRepository(TicketPageContext context) : base(context) { }

        public async Task<bool> AddAsync(IComment entity)
        {
            return await AddAsync(entity.MapToInternal());
        }

        public async Task<IComment> GetByIDAsync(int id)
        {
            return await Task.Run(() =>
            {
                var comments = GetByAsync(c => c.ID == id).Result;

                if (comments != null && comments.Any())
                {
                    return comments
                    .SingleOrDefault()
                    .MapToPublic();
                }

                return null;
            });
        }

        public async Task<bool> RemoveAsync(IComment entity)
        {
            return await RemoveAsync(entity.MapToInternal());
        }

        public async Task<bool> UpdateAsync(IComment entity)
        {
            return await UpdateAsync(entity.MapToInternal());
        }

        new public async Task<IReadOnlyList<IComment>> GetAllAsync()
        {
            var comments = await base.GetAllAsync();

            if (comments != null && await comments.AnyAsync())
            {
                return await comments
                .MapToPublic()
                .ToListAsync();
            }

            return new List<IComment>();
        }

        public async Task<IReadOnlyList<IComment>> GetByEmployeeAsync(int employeeID)
        {
            var comments = await GetByAsync(c => c.AuthorID == employeeID);

            if (comments != null && await comments.AnyAsync())
            {
                return await comments
                .MapToPublic()
                .ToListAsync();
            }

            return new List<IComment>();
        }

        public async Task<IReadOnlyList<IComment>> GetByTicketAsync(int ticketID)
        {
            var comments = await GetByAsync(c => c.TicketID == ticketID);

            if (comments != null && await comments.AnyAsync())
            {
                return await comments
                .MapToPublic()
                .ToListAsync();
            }

            return new List<IComment>();
        }
    }
}
