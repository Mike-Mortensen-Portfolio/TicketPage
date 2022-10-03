using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SKP.TicketPage.Services;

namespace SKP.TicketPage.Web.Pages
{
    [AllowAnonymous]
    public class TicketPageModel : PageModel
    {
        public TicketPageModel(ITicketPageService service)
        {
            Service = service;
        }

        public ITicketPageService Service { get; }
        public ITicket Ticket { get; private set; }

        [BindProperty]
        public EmployeeFilterOptions FilterOptions { get; set; }
        public IReadOnlyList<IEmployee> AssignedEmployees { get; set; }

        [BindProperty]
        public CommentDTO Input { get; set; }
        public bool EditComment { get; set; }
        public string FocusID { get; set; }

        public async Task<IActionResult> OnGetAsync(int id, string focusID = null)
        {
            Ticket = await Service.Ticket.GetByIDAsync(id);

            AssignedEmployees = await Ticket.GetAssignedEmployeesAsync();

            FocusID = focusID;

            return Page();
        }

        public async Task<IActionResult> OnPostCommentFormConfirmAsync(int id)
        {
            Ticket = await Service.Ticket.GetByIDAsync(id);

            if (ModelState.IsValid)
            {
                Input.AuthorID = int.Parse(User.FindFirst(c => c.Type == ClaimTypes.NameIdentifier).Value);
                Input.TicketID = Ticket.ID;
                Input.DateOfCreation = DateTime.Now;

                await Service.Comment.AddAsync(Input);

                int focusID = (await Service.Comment.GetByTicketAsync(id)).SingleOrDefault(c => c.AuthorID == Input.AuthorID && c.DateOfCreation == Input.DateOfCreation).ID;

                return Redirect($"/TicketPage/{id}/{focusID}");
            }

            FilterOptions = new EmployeeFilterOptions
            {
                Active = FilterOptions.Active,
                DepartmentID = FilterOptions.DepartmentID,
                SearchKey = FilterOptions.SearchKey,
                TicketID = Ticket.ID
            };

            AssignedEmployees = await Service.Employee.FilterAsync(FilterOptions);

            return Page();
        }

        public async Task<IActionResult> OnPostAssignEmployeeAsync(int id, int employeeID)
        {
            Ticket = await Service.Ticket.GetByIDAsync(id);

            IEmployee employee = await Service.Employee.GetByIDAsync(employeeID);

            ModelState.Clear();

            if (await Ticket.AssignEmployee(employee))
            {
                IEmployee editor = await Service.Employee.GetByIDAsync(User.GetID());

                CommentDTO comment = new CommentDTO
                {
                    AuthorID = editor.ID,
                    Content = $"{AutoComment.BuildAuthorAnchor(editor)} føjede {AutoComment.BuildAuthorAnchor(employee)} til opgaven",
                    DateOfCreation = DateTime.Now,
                    TicketID = Ticket.ID
                };

                await Service.Comment.AddAsync(comment);
            }

            FilterOptions = new EmployeeFilterOptions
            {
                Active = FilterOptions.Active,
                DepartmentID = FilterOptions.DepartmentID,
                SearchKey = FilterOptions.SearchKey,
                TicketID = Ticket.ID
            };

            AssignedEmployees = await Service.Employee.FilterAsync(FilterOptions);

            return Page();
        }

        public async Task<IActionResult> OnPostRemoveEmployeeAsync(int id, int employeeID)
        {
            Ticket = await Service.Ticket.GetByIDAsync(id);

            IEmployee employee = await Service.Employee.GetByIDAsync(employeeID);

            ModelState.Clear();

            if (await Ticket.RemoveEmployee(employee))
            {
                IEmployee editor = await Service.Employee.GetByIDAsync(User.GetID());

                CommentDTO comment = new CommentDTO
                {
                    AuthorID = editor.ID,
                    Content = $"{AutoComment.BuildAuthorAnchor(editor)} fjernede {AutoComment.BuildAuthorAnchor(employee)} fra opgaven",
                    DateOfCreation = DateTime.Now,
                    TicketID = Ticket.ID
                };

                await Service.Comment.AddAsync(comment);
            }

            FilterOptions = new EmployeeFilterOptions
            {
                Active = FilterOptions.Active,
                DepartmentID = FilterOptions.DepartmentID,
                SearchKey = FilterOptions.SearchKey,
                TicketID = Ticket.ID
            };

            AssignedEmployees = await Service.Employee.FilterAsync(FilterOptions);

            return Page();
        }

