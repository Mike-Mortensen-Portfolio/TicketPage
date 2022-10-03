using Microsoft.AspNetCore.Identity;

namespace SKP.TicketPage.Domain.Entities
{
    /// <summary>
    ///  Join table between <see cref="Employee"/> ↔ <see cref="Role"/> with combined key: <see cref="IdentityUserRole.UserId"/> ↔ <see cref="IdentityUserRole.RoleId"/> (<i>Corrosponds to <strong>AspNetUserRoles</strong> table. See ER Diagram fo rmore info</i>)
    /// </summary>
    public class EmployeeRole : IdentityUserRole<int>
    {
    }
}
