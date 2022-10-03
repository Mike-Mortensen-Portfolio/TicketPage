using System;
using System.ComponentModel.DataAnnotations;

namespace SKP.TicketPage.Services
{
    public class TicketDTO : ITicket
    {
        public int ID { get; set; }
        public string TicketNumber { get; set; }
        [Range((double)ITicket.TicketStatus.Inbound, (double)ITicket.TicketStatus.Completed, ErrorMessage = "Du skal vælge en status!")]
        [Required] public ITicket.TicketStatus Status { get; set; }
        [Range((double)ITicket.TicketPriority.Normal, (double)ITicket.TicketPriority.Critical, ErrorMessage = "Du skal vælge en prioritet!")]
        [Required] public ITicket.TicketPriority Priority { get; set; }
        [MaxLength(25, ErrorMessage = "Titlen må ikke være længere end 25 karakterer")]
        [Required(ErrorMessage = "Opgaver skal have en title!")] public string Title { get; set; }
        [MaxLength(2450, ErrorMessage = "Beskrivelsen må ikke være længere end 2450 karakterer")]
        [Required(ErrorMessage = "Opgaver skal have en beskrivelse!")] public string Description { get; set; }
        public DateTime DateOfCreation { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? StartDate { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? EndDate { get; set; }
        public int AuthorID { get; set; }
        [Range(1, int.MaxValue, ErrorMessage = "Du skal vælge en afdeling!")]
        [Required] public int DepartmentID { get; set; }
    }
}
