using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SKP.TicketPage.Services;

namespace SKP.TicketPage.Web.Pages
{
    [Authorize(Roles = RoleHelper.INSTRUCTOR_DEVELOPER)]
    public class DepartmentOverviewModel : PageModel
    {
        public DepartmentOverviewModel(ITicketPageService service)
        {
            Service = service;
        }

        public ITicketPageService Service { get; }
        public IReadOnlyList<IDepartment> Departments { get; set; }
        [BindProperty]
        public DepartmentFilterOptions FilterOptions { get; set; }

        [BindProperty]
        public string ConfirmPackage { get; set; }
        public int PageSize { get; set; } = 10;
        public int CurrentPage { get; set; }

        public async Task<IActionResult> OnGet()
        {
            Departments = await Service.Department.GetAllAsync();

            return Page();
        }

        public async Task<IActionResult> OnPostDepartmentFilterAsync(int currentPage)
        {
            CurrentPage = currentPage;
            Departments = await Service.Department.FilterAsync(FilterOptions);

            return Page();
        }

        public IActionResult OnPostDepartmentEdit(int departmentID)
        {
            return Redirect($"/DepartmentPageEdit/{departmentID}");
        }

        public async Task<IActionResult> OnPostAcceptAsync()
        {
            int id = int.Parse(ConfirmPackage);

            IDepartment department = await Service.Department.GetByIDAsync(id);

            if (department != null)
            {
                await Service.Department.RemoveAsync(department);
            }

            FilterOptions = new DepartmentFilterOptions
            {
                SearchKey = FilterOptions.SearchKey
            };

            Departments = await Service.Department.FilterAsync(FilterOptions);

            return Page();
        }
    }
}
