using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SKP.TicketPage.Services;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SKP.TicketPage.Web.Pages
{
    [AllowAnonymous]
    public class MonitorModel : PageModel
    {
        public MonitorModel(ITicketPageService service)
        {
            Service = service;
        }

        public ITicketPageService Service { get; set; }
        [BindProperty(SupportsGet = true)]
        public InputModel Settings { get; set; }
        public string Title { get; private set; } = "Monitor";

        public async Task<IActionResult> OnGetAsync(string setting, string value)
        {
            IDepartment department;

            switch (setting.ToLower())
            {
                case "all": //  Setting for showing all departments with a 4 pr. page
                    Settings.ShowAll = true;

                    if (int.TryParse(value, out int _index))
                    {
                        Settings.Index = _index;
                        Title = $"Alle [{Settings.Index}]";
                    }
                    else
                    {
                        return Redirect($"/Monitor/All/0");
                    }
                    break;
                case "id":  //  Only display the department with the given ID
                    Settings.ShowAll = false;
                    if (int.TryParse(value, out int _id))
                    {
                        department = (await Service.Department.GetByIDAsync(_id));
                        if (department != null)
                        {
                            Title = department.Name;
                        }

                        Settings.Index = _id;
                    }
                    break;
                case "prefix":  //  Only display the department with the given prefix
                    Settings.ShowAll = false;

                    if (string.IsNullOrWhiteSpace(value) || value == "0")
                    {
                        department = (await Service.Department.GetAllAsync()).FirstOrDefault();
                    }
                    else
                    {
                        department = (await Service.Department.GetAllAsync()).FirstOrDefault(d => d.Prefix.ToLower() == value.ToLower());
                    }

                    if (department != null)
                    {
                        Title = department.Name;
                        Settings.DepartmentID = department.ID;
                        break;
                    }

                    Settings.DepartmentID = -1;
                    break;
                default:
                    if (int.TryParse(setting, out int _setting))
                    {
                        return Redirect($"/Monitor/All/{_setting}");
                    }

                    return Redirect($"/Monitor/All/0");
            }

            return Page();
        }

        public class InputModel
        {
            public bool ShowAll { get; set; }
            public int DepartmentID { get; set; } = 1;
            public int Index { get; set; } = 0;
        }
    }
}