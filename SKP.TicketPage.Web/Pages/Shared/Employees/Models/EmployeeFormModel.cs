using SKP.TicketPage.Services;

namespace SKP.TicketPage.Web.Pages.Shared.Employees.Models
{
    public class EmployeeFormModel
    {
        public bool ReadOnly { get; set; }
        public EmployeeFormInputModel Input { get; set; }
        public string ReturnURL { get; set; } = null;

        public Lock LockFlag { get; set; } = Lock.None;
        public Helper LockHelper { get; } = new Helper();

        public class EmployeeFormInputModel
        {
            public EmployeeDTO Employee { get; set; }
            public string RoleName { get; set; }
        }

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
            public bool NameLocked(Lock lockIndex)
            {
                return (lockIndex == Lock.Name ||
                        lockIndex == Lock.NameAndDepartment ||
                        lockIndex == Lock.NameAndEmail ||
                        lockIndex == Lock.NameAndRole ||
                        lockIndex == Lock.NameDepartmentAndRole ||
                        lockIndex == Lock.NameEmailAndDepartment ||
                        lockIndex == Lock.NameEmailAndRole);
            }

            /// <summary>
            /// 
            /// </summary>
            /// <param name="lockIndex"></param>
            /// <returns><see langword="True"/> if <paramref name="lockIndex"/> matches a status lock; Otherwise, if not, <see langword="false"/></returns>
            public bool EmailLocked(Lock lockIndex)
            {
                return (lockIndex == Lock.Email ||
                        lockIndex == Lock.EmailAndDepartment ||
                        lockIndex == Lock.EmailAndRole ||
                        lockIndex == Lock.NameAndEmail ||
                        lockIndex == Lock.NameEmailAndDepartment ||
                        lockIndex == Lock.NameEmailAndRole);
            }

            /// <summary>
            /// 
            /// </summary>
            /// <param name="lockIndex"></param>
            /// <returns><see langword="True"/> if <paramref name="lockIndex"/> matches a department lock; Otherwise, if not, <see langword="false"/></returns>
            public bool DepartmentLocked(Lock lockIndex)
            {
                return (lockIndex == Lock.Department ||
                        lockIndex == Lock.DepartmentAndRole ||
                        lockIndex == Lock.EmailAndDepartment ||
                        lockIndex == Lock.NameAndDepartment ||
                        lockIndex == Lock.NameDepartmentAndRole ||
                        lockIndex == Lock.NameEmailAndDepartment);
            }

            /// <summary>
            /// 
            /// </summary>
            /// <param name="lockIndex"></param>
            /// <returns><see langword="True"/> if <paramref name="lockIndex"/> matches a priority lock; Otherwise, if not, <see langword="false"/></returns>
            public bool RoleLocked(Lock lockIndex)
            {
                return (lockIndex == Lock.Role ||
                        lockIndex == Lock.DepartmentAndRole ||
                        lockIndex == Lock.EmailAndRole ||
                        lockIndex == Lock.NameAndRole ||
                        lockIndex == Lock.NameDepartmentAndRole ||
                        lockIndex == Lock.NameEmailAndRole);
            }
        }

        public enum Lock
        {
            None,
            Name,
            Email,
            Department,
            Role,
            NameAndEmail,
            NameAndDepartment,
            NameAndRole,
            NameEmailAndDepartment,
            NameEmailAndRole,
            NameDepartmentAndRole,
            EmailAndDepartment,
            EmailAndRole,
            DepartmentAndRole
        }
    }
}
