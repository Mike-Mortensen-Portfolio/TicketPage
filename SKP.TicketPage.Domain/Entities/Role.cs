using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace SKP.TicketPage.Domain.Entities
{
    /// <summary>
    /// Represents an authorization level for an <see cref="Employee"/> (<i>Corrosponds to <strong>AspNetRoles</strong> table. See ER Diagram fo rmore info</i>)
    /// </summary>
    public class Role : IdentityRole<int>
    {
        /// <summary>
        /// This should be used to display the <see cref="IdentityRole{T}.Name"/>
        /// </summary>
        [MaxLength(50)]
        public string DisplayName { get; set; }
        [MaxLength(500)]
        public string Description { get; set; }
    }
}
