using SKP.TicketPage.Services;
using System.Collections.Generic;

namespace SKP.TicketPage.Web.Pages.Shared.Employees.Models
{
    public class EmployeeListModel
    {
        public string TableID { get; set; } = string.Empty;
        public IReadOnlyList<IEmployee> Employees { get; set; }
        public string ReturnURL { get; set; }
        public bool HideSettings { get; set; } = false;
        public bool HideFilter { get; set; } = false;
        public string FilterHandler { get; set; } = "EmployeeFilter";
        public string FilterPropertyName { get; set; } = "FilterOptions";
        public EmployeeFilterOptions FilterOptions { get; set; }
        public bool UsePagination { get; set; } = true;
        public Lock FilterLock { get; set; } = Lock.None;
        public Helper LockHelper { get; } = new Helper();
        public int PageSize { get; set; } = 10;
        public int CurrentPage { get; set; }
        public int PageCount { get; set; }

        public enum Lock
        {
            None,
            SearchKey,
            SearchKeyAndDepartment,
            SearchKeyAndStatus,
            Department,
            DepartmentAndStatus,
            Status
        }

        public class Helper
        {
            public bool SearchKeyLocked(Lock lockIndex)
            {
                return (lockIndex == Lock.SearchKey || lockIndex == Lock.SearchKeyAndDepartment || lockIndex == Lock.SearchKeyAndStatus);
            }

            public bool DepartmentLocked(Lock lockIndex)
            {
                return (lockIndex == Lock.Department || lockIndex == Lock.DepartmentAndStatus || lockIndex == Lock.SearchKeyAndDepartment);
            }

            public bool StatusLocked(Lock lockIndex)
            {
                return (lockIndex == Lock.Status || lockIndex == Lock.DepartmentAndStatus || lockIndex == Lock.SearchKeyAndStatus);
            }
        }
    }
}
