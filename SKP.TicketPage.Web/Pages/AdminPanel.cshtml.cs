using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SKP.TicketPage.Services;

namespace SKP.TicketPage.Web.Pages
{
    [Authorize(Roles = RoleHelper.ADMIN_INSTRUCTOR_DEVELOPER)]
    public class AdminPanelModel : PageModel
    {
        public void OnGet()
        {
        }
    }
}
