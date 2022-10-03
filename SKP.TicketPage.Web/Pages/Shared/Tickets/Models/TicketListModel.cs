using SKP.TicketPage.Services;
using System.Collections.Generic;

namespace SKP.TicketPage.Web.Pages.Shared.Tickets.Models
{
    public class TicketListModel
    {
        public string Header { get; set; } = null;
        public IReadOnlyList<ITicket> Tickets { get; set; }
        public bool HideSettings { get; set; } = false;
        public bool HideConditionals { get; set; } = false;
        public bool HideCreateButton { get; set; } = false;
        public string ReturnURL { get; set; } = null;
        public bool HideFilter { get; set; } = false;
        public string FilterHandler { get; set; } = "TicketFilter";
        public string FilterPropertyName { get; set; } = "FilterOptions";
        public TicketFilterOptions FilterOptions { get; set; }
        public bool UsePagination { get; set; } = true;
        public string CurrentPagePropertyName { get; set; } = "CurrentPage";
        public int PageSize { get; set; } = 10;
        public int CurrentPage { get; set; } = 0;
        public int PageCount { get; set; }
    }
}
