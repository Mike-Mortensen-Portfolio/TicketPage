using System;

namespace SKP.TicketPage.Services
{
    public static class DateTimeExtensions
    {
        /// <summary>
        /// Compares the <see cref="DateTime"/> to <paramref name="d2"/>
        /// </summary>
        /// <param name="d1"></param>
        /// <param name="d2"></param>
        /// <returns><see langword="True"/> if the <see cref="DateTime"/> is earlier, or is the same as <paramref name="d2"/>. Otherwise, if not, <see langword="false"/></returns>
        public static bool IsEarlierThan(this DateTime d1, DateTime d2)
        {
            return (d1 <= d2);
        }
        /// <summary>
        /// Compares the <see cref="DateTime"/> to <paramref name="d2"/>
        /// </summary>
        /// <param name="d1"></param>
        /// <param name="d2"></param>
        /// <returns><see langword="True"/> if the <see cref="DateTime"/> is later, or is the same as <paramref name="d2"/>. Otherwise, if not, <see langword="false"/></returns>
        public static bool IsLaterThan(this DateTime d1, DateTime d2)
        {
            return (d1 >= d2);
        }

        /// <summary>
        /// Compares the <see cref="DateTime"/> to <paramref name="d2"/>
        /// </summary>
        /// <param name="d1"></param>
        /// <param name="d2"></param>
        /// <returns><see langword="True"/> if the <see cref="DateTime"/> is the same as <paramref name="d2"/>. Otherwise, if not, <see langword="false"/></returns>
        public static bool IsSame(this DateTime d1, DateTime d2)
        {
            return (d1 == d2);
        }
    }
}
