namespace SKP.TicketPage.Services
{
    public class RoleDTO : IRole
    {
        public int ID { get; set; }

        public string Name { get; set; }

        public string DisplayName { get; set; }

        public string Description { get; set; }
    }
}
