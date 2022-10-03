using SKP.TicketPage.Domain;
using SKP.TicketPage.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SKP.TicketPage.Services
{
    public static class TicketExtensions
    {
        /// <summary>
        /// Maps a <see langword="public"/> <see cref="ITicket"/> instance to an <see langword="internal"/> <see cref="Ticket"/> entity
        /// </summary>
        /// <param name="ticket"></param>
        /// <returns>The <see cref="Ticket"/> instance if the mapping was succesfull</returns>
        /// <exception cref="ArgumentNullException"></exception>
        internal static Ticket MapToInternal(this ITicket ticket)
        {
            if (ticket == null) throw new ArgumentNullException(nameof(ticket), "Cannot map NULL value");

            var mappedTicket = new Ticket
            {
                ID = ticket.ID,
                TicketNumber = ticket.TicketNumber,
                AuthorID = ticket.AuthorID,
                DateOfCreation = ticket.DateOfCreation,
                DepartmentID = ticket.DepartmentID,
                Description = ticket.Description,
                StartDate = ticket.StartDate,
                EndDate = ticket.EndDate,
                Priority = (Ticket.TicketPriority)ticket.Priority,
                Status = (Ticket.TicketStatus)ticket.Status,
                Title = ticket.Title
            };

            return mappedTicket;
        }

        /// <summary>
        /// Maps the <see langword="internal"/> <see cref="Ticket"/> entity to a <see langword="public"/> <see cref="TicketDTO"/> masked as an <see cref="ITicket"/> instance
        /// </summary>
        /// <param name="ticket"></param>
        /// <returns>The <see cref="ITicket"/> instance if the mapping was succesfull</returns>
        /// <exception cref="ArgumentNullException"></exception>
        internal static ITicket MapToPublic(this Ticket ticket)
        {
            if (ticket == null) throw new ArgumentNullException(nameof(ticket), "Cannot map NULL value");

            var mappedTicket = new TicketDTO
            {
                ID = ticket.ID,
                TicketNumber = ticket.TicketNumber,
                AuthorID = ticket.AuthorID,
                DateOfCreation = ticket.DateOfCreation,
                DepartmentID = ticket.DepartmentID,
                Description = ticket.Description,
                StartDate = ticket.StartDate,
                EndDate = ticket.EndDate,
                Priority = (ITicket.TicketPriority)ticket.Priority,
                Status = (ITicket.TicketStatus)ticket.Status,
                Title = ticket.Title
            };

            return mappedTicket;
        }

        /// <summary>
        /// Maps a queryable range of <see langword="public"/> <see cref="ITicket"/> entities to a queryable collection of <see langword="internal"/> <see cref="Ticket"/> instances
        /// </summary>
        /// <param name="ticket"></param>
        /// <returns>The collection of <see cref="Ticket"/> instances if the mapping was succesfull</returns>
        /// <exception cref="ArgumentNullException"></exception>
        internal static IQueryable<Ticket> MapToInternal(this IQueryable<ITicket> ticket)
        {
            if (ticket == null) throw new ArgumentNullException(nameof(ticket), "Cannot map NULL value");

            return ticket
                .Select(t => new Ticket
                {
                    ID = t.ID,
                    TicketNumber = t.TicketNumber,
                    AuthorID = t.AuthorID,
                    DateOfCreation = t.DateOfCreation,
                    DepartmentID = t.DepartmentID,
                    Description = t.Description,
                    StartDate = t.StartDate,
                    EndDate = t.EndDate,
                    Priority = (Ticket.TicketPriority)t.Priority,
                    Status = (Ticket.TicketStatus)t.Status,
                    Title = t.Title
                });
        }

        /// <summary>
        /// Maps a queryable range of <see langword="internal"/> <see cref="Ticket"/> entities to a queryable collection of <see langword="public"/> <see cref="TicketDTO"/> <see langword="objects"/> masked as <see cref="ITicket"/> instances
        /// </summary>
        /// <param name="ticket"></param>
        /// <returns>The collection of <see cref="ITicket"/> instances if the mapping was succesfull</returns>
        /// <exception cref="ArgumentNullException"></exception>
        internal static IQueryable<ITicket> MapToPublic(this IQueryable<Ticket> ticket)
        {
            if (ticket == null) throw new ArgumentNullException(nameof(ticket), "Cannot map NULL value");

            return ticket
                .Select(t => new TicketDTO
                {
                    ID = t.ID,
                    TicketNumber = t.TicketNumber,
                    AuthorID = t.AuthorID,
                    DateOfCreation = t.DateOfCreation,
                    DepartmentID = t.DepartmentID,
                    Description = t.Description,
                    StartDate = t.StartDate,
                    EndDate = t.EndDate,
                    Priority = (ITicket.TicketPriority)t.Priority,
                    Status = (ITicket.TicketStatus)t.Status,
                    Title = t.Title
                });
        }

        /// <summary>
        /// Pulls the associated author <see cref="IEmployee"/> <see langword="object"/> from DB
        /// </summary>
        /// <param name="ticket"></param>
        /// <returns>An the associated <see cref="IEmployee"/> <see langword="object"/> if it exists. Otherwise, if not, <see langword="null"/></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public static async Task<IEmployee> GetAuthorAsync(this ITicket ticket)
        {
            if (ticket == null) throw new ArgumentNullException(nameof(ticket), "Source can't be NULL");

            return await new TicketPageService(null, null, null).Employee.GetByIDAsync(ticket.AuthorID);
        }

        /// <summary>
        /// Pulls the associated <see cref="IDepartment"/> <see langword="object"/> from DB
        /// </summary>
        /// <param name="ticket"></param>
        /// <returns>An the associated <see cref="IDepartment"/> <see langword="object"/> if it exists. Otherwise, if not, <see langword="null"/></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public static async Task<IDepartment> GetDepartmentAsync(this ITicket ticket)
        {
            if (ticket == null) throw new ArgumentNullException(nameof(ticket), "Source can't be NULL");

            return await new TicketPageService().Department.GetByIDAsync(ticket.DepartmentID);
        }

        /// <summary>
        /// Pulls all associated <see cref="IEmployee"/> <see langword="objects"/> from DB
        /// </summary>
        /// <param name="_employee"></param>
        /// <returns>An <see cref="IReadOnlyList{T}"/> containing all associated <see cref="IEmployee"/> <see langword="objects"/> if they exist. Otherwise, if not, <see langword="null"/></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public static async Task<IReadOnlyList<IEmployee>> GetAssignedEmployeesAsync(this ITicket ticket)
        {
            if (ticket == null) throw new ArgumentNullException(nameof(ticket), "Source can't be NULL");

            var service = new TicketPageService(null, null, null);

            var employees = await service.Employee.GetByTicketAsync(ticket.ID);

            return ((employees.Count == 0) ? (null) : (employees));
        }

        /// <summary>
        /// Pulls all associated <see cref="IComment"/> <see langword="objects"/> from DB
        /// </summary>
        /// <param name="_employee"></param>
        /// <returns>An <see cref="IReadOnlyList{T}"/> containing all associated <see cref="IComment"/> <see langword="objects"/> if they exist. Otherwise, if not, <see langword="null"/></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public static async Task<IReadOnlyList<IComment>> GetComentsAsync(this ITicket ticket)
        {
            if (ticket == null) throw new ArgumentNullException(nameof(ticket), "Source can't be NULL");

            var service = new TicketPageService();

            var comments = await service.Comment.GetByTicketAsync(ticket.ID);

            return ((comments.Count == 0) ? (null) : (comments));
        }

        /// <summary>
        /// Assign <paramref name="employee"/> to the <see cref="ITicket"/>
        /// </summary>
        /// <param name="ticket">The <see cref="ITicket"/> to assign the <see cref="IEmployee"/> to</param>
        /// <param name="employee">The <see cref="IEmployee"/> to assign the <see cref="ITicket"/></param>
        /// <returns><see langword="True"/> if <paramref name="employee"/> could be assigned. Otherwise, if not, <see langword="false"/></returns>
        public static async Task<bool> AssignEmployee(this ITicket ticket, IEmployee employee)
        {
            if (ticket == null) throw new ArgumentNullException(nameof(ticket), "Source can't be NULL");

            if (employee == null) return false;   //  Avoid operations if employee object is NULL

            var employees = await ticket.GetAssignedEmployeesAsync() ?? new List<IEmployee>();

            if (employees.SingleOrDefault(e => e.ID == employee.ID) == null)
            {
                using var context = new TicketPageContext();
                await context.Set<EmployeeTicket>()
                    .AddAsync(new EmployeeTicket { TicketID = ticket.ID, DateAssigned = DateTime.Now, AssignedEmployeeID = employee.ID });

                return context.SaveChanges() > 0;
            }

            return false;
        }

        /// <summary>
        /// Remove <paramref name="employee"/> from the <see cref="ITicket"/>
        /// </summary>
        /// <param name="ticket">The <see cref="ITicket"/> to remove the <see cref="IEmployee"/> from</param>
        /// <param name="employee">The <see cref="IEmployee"/> to remove from the <see cref="ITicket"/></param>
        /// <returns><see langword="True"/> if <paramref name="employee"/> could be removed. Otherwise, if not, <see langword="false"/></returns>
        public static async Task<bool> RemoveEmployee(this ITicket ticket, IEmployee employee)
        {
            if (ticket == null) throw new ArgumentNullException(nameof(ticket), "Source can't be NULL");

            if (employee == null) return false;   //  Avoid operations if employee object is NULL

            var employees = await ticket.GetAssignedEmployeesAsync() ?? new List<IEmployee>();

            if (employees.SingleOrDefault(e => e.ID == employee.ID) != null)
            {
                using var context = new TicketPageContext();
                context.Set<EmployeeTicket>()
                   .Remove(new EmployeeTicket { TicketID = ticket.ID, AssignedEmployeeID = employee.ID });

                return context.SaveChanges() > 0;
            }

            return false;
        }

        /// <summary>
        /// Generates a ticket number for the given <see cref="ITicket"/> based on the following format: [Department Prefix][Date of Creation][Serial Number]
        /// </summary>
        /// <param name="ticket"></param>
        /// <returns>The <see langword="string"/> representaion of the ticket number</returns>
        public static async Task<string> GenerateTicketNumberAsync(this ITicket ticket, DateTime dateOfCreation)
        {
            ITicketPageService service = new TicketPageService();

            IDepartment department = await ticket.GetDepartmentAsync();
            ITicket latestTicket = (await service.Ticket.GetAllAsync())
                .Where(t => t.TicketNumber.StartsWith($"{((department.IncludePrefix) ? (department.Prefix) : (string.Empty))}{dateOfCreation:yyMMdd}"))
                .OrderByDescending(t => t.TicketNumber).FirstOrDefault();   //  Fetches the tickets created under a specific department on a specific date and takes the latest ticket.
            int serialNumber = ((latestTicket != null) ? (int.Parse(latestTicket.GetTicketNumber().Split("-")[1]) + 1) : (1)); //  Takes the serial number of the latest ticket and increments it by one (If no ticket in that department has ben raised today the serial number is set to 1). This is the serial number used for the new ticket.


            return $"{((department.IncludePrefix) ? (department.Prefix) : (string.Empty))}{dateOfCreation:yyMMdd}{serialNumber:D3}";
        }

        /// <summary>
        /// Formates the <see cref="ITicket.TicketNumber"/> in the following format: [<see cref="IDepartment.Prefix"/>][YYMMDD]-[Serial Number] - Example: E220304-001
        /// </summary>
        /// <param name="ticket"></param>
        /// <returns>A formatted <see langword="string"/> that represents a <see cref="ITicket.TicketNumber"/></returns>
        public static string GetTicketNumber(this ITicket ticket)
        {
            if (ticket == null) throw new ArgumentNullException(nameof(ticket), "Source can't be NULL");

            string ticketNum = ticket.TicketNumber[0..^3];
            string serialNum = ticket.TicketNumber[^3..];

            return $"{ticketNum}-{serialNum}";
        }

        /// <summary>
        /// Changes the <strong>prefix</strong> of a tickets case number if possible
        /// </summary>
        /// <param name="ticket"></param>
        /// <param name="prefix"></param>
        /// <returns><see langword="True"/> if the process could be completed. Otherwise, if the process would result in a duplicated case number, <see langword="false"/></returns>
        public static async Task<bool> ChangeTicketNumberPrefixAsync(this ITicket ticket, string prefix)
        {
            if (ticket == null) throw new ArgumentNullException(nameof(ticket), "Source can't be NULL");

            var service = new TicketPageService();

            string date = ticket.DateOfCreation.ToString("yyMMdd");
            string serialNumber = ticket.GetTicketNumber().Split("-")[1];

            var toUpdate = new TicketDTO
            {
                AuthorID = ticket.AuthorID,
                DateOfCreation = ticket.DateOfCreation,
                DepartmentID = ticket.DepartmentID,
                Description = ticket.Description,
                EndDate = ticket.EndDate,
                ID = ticket.ID,
                Priority = ticket.Priority,
                StartDate = ticket.StartDate,
                Status = ticket.Status,
                TicketNumber = $"{prefix}{date}{serialNumber}",
                Title = ticket.Title
            };

            if ((await service.Ticket.GetAllAsync()).SingleOrDefault(t => t.TicketNumber == toUpdate.TicketNumber) == null && await service.Ticket.UpdateAsync(toUpdate))
            {
                return true;
            }

            return false;
        }
    }
}
