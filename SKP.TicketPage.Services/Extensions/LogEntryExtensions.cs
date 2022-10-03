using SKP.TicketPage.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SKP.TicketPage.Services
{
    public static class LogEntryExtensions
    {
        /// <summary>
        /// Maps a <see langword="public"/> <see cref="ILogEntry"/> instance to an <see langword="internal"/> <see cref="LogEntry"/> entity
        /// </summary>
        /// <param name="logEntry"></param>
        /// <returns>The <see cref="LogEntry"/> instance if the mapping was succesfull</returns>
        /// <exception cref="ArgumentNullException"></exception>
        internal static LogEntry MapToInternal(this ILogEntry logEntry)
        {
            if (logEntry == null) throw new ArgumentNullException(nameof(logEntry), "Cannot map NULL value");

            var mappedLogEntry = new LogEntry
            {
                ID = logEntry.ID,
                LogDate = logEntry.LogDate,
                Message = logEntry.Message,
                RequestID = logEntry.RequestID,
                SeverityFlag = (LogEntry.Severity)logEntry.SeverityFlag,
                StackTrace = logEntry.StackTrace
            };

            return mappedLogEntry;
        }

        /// <summary>
        /// Maps the <see langword="internal"/> <see cref="LogEntry"/> entity to a <see langword="public"/> <see cref="LogEntryDTO"/> masked as an <see cref="ILogEntry"/> instance
        /// </summary>
        /// <param name="logEntry"></param>
        /// <returns>The <see cref="ILogEntry"/> instance if the mapping was succesfull</returns>
        /// <exception cref="ArgumentNullException"></exception>
        internal static ILogEntry MapToPublic(this LogEntry logEntry)
        {
            if (logEntry == null) throw new ArgumentNullException(nameof(logEntry), "Cannot map NULL value");

            var mappedLogEntry = new LogEntryDTO
            {
                ID = logEntry.ID,
                LogDate = logEntry.LogDate,
                Message = logEntry.Message,
                RequestID = logEntry.RequestID,
                SeverityFlag = (ILogEntry.Severity)logEntry.SeverityFlag,
                StackTrace = logEntry.StackTrace
            };

            return mappedLogEntry;
        }

        /// <summary>
        /// Maps a queryable range of <see langword="public"/> <see cref="ILogEntry"/> entities to a queryable collection of <see langword="internal"/> <see cref="LogEntry"/> instances
        /// </summary>
        /// <param name="logEntry"></param>
        /// <returns>The collection of <see cref="LogEntry"/> instances if the mapping was succesfull</returns>
        /// <exception cref="ArgumentNullException"></exception>
        internal static IQueryable<LogEntry> MapToInternal(this IQueryable<ILogEntry> logEntry)
        {
            if (logEntry == null) throw new ArgumentNullException(nameof(logEntry), "Cannot map NULL value");

            return logEntry
                .Select(l => new LogEntry
                {
                    ID = l.ID,
                    LogDate = l.LogDate,
                    Message = l.Message,
                    RequestID = l.RequestID,
                    SeverityFlag = (LogEntry.Severity)l.SeverityFlag,
                    StackTrace = l.StackTrace
                });
        }

        /// <summary>
        /// Maps a queryable range of <see langword="internal"/> <see cref="LogEntry"/> entities to a queryable collection of <see langword="public"/> <see cref="LogEntryDTO"/> <see langword="objects"/> masked as <see cref="ILogEntry"/> instances
        /// </summary>
        /// <param name="logEntry"></param>
        /// <returns>The collection of <see cref="ILogEntry"/> instances if the mapping was succesfull</returns>
        /// <exception cref="ArgumentNullException"></exception>
        internal static IQueryable<ILogEntry> MapToPublic(this IQueryable<LogEntry> logEntry)
        {
            if (logEntry == null) throw new ArgumentNullException(nameof(logEntry), "Cannot map NULL value");

            return logEntry
                .Select(l => new LogEntryDTO
                {
                    ID = l.ID,
                    LogDate = l.LogDate,
                    Message = l.Message,
                    RequestID = l.RequestID,
                    SeverityFlag = (ILogEntry.Severity)l.SeverityFlag,
                    StackTrace = l.StackTrace
                });
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="logEntry"></param>
        /// <returns>A <see langword="string"/> reprensation of the <see cref="ILogEntry"/>'s public Identifier</returns>
        public static string GetPublicIdentifier(this ILogEntry logEntry)
        {
            if (logEntry == null) throw new ArgumentNullException(nameof(logEntry), "Source can't be NULL");

            if (logEntry.RequestID.Length == 9) //  9 because the generated public identifier is 9 in length
            {
                string entryNum = logEntry.RequestID[0..^3];
                string serialNum = logEntry.RequestID[^3..];

                return $"{entryNum}-{serialNum}";
            }

            return logEntry.RequestID;
        }

        /// <summary>
        /// Converts the <see cref="ILogEntry"/> <see langword="object"/> to a <see langword="string"/>, which is formatted to give a public display without including critical details
        /// </summary>
        /// <param name="logEntry"></param>
        /// <returns>A <see langword="string"/> representation of the <see cref="ILogEntry"/> exception</returns>
        /// <exception cref="ArgumentNullException"></exception>
        public static string ToPublicException(this ILogEntry logEntry)
        {
            if (logEntry == null) throw new ArgumentNullException(nameof(logEntry), "Source cannot be NULL");

            return $"({logEntry.SeverityFlag.GetDisplayName()}): {logEntry.Message} - {logEntry.GetPublicIdentifier()}";
        }

    }
}
