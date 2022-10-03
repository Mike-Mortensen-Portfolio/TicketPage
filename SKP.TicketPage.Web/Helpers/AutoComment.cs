using SKP.TicketPage.Services;
using System;

namespace SKP.TicketPage.Web
{
    /// <summary>
    /// A <see langword="class"/> to help auto generate <see cref="IComment"/> and html <see langword="strings"/> based on input
    /// </summary>
    public static class AutoComment
    {
        /// <summary>
        /// Builds a <see cref="IComment"/> for which the content contains an edit message
        /// </summary>
        /// <param name="ticket"></param>
        /// <param name="editor"></param>
        /// <param name="status"></param>
        /// <param name="priority"></param>
        /// <returns>A <see cref="IComment"/> where the content is generated based on <paramref name="editor"/>, <paramref name="status"/> and <paramref name="priority"/></returns>
        public static IComment BuildEdit(ITicket ticket, IEmployee editor, ITicket.TicketStatus? status, ITicket.TicketPriority? priority)
        {
            string statusContent = string.Empty;
            string priorityContent = string.Empty;

            if (status.HasValue)
            {
                string statusColor = ITicket.Helper.TicketStatusSwitch(status.Value, new string[] { "cust-text-pyellow", "cust-text-pgreen", "cust-text-sblue", "cust-text-tertiary", string.Empty, "cust-text-pred" });
                statusContent = $"ændrede status til {BuildStatusSpan(status.Value, statusColor)}";
            }

            if (priority.HasValue)
            {
                string priorityColor = ITicket.Helper.TicketPrioritySwitch(priority.Value, new string[] { "cust-text-sblue", "cust-text-pyellow", "cust-text-pred" });
                priorityContent = $"ændrede prioritet til {BuildPrioritySpan(priority.Value, priorityColor)}";
            }


            string content = $"Ændret af {BuildAuthorAnchor(editor)}{((status.HasValue || priority.HasValue) ? (":") : (string.Empty))} {statusContent} {((status.HasValue && priority.HasValue) ? ("og") : (string.Empty))} {priorityContent}";

            var comment = new CommentDTO
            {
                AuthorID = 1,   //  Author is System
                Content = content,
                DateOfCreation = DateTime.Now,
                TicketID = ticket.ID
            };

            return comment;
        }

        /// <summary>
        /// Builds an html span tag that incapsulates <paramref name="priority"/> and applies the specified <paramref name="cssClass"/>
        /// </summary>
        /// <param name="status"></param>
        /// <param name="cssClass"></param>
        /// <returns></returns>
        public static string BuildPrioritySpan(ITicket.TicketPriority priority, string cssClass = null)
        {
            return $"<span class=\"{cssClass ?? string.Empty}\">{priority.GetDisplayName()}</span>";
        }

        /// <summary>
        /// Builds an html span tag that incapsulates <paramref name="status"/> and applies the specified <paramref name="cssClass"/>
        /// </summary>
        /// <param name="status"></param>
        /// <param name="cssClass"></param>
        /// <returns></returns>
        public static string BuildStatusSpan(ITicket.TicketStatus status, string cssClass = null)
        {
            return $"<span class=\"{cssClass ?? string.Empty}\">{status.GetDisplayName()}</span>";
        }

        /// <summary>
        /// Builds an html anchor element that incapsulates <paramref name="author"/>s name and applies the specified <paramref name="cssClass"/>
        /// </summary>
        /// <param name="author"></param>
        /// <param name="cssClass"></param>
        /// <returns></returns>
        public static string BuildAuthorAnchor(IEmployee author, string cssClass = null)
        {
            string area = "Identity";
            string page = "Account/UserPage";
            string hrefContent = $"{area}/{page}/{author.ID}";
            string authorName = $"{author.FirstName} {author.LastName}";

            return $"<a href=\"/{hrefContent}\" class=\"{cssClass ?? string.Empty}\">{authorName}</a>";
        }
    }
}
