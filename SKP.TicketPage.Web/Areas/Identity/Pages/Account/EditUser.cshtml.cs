using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SKP.TicketPage.Services;
using static SKP.TicketPage.Web.Pages.Shared.Employees.Models.EmployeeFormModel;

namespace SKP.TicketPage.Web.Areas.Identity.Pages.Account
{
    [Authorize(Roles = RoleHelper.INSTRUCTOR_DEVELOPER)]
    public class EditUserModel : PageModel
    {
        public EditUserModel(ITicketPageService service)
        {
            Service = service;
        }

        public ITicketPageService Service { get; }

        public IEmployee Employee { get; set; }

        [BindProperty]
        public EmployeeFormInputModel Input { get; set; }

        public async Task<IActionResult> OnGet(int id)
        {
            Employee = await Service.Employee.GetByIDAsync(id);

            Input = new EmployeeFormInputModel();

            Input.Employee = new EmployeeDTO
            {
                Active = Employee.Active,
                DepartmentID = Employee.DepartmentID,
                Email = Employee.Email,
                FirstName = Employee.FirstName,
                ID = Employee.ID,
                LastName = Employee.LastName,
                Username = Employee.Username
            };

            Input.RoleName = await Employee.GetRoleNameAsync();

            return Page();
        }

        public async Task<IActionResult> OnPostConfirmEmployeeFormAsync(int id, string returnURL)
        {
            Employee = await Service.Employee.GetByIDAsync(id);

            Input.Employee.ID = Employee.ID;

            if (Input.RoleName == "Invalid") { ModelState.AddModelError("RoleError", "Du skal vælge en rolle!"); }

            if (ModelState.IsValid)
            {
                await Service.Employee.RemoveFromRoleAsync(Employee.ID, await Employee.GetRoleNameAsync());
                await Service.Employee.AddToRoleAsync(Employee.ID, Input.RoleName);

                await Service.Employee.UpdateAsync(Input.Employee);

                return Redirect($"/{returnURL}" ?? $"/Identity/Account/UserPage/{Input.Employee.ID}");
            }

            return Page();
        }
    }
}
