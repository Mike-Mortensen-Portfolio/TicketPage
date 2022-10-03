using SKP.TicketPage.Services;

namespace SKP.TicketPage.Web.Pages.Shared.Departments.Models
{
    public class DepartmentFormModel
    {
        public string Header { get; set; } = null;
        public bool ReadOnly { get; set; }
        public DepartmentDTO Input { get; set; }
        public string ReturnURL { get; set; } = null;
        public bool HideSyncButton { get; set; } = false;

        public Lock LockFlag { get; set; } = Lock.None;
    }

    public enum Lock
    {
        None,
        Name,
        NameAndPrefix,
        NameAndSync,
        Prefix,
        PrefixAndSync,
        Sync,
    }
}
