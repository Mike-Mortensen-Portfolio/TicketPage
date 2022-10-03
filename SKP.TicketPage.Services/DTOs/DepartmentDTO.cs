using System.ComponentModel.DataAnnotations;

namespace SKP.TicketPage.Services
{
    public class DepartmentDTO : IDepartment
    {
        public int ID { get; set; }
        [MaxLength(30)]
        [Required(ErrorMessage = "Afdelinger skal have et navn!")] public string Name { get; set; }
        [MaxLength(2)]
        public string Prefix { get; set; }
        public bool IncludePrefix { get; set; }
    }
}
