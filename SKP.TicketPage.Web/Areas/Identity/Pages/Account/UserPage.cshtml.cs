using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SKP.TicketPage.Services;

namespace SKP.TicketPage.Web.Areas.Identity.Pages.Account
{
    [Authorize(Roles = RoleHelper.BASE_ADMIN_INSTRUCTOR_DEVELOPER)]
    public class UserPageModel : PageModel
    {
        public UserPageModel(ITicketPageService service)
        {
            Service = service;
        }

        public ITicketPageService Service { get; }
        public IEmployee Employee { get; private set; }

        public IReadOnlyList<ITicket> AssignedTickets { get; set; }
        public IReadOnlyList<ITicket> OwnedTickets { get; set; }

        [BindProperty]
        public TicketFilterOptions AssignedFilterOptions { get; set; }
        [BindProperty]
        public TicketFilterOptions OwnedFilterOptions { get; set; }
        public int PageSize { get; set; } = 5;
        public int OwnedTicketsCurrentPage { get; set; }
        public int AssignedTicketsCurrentPage { get; set; }
        public int PageCount { get; set; }

        public async Task<IActionResult> OnGet(int id)
        {
            if (!Service.Employee.IsSignedIn(User)) return Redirect($"/Identity/Account/Login");  //  Prevent users from rendering the page unless they log in

            if (!User.IsSelf(id) && !(User.IsSuperUser())) //  Only Instructor and Developer are allowed to see data they do not own
            {
                return Redirect($"/Identity/Account/AccessDenied");
            }

            Employee = await Service.Employee.GetByIDAsync(id);

            AssignedTickets = (await Employee.GetAssignedTicketsAsync())?
                .Where(t => t.Status != ITicket.TicketStatus.Denied && t.Status != ITicket.TicketStatus.Completed)
                .ToList();
            OwnedTickets = (await Employee.GetOwnedTicketsAsync())?
                .Where(t => t.Status != ITicket.TicketStatus.Denied && t.Status != ITicket.TicketStatus.Completed)
                .ToList();

            return Page();
        }

        public IActionResult OnPostTicketEdit(int ticketID)
        {
            return Redirect($"/TicketPageEdit/{ticketID}");
        }

        public IActionResult OnPostTicketDeleteAsync(int ticketID)
        {
            return Redirect($"/TicketPageDelete/{ticketID}");
        }

        public async Task<IActionResult> OnPostAssignedTicketFilter(int id, int assignedTicketsCurrentPage)
        {
            AssignedTicketsCurrentPage = assignedTicketsCurrentPage;
            Employee = await Service.Employee.GetByIDAsync(id);

            //  All code below keeps the filter settings across server contact
            AssignedFilterOptions.EmployeeID = Employee.ID;
            OwnedFilterOptions.AuthorID = Employee.ID;

            AssignedTickets = (await Service.Ticket.FilterAsync(AssignedFilterOptions))?
                .Where(t => ((AssignedFilterOptions.Status != (int)ITicket.TicketStatus.Denied) ? (t.Status != ITicket.TicketStatus.Denied) : (true))
                && ((AssignedFilterOptions.Status != (int)ITicket.TicketStatus.Completed) ? (t.Status != ITicket.TicketStatus.Completed) : (true)))
                .ToList();
            OwnedTickets = (await Service.Ticket.FilterAsync(OwnedFilterOptions))?
                .Where(t => ((OwnedFilterOptions.Status != (int)ITicket.TicketStatus.Denied) ? (t.Status != ITicket.TicketStatus.Denied) : (true))
                && ((OwnedFilterOptions.Status != (int)ITicket.TicketStatus.Completed) ? (t.Status != ITicket.TicketStatus.Completed) : (true)))
                .ToList();

            return Page();
        }

        public async Task<IActionResult> OnPostOwnedTicketFilter(int id, int ownedTicketsCurrentPage)
        {
            OwnedTicketsCurrentPage = ownedTicketsCurrentPage;
            Employee = await Service.Employee.GetByIDAsync(id);

            //  All code below keeps the filter settings across server contact
            AssignedFilterOptions.EmployeeID = Employee.ID;
            OwnedFilterOptions.AuthorID = Employee.ID;

            AssignedTickets = (await Service.Ticket.FilterAsync(AssignedFilterOptions))?
                .Where(t => ((AssignedFilterOptions.Status != (int)ITicket.TicketStatus.Denied) ? (t.Status != ITicket.TicketStatus.Denied) : (true))
                && ((AssignedFilterOptions.Status != (int)ITicket.TicketStatus.Completed) ? (t.Status != ITicket.TicketStatus.Completed) : (true)))
                .ToList();
            OwnedTickets = (await Service.Ticket.FilterAsync(OwnedFilterOptions))?
                .Where(t => ((OwnedFilterOptions.Status != (int)ITicket.TicketStatus.Denied) ? (t.Status != ITicket.TicketStatus.Denied) : (true))
                && ((OwnedFilterOptions.Status != (int)ITicket.TicketStatus.Completed) ? (t.Status != ITicket.TicketStatus.Completed) : (true)))
                .ToList();

            return Page();
        }

