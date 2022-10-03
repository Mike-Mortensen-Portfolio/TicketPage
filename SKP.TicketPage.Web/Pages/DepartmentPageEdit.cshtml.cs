using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SKP.TicketPage.Services;
using SKP.TicketPage.Web.Pages.Shared.Departments.Models;

namespace SKP.TicketPage.Web.Pages
{
    [Authorize(Roles = RoleHelper.INSTRUCTOR_DEVELOPER)]
    public class DepartmentPageEditModel : PageModel
    {
        public DepartmentPageEditModel(ITicketPageService service)
        {
            Service = service;
        }

        public ITicketPageService Service { get; }
        public IDepartment Department { get; set; }
        [BindProperty]
        public DepartmentDTO Input { get; set; }

        public async Task<IActionResult> OnGetAsync(int id)
        {
            Department = await Service.Department.GetByIDAsync(id);

            Input = new DepartmentDTO
            {
                ID = Department.ID,
                Name = Department.Name,
                Prefix = Department.Prefix,
                IncludePrefix = Department.IncludePrefix
            };

            return Page();
        }

        public async Task<IActionResult> OnPostConfirmDepartmentFormAsync(int id)
        {
            Department = await Service.Department.GetByIDAsync(id);

            if (ModelState.IsValid && Department != null)
            {
                var toUpdate = new DepartmentDTO
                {
                    ID = Department.ID,
                    Name = Input.Name,
                    Prefix = Input.Prefix,
                    IncludePrefix = Input.IncludePrefix
                };

                await Service.Department.UpdateAsync(toUpdate);

                return Redirect($"/DepartmentOverview");
            }

            return Page();
        }

        public async Task<IActionResult> OnPostSyncTickets(int id)
        {
            Department = await Service.Department.GetByIDAsync(id);

            if (ModelState.IsValid && Department != null)
            {
                var toUpdate = new DepartmentDTO
                {
                    ID = Department.ID,
                    Name = Input.Name,
                    Prefix = Input.Prefix,
                    IncludePrefix = Input.IncludePrefix
                };

                await Service.Department.UpdateAsync(toUpdate);

                var tickets = await Service.Ticket.GetByDepartmentAsync(id);

                foreach (var ticket in tickets)
                {
                    await ticket.ChangeTicketNumberPrefixAsync(((toUpdate.IncludePrefix) ? (toUpdate.Prefix) : (string.Empty)));
                }

                return Redirect($"/DepartmentOverview");
            }

            return Page();
        }
    }
}
