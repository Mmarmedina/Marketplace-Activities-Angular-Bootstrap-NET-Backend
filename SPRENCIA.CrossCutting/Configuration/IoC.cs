using Microsoft.Extensions.DependencyInjection;
using SPRENCIA.Application.Contracts.Services;
using SPRENCIA.Application.Services;
using SPRENCIA.Infraestructure;
using SPRENCIA.Infraestructure.Contracts;
using SPRENCIA.Infraestructure.Repositories;

namespace SPRENCIA.CrossCutting.Configuration
{
    public static class IoC
    {
        public static IServiceCollection Register(this IServiceCollection services)
        {
            AddRepositories(services);
            AddServices(services);
            AddDbContext(services);

            return services;    
        }

        public static IServiceCollection AddDbContext(this IServiceCollection services)
        {
            services.AddTransient<SprenciaDbContext>();
            return services;
        }

        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            services.AddTransient<IActivityService, ActivityService>();
            services.AddTransient<IReviewService, ReviewService>();

            return services;    
        }

        public static IServiceCollection AddRepositories(this IServiceCollection services)
        {
            services.AddTransient<IActivityRepository, ActivityRepository>();
            services.AddTransient<IActivityScheduleRepository, ActivityScheduleRepository>();
            services.AddTransient<IReviewRepository, ReviewRepository>();
            
            return services;
        }
    }
}
