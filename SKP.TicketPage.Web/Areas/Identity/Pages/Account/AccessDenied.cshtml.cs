using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using System.Linq;
using System.Security.Claims;

namespace SKP.TicketPage.Web.Areas.Identity.Pages.Account
{
    [AllowAnonymous]
    public class AccessDeniedModel : PageModel
    {
        public AccessDeniedModel(ILogger<AccessDeniedModel> logger)
        {
            _logger = logger;
        }

        private readonly ILogger<AccessDeniedModel> _logger;


        public void OnGet(string returnUrl)
        {
            string uniLogin = GetUniLogin(User);
            if (uniLogin == null)
            {
                _logger.LogError("A user (email: {email}) did not receive their uni login claim (WindowsAccountName) from the sso", User.Identity.Name);
            }
            _logger.LogWarning("The user {user} was denied access to \"{url}\". The user had these claims: {Claims}", GetUniLogin(User), returnUrl, GetClaims(User));
        }

        private string GetClaims(ClaimsPrincipal user)
        {
            return string.Join(", ", user.Claims.Select(c => c.Value));
        }
        private string GetUniLogin(ClaimsPrincipal user)
        {
            return user.FindFirstValue(ClaimTypes.WindowsAccountName);
        }
    }
}

