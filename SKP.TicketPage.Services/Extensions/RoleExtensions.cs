using SKP.TicketPage.Domain.Entities;
using SKP.TicketPage.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SKP.TicketPage.Services
{
    public static class RoleExtensions
    {
        /// <summary>
        /// Maps a <see langword="public"/> <see cref="IRole"/> instance to an <see langword="internal"/> <see cref="Role"/> entity
        /// </summary>
        /// <param name="role"></param>
        /// <returns>The <see cref="Role"/> instance if the mapping was succesfull</returns>
        /// <exception cref="ArgumentNullException"></exception>
        internal static Role MapToInternal(this IRole role)
        {
            if (role == null) throw new ArgumentNullException(nameof(role), "Cannot map NULL value");

            return new Role
            {
                Id = role.ID,
                DisplayName = role.DisplayName,
                Description = role.Description,
                Name = role.Name
            };
        }

        /// <summary>
        /// Maps the <see langword="internal"/> <see cref="Role"/> entity to a <see langword="public"/> <see cref="RoleDTO"/> masked as an <see cref="IRole"/> instance
        /// </summary>
        /// <param name="role"></param>
        /// <returns>The <see cref="IRole"/> instance if the mapping was succesfull</returns>
        /// <exception cref="ArgumentNullException"></exception>
        internal static IRole MapToPublic(this Role role)
        {
            if (role == null) throw new ArgumentNullException(nameof(role), "Cannot map NULL value");

            return new RoleDTO
            {
                ID = role.Id,
                DisplayName = role.DisplayName,
                Description = role.Description,
                Name = role.Name
            };
        }

        /// <summary>
        /// Maps a queryable range of <see langword="public"/> <see cref="IRole"/> entities to a queryable collection of <see langword="internal"/> <see cref="Role"/> instances
        /// </summary>
        /// <param name="roles"></param>
        /// <returns>The collection of <see cref="Role"/> instances if the mapping was succesfull</returns>
        /// <exception cref="ArgumentNullException"></exception>
        internal static IQueryable<Role> MapToInternal(this IQueryable<IRole> roles)
        {
            if (roles == null) throw new ArgumentNullException(nameof(roles), "Cannot map NULL value");

            return roles
                .Select(r => new Role
                {
                    Id = r.ID,
                    DisplayName = r.DisplayName,
                    Description = r.Description,
                    Name = r.Name
                });
        }

        /// <summary>
        /// Maps a queryable range of <see langword="internal"/> <see cref="Role"/> entities to a queryable collection of <see langword="public"/> <see cref="RoleDTO"/> <see langword="objects"/> masked as <see cref="IRole"/> instances
        /// </summary>
        /// <param name="roles"></param>
        /// <returns>The collection of <see cref="IRole"/> instances if the mapping was succesfull</returns>
        /// <exception cref="ArgumentNullException"></exception>
        internal static IQueryable<IRole> MapToPublic(this IQueryable<Role> roles)
        {
            if (roles == null) throw new ArgumentNullException(nameof(roles), "Cannot map NULL value");

            return roles
                .Select(r => new RoleDTO
                {
                    ID = r.Id,
                    DisplayName = r.DisplayName,
                    Description = r.Description,
                    Name = r.Name
                });
        }
    }
}