        public async Task<IActionResult> OnPostDenyAsync(int id, int ticketID)
        {
            Employee = await Service.Employee.GetByIDAsync(id);

            var ticket = await Service.Ticket.GetByIDAsync(ticketID);

            var comment = AutoComment.BuildEdit(ticket, await Service.Employee.GetByIDAsync(User.GetID()), ITicket.TicketStatus.Denied, null);

            await Service.Comment.AddAsync(comment);

            var toUpdate = new TicketDTO
            {
                TicketNumber = ticket.TicketNumber,
                AuthorID = ticket.AuthorID,
                DateOfCreation = ticket.DateOfCreation,
                DepartmentID = ticket.DepartmentID,
                Description = ticket.Description,
                EndDate = ticket.EndDate,
                ID = ticket.ID,
                Priority = ticket.Priority,
                Status = ITicket.TicketStatus.Denied,
                Title = ticket.Title
            };

            await Service.Ticket.UpdateAsync(toUpdate);

            //  All code below keeps the filter settings across server contact
            AssignedFilterOptions.EmployeeID = Employee.ID;
            OwnedFilterOptions.AuthorID = Employee.ID;

            AssignedTickets = (await Service.Ticket.FilterAsync(AssignedFilterOptions))?
                .Where(t => ((AssignedFilterOptions.Status != (int)ITicket.TicketStatus.Denied) ? (t.Status != ITicket.TicketStatus.Denied) : (true))
                && ((AssignedFilterOptions.Status != (int)ITicket.TicketStatus.Completed) ? (t.Status != ITicket.TicketStatus.Completed) : (true)))
                .ToList();
            OwnedTickets = (await Service.Ticket.FilterAsync(OwnedFilterOptions))?
                .Where(t => ((OwnedFilterOptions.Status != (int)ITicket.TicketStatus.Denied) ? (t.Status != ITicket.TicketStatus.Denied) : (true))
                && ((OwnedFilterOptions.Status != (int)ITicket.TicketStatus.Completed) ? (t.Status != ITicket.TicketStatus.Completed) : (true)))
                .ToList();

            return Page();
        }

        public async Task<IActionResult> OnPostAcceptAsync(int id, int ticketID)
        {
            Employee = await Service.Employee.GetByIDAsync(id);

            var ticket = await Service.Ticket.GetByIDAsync(ticketID);

            var comment = AutoComment.BuildEdit(ticket, await Service.Employee.GetByIDAsync(User.GetID()), ITicket.TicketStatus.Completed, null);

            await Service.Comment.AddAsync(comment);

            var toUpdate = new TicketDTO
            {
                TicketNumber = ticket.TicketNumber,
                AuthorID = ticket.AuthorID,
                DateOfCreation = ticket.DateOfCreation,
                DepartmentID = ticket.DepartmentID,
                Description = ticket.Description,
                EndDate = ticket.EndDate,
                ID = ticket.ID,
                Priority = ticket.Priority,
                Status = ITicket.TicketStatus.Completed,
                Title = ticket.Title
            };

            await Service.Ticket.UpdateAsync(toUpdate);

            //  All code below keeps the filter settings across server contact
            AssignedFilterOptions.EmployeeID = Employee.ID;
            OwnedFilterOptions.AuthorID = Employee.ID;

            AssignedTickets = (await Service.Ticket.FilterAsync(AssignedFilterOptions))?
                .Where(t => ((AssignedFilterOptions.Status != (int)ITicket.TicketStatus.Denied) ? (t.Status != ITicket.TicketStatus.Denied) : (true))
                && ((AssignedFilterOptions.Status != (int)ITicket.TicketStatus.Completed) ? (t.Status != ITicket.TicketStatus.Completed) : (true)))
                .ToList();
            OwnedTickets = (await Service.Ticket.FilterAsync(OwnedFilterOptions))?
                .Where(t => ((OwnedFilterOptions.Status != (int)ITicket.TicketStatus.Denied) ? (t.Status != ITicket.TicketStatus.Denied) : (true))
                && ((OwnedFilterOptions.Status != (int)ITicket.TicketStatus.Completed) ? (t.Status != ITicket.TicketStatus.Completed) : (true)))
                .ToList();

            return Page();
        }

