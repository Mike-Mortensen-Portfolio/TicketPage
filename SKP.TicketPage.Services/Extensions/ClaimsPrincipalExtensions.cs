using System;
using System.Security.Claims;

namespace SKP.TicketPage.Services
{
    public static class ClaimsPrincipalExtensions
    {
        /// <summary>
        /// Applies to the role of <see cref="RoleHelper.ADMIN"/>, <see cref="RoleHelper.INSTRUCTOR"/> and <see cref="RoleHelper.DEVELOPER"/>
        /// </summary>
        /// <param name="principal"></param>
        /// <returns><see langword="True"/> if the user has admin privileges; Otherwise, if not, <see langword="false"/></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public static bool IsAdmin(this ClaimsPrincipal principal)
        {
            if (principal == null) throw new ArgumentNullException(nameof(principal), "Source can't be NULL");

            return (principal.IsInRole(RoleHelper.ADMIN) || principal.IsSuperUser());
        }

        /// <summary>
        /// Applies to the role of <see cref="RoleHelper.INSTRUCTOR"/> and <see cref="RoleHelper.DEVELOPER"/>
        /// </summary>
        /// <param name="principal"></param>
        /// <returns><see langword="True"/> if the user has super user privileges; Otherwise, if not, <see langword="false"/></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public static bool IsSuperUser(this ClaimsPrincipal principal)
        {
            if (principal == null) throw new ArgumentNullException(nameof(principal), "Source can't be NULL");

            return (principal.IsInRole(RoleHelper.INSTRUCTOR) || principal.IsInRole(RoleHelper.DEVELOPER));
        }

        /// <summary>
        /// Uses the <see cref="ClaimTypes.NameIdentifier"/> to retrieve ID from identity. In that regard the process will return <strong>-1</strong> if the identifier does not return a numeric value
        /// </summary>
        /// <param name="principal"></param>
        /// <returns>The given <strong>ID</strong> if the user exists and the ID value is an <see langword="int"/>; Othwerwise if not, <strong>-1</strong></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public static int GetID(this ClaimsPrincipal principal)
        {
            if (principal == null) throw new ArgumentNullException(nameof(principal), "Source can't be NULL");

            string stringID = principal.FindFirst(c => c.Type == ClaimTypes.NameIdentifier)?.Value;

            if (int.TryParse(stringID, out int ID))
            {
                return ID;
            }

            return -1;
        }

        /// <summary>
        /// Uses the <see cref="ClaimTypes.Email"/> to retrieve email form identity
        /// </summary>
        /// <param name="principal"></param>
        /// <returns>The <see langword="string"/> representaion of the users email</returns>
        /// <exception cref="ArgumentNullException"></exception>
        public static string GetEmail(this ClaimsPrincipal principal)
        {
            if (principal == null) throw new ArgumentNullException(nameof(principal), "Source can't be NULL");

            string email = principal.FindFirst(c => c.Type == ClaimTypes.Email)?.Value;

            return email;
        }

        /// <summary>
        /// Checks if the identity of the user matches the identity of <paramref name="employee"/>
        /// </summary>
        /// <param name="principal"></param>
        /// <param name="employee">The identity to validate against</param>
        /// <returns><see langword="True"/> if the identity of the user matches the identity of <paramref name="employee"/>; Otherwise, if not, <see langword="false"/></returns>
        public static bool IsSelf(this ClaimsPrincipal principal, IEmployee employee)
        {
            return (principal.IsSelf(employee.ID));
        }
        /// <summary>
        /// Checks if the identity of the user matches the identity of the <see cref="IEmployee"/> with <paramref name="id"/>
        /// </summary>
        /// <param name="principal"></param>
        /// <param name="id">The identity to validate against</param>
        /// <returns><see langword="True"/> if the id of the user matches <paramref name="id"/>; Otherwise, if not, <see langword="false"/></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public static bool IsSelf(this ClaimsPrincipal principal, int id)
        {
            if (principal == null) throw new ArgumentNullException(nameof(principal), "Source can't be NULL");

            return (principal.GetID() == id);
        }

    }
}
