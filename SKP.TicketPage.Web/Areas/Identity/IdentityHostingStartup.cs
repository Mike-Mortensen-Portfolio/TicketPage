using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using SKP.TicketPage.Domain;

[assembly: HostingStartup(typeof(SKP.TicketPage.Web.Areas.Identity.IdentityHostingStartup))]

namespace SKP.TicketPage.Web.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) =>
            {
                services.AddDbContext<TicketPageContext>();
            });
        }
    }
}