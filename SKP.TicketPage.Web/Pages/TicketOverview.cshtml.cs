using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SKP.TicketPage.Services;

namespace SKP.TicketPage.Web.Pages
{
    [Authorize(Roles = RoleHelper.ADMIN_INSTRUCTOR_DEVELOPER)]
    public class TicketOverviewModel : PageModel
    {
        public TicketOverviewModel(ITicketPageService service)
        {
            Service = service;
        }

        public ITicketPageService Service { get; set; }
        public IReadOnlyList<ITicket> Tickets { get; set; }
        [BindProperty]
        public TicketFilterOptions FilterOptions { get; set; }
        [BindProperty]
        public string TicketID { get; set; }

        public int PageSize { get; set; } = 10;
        public int CurrentPage { get; set; }

        public async Task OnGet()
        {
            CurrentPage = 1;
            Tickets = await Service.Ticket.GetAllAsync();
            Tickets = Tickets
                .Where(t => t.Status != ITicket.TicketStatus.Completed && t.Status != ITicket.TicketStatus.Denied)
                .ToList();
        }

        public async Task<IActionResult> OnPostTicketFilterAsync(int currentPage)
        {
            CurrentPage = currentPage;

            Tickets = await Service.Ticket.FilterAsync(FilterOptions);

            if (FilterOptions.Status == -1)
            {
                Tickets = Tickets
                .Where(t => t.Status != ITicket.TicketStatus.Completed && t.Status != ITicket.TicketStatus.Denied)
                .ToList();
            }

            return Page();
        }

        public IActionResult OnPostTicketEdit(int ticketID)
        {
            return Redirect($"/TicketPageEdit/{ticketID}");
        }

        public IActionResult OnPostTicketDelete(int ticketID)
        {
            return Redirect($"/TicketPageDelete/{ticketID}");
        }

        public async Task<IActionResult> OnPostDenyAsync(int ticketID)
        {
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
            FilterOptions = new TicketFilterOptions
            {
                DepartmentID = FilterOptions.DepartmentID,
                Priority = FilterOptions.Priority,
                SearchKey = FilterOptions.SearchKey,
                Status = FilterOptions.Status
            };

            Tickets = await Service.Ticket.FilterAsync(FilterOptions);

            if (FilterOptions.Status == -1)
            {
                Tickets = Tickets
                .Where(t => t.Status != ITicket.TicketStatus.Completed && t.Status != ITicket.TicketStatus.Denied)
                .ToList();
            }

            return Page();
        }

        public async Task<IActionResult> OnPostAcceptAsync(int ticketID)
        {
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
            FilterOptions = new TicketFilterOptions
            {
                DepartmentID = FilterOptions.DepartmentID,
                Priority = FilterOptions.Priority,
                SearchKey = FilterOptions.SearchKey,
                Status = FilterOptions.Status
            };

            Tickets = await Service.Ticket.FilterAsync(FilterOptions);

            if (FilterOptions.Status == -1)
            {
                Tickets = Tickets
                .Where(t => t.Status != ITicket.TicketStatus.Completed && t.Status != ITicket.TicketStatus.Denied)
                .ToList();
            }

            return Page();
        }

        public async Task<IActionResult> OnPostSinkTicket(int ticketID)
        {
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
            FilterOptions = new TicketFilterOptions
            {
                DepartmentID = FilterOptions.DepartmentID,
                Priority = FilterOptions.Priority,
                SearchKey = FilterOptions.SearchKey,
                Status = FilterOptions.Status
            };

            Tickets = await Service.Ticket.FilterAsync(FilterOptions);

            if (FilterOptions.Status == -1)
            {
                Tickets = Tickets
                .Where(t => t.Status != ITicket.TicketStatus.Completed && t.Status != ITicket.TicketStatus.Denied)
                .ToList();
            }

            return Page();
        }

        public async Task<IActionResult> OnPostBubbleTicket(int ticketID)
        {
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
            FilterOptions = new TicketFilterOptions
            {
                DepartmentID = FilterOptions.DepartmentID,
                Priority = FilterOptions.Priority,
                SearchKey = FilterOptions.SearchKey,
                Status = FilterOptions.Status
            };

            Tickets = await Service.Ticket.FilterAsync(FilterOptions);

            if (FilterOptions.Status == -1)
            {
                Tickets = Tickets
                .Where(t => t.Status != ITicket.TicketStatus.Completed && t.Status != ITicket.TicketStatus.Denied)
                .ToList();
            }

            return Page();
        }

        public async Task<IActionResult> OnPostQuickPause(int ticketID)
        {
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
            FilterOptions = new TicketFilterOptions
            {
                DepartmentID = FilterOptions.DepartmentID,
                Priority = FilterOptions.Priority,
                SearchKey = FilterOptions.SearchKey,
                Status = FilterOptions.Status
            };

            Tickets = await Service.Ticket.FilterAsync(FilterOptions);

            if (FilterOptions.Status == -1)
            {
                Tickets = Tickets
                .Where(t => t.Status != ITicket.TicketStatus.Completed && t.Status != ITicket.TicketStatus.Denied)
                .ToList();
            }

            return Page();
        }
    }
}
