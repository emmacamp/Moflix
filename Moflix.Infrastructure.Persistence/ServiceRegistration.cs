using Moflix.Infrastructure.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Moflix.Core.Application.Interfaces.Repositories;
using Moflix.Infrastructure.Persistence.Context;


namespace Moflix.Infrastructure.Persistence
{

    //Extension Method - Decorator
    public static class ServiceRegistration
    {
        public static void AddPersistenceInfrastructure(this IServiceCollection services,IConfiguration configuration)
        {
            #region Contexts
            if (configuration.GetValue<bool>("UseInMemoryDatabase"))
            {
                services.AddDbContext<ApplicationContext>(options => options.UseInMemoryDatabase("ApplicationDb"));
            }
            else
            {
                services.AddDbContext<ApplicationContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"),
                m=> m.MigrationsAssembly(typeof(ApplicationContext).Assembly.FullName)));
            }
            #endregion

            #region Repositories
            services.AddTransient(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            services.AddTransient<IMoviesRepository, MoviesRepository>();
            services.AddTransient<ICategoryRepository, CategoryRepository>();  
            #endregion
        }
    }
}
