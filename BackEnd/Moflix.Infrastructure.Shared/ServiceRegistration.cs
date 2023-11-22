using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Moflix.Core.Application.Interfaces.Services;
using Moflix.Core.Domain.Settings;
using Moflix.Infrastructure.Shared.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Moflix.Infrastructure.Shared
{
    public static class ServiceRegistration
    {  
        public static void AddSharedInfrastructure(this IServiceCollection services, IConfiguration _config)
        {
            services.Configure<MailSettings>(_config.GetSection("MailSettings"));         
            services.AddTransient<IEmailService, EmailService>();
        }
    }
}
