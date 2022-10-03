using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SKP.TicketPage.Domain.Entities
{
    /// <summary>
    /// Defines the DB entity data container for users (<i>Corrosponds to <strong>AspNetUsers</strong> table. See ER Diagram fo rmore info</i>)
    /// </summary>
    public class Employee : IdentityUser<int>
    {

        /// <summary>
        /// If <see langword="false"/> the <see cref="Employee"/> account is considered deactivated and therefore locked out of the system
        /// </summary>
        public bool Active { get; set; }
        [MaxLength(50)]
        [Required] public string FirstName { get; set; }
        [MaxLength(50)]
        [Required] public string LastName { get; set; }

        public int? DepartmentID { get; set; }
        [ForeignKey(nameof(DepartmentID))]
        public Department Department { get; set; }  //  Nav Property (One to Many)
        public ICollection<EmployeeTicket> AssignedTickets { get; set; }    // Nav Property (Many to Many)
        public ICollection<Comment> Comments { get; set; }  // Nav property (One to Many)
    }
}
