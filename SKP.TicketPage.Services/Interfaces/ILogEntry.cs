using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SKP.TicketPage.Services
{

    public interface ILogEntry
    {
        int ID { get; }
        Severity SeverityFlag { get; }
        string RequestID { get; }
        string StackTrace { get; }
        string Message { get; }
        DateTime LogDate { get; }

        public enum Severity
        {
            [Display(Name = "Kritisk")]
            Critical,
            [Display(Name = "Advarsel")]
            Warning,
            [Display(Name = "Information")]
            Info
        }

        /// <summary>
        /// A helper <see langword="class"/> that defines methods for common tasks when working with <see cref="ILogEntry"/> <see langword="objects"/>
        /// </summary>
        public static class Helper
        {
            public static string[] GetSeverityDisplayNames()
            {
                string[] severityNames = new string[Enum.GetNames(typeof(Severity)).Length];

                for (int i = 0; i < severityNames.Length; i++)
                {
                    severityNames[i] = ((Severity)i).GetDisplayName();
                }

                return severityNames;
            }

            public static string LogEntrySeveritySwitch(Severity severity, string[] values)
            {
                if (severity < 0) return string.Empty;

                int enumLength = Enum.GetValues(typeof(Severity)).Length;

                if (values.Length != enumLength) { throw new ArgumentException($"Must be exactly {enumLength} of length", nameof(values)); }

                return values[(int)severity];
            }
        }
    }
}
