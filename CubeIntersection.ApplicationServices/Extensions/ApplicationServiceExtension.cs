using CubeIntersection.ApplicationServices.Cubes;
using CubeIntersection.ApplicationServices.Mappers;
using CubeIntersection.Domain.Entities.Cubes;
using CubeIntersection.Infrastructure.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace CubeIntersection.ApplicationServices.Extensions
{
    /// <summary>
    /// The application service extension class.
    /// </summary>
    public static class ApplicationServiceExtension
    {
        /// <summary>
        /// Adds the application services.
        /// </summary>
        /// <param name="services">The services.</param>
        /// <returns></returns>
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddScoped<ICubeService, CubeService>();
            services.AddScoped<IMapper<Cube, CubeDto>, CubeToCubeDto>();
            return services;
        }
        /// <summary>
        /// Adds the infraestructure.
        /// </summary>
        /// <param name="services">The services.</param>
        /// <returns></returns>
        public static IServiceCollection AddInfraestructure(this IServiceCollection services)
        {
            services.AddScoped<ICubeRepository, CubeRepository>();
            return services;
        }
    }
}