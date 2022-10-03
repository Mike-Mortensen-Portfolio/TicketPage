using SKP.TicketPage.Domain.Entities;
using System;
using System.Linq;

namespace SKP.TicketPage.Services
{
    public static class CommentExtensions
    {
        /// <summary>
        /// Maps a <see langword="public"/> <see cref="IComment"/> instance to an <see langword="internal"/> <see cref="Comment"/> entity
        /// </summary>
        /// <param name="comment"></param>
        /// <returns>The <see cref="Comment"/> instance if the mapping was succesfull</returns>
        /// <exception cref="ArgumentNullException"></exception>
        internal static Comment MapToInternal(this IComment comment)
        {
            if (comment == null) throw new ArgumentNullException(nameof(comment), "Cannot map NULL value");

            return new Comment
            {
                ID = comment.ID,
                AuthorID = comment.AuthorID,
                Content = comment.Content,
                DateOfCreation = comment.DateOfCreation,
                TicketID = comment.TicketID
            };
        }

        /// <summary>
        /// Maps the <see langword="internal"/> <see cref="Comment"/> entity to a <see langword="public"/> <see cref="CommentDTO"/> masked as an <see cref="IComment"/> instance
        /// </summary>
        /// <param name="comment"></param>
        /// <returns>The <see cref="IComment"/> instance if the mapping was succesfull</returns>
        /// <exception cref="ArgumentNullException"></exception>
        internal static IComment MapToPublic(this Comment comment)
        {
            if (comment == null) throw new ArgumentNullException(nameof(comment), "Cannot map NULL value");

            return new CommentDTO
            {
                ID = comment.ID,
                AuthorID = comment.AuthorID,
                Content = comment.Content,
                DateOfCreation = comment.DateOfCreation,
                TicketID = comment.TicketID
            };
        }

        /// <summary>
        /// Maps a queryable range of <see langword="public"/> <see cref="IComment"/> entities to a queryable collection of <see langword="internal"/> <see cref="Comment"/> instances
        /// </summary>
        /// <param name="comments"></param>
        /// <returns>The collection of <see cref="Comment"/> instances if the mapping was succesfull</returns>
        /// <exception cref="ArgumentNullException"></exception>
        internal static IQueryable<Comment> MapToInternal(this IQueryable<IComment> comments)
        {
            if (comments == null) throw new ArgumentNullException(nameof(comments), "Cannot map NULL value");

            return comments
                .Select(c => new Comment
                {
                    ID = c.ID,
                    AuthorID = c.AuthorID,
                    Content = c.Content,
                    DateOfCreation = c.DateOfCreation,
                    TicketID = c.TicketID
                });
        }

        /// <summary>
        /// Maps a queryable range of <see langword="internal"/> <see cref="Comment"/> entities to a queryable collection of <see langword="public"/> <see cref="CommentDTO"/> <see langword="objects"/> masked as <see cref="IComment"/> instances
        /// </summary>
        /// <param name="comments"></param>
        /// <returns>The collection of <see cref="IComment"/> instances if the mapping was succesfull</returns>
        /// <exception cref="ArgumentNullException"></exception>
        internal static IQueryable<IComment> MapToPublic(this IQueryable<Comment> comments)
        {
            if (comments == null) throw new ArgumentNullException(nameof(comments), "Cannot map NULL value");

            return comments
                .Select(c => new CommentDTO
                {
                    ID = c.ID,
                    AuthorID = c.AuthorID,
                    Content = c.Content,
                    DateOfCreation = c.DateOfCreation,
                    TicketID = c.TicketID
                });
        }
    }
}
