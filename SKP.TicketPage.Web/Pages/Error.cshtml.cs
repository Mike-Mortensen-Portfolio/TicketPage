using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SKP.TicketPage.Services;
using System.Diagnostics;
using System.Threading.Tasks;

namespace SKP.TicketPage.Web.Pages
{
    [AllowAnonymous]
    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public class ErrorModel : PageModel
    {
        public ErrorModel(IErrorLogger logger)
        {
            Logger = logger;
        }

        public string RequestId { get; set; }

        public bool ShowRequestInformation => !string.IsNullOrEmpty(RequestId);

        public IErrorLogger Logger { get; }

        public void OnGet()
        {

        }
    }
}
