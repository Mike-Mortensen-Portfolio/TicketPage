using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SKP.TicketPage.Services
{
    public static class ServiceCollectionExtensions
    {
        /// <summary>
        /// Registrers an <see cref="IErrorLogger"/> as a <strong>scoped</strong> entry in the service collection
        /// </summary>
        /// <param name="services"></param>
        public static void RegisterLogger(this IServiceCollection services)
        {
            services.AddScoped<IErrorLogger, ErrorLogger>();
        }
    }
}
