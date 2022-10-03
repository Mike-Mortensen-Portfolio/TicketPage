namespace SKP.TicketPage.Web.Pages.Shared.Misc.Models
{
    public class ConfirmationWindowModel
    {
        //  Window Settings
        public bool Hide { get; set; } = true;
        public bool IsWarning { get; set; } = false;
        public string WindowID { get; set; } = "popup";

        //  Values and visual settings
        public string Header { get; set; } = null;
        public string SubHeader { get; set; } = null;
        public string AcceptButtonText { get; set; } = "Bekræft";
        public string DeclineButtonText { get; set; } = "Fortryd";

        //  Data input settings
        public string DataInputID
        {
            get
            {
                return $"{char.ToLower(DataInputName[0])}{DataInputName[1..]}";
            }
        }
        public string DataInputName { get; set; } = "ConfirmPackage";

        //  Handler settings
        public bool AcceptUsingForm { get; set; } = true;
        public bool DeclineUsingForm { get; set; } = false;

        //  Client Handlers
        public string AcceptClientHandler { get; set; }
        public string DeclineClientHandler { get; set; }

        //  Server Handlers
        public string AcceptHandler { get; set; } = "Accept";
        public string DeclineHandler { get; set; } = "Decline";
    }
}
