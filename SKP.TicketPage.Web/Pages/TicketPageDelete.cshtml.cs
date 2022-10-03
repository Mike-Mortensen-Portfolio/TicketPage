using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SKP.TicketPage.Services;

namespace SKP.TicketPage.Web.Pages
{
    [Authorize(Roles = RoleHelper.ADMIN_INSTRUCTOR_DEVELOPER)]
    public class TicketPageDeleteModel : PageModel
    {
        public TicketPageDeleteModel(ITicketPageService service)
        {
            Service = service;
        }

        public ITicketPageService Service { get; }
        public ITicket Ticket { get; private set; }

        [BindProperty]
        public InputModel Input { get; set; }

        public class InputModel
        {
            [Required]
            public string Title { get; set; }
        }

        public async Task<IActionResult> OnGetAsync(int id)
        {
            Ticket = await Service.Ticket.GetByIDAsync(id);

            return Page();
        }

        public async Task<IActionResult> OnPostDeleteAsync(int id)
        {
            Ticket = await Service.Ticket.GetByIDAsync(id);

            if (ModelState.IsValid && Input.Title == Ticket.Title)
            {
                if (await Service.Ticket.RemoveAsync(Ticket))
                {
                    return Redirect("/");
                }
            }

            return Page();
        }
    }
}
