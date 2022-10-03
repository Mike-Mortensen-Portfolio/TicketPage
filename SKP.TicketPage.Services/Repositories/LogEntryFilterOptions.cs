using System;

namespace SKP.TicketPage.Services
{
    public class LogEntryFilterOptions
    {
        public DateTime? LogDate { get; set; } = null;
        public int Severity { get; set; } = -1;
        public string SearchKey { get; set; }
    }
}