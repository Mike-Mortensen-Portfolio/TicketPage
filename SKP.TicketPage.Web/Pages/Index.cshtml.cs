using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using SKP.TicketPage.Services;

namespace SKP.TicketPage.Web.Pages
{
    [AllowAnonymous]
    public class IndexModel : PageModel
    {
        public IndexModel(ITicketPageService service, ILogger<IndexModel> logger)
        {
            Service = service;
            _logger = logger;
        }

        private readonly ILogger<IndexModel> _logger;
        public ITicketPageService Service { get; }

        public IActionResult OnGet()
        {
            if (Service.Employee.IsSignedIn(User))
            {
                return Redirect($"/Identity/Account/UserPage/{User.GetID()}");
            }

            return Page();
        }
    }
}
