namespace SKP.TicketPage.Services
{
    public class EmployeeFilterOptions
    {
        public string SearchKey { get; set; } = null;
        public int TicketID { get; set; } = -1;
        public int DepartmentID { get; set; } = -1;
        public string Active { get; set; } = "Invalid";
    }
}