using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SKP.TicketPage.Services;

namespace SKP.TicketPage.Web.Pages
{
    [Authorize(Roles = RoleHelper.ADMIN_INSTRUCTOR_DEVELOPER)]
    public class TicketPageEditModel : PageModel
    {
        public TicketPageEditModel(ITicketPageService service)
        {
            Service = service;
        }

        public ITicketPageService Service { get; }
        public ITicket Ticket { get; private set; }

        [BindProperty]
        public TicketDTO Input { get; set; }

        public async Task<IActionResult> OnGetAsync(int id)
        {
            Ticket = await Service.Ticket.GetByIDAsync(id);

            Input = new TicketDTO
            {
                TicketNumber = Ticket.TicketNumber,
                AuthorID = Ticket.AuthorID,
                DateOfCreation = Ticket.DateOfCreation,
                DepartmentID = Ticket.DepartmentID,
                Description = Ticket.Description,
                StartDate = Ticket.StartDate,
                EndDate = Ticket.EndDate,
                ID = Ticket.ID,
                Priority = Ticket.Priority,
                Status = Ticket.Status,
                Title = Ticket.Title
            };

            return Page();
        }

        public async Task<IActionResult> OnPostConfirmTicketFormAsync(int id)
        {
            Ticket = await Service.Ticket.GetByIDAsync(id);

            if (ModelState.IsValid && Ticket != null && ITicket.Helper.ValidateTicketDates(Input, Ticket.DateOfCreation.Date, Ticket))
            {
                IEmployee editor = await Service.Employee.GetByIDAsync(User.GetID());

                bool priorityChanged = (Input.Priority != Ticket.Priority);
                bool statusChanged = (Input.Status != Ticket.Status);

                var comment = AutoComment.BuildEdit(Ticket, editor, ((statusChanged) ? (Input.Status) : (null)), ((priorityChanged) ? (Input.Priority) : (null)));

                await Service.Comment.AddAsync(comment);

                var toUpdate = new TicketDTO
                {
                    TicketNumber = Ticket.TicketNumber,
                    AuthorID = Ticket.AuthorID,
                    DateOfCreation = Ticket.DateOfCreation,
                    DepartmentID = Input.DepartmentID,
                    Description = Input.Description,
                    StartDate = Input.StartDate,
                    EndDate = Input.EndDate,
                    ID = Ticket.ID,
                    Priority = Input.Priority,
                    Status = Input.Status,
                    Title = Input.Title
                };

                await Service.Ticket.UpdateAsync(toUpdate);

                return Redirect($"/TicketPage/{toUpdate.ID}");
            }

            ModelState.AddModelError("InvalidDate", "Start data må ikke være før i dag, eller efter slut dato.");

            return Page();
        }
    }
}
