using SKP.TicketPage.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SKP.TicketPage.Services
{
    /// <summary>
    /// Provides an <see langword="async"/> entry point for logging messages. The <see langword="interface"/> serves as an <see cref="ICrudRepository{T}"/> as well
    /// </summary>
    public interface IErrorLogger : ICrudRepository<ILogEntry>
    {
        Task<ILogEntry> GetByRequestIDAsync(string requestID);
        Task<IReadOnlyList<ILogEntry>> GetBySeverityAsync(ILogEntry.Severity severity);
        Task<string> LogInfoAsync(string message);
        Task<string> LogWarningAsync(string message);
        Task<string> LogWarningAsync(string message, Exception exception);
        Task<string> LogCriticalAsync(string message);
        Task<string> LogCriticalAsync(string message, Exception exception);
        Task<string> LogExceptionAsync(ILogEntry.Severity severity, Exception exception, string RequestID = null);

        Task<IReadOnlyList<ILogEntry>> FilterAsync(LogEntryFilterOptions options);
    }
}
