namespace SKP.TicketPage.Services
{
    public interface IRole
    {
        int ID { get; }
        string Name { get; }
        string DisplayName { get; }
        string Description { get; }
    }
}
