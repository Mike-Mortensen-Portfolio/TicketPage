using System;

namespace SKP.TicketPage.Services
{
    public class LogEntryDTO : ILogEntry
    {
        public int ID { get; set; }

        public ILogEntry.Severity SeverityFlag { get; set; }

        public string StackTrace { get; set; }

        public string Message { get; set; }

        public DateTime LogDate { get; set; }

        public string RequestID { get; set; }
    }
}