        public async Task<IActionResult> OnPostEditCommentAsync(int id, int commentID, bool editComment, string focusID)
        {
            Ticket = await Service.Ticket.GetByIDAsync(id);
            IComment comment = await Service.Comment.GetByIDAsync(commentID);
            Input.ID = comment.ID;

            EditComment = editComment;

            FocusID = focusID;

            if (EditComment && ModelState.IsValid)
            {
                Input.AuthorID = comment.AuthorID;
                Input.TicketID = Ticket.ID;
                Input.DateOfCreation = comment.DateOfCreation;

                await Service.Comment.UpdateAsync(Input);

                return Redirect($"/TicketPage/{Ticket.ID}/{FocusID}");
            }
            else
            {
                Input.Content = comment.Content;
            }

            EditComment = true;

            return Page();
        }

        public async Task<IActionResult> OnPostRemoveCommentAsync(int id, int commentID)
        {
            IComment comment = await Service.Comment.GetByIDAsync(commentID);

            if (comment != null && await Service.Comment.RemoveAsync(comment))
            {
                return Redirect($"/TicketPage/{id}");
            }

            FilterOptions = new EmployeeFilterOptions
            {
                Active = FilterOptions.Active,
                DepartmentID = FilterOptions.DepartmentID,
                SearchKey = FilterOptions.SearchKey,
                TicketID = Ticket.ID
            };

            AssignedEmployees = await Service.Employee.FilterAsync(FilterOptions);

            return Page();
        }

        public IActionResult OnPostEmployeeEdit(int employeeID)
        {
            return Redirect($"/Identity/Account/EditUser/{employeeID}");
        }

        public async Task<IActionResult> OnPostEmployeePromoteAsync(int id, string returnURL, int employeeID)
        {
            Ticket = await Service.Ticket.GetByIDAsync(id);
            IEmployee employee = await Service.Employee.GetByIDAsync(employeeID);

            if (await Service.Employee.IsInRoleAsync(employee.ID, RoleHelper.ADMIN))
            {

                await Service.Employee.AddToRoleAsync(employee.ID, RoleHelper.BASE);
                await Service.Employee.RemoveFromRoleAsync(employee.ID, RoleHelper.ADMIN);
            }
            else
            {
                await Service.Employee.AddToRoleAsync(employee.ID, RoleHelper.ADMIN);
                await Service.Employee.RemoveFromRoleAsync(employee.ID, RoleHelper.BASE);

            }

            FilterOptions = new EmployeeFilterOptions
            {
                Active = FilterOptions.Active,
                DepartmentID = FilterOptions.DepartmentID,
                SearchKey = FilterOptions.SearchKey,
                TicketID = Ticket.ID
            };

            AssignedEmployees = await Service.Employee.FilterAsync(FilterOptions);

            return Redirect(returnURL);
        }

        public async Task<IActionResult> OnPostEmployeeActivateAsync(int id, int employeeID)
        {
            Ticket = await Service.Ticket.GetByIDAsync(id);
            IEmployee employee = await Service.Employee.GetByIDAsync(employeeID);

            var toUpdate = new EmployeeDTO
            {
                Active = !employee.Active,
                DepartmentID = employee.DepartmentID,
                Email = employee.Email,
                FirstName = employee.FirstName,
                ID = employee.ID,
                LastName = employee.LastName,
                Username = employee.Username
            };

            await Service.Employee.UpdateAsync(toUpdate);

            FilterOptions = new EmployeeFilterOptions
            {
                Active = FilterOptions.Active,
                DepartmentID = FilterOptions.DepartmentID,
                SearchKey = FilterOptions.SearchKey,
                TicketID = Ticket.ID
            };

            AssignedEmployees = await Service.Employee.FilterAsync(FilterOptions);

            return Page();
        }

        public async Task<IActionResult> OnPostEmployeeDeleteAsync(int id, string returnURL, int employeeID)
        {
            Ticket = await Service.Ticket.GetByIDAsync(id);

            await Service.Employee.RemoveAsync(employeeID);

            FilterOptions = new EmployeeFilterOptions
            {
                Active = FilterOptions.Active,
                DepartmentID = FilterOptions.DepartmentID,
                SearchKey = FilterOptions.SearchKey,
                TicketID = Ticket.ID
            };

            AssignedEmployees = await Service.Employee.FilterAsync(FilterOptions);

            return Redirect(returnURL);
        }

        public async Task<IActionResult> OnPostEmployeeFilter(int id)
        {
            Ticket = await Service.Ticket.GetByIDAsync(id);

            ModelState.Clear();

            FilterOptions = new EmployeeFilterOptions
            {
                Active = FilterOptions.Active,
                DepartmentID = FilterOptions.DepartmentID,
                SearchKey = FilterOptions.SearchKey,
                TicketID = Ticket.ID
            };

            AssignedEmployees = await Service.Employee.FilterAsync(FilterOptions);

            return Page();
        }
    }
}
