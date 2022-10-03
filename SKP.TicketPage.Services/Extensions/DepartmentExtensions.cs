using SKP.TicketPage.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SKP.TicketPage.Services
{
    public static class DepartmentExtensions
    {
        /// <summary>
        /// Maps a <see langword="public"/> <see cref="IDepartment"/> instance to an <see langword="internal"/> <see cref="Department"/> entity
        /// </summary>
        /// <param name="department"></param>
        /// <returns>The <see cref="Department"/> instance if the mapping was succesfull</returns>
        /// <exception cref="ArgumentNullException"></exception>
        internal static Department MapToInternal(this IDepartment department)
        {
            if (department == null) throw new ArgumentNullException(nameof(department), "Cannot map NULL value");

            return new Department
            {
                ID = department.ID,
                Name = department.Name,
                Prefix = department.Prefix,
                IncludePrefix = department.IncludePrefix
            };
        }

        /// <summary>
        /// Maps the <see langword="internal"/> <see cref="Department"/> entity to a <see langword="public"/> <see cref="DepartmentDTO"/> masked as an <see cref="IDepartment"/> instance
        /// </summary>
        /// <param name="department"></param>
        /// <returns>The <see cref="IDepartment"/> instance if the mapping was succesfull</returns>
        /// <exception cref="ArgumentNullException"></exception>
        internal static IDepartment MapToPublic(this Department department)
        {
            if (department == null) throw new ArgumentNullException(nameof(department), "Cannot map NULL value");

            return new DepartmentDTO
            {
                ID = department.ID,
                Name = department.Name,
                Prefix = department.Prefix,
                IncludePrefix = department.IncludePrefix
            };
        }

        /// <summary>
        /// Maps a queryable range of <see langword="public"/> <see cref="IDepartment"/> entities to a queryable collection of <see langword="internal"/> <see cref="Department"/> instances
        /// </summary>
        /// <param name="departments"></param>
        /// <returns>The collection of <see cref="Department"/> instances if the mapping was succesfull</returns>
        /// <exception cref="ArgumentNullException"></exception>
        internal static IQueryable<Department> MapToInternal(this IQueryable<IDepartment> departments)
        {
            if (departments == null) throw new ArgumentNullException(nameof(departments), "Cannot map NULL value");

            return departments
                .Select(d => new Department
                {
                    ID = d.ID,
                    Name = d.Name,
                    Prefix = d.Prefix,
                    IncludePrefix = d.IncludePrefix
                });
        }

        /// <summary>
        /// Maps a queryable range of <see langword="internal"/> <see cref="Department"/> entities to a queryable collection of <see langword="public"/> <see cref="DepartmentDTO"/> <see langword="objects"/> masked as <see cref="IDepartment"/> instances
        /// </summary>
        /// <param name="departments"></param>
        /// <returns>The collection of <see cref="IDepartment"/> instances if the mapping was succesfull</returns>
        /// <exception cref="ArgumentNullException"></exception>
        internal static IQueryable<IDepartment> MapToPublic(this IQueryable<Department> departments)
        {
            if (departments == null) throw new ArgumentNullException(nameof(departments), "Cannot map NULL value");

            return departments
                .Select(d => new DepartmentDTO
                {
                    ID = d.ID,
                    Name = d.Name,
                    Prefix = d.Prefix,
                    IncludePrefix = d.IncludePrefix
                });
        }

        /// <summary>
        /// Pulls all associated <see cref="IEmployee"/> <see langword="objects"/> from DB
        /// </summary>
        /// <param name="department"></param>
        /// <returns>An <see cref="IReadOnlyList{T}"/> containing all associated <see cref="IEmployee"/> <see langword="objects"/> if they exist. Otherwise, if not, <see langword="null"/></returns>
        public static async Task<IReadOnlyList<IEmployee>> GetEmployeesAsync(this IDepartment department)
        {
            if (department == null) throw new ArgumentNullException(nameof(department), "Source can't be NULL");

            var service = new TicketPageService();

            var employees = await service.Employee.GetByDepartmentAsync(department.ID);

            return ((employees.Count == 0) ? (null) : (employees));
        }

        /// <summary>
        /// Pulls all associated <see cref="ITicket"/> <see langword="objects"/> from DB
        /// </summary>
        /// <param name="department"></param>
        /// <returns>An <see cref="IReadOnlyList{T}"/> containing all associated <see cref="ITicket"/> <see langword="objects"/> if they exist. Otherwise, if not, <see langword="null"/></returns>
        public static async Task<IReadOnlyList<ITicket>> GetTicketsAsync(this IDepartment department)
        {
            if (department == null) throw new ArgumentNullException(nameof(department), "Source can't be NULL");

            var service = new TicketPageService();

            var tickets = await service.Ticket.GetByDepartmentAsync(department.ID);

            return ((tickets.Count == 0) ? (null) : (tickets));
        }
    }
}
