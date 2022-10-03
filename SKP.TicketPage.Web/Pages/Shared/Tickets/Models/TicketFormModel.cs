using SKP.TicketPage.Services;

namespace SKP.TicketPage.Web.Pages.Shared.Tickets.Models
{
    public class TicketFormModel
    {
        public string Header { get; set; } = null;
        public bool HideControls { get; set; } = true;
        public bool Readonly { get; set; } = false;
        public TicketDTO Input { get; set; }
        public Lock LockFlag { get; set; } = Lock.None;
        public Helper LockHelper { get; } = new Helper();

        /// <summary>
        /// A <see langword="class"/> that aids with <see cref="Lock"/> functionality
        /// </summary>
        public class Helper
        {
            /// <summary>
            /// 
            /// </summary>
            /// <param name="lockIndex"></param>
            /// <returns><see langword="True"/> if <paramref name="lockIndex"/> matches a title lock; Otherwise, if not, <see langword="false"/></returns>
            public bool TitleLocked(Lock lockIndex)
            {
                return (lockIndex == Lock.Title ||
                        lockIndex == Lock.TitleAndDepartment ||
                        lockIndex == Lock.TitleAndDescription ||
                        lockIndex == Lock.TitleAndStatus ||
                        lockIndex == Lock.TitleAndPriority ||
                        lockIndex == Lock.TitleAndStartDate ||
                        lockIndex == Lock.TitleAndEndDate);
            }

            /// <summary>
            /// 
            /// </summary>
            /// <param name="lockIndex"></param>
            /// <returns><see langword="True"/> if <paramref name="lockIndex"/> matches a department lock; Otherwise, if not, <see langword="false"/></returns>
            public bool DepartmentLocked(Lock lockIndex)
            {
                return (lockIndex == Lock.Department ||
                        lockIndex == Lock.DepartmentAndDescription ||
                        lockIndex == Lock.TitleAndDepartment ||
                        lockIndex == Lock.DepartmentAndEndDate ||
                        lockIndex == Lock.DepartmentAndPriority ||
                        lockIndex == Lock.DepartmentAndStartDate ||
                        lockIndex == Lock.DepartmentAndStatus);
            }

            /// <summary>
            /// 
            /// </summary>
            /// <param name="lockIndex"></param>
            /// <returns><see langword="True"/> if <paramref name="lockIndex"/> matches a status lock; Otherwise, if not, <see langword="false"/></returns>
            public bool StatusLocked(Lock lockIndex)
            {
                return (lockIndex == Lock.Status ||
                        lockIndex == Lock.StatusAndDescription ||
                        lockIndex == Lock.StatusAndEndDate ||
                        lockIndex == Lock.StatusAndPriority ||
                        lockIndex == Lock.StatusAndStartDate ||
                        lockIndex == Lock.DepartmentAndStatus ||
                        lockIndex == Lock.TitleAndStatus);
            }

            /// <summary>
            /// 
            /// </summary>
            /// <param name="lockIndex"></param>
            /// <returns><see langword="True"/> if <paramref name="lockIndex"/> matches a priority lock; Otherwise, if not, <see langword="false"/></returns>
            public bool PriorityLocked(Lock lockIndex)
            {
                return (lockIndex == Lock.Priority ||
                        lockIndex == Lock.PriorityAndDescription ||
                        lockIndex == Lock.PriorityAndEndDate ||
                        lockIndex == Lock.PriorityAndStartDate ||
                        lockIndex == Lock.DepartmentAndPriority ||
                        lockIndex == Lock.StatusAndPriority ||
                        lockIndex == Lock.TitleAndPriority);
            }

            /// <summary>
            /// 
            /// </summary>
            /// <param name="lockIndex"></param>
            /// <returns><see langword="True"/> if <paramref name="lockIndex"/> matches a description lock; Otherwise, if not, <see langword="false"/></returns>
            public bool DescriptionLocked(Lock lockIndex)
            {
                return (lockIndex == Lock.Description ||
                        lockIndex == Lock.DescriptionAndEndDate ||
                        lockIndex == Lock.DescriptionAndStartDate ||
                        lockIndex == Lock.DepartmentAndDescription ||
                        lockIndex == Lock.PriorityAndDescription ||
                        lockIndex == Lock.StatusAndDescription ||
                        lockIndex == Lock.TitleAndDescription);
            }

            /// <summary>
            /// 
            /// </summary>
            /// <param name="lockIndex"></param>
            /// <returns><see langword="True"/> if <paramref name="lockIndex"/> matches a start date lock; Otherwise, if not, <see langword="false"/></returns>
            public bool StartDateLocked(Lock lockIndex)
            {
                return (lockIndex == Lock.StartDate ||
                        lockIndex == Lock.StartDateAndEndDate ||
                        lockIndex == Lock.DepartmentAndStartDate ||
                        lockIndex == Lock.DescriptionAndStartDate ||
                        lockIndex == Lock.PriorityAndStartDate ||
                        lockIndex == Lock.StatusAndStartDate ||
                        lockIndex == Lock.TitleAndStartDate);
            }

            /// <summary>
            /// 
            /// </summary>
            /// <param name="lockIndex"></param>
            /// <returns><see langword="True"/> if <paramref name="lockIndex"/> matches a end date lock; Otherwise, if not, <see langword="false"/></returns>
            public bool EndDateLocked(Lock lockIndex)
            {
                return (lockIndex == Lock.EndDate ||
                        lockIndex == Lock.DepartmentAndEndDate ||
                        lockIndex == Lock.DescriptionAndEndDate ||
                        lockIndex == Lock.PriorityAndEndDate ||
                        lockIndex == Lock.StartDateAndEndDate ||
                        lockIndex == Lock.StatusAndEndDate ||
                        lockIndex == Lock.TitleAndEndDate);
            }
        }

        public enum Lock
        {
            None,
            Title,
            Department,
            Status,
            Priority,
            Description,
            StartDate,
            EndDate,
            TitleAndDepartment,
            TitleAndStatus,
            TitleAndPriority,
            TitleAndDescription,
            TitleAndStartDate,
            TitleAndEndDate,
            DepartmentAndStatus,
            DepartmentAndPriority,
            DepartmentAndDescription,
            DepartmentAndStartDate,
            DepartmentAndEndDate,
            StatusAndPriority,
            StatusAndDescription,
            StatusAndStartDate,
            StatusAndEndDate,
            PriorityAndDescription,
            PriorityAndStartDate,
            PriorityAndEndDate,
            DescriptionAndStartDate,
            DescriptionAndEndDate,
            StartDateAndEndDate
        }
    }
}
