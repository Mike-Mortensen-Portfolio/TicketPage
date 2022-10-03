using System;

namespace SKP.TicketPage.Services
{
    public interface IComment
    {
        int ID { get; }
        string Content { get; }
        DateTime DateOfCreation { get; }
        int TicketID { get; }
        int AuthorID { get; }
    }
}
