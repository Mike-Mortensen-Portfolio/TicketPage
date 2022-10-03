using System;
using System.ComponentModel.DataAnnotations;

namespace SKP.TicketPage.Services
{
    public class CommentDTO : IComment
    {
        public int ID { get; set; }
        [MaxLength(1225, ErrorMessage = "Kommentarfeltet kan ikke være længere end 1225 karakterer")]
        [Required(ErrorMessage = "Tomme kommentare er ikke tilladt!")] public string Content { get; set; }
        public DateTime DateOfCreation { get; set; }
        public int TicketID { get; set; }
        public int AuthorID { get; set; }
    }
}
