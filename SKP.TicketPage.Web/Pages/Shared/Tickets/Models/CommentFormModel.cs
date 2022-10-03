using SKP.TicketPage.Services;

namespace SKP.TicketPage.Web.Pages.Shared.Tickets.Models
{
    public class CommentFormModel
    {
        public int TicketID { get; init; }
        public bool EditComment { get; set; } = false;
        public CommentDTO Input { get; set; }
    }
}
