using SKP.TicketPage.Domain;
using SKP.TicketPage.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SKP.TicketPage.Services
{
    internal class ErrorLogger : RepositoryBase<LogEntry>, IErrorLogger
    {
        public ErrorLogger(TicketPageContext context) : base(context) { }

        public async Task<bool> AddAsync(ILogEntry entity)
        {
            return await AddAsync(entity.MapToInternal());
        }

        public async Task<ILogEntry> GetByIDAsync(int id)
        {
            return await Task.Run(() =>
            {
                var entries = GetByAsync(l => l.ID == id).Result;

                if (entries != null && entries.Any())
                {
                    return entries
                    .SingleOrDefault()
                    .MapToPublic();
                }

                return null;
            });
        }

        public async Task<string> LogCriticalAsync(string message)
        {
            LogEntryDTO entry = await GenerateBaseEntry(message);
            entry.SeverityFlag = ILogEntry.Severity.Critical;

            await AddAsync(entry);

            return entry.ToPublicException();
        }

        public async Task<string> LogCriticalAsync(string message, Exception exception)
        {
            LogEntryDTO entry = await GenerateBaseEntry(message);
            entry.SeverityFlag = ILogEntry.Severity.Critical;
            entry.StackTrace = FormatStackTrace(exception);

            await AddAsync(entry);

            return entry.ToPublicException();
        }

        public async Task<string> LogExceptionAsync(ILogEntry.Severity severity, Exception exception, string requestID)
        {
            LogEntryDTO entry = await GenerateBaseEntry(exception.Message);
            entry.RequestID = requestID;
            entry.SeverityFlag = severity;
            entry.StackTrace = FormatStackTrace(exception);

            await AddAsync(entry);

            return entry.ToPublicException();
        }

        public async Task<string> LogInfoAsync(string message)
        {
            var entry = await GenerateBaseEntry(message);
            entry.SeverityFlag = ILogEntry.Severity.Info;

            await AddAsync(entry);

            return entry.ToPublicException();
        }

        public async Task<string> LogWarningAsync(string message)
        {
            var entry = await GenerateBaseEntry(message);
            entry.SeverityFlag = ILogEntry.Severity.Warning;

            await AddAsync(entry);

            return entry.ToPublicException();
        }

        public async Task<string> LogWarningAsync(string message, Exception exception)
        {
            var entry = await GenerateBaseEntry(message);
            entry.SeverityFlag = ILogEntry.Severity.Warning;
            entry.StackTrace = FormatStackTrace(exception);

            await AddAsync(entry);

            return entry.ToPublicException();
        }

        public async Task<bool> RemoveAsync(ILogEntry entity)
        {
            return await RemoveAsync(entity.MapToInternal());
        }

        public async Task<bool> UpdateAsync(ILogEntry entity)
        {
            return await UpdateAsync(entity.MapToInternal());
        }

        new public async Task<IReadOnlyList<ILogEntry>> GetAllAsync()
        {

            var entries = await base.GetAllAsync();

            if (entries != null && entries.Any())
            {
                return entries
                .MapToPublic()
                .OrderByDescending(l => l.LogDate)
                .ToList();
            }

            return new List<ILogEntry>();
        }

        public async Task<IReadOnlyList<ILogEntry>> GetBySeverityAsync(ILogEntry.Severity severity)
        {
            return await Task.Run(() =>
            {
                var entries = context.Set<LogEntry>()
                .Where(l => l.SeverityFlag == (LogEntry.Severity)severity);

                if (entries != null && entries.Any())
                {
                    return entries
                    .MapToPublic()
                    .OrderByDescending(l => l.LogDate)
                    .ToList();
                }

                return new List<ILogEntry>();
            });
        }

        public async Task<ILogEntry> GetByRequestIDAsync(string requestID)
        {
            var entries = await GetByAsync(l => l.RequestID == requestID);

            if (entries != null && entries.Any())
            {
                return entries
                .SingleOrDefault()
                .MapToPublic();
            }

            return null;
        }

        public async Task<IReadOnlyList<ILogEntry>> FilterAsync(LogEntryFilterOptions options)
        {
            var logEntries = await GetAllAsync();

            return logEntries.Where(logEntry =>
            {
                if (options.LogDate != null && logEntry.LogDate.Date != options.LogDate?.Date)
                {
                    return false;
                }

                if (options.Severity != -1 && logEntry.SeverityFlag != (ILogEntry.Severity)options.Severity)
                {
                    return false;
                }

                //  Checks if the message or the request ID contains the searh key. If a key is present.
                if (options.SearchKey != null && !(logEntry.Message.ToLower().Contains(options.SearchKey.ToLower()) || logEntry.RequestID.ToLower().Contains(options.SearchKey.ToLower()) || logEntry.RequestID.Contains(options.SearchKey.Replace("-", string.Empty))))
                {
                    return false;
                }

                return true;
            })
           .ToList();
        }

        private async Task<LogEntryDTO> GenerateBaseEntry(string message)
        {
            var stamp = DateTime.Now;

            return new LogEntryDTO
            {
                LogDate = stamp,
                Message = message[..((message.Length > 1200) ? (1200) : (message.Length))],
                SeverityFlag = ILogEntry.Severity.Info,
                RequestID = await GeneratePublicIdentifier(),
                StackTrace = null
            };
        }

        private string FormatStackTrace(Exception exception)
        {
            return exception.StackTrace?[..((exception.StackTrace.Length > 1200) ? (1200) : (exception.StackTrace.Length))];
        }

        private async Task<string> GeneratePublicIdentifier()
        {
            ILogEntry latestEntry = (await GetAllAsync())
                .Where(l => l.RequestID.StartsWith($"{DateTime.Now:yyMMdd}"))
                .OrderByDescending(l => l.RequestID).FirstOrDefault();   //  Fetches the entry created on a specific date and takes the latest ticket.

            int serialNumber = ((latestEntry != null) ? (int.Parse(latestEntry.GetPublicIdentifier().Split("-")[1]) + 1) : (1)); //  Takes the serial number of the latest ticket and increments it by one (If no ticket in that department has ben raised today the serial number is set to 1). This is the serial number used for the new ticket.

            return $"{DateTime.Now:yyMMdd}{serialNumber:D3}";
        }
    }
}
