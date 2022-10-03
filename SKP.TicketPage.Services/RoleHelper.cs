using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SKP.TicketPage.Services
{
    /// <summary>
    /// A <see langword="static"/> <see langword="object"/> that provides <see cref="IRole"/> specific <strong>constants</strong>
    /// </summary>
    public static class RoleHelper
    {
        //Roles
        public const string SYSTEM = "System";
        public const string BASE = "Base";
        public const string ADMIN = "Admin";
        public const string INSTRUCTOR = "Instructor";
        public const string DEVELOPER = "Developer";

        //  Authorization definitions
        public const string BASE_ADMIN_INSTRUCTOR_DEVELOPER = "Base,Admin,Instructor,Developer";
        public const string BASE_ADMIN_INSTRUCTOR = "Base,Admin,Instructor";
        public const string BASE_ADMIN = "Base,Admin";
        public const string BASE_INSTRUCTOR = "Base,Instructor";
        public const string BASE_DEVELOPER = "Base,Developer";
        public const string ADMIN_INSTRUCTOR_DEVELOPER = "Admin,Instructor,Developer";
        public const string ADMIN_INSTRUCTOR = "Admin,Instructor";
        public const string ADMIN_DEVELOPER = "Admin,Developer";
        public const string INSTRUCTOR_DEVELOPER = "Instructor,Developer";
    }
}
