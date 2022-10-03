using Microsoft.EntityFrameworkCore;
using SKP.TicketPage.Domain;
using SKP.TicketPage.Domain.Entities;
using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace SKP.TicketPage.Services
{
    /// <summary>
    /// Serves as an <see langword="async"/> <see langword="base"/> for all <strong>repositories</strong> and provides common CRUD functionality
    /// </summary>
    /// <typeparam name="T"></typeparam>
    internal abstract class RepositoryBase<T> : IRepositoryBase<T> where T : class
    {
        public RepositoryBase(TicketPageContext context)
        {
            this.context = context;
        }

        protected readonly TicketPageContext context;

        public virtual async Task<bool> AddAsync(T entity)
        {
            await context.AddAsync(entity);
            return (await context.SaveChangesAsync()) > 0;
        }

        public virtual async Task<IQueryable<T>> GetAllAsync()
        {
            return await Task.Run(() =>
            {
                return context.Set<T>()
                .AsNoTracking();
            });
        }

        public virtual async Task<IQueryable<T>> GetByAsync(Expression<Func<T, bool>> condition)
        {
            return await Task.Run(() =>
            {
                return context.Set<T>()
                .Where(condition)
                .AsNoTracking();
            });
        }

        public virtual async Task<bool> RemoveAsync(T entity)
        {
            return await Task.Run(() =>
            {
                context.Remove(entity);

                return (context.SaveChanges() > 0);
            });
        }

        public virtual async Task<bool> UpdateAsync(T entity)
        {
            context.Update(entity);
            return (await context.SaveChangesAsync() > 0);
        }
    }
}
