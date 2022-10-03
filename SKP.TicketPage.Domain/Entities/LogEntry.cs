using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SKP.TicketPage.Domain.Entities
{
    /// <summary>
    /// Defines the DB entity data container for log entries
    /// </summary>
    [Table("LogEntries")]
    public class LogEntry
    {
        [Key] public int ID { get; set; }
        [Required] public Severity SeverityFlag { get; set; }
        [MaxLength(50)]
        [Required] public string RequestID { get; set; }
        [MaxLength(1200)]
        public string StackTrace { get; set; }  //  Limited because a stack trace can be huge
        [MaxLength(1200)]
        [Required] public string Message { get; set; }
        [Required] public DateTime LogDate { get; set; }

        public enum Severity
        {
            Critical,
            Warning,
            Info
        }
    }
}