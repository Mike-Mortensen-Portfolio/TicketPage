using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SKP.TicketPage.Domain.Entities
{
    /// <summary>
    /// Defines a DB entity group of <see cref="Employee"/> and <see cref="Ticket"/> <see langword="objects"/>
    /// </summary>
    [Table("Departments")]
    public class Department
    {
        [Key] public int ID { get; set; }
        [MaxLength(50)]
        [Required] public string Name { get; set; }
        [MaxLength(2)]
        public string Prefix { get; set; }  //  The department indicator prefixed in a Ticket Number - Example: [E]220304-001
        /// <summary>
        /// If <see langword="true"/> <see cref="Prefix"/> should be included in <see cref="Ticket.TicketNumber"/>; Otherwise, if <see langword="false"/>, do not include <see cref="Prefix"/>
        /// </summary>
        public bool IncludePrefix { get; set; }

        public ICollection<Employee> Employees { get; set; }    //  Nav Property (One to Many)
        public ICollection<Ticket> Tickets { get; set; }  //  Nav Property (One to Many)
    }
}