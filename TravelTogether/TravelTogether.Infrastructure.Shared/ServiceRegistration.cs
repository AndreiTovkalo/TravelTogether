using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TravelTogether.Application.Interfaces;
using TravelTogether.Domain.Entities;
using TravelTogether.Domain.Settings;
using TravelTogether.Infrastructure.Shared.Services;

namespace TravelTogether.Infrastructure.Shared
{
    public static class ServiceRegistration
    {
        public static void AddSharedInfrastructure(this IServiceCollection services, IConfiguration _config)
        {
            services.Configure<MailSettings>(_config.GetSection("MailSettings"));
            services.AddTransient<IDateTimeService, DateTimeService>();
            services.AddTransient<IEmailService, EmailService>();
            services.AddTransient<IMockService, MockService>();
            services.AddScoped<IUserService, UserService>();
        }
    }
}