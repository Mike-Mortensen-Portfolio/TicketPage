using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using SKP.TicketPage.Domain.Entities;
using SKP.TicketPage.Services;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace SKP.TicketPage.Web.Areas.Identity.Pages.Account
{
    [AllowAnonymous]
    public class ExternalLoginModel : PageModel
    {
        public ExternalLoginModel(ITicketPageService service, SignInManager<Employee> signInManager, UserManager<Employee> userManager, IErrorLogger logger, RoleManager<Role> roleManager, IConfiguration config)
        {
            Service = service;

            _signInManager = signInManager;
            _userManager = userManager;
            _logger = logger;
            _roleManager = roleManager;
            _adminGroups = config.GetSection("SSOSettings:Instructor-Groups").Get<IEnumerable<string>>();
            _developerGroups = config.GetSection("SSOSettings:Developer-Groups").Get<IEnumerable<string>>();
        }

        private readonly SignInManager<Employee> _signInManager;
        private readonly UserManager<Employee> _userManager;
        private readonly IErrorLogger _logger;
        private readonly RoleManager<Role> _roleManager;
        private readonly IEnumerable<string> _adminGroups;
        private readonly IEnumerable<string> _developerGroups;

        [BindProperty]
        public InputModel Input { get; set; }

        public ITicketPageService Service { get; }

        public string ProviderDisplayName { get; set; }

        public string ReturnUrl { get; set; }

        [TempData]
        public string ErrorMessage { get; set; }

        public class InputModel
        {

            [EmailAddress(ErrorMessage = " skal være en rigtig email!")]
            [Required(ErrorMessage = " må ikke være tom!")] public string Email { get; set; }

            [MaxLength(25)]
            [Required(ErrorMessage = " må ikke være tom!")] public string FirstName { get; set; }

            [MaxLength(25)]
            [Required(ErrorMessage = " må ikke være tom!")] public string LastName { get; set; }
            [Range(0, int.MaxValue, ErrorMessage = " skal vælges!")]
            public int DepartmentID { get; set; }
        }

        public IActionResult OnGetAsync()
        {
            return RedirectToPage("./Login");
        }

        public IActionResult OnPost(string provider, string returnUrl = null)
        {
            // Request a redirect to the external login provider.
            var redirectUrl = Url.Page("./ExternalLogin", pageHandler: "Callback", values: new { returnUrl });
            var properties = _signInManager.ConfigureExternalAuthenticationProperties(provider, redirectUrl);
            return new ChallengeResult(provider, properties);
        }

        public async Task<IActionResult> OnGetCallbackAsync(string returnUrl = null, string remoteError = null)
        {
            returnUrl ??= Url.Content("~/");
            if (remoteError != null)
            {
                ErrorMessage = $"Error from external provider: {remoteError}";
                return RedirectToPage("./Login", new { ReturnUrl = returnUrl });
            }
            var info = await _signInManager.GetExternalLoginInfoAsync();
            if (info == null)
            {
                ErrorMessage = "Error loading external login information.";
                return RedirectToPage("./Login", new { ReturnUrl = returnUrl });
            }


            //  Check if an account is disabled. If it is that account may not sign in
            IEmployee employeeToValidate = (await Service.Employee.GetAllAsync()).SingleOrDefault(e => e.Email == info.Principal.GetEmail());

            if (employeeToValidate != null && !employeeToValidate.Active)
            {
                await _logger.LogWarningAsync($"Attempted sign in by deactivated user: {employeeToValidate.Username}");
                //ErrorMessage = "Brugeren er deaktiveret";
                //return RedirectToPage("./Login", new { ReturnUrl = returnUrl });

                return Redirect("https://adfs.pcsyd.dk/adfs/ls/?wa=wsignout1.0");
            }

            // Sign in the user with this external login provider if the user already has a login.
            var result = await _signInManager.ExternalLoginSignInAsync(info.LoginProvider, info.ProviderKey, isPersistent: false, bypassTwoFactor: true);
            if (result.Succeeded)
            {
                await _logger.LogInfoAsync($"{GetUniLogin(info.Principal)} logged in with {info.LoginProvider} provider.");

                await AutoAssignRoleAsync(info.Principal);

                return LocalRedirect(returnUrl);
            }
            if (result.IsLockedOut)
            {
                return RedirectToPage("./Lockout");
            }
            else
            {
                // If the user does not have an account, then ask the user to create an account.
                ReturnUrl = returnUrl;
                ProviderDisplayName = info.ProviderDisplayName;
                if (info.Principal.HasClaim(c => c.Type == ClaimTypes.Email))
                {
                    Input = new InputModel
                    {
                        Email = info.Principal.FindFirstValue(ClaimTypes.Email),
                        FirstName = info.Principal.FindFirstValue(ClaimTypes.GivenName),
                        LastName = info.Principal.FindFirstValue(ClaimTypes.Surname)
                    };
                }
                return Page();
            }
        }

        public async Task<IActionResult> OnPostConfirmationAsync(string returnUrl = null)
        {
            returnUrl ??= Url.Content("~/");
            // Get the information about the user from the external login provider
            var info = await _signInManager.GetExternalLoginInfoAsync();
            if (info == null)
            {
                ErrorMessage = "Error loading external login information during confirmation.";
                return RedirectToPage("./Login", new { ReturnUrl = returnUrl });
            }

            if (ModelState.IsValid)
            {
                /*
                    The reason for this check and process below is because of the mapping tool, as users from the old DB (Opgaveside v2)
                    aren't completely compatible with the new DB user (Opgaveside v3).
                    
                    In order for the mapping tool to work as intended old users need to be imported,
                    which means that the first time users log in they might already exist in DB (Opgaveside v3).
                    
                    So I check if they do exist and then update the existing (mapped) user and assign the external login info to that user
                    instead of creating a new one.
                 */
                string normEmail = new UpperInvariantLookupNormalizer().NormalizeEmail(Input.Email);
                Employee userConfirm = _userManager.Users.SingleOrDefault(e => e.NormalizedEmail == normEmail);
                IdentityResult result = null;

                if (userConfirm != null)
                {
                    userConfirm.FirstName = Input.FirstName;
                    userConfirm.LastName = Input.LastName;
                    userConfirm.DepartmentID = Input.DepartmentID;
                    result = await _userManager.UpdateAsync(userConfirm);
                    await _logger.LogInfoAsync($"Mapped: {userConfirm.UserName}");
                }
                else
                {
                    userConfirm = new Employee { UserName = Input.Email, Email = Input.Email, FirstName = Input.FirstName, LastName = Input.LastName, DepartmentID = Input.DepartmentID, Active = true };
                    result = await _userManager.CreateAsync(userConfirm);
                }

                if (result.Succeeded)
                {
                    result = await _userManager.AddLoginAsync(userConfirm, info);
                    if (result.Succeeded)
                    {
                        await _logger.LogInfoAsync($"{GetUniLogin(info.Principal)} registered an account using {info.LoginProvider} provider.");

                        var userId = await _userManager.GetUserIdAsync(userConfirm);
                        var user = await _userManager.FindByIdAsync(userId);
                        var code = await _userManager.GenerateEmailConfirmationTokenAsync(userConfirm);
                        await _userManager.ConfirmEmailAsync(user, code);

                        await AutoAssignRoleAsync(info.Principal);

                        await _signInManager.SignInAsync(userConfirm, isPersistent: false, info.LoginProvider);

                        return LocalRedirect(returnUrl);
                    }
                }

                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
            }

            ProviderDisplayName = info.ProviderDisplayName;
            ReturnUrl = returnUrl;
            return Page();
        }

        private async Task EnsureRoleExistsAsync(string role, string displayName, string description = "Auto Created")
        {
            if (!await _roleManager.RoleExistsAsync(role))
            {
                await _roleManager.CreateAsync(new Role { Name = role, DisplayName = displayName, Description = description });
            }
        }
        private bool IsInInstuctorGroup(ClaimsPrincipal user)
        {
            return user.Claims.Where(c => c.Type.Contains("Group")).Any(c => _adminGroups.Contains(c.Value));
        }

        private bool IsInDeveloperGroup(ClaimsPrincipal user)
        {
            return user.Claims.Where(c => c.Type.Contains("Group")).Any(c => _developerGroups.Contains(c.Value));
        }

        private async Task AutoAssignRoleAsync(ClaimsPrincipal claim)
        {
            var employee = await _userManager.FindByEmailAsync(claim.GetEmail());

            if (await employee.HasRole()) { return; }

            if (IsInDeveloperGroup(claim))
            {
                await EnsureRoleExistsAsync(RoleHelper.DEVELOPER, "Udvikler");
                Employee user = await _userManager.FindByNameAsync(claim.FindFirstValue(ClaimTypes.Email));
                await _userManager.AddToRoleAsync(user, RoleHelper.DEVELOPER);
            }
            else if (IsInInstuctorGroup(claim))
            {
                await EnsureRoleExistsAsync(RoleHelper.INSTRUCTOR, "Instruktør");
                Employee user = await _userManager.FindByNameAsync(claim.FindFirstValue(ClaimTypes.Email));
                await _userManager.AddToRoleAsync(user, RoleHelper.INSTRUCTOR);
            }
            else
            {
                await EnsureRoleExistsAsync(RoleHelper.BASE, "Normal");
                Employee user = await _userManager.FindByNameAsync(claim.FindFirstValue(ClaimTypes.Email));
                await _userManager.AddToRoleAsync(user, RoleHelper.BASE);
            }
        }

        private string GetUniLogin(ClaimsPrincipal user)
        {
            return user.FindFirstValue(ClaimTypes.WindowsAccountName);
        }
    }
}
