using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SKP.TicketPage.Domain.Entities
{
    /// <summary>
    /// Defines the DB entity data container for tickets
    /// </summary>
    [Table("Tickets")]
    public class Ticket
    {
        [Key] public int ID { get; set; }
        [MaxLength(15)]
        [Required] public string TicketNumber { get; set; } //  Format: [Departmetn Prefix][YYMMDD][Serial Number] - Example: E220304-001
        public TicketStatus Status { get; set; }
        public TicketPriority Priority { get; set; }
        [MaxLength(50)]
        [Required] public string Title { get; set; }
        [MaxLength(2450)]
        [Required] public string Description { get; set; }
        [Required] public DateTime DateOfCreation { get; set; }
        /// <summary>
        /// Combined with <see cref="EndDate"/>, this specifies the timeframe where the task must be completed
        /// </summary>
        public DateTime? StartDate { get; set; }
        /// <summary>
        /// Combined with <see cref="StartDate"/>, this specifies the timeframe where the task must be completed
        /// </summary>
        public DateTime? EndDate { get; set; }

        [Column("EmployeeID")]
        [Required] public int AuthorID { get; set; }
        [ForeignKey(nameof(AuthorID))]
        public Employee Author { get; set; }    //  Nav Property (Many to one)
        [Required] public int DepartmentID { get; set; }
        [ForeignKey(nameof(DepartmentID))]
        public Department Department { get; set; }  //  Nav Property (Many to One)

        public ICollection<EmployeeTicket> AssignedEmployees { get; set; }  //  Nav Property (Many to Many)
        public ICollection<Comment> Comments { get; set; }  //  Nav property (One to Many)

        public enum TicketStatus
        {
            Inbound,
            Ongoing,
            Pending,
            Paused,
            Denied,
            Completed
        }

        public enum TicketPriority
        {
            Normal,
            Important,
            Critical
        }
    }
}