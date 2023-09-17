using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TravelTogether.Application.Interfaces;
using TravelTogether.Application.Interfaces.Repositories;
using TravelTogether.Domain.Entities;
using TravelTogether.Infrastructure.Persistence.Contexts;
using TravelTogether.Infrastructure.Persistence.Repositories;
using TravelTogether.Infrastructure.Persistence.Repositories;


namespace TravelTogether.Infrastructure.Persistence
{
    public static class ServiceRegistration
    {
        public static void AddPersistenceInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {


            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseMySql("server=127.0.0.1;uid=root;pwd=root;database=travel_together;port=8889",
                    new MySqlServerVersion(new Version(5, 7, 39))));

            services.AddTransient(typeof(IGenericRepositoryAsync<>), typeof(GenericRepositoryAsync<>));
            // services.AddTransient<IPositionRepositoryAsync, PositionRepositoryAsync>();
            // services.AddTransient<IEmployeeRepositoryAsync, EmployeeRepositoryAsync>();
            services.AddScoped<IUserRepository, UserRepository>();

        }
    }
}