namespace SKP.TicketPage.Services
{
    public interface ITicketPageService
    {
        IDepartmentRepository Department { get; }

        IEmployeeManager Employee { get; }

        ITicketRepository Ticket { get; }

        ICommentRepository Comment { get; }
    }
}
