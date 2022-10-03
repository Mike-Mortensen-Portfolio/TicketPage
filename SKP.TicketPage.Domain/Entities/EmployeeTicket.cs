using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SKP.TicketPage.Domain.Entities
{
    /// <summary>
    /// Join table between <see cref="Entities.Employee"/> ↔ <see cref="Entities.Ticket"/> with combined key: <see cref="AssignedEmployeeID"/> ↔ <see cref="TicketID"/>
    /// </summary>
    [Table("EmployeeTickets")]
    public class EmployeeTicket
    {
        [Column("EmployeeID")]
        [Required] public int AssignedEmployeeID { get; set; }
        [ForeignKey(nameof(AssignedEmployeeID))]
        public Employee AssignedEmployee { get; set; }
        [Required] public int TicketID { get; set; }
        [ForeignKey(nameof(TicketID))]
        public Ticket Ticket { get; set; }
        [Required] public DateTime DateAssigned { get; set; }
    }
}