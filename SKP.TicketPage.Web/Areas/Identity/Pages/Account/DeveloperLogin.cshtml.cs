using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using SKP.TicketPage.Domain.Entities;
using SKP.TicketPage.Services;

namespace SKP.TicketPage.Web.Areas.Identity.Pages.Account
{
    [AllowAnonymous]
    public class DeveloperLoginModel : PageModel
    {
        private readonly ILogger<DeveloperLoginModel> _logger;
        private readonly ITicketPageService _service;

        public DeveloperLoginModel(ITicketPageService service, ILogger<DeveloperLoginModel> logger)
        {
            _service = service;
            _logger = logger;
        }

        [BindProperty]
        public InputModel Input { get; set; }

        public IList<AuthenticationScheme> ExternalLogins { get; set; }

        public string ReturnUrl { get; set; }

        [TempData]
        public string ErrorMessage { get; set; }

        public class InputModel
        {

            [EmailAddress]
            public string Email { get; set; }

            [DataType(DataType.Password)]
            public string Password { get; set; }
        }

        public async Task OnGetAsync(string returnUrl = null)
        {
            if (!string.IsNullOrEmpty(ErrorMessage))
            {
                ModelState.AddModelError(string.Empty, ErrorMessage);
            }

            returnUrl ??= Url.Content("~/");

            // Clear the existing external cookie to ensure a clean login process
            await HttpContext.SignOutAsync(IdentityConstants.ExternalScheme);

            ReturnUrl = returnUrl;
        }

        public async Task<IActionResult> OnPostAsync(string returnUrl = null)
        {
            returnUrl ??= Url.Content("~/");

            if (ModelState.IsValid && !string.IsNullOrWhiteSpace(Input.Email) && !string.IsNullOrWhiteSpace(Input.Password))
            {
                // This doesn't count login failures towards account lockout
                // To enable password failures to trigger account lockout, set lockoutOnFailure: true
                Employee employeeToSignIn = new Employee { UserName = Input.Email };

                //  To check if an account is disabled. If it is that account may not sign in
                IEmployee employeeToValidate = (await _service.Employee.GetAllAsync()).SingleOrDefault(e => e.Username?.ToUpper() == employeeToSignIn.UserName.ToUpper());

                if (employeeToValidate != null && !employeeToValidate.Active)
                {
                    ModelState.AddModelError(string.Empty, "User is deactivated");

                    return Page();
                }

                var result = await _service.Employee.SignInAsync(employeeToSignIn.UserName, Input.Password, _lockoutOnFail: false);

                if (result.Succeeded)
                {
                    _logger.LogInformation("User logged in.");
                    return LocalRedirect(returnUrl);
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Invalid login attempt.");
                    return Page();
                }
            }

            // If we got this far, something failed, redisplay form
            return Page();
        }
    }
}

