using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SKP.TicketPage.Services;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SKP.TicketPage.Web.Pages
{
    [Authorize(Roles = RoleHelper.ADMIN_INSTRUCTOR_DEVELOPER)]
    public class UserOverviewModel : PageModel
    {
        public UserOverviewModel(ITicketPageService service)
        {
            Service = service;
        }

        public ITicketPageService Service { get; }

        public IReadOnlyList<IEmployee> Employees { get; set; }

        [BindProperty(SupportsGet = true)]
        public EmployeeFilterOptions FilterOptions { get; set; }

        [BindProperty]
        public string EmployeeID { get; set; }
        public int PageSize { get; set; } = 10;
        public int CurrentPage { get; set; }

        public async Task OnGet()
        {
            FilterOptions.Active = "true";
            Employees = (await Service.Employee.FilterAsync(FilterOptions))
                .OrderBy(e => $"{e.FirstName} {e.LastName}")
                .ToList();
        }

        public async Task<IActionResult> OnPostEmployeePromoteAsync(int employeeID)
        {
            IEmployee employee = await Service.Employee.GetByIDAsync(employeeID);

            if (await Service.Employee.IsInRoleAsync(employee.ID, RoleHelper.ADMIN))
            {
                await Service.Employee.AddToRoleAsync(employee.ID, RoleHelper.BASE);
                await Service.Employee.RemoveFromRoleAsync(employee.ID, RoleHelper.ADMIN);
            }
            else
            {
                await Service.Employee.AddToRoleAsync(employee.ID, RoleHelper.ADMIN);
                await Service.Employee.RemoveFromRoleAsync(employee.ID, RoleHelper.BASE);
            }

            return RedirectToPage("/EmployeeOverview", FilterOptions);
        }

        public async Task<IActionResult> OnPostEmployeeActivateAsync(int employeeID)
        {
            IEmployee employee = await Service.Employee.GetByIDAsync(employeeID);

            var toUpdate = new EmployeeDTO
            {
                Active = !employee.Active,
                DepartmentID = employee.DepartmentID,
                Email = employee.Email,
                FirstName = employee.FirstName,
                ID = employee.ID,
                LastName = employee.LastName,
                Username = employee.Username
            };

            await Service.Employee.UpdateAsync(toUpdate);

            return RedirectToPage("/EmployeeOverview", FilterOptions);
        }

        public IActionResult OnPostEmployeeEdit(int employeeID)
        {
            return Redirect($"/Identity/Account/EditUser/{employeeID}");
        }

        public async Task<IActionResult> OnPostEmployeeDeleteAsync()
        {
            if (int.TryParse(EmployeeID, out int id))
            {
                await Service.Employee.RemoveAsync(id);
            }

            FilterOptions.Active = ((FilterOptions.Active == "Invalid") ? ("true") : (FilterOptions.Active));
            Employees = (await Service.Employee.FilterAsync(FilterOptions))
                .OrderBy(e => $"{e.FirstName} {e.LastName}")
                .ToList();

            return Page();
        }

        public async Task<IActionResult> OnPostEmployeeFilterAsync(int currentPage)
        {
            CurrentPage = currentPage;

            FilterOptions.Active = ((FilterOptions.Active == "Invalid") ? ("true") : (FilterOptions.Active));
            Employees = (await Service.Employee.FilterAsync(FilterOptions))
                .OrderBy(e => $"{e.FirstName} {e.LastName}")
                .ToList();
            return Page();
        }
    }
}
