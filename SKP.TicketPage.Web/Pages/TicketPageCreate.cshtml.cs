using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SKP.TicketPage.Services;
using System.Threading.Tasks;
using System.Linq;
using System;
using Microsoft.AspNetCore.Authorization;

namespace SKP.TicketPage.Web.Pages
{
    [Authorize(Roles = RoleHelper.ADMIN_INSTRUCTOR_DEVELOPER)]
    public class TicketPageCreateModel : PageModel
    {
        public TicketPageCreateModel(ITicketPageService service)
        {
            Service = service;
        }

        public ITicketPageService Service { get; }

        [BindProperty]
        public TicketDTO Input { get; set; }

        public void OnGet()
        {
            Input = new TicketDTO
            {
                DepartmentID = -1,
                Status = ITicket.TicketStatus.Inbound
            };
        }

        public async Task<IActionResult> OnPostConfirmTicketFormAsync()
        {
            DateTime dateOfCreation = DateTime.Now;

            if (ModelState.IsValid && ITicket.Helper.ValidateTicketDates(Input, DateTime.Today))
            {
                Input.TicketNumber = await Input.GenerateTicketNumberAsync(dateOfCreation);
                Input.AuthorID = await Service.Employee.GetUserIDAsync(User);
                Input.DateOfCreation = dateOfCreation;
                Input.Status = ITicket.TicketStatus.Inbound;

                await Service.Ticket.AddAsync(Input);

                var tickets = await Service.Ticket.GetAllAsync();
                ITicket ticket = tickets.SingleOrDefault(t => t.Title == Input.Title && t.DateOfCreation == Input.DateOfCreation);

                return Redirect($"/TicketPage/{ticket.ID}");
            }

            ModelState.AddModelError("InvalidDate", "Start dato må ikke være før i dag, eller efter slut dato.");

            return Page();
        }
    }
}
