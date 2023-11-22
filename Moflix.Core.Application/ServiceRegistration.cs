using Microsoft.Extensions.DependencyInjection;
using Moflix.Core.Application.Interfaces.Services;
using Moflix.Core.Application.Services;
using System.Reflection;

namespace Moflix.Core.Application
{
    public static class ServiceRegistration
    {
        //Extension Method - Decorator
        public static void AddApplicationLayer(this IServiceCollection services)
        {
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));

            #region Services

            services.AddTransient(typeof(IGenericService<,,>), typeof(GenericService<,,>));
            services.AddTransient<IMoviesService, MovieService>();
            services.AddTransient<ICategoryService, CategoryService>();
            services.AddTransient<IUserService, UserService>();

            #endregion Services
        }
    }
}