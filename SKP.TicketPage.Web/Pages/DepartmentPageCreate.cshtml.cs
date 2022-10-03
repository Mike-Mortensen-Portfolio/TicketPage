using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SKP.TicketPage.Services;
using SKP.TicketPage.Web.Pages.Shared.Departments.Models;

namespace SKP.TicketPage.Web.Pages
{
    [Authorize(Roles = RoleHelper.INSTRUCTOR_DEVELOPER)]
    public class DepartmentPageCreateModel : PageModel
    {
        public DepartmentPageCreateModel(ITicketPageService service)
        {
            Service = service;
        }

        public ITicketPageService Service { get; }

        [BindProperty]
        public DepartmentDTO Input { get; set; }

        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPostConfirmDepartmentFormAsync()
        {
            if (ModelState.IsValid)
            {
                await Service.Department.AddAsync(Input);

                return Redirect("/DepartmentOverview");
            }

            return Page();
        }
    }
}
