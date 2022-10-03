using System;
using System.ComponentModel.DataAnnotations;

namespace SKP.TicketPage.Services
{
    public interface ITicket
    {
        int ID { get; }
        /// <summary>
        /// <strong>Format:</strong> [<see cref="IDepartment.Prefix"/>][YYMMDD][Serial Number] - Example: E220304-001
        /// </summary>
        string TicketNumber { get; }
        TicketStatus Status { get; }
        TicketPriority Priority { get; }
        string Title { get; }
        string Description { get; }
        DateTime DateOfCreation { get; }
        /// <summary>
        /// Combined with <see cref="EndDate"/>, this specifies the timeframe where the task must be completed
        /// </summary>
        DateTime? StartDate { get; }
        /// <summary>
        /// Combined with <see cref="StartDate"/>, this specifies the timeframe where the task must be completed
        /// </summary>
        DateTime? EndDate { get; }
        int AuthorID { get; }
        int DepartmentID { get; }

        public enum TicketStatus
        {
            [Display(Name = "Indgående")]
            Inbound,
            [Display(Name = "Igangværende")]
            Ongoing,
            [Display(Name = "Forespørgelser")]
            Pending,
            [Display(Name = "Pause")]
            Paused,
            [Display(Name = "Nægtet")]
            Denied,
            [Display(Name = "Afsluttet")]
            Completed
        }

        public enum TicketPriority
        {
            [Display(Name = "Normal")]
            Normal,
            [Display(Name = "Vigtig")]
            Important,
            [Display(Name = "Kritisk")]
            Critical
        }

        /// <summary>
        /// A helper <see langword="class"/> that defines methods for common tasks when working with <see cref="ITicket"/> <see langword="objects"/>
        /// </summary>
        public static class Helper
        {
            /// <summary>
            /// Takes in a <see cref="TicketStatus"/> and returns the corrosponding <paramref name="values"/> entry
            /// </summary>
            /// <param name="status">The index to matchn in <paramref name="values"/></param>
            /// <param name="values">The range of values to select from</param>
            /// <returns>The <see langword="string"/> value at the specified <see cref="TicketStatus"/> index. If the <see cref="Enum"/> value is invalid this returns <see cref="string.Empty"/></returns>
            /// <exception cref="ArgumentException"></exception>
            public static string TicketStatusSwitch(TicketStatus status, string[] values)
            {
                if (status < 0) return string.Empty;

                int enumLength = Enum.GetValues(typeof(TicketStatus)).Length;

                if (values.Length != enumLength) { throw new ArgumentException($"Must be exactly {enumLength} of length", nameof(values)); }

                return values[(int)status];
            }

            /// <summary>
            /// Takes in a <see cref="TicketPriority"/> and returns the corrosponding <paramref name="values"/> entry
            /// </summary>
            /// <param name="priority">The index to matchn in <paramref name="values"/></param>
            /// <param name="values">The range of values to select from</param>
            /// <returns>The <see langword="string"/> value at the specified <see cref="TicketPriority"/> index. If the <see cref="Enum"/> value is invalid this returns <see cref="string.Empty"/></returns>
            /// <exception cref="ArgumentException"></exception>
            public static string TicketPrioritySwitch(TicketPriority priority, string[] values)
            {
                if (priority < 0) return string.Empty;

                int enumLength = Enum.GetValues(typeof(TicketPriority)).Length;

                if (values.Length != enumLength) { throw new ArgumentException($"Must be exactly {enumLength} of length", nameof(values)); }

                return values[(int)priority];
            }

            public static bool ValidateTicketDates(ITicket newTicket, DateTime now, ITicket oldTicket = null)
            {
                //  Verifying that 'newTicket' has a value for start date and end date
                bool newTicketHasStartDate = newTicket.StartDate.HasValue;
                bool newTicketHasEndDate = newTicket.EndDate.HasValue;
                bool newTicketHasBothDates = (newTicketHasStartDate && newTicketHasEndDate);

                bool startDateChanged = true;
                bool endDateChanged = true;
                if (oldTicket != null)
                {
                    //  Verifying that 'oldTicket' has a value for start date and end date
                    bool oldTicketHasStartDate = oldTicket.StartDate.HasValue;
                    bool oldTicketHasEndDate = oldTicket.EndDate.HasValue;

                    //  Verifying that the dates were indeed changed
                    startDateChanged = ((newTicketHasStartDate && oldTicketHasStartDate) ? (newTicket.StartDate.Value.IsSame(oldTicket.StartDate.Value)) : (true));
                    endDateChanged = ((newTicketHasEndDate && oldTicketHasEndDate) ? (oldTicket.EndDate.Value.IsSame(oldTicket.EndDate.Value)) : (true));
                }


                //  Verifying that start date and end date is later than 'now' and that start date is earlier than end date (In that order)
                DateTime mimicNow = DateTime.Parse(now.ToString("yyyy/MM/dd HH:mm"));   //  Leaves a margin of seconds to avoid exact validation

                bool startDateIsAfterCreation = ((newTicketHasStartDate && startDateChanged) ? (newTicket.StartDate.Value.IsLaterThan(mimicNow)) : (true));
                bool endDateIsAfterCreation = ((newTicketHasEndDate && endDateChanged) ? (newTicket.EndDate.Value.IsLaterThan(mimicNow)) : (true));
                bool StartDateIsEarlierThanEndDate = ((newTicketHasBothDates && startDateChanged && endDateChanged) ? (newTicket.StartDate.Value.IsEarlierThan(newTicket.EndDate.Value)) : (true));

                return (startDateIsAfterCreation && endDateIsAfterCreation && StartDateIsEarlierThanEndDate);
            }

            public static string[] GetStatusDisplayNames()
            {
                string[] statusNames = new string[Enum.GetNames(typeof(TicketStatus)).Length];

                for (int i = 0; i < statusNames.Length; i++)
                {
                    statusNames[i] = ((TicketStatus)i).GetDisplayName();
                }

                return statusNames;
            }
            public static string[] GetPriorityDisplayNames()
            {
                string[] priorityNames = new string[Enum.GetNames(typeof(TicketPriority)).Length];

                for (int i = 0; i < priorityNames.Length; i++)
                {
                    priorityNames[i] = ((TicketPriority)i).GetDisplayName();
                }

                return priorityNames;
            }
        }
    }
}
