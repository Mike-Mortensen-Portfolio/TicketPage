using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SKP.TicketPage.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SKP.TicketPage.Web.Pages.DeveloperAccess
{
    [Authorize(Roles = RoleHelper.DEVELOPER)]
    public class LogOverviewModel : PageModel
    {
        public LogOverviewModel(IErrorLogger logger)
        {
            Logger = logger;
        }

        public IErrorLogger Logger { get; }
        public IReadOnlyList<ILogEntry> LogEntries { get; private set; }
        [BindProperty(SupportsGet = true)]
        public LogEntryFilterOptions FilterOptions { get; set; }
        public int PageSize { get; set; } = 5;
        public int CurrentPage { get; set; } = 0;
        public int PageCount { get; set; }

        public async Task OnGetAsync()
        {
            FilterOptions.LogDate = DateTime.Now.Date;
            LogEntries = await Logger.GetAllAsync();
            LogEntries = LogEntries
                .Where(l => l.LogDate.Date == DateTime.Now.Date)
                .OrderByDescending(l => l.LogDate)
                .ToList();
        }

        public async Task<IActionResult> OnPostFilterAsync(int currentPage)
        {
            CurrentPage = currentPage;

            LogEntries = (await Logger.FilterAsync(FilterOptions))
                .OrderByDescending(l => l.LogDate)
                .ToList();

            return Page();
        }
    }
}
