using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SKP.TicketPage.Domain.Entities
{
    /// <summary>
    /// Defines the DB entity data container for comments
    /// </summary>
    [Table("Comments")]
    public class Comment
    {
        [Key] public int ID { get; set; }
        [MaxLength(1225)]
        [Required] public string Content { get; set; }
        [Required] public DateTime DateOfCreation { get; set; }

        [Required] public int TicketID { get; set; }
        [ForeignKey(nameof(TicketID))]
        public Ticket Ticket { get; set; }  //  Nav Property (Many to One)
        [Column("EmployeeID")]
        [Required] public int AuthorID { get; set; }
        [ForeignKey(nameof(AuthorID))]
        public Employee Author { get; set; }    //  Nav Property (Many to One)
    }
}