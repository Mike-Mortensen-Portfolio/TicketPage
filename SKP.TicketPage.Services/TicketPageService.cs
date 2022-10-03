using Microsoft.AspNetCore.Identity;
using SKP.TicketPage.Domain;
using SKP.TicketPage.Domain.Entities;

namespace SKP.TicketPage.Services
{
    /// <summary>
    /// Service instance that allows for communication with DB
    /// </summary>
    public sealed class TicketPageService : ITicketPageService
    {
        public TicketPageService()
        {
            _context = new TicketPageContext();
            Department = new DepartmentRepository(_context);
            Ticket = new TicketRepository(_context);
            Comment = new CommentRepository(_context);
        }

        public TicketPageService(UserManager<Employee> userManager, SignInManager<Employee> signInManager, RoleManager<Role> roleManager) : this()
        {
            Employee = new EmployeeManager(userManager, signInManager, roleManager);
        }

        private readonly TicketPageContext _context;

        public IDepartmentRepository Department { get; }

        public IEmployeeManager Employee { get; }
        public ITicketRepository Ticket { get; }
        public ICommentRepository Comment { get; }
    }
}