        public async Task<IActionResult> OnPostSinkTicket(int id, int ticketID)
        {
            Employee = await Service.Employee.GetByIDAsync(id);

            ITicket ticket = await Service.Ticket.GetByIDAsync(ticketID);

            int status = (int)ticket.Status;

            var comment = AutoComment.BuildEdit(ticket, await Service.Employee.GetByIDAsync(User.GetID()), (ITicket.TicketStatus)(status - 1), null);

            await Service.Comment.AddAsync(comment);

            TicketDTO toUpdate = new TicketDTO
            {
                TicketNumber = ticket.TicketNumber,
                AuthorID = ticket.AuthorID,
                DateOfCreation = ticket.DateOfCreation,
                DepartmentID = ticket.DepartmentID,
                Description = ticket.Description,
                EndDate = ticket.EndDate,
                ID = ticket.ID,
                Priority = ticket.Priority,
                Status = (ITicket.TicketStatus)(--status),
                Title = ticket.Title
            };

            await Service.Ticket.UpdateAsync(toUpdate);

            //  All code below keeps the filter settings across server contact
            AssignedFilterOptions.EmployeeID = Employee.ID;
            OwnedFilterOptions.AuthorID = Employee.ID;

            AssignedTickets = (await Service.Ticket.FilterAsync(AssignedFilterOptions))?
                .Where(t => ((AssignedFilterOptions.Status != (int)ITicket.TicketStatus.Denied) ? (t.Status != ITicket.TicketStatus.Denied) : (true)))
                .ToList();
            OwnedTickets = (await Service.Ticket.FilterAsync(OwnedFilterOptions))?
                .Where(t => ((OwnedFilterOptions.Status != (int)ITicket.TicketStatus.Denied) ? (t.Status != ITicket.TicketStatus.Denied) : (true)))
                .ToList();

            return Page();
        }

        public async Task<IActionResult> OnPostBubbleTicket(int id, int ticketID)
        {
            Employee = await Service.Employee.GetByIDAsync(id);

            ITicket ticket = await Service.Ticket.GetByIDAsync(ticketID);

            int status = (int)ticket.Status;

            var comment = AutoComment.BuildEdit(ticket, await Service.Employee.GetByIDAsync(User.GetID()), (ITicket.TicketStatus)(status + 1), null);

            await Service.Comment.AddAsync(comment);

            TicketDTO toUpdate = new TicketDTO
            {
                TicketNumber = ticket.TicketNumber,
                AuthorID = ticket.AuthorID,
                DateOfCreation = ticket.DateOfCreation,
                DepartmentID = ticket.DepartmentID,
                Description = ticket.Description,
                EndDate = ticket.EndDate,
                ID = ticket.ID,
                Priority = ticket.Priority,
                Status = (ITicket.TicketStatus)(++status),
                Title = ticket.Title
            };

            await Service.Ticket.UpdateAsync(toUpdate);

            //  All code below keeps the filter settings across server contact
            AssignedFilterOptions.EmployeeID = Employee.ID;
            OwnedFilterOptions.AuthorID = Employee.ID;

            AssignedTickets = (await Service.Ticket.FilterAsync(AssignedFilterOptions))?
                .Where(t => ((AssignedFilterOptions.Status != (int)ITicket.TicketStatus.Denied) ? (t.Status != ITicket.TicketStatus.Denied) : (true)))
                .ToList();
            OwnedTickets = (await Service.Ticket.FilterAsync(OwnedFilterOptions))?
                .Where(t => ((OwnedFilterOptions.Status != (int)ITicket.TicketStatus.Denied) ? (t.Status != ITicket.TicketStatus.Denied) : (true)))
                .ToList();

            return Page();
        }

        public async Task<IActionResult> OnPostQuickPause(int id, int ticketID)
        {
            Employee = await Service.Employee.GetByIDAsync(id);

            ITicket ticket = await Service.Ticket.GetByIDAsync(ticketID);

            ITicket.TicketStatus status = ((ticket.Status != ITicket.TicketStatus.Paused) ? (ITicket.TicketStatus.Paused) : (ITicket.TicketStatus.Ongoing));

            var comment = AutoComment.BuildEdit(ticket, await Service.Employee.GetByIDAsync(User.GetID()), status, null);

            await Service.Comment.AddAsync(comment);

            TicketDTO toUpdate = new TicketDTO
            {
                TicketNumber = ticket.TicketNumber,
                AuthorID = ticket.AuthorID,
                DateOfCreation = ticket.DateOfCreation,
                DepartmentID = ticket.DepartmentID,
                Description = ticket.Description,
                EndDate = ticket.EndDate,
                ID = ticket.ID,
                Priority = ticket.Priority,
                Status = status,
                Title = ticket.Title
            };

            await Service.Ticket.UpdateAsync(toUpdate);

            //  All code below keeps the filter settings across server contact
            AssignedFilterOptions.EmployeeID = Employee.ID;
            OwnedFilterOptions.AuthorID = Employee.ID;

            AssignedTickets = (await Service.Ticket.FilterAsync(AssignedFilterOptions))?
                .Where(t => ((AssignedFilterOptions.Status != (int)ITicket.TicketStatus.Denied) ? (t.Status != ITicket.TicketStatus.Denied) : (true))
                && ((AssignedFilterOptions.Status != (int)ITicket.TicketStatus.Completed) ? (t.Status != ITicket.TicketStatus.Completed) : (true)))
                .ToList();
            OwnedTickets = (await Service.Ticket.FilterAsync(OwnedFilterOptions))?
                .Where(t => ((OwnedFilterOptions.Status != (int)ITicket.TicketStatus.Denied) ? (t.Status != ITicket.TicketStatus.Denied) : (true))
                && ((OwnedFilterOptions.Status != (int)ITicket.TicketStatus.Completed) ? (t.Status != ITicket.TicketStatus.Completed) : (true)))
                .ToList();

            return Page();
        }
    }
}
