using System.Threading.Tasks;

namespace SKP.TicketPage.Services
{
    public interface IEmployee
    {
        int ID { get; }
        /// <summary>
        /// If <see langword="false"/> the <see cref="Employee"/> account is considered deactivated and therefore locked out of the system
        /// </summary>
        bool Active { get; set; }
        string Username { get; }
        string Email { get; }
        string FirstName { get; }
        string LastName { get; }
        int DepartmentID { get; }
    }
}
