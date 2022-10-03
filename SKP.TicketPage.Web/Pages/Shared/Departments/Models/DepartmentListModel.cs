using SKP.TicketPage.Services;
using System.Collections.Generic;

namespace SKP.TicketPage.Web.Pages.Shared.Departments.Models
{
    public class DepartmentListModel
    {
        public string TableID { get; set; } = string.Empty;
        public IReadOnlyList<IDepartment> Departments { get; set; }
        public string Header { get; set; } = null;
        public string ReturnURL { get; set; }
        public bool HideSettings { get; set; } = false;
        public bool HideCreateButton { get; set; } = false;
        public bool HideFilter { get; set; } = false;
        public string FilterPropertyName { get; set; } = "FilterOptions";
        public string FilterHandler { get; set; } = "DepartmentFilter";
        public DepartmentFilterOptions FilterOptions { get; set; }
        public bool UsePagination { get; set; } = true;
        public string ConfirmPackage { get; set; }
        public int PageSize { get; set; } = 10;
        public int CurrentPage { get; set; }
        public int PageCount { get; set; }
    }
}
