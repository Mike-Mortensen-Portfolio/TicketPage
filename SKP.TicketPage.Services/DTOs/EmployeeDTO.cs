using System.ComponentModel.DataAnnotations;

namespace SKP.TicketPage.Services
{
    public class EmployeeDTO : IEmployee
    {
        public int ID { get; set; }
        public bool Active { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        [Range(1, int.MaxValue, ErrorMessage = "Brugere skal være en del af en afdeling!")]
        [Required(ErrorMessage = "Brugere skal være en del af en afdeling!")] public int DepartmentID { get; set; }
    }
}
