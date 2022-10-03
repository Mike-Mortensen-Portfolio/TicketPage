using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;

namespace SKP.TicketPage.Services
{
    public static class EnumExtensions
    {
        /// <summary>
        /// Gets the display name for the <see cref="Enum"/> <paramref name="value"/>
        /// </summary>
        /// <param name="value"></param>
        /// <returns>A <see langword="string"/> that represents the <see cref="DisplayAttribute"/> of the <see cref="Enum"/> <paramref name="value"/></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public static string GetDisplayName(this Enum value)
        {
            if (value == null) throw new ArgumentNullException(nameof(value), "Source can't be null");

            return value.GetType()
                .GetMember(value.ToString())
                .FirstOrDefault()
                .GetCustomAttribute<DisplayAttribute>()?
                .GetName();
        }
    }
}
