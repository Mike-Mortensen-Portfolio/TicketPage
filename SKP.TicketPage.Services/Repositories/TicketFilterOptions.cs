namespace SKP.TicketPage.Services
{
    public class TicketFilterOptions
    {
        public string SearchKey { get; set; } = null;
        public int DepartmentID { get; set; } = -1;
        public int Status { get; set; } = -1;
        public int Priority { get; set; } = -1;
        public int AuthorID { get; set; } = -1;
        public int EmployeeID { get; set; } = -1;
    }
}