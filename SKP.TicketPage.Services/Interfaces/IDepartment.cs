namespace SKP.TicketPage.Services
{
    public interface IDepartment
    {
        int ID { get; }
        string Name { get; }
        /// <summary>
        /// The <see cref="IDepartment"/> indicator, prefixed in a <see cref="ITicket.TicketNumber"/> (<i>Can't be more than 2 letters</i>)
        /// </summary>
        string Prefix { get; }
        /// <summary>
        /// If <see langword="true"/> <see cref="Prefix"/> is included in <see cref="Ticket.TicketNumber"/>; Otherwise, if <see langword="false"/>, it's not included
        /// </summary>
        public bool IncludePrefix { get; set; }
    }
}
