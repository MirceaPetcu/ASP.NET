using Microsoft.Extensions.DependencyInjection;
using ProiectV1.Helpers.JwtUtils;
using ProiectV1.Helpers.Seeders;
using ProiectV1.Repositories.OrderRepository;
using ProiectV1.Repositories.ProductRepository;
using ProiectV1.Repositories.PromotionRepository;
using ProiectV1.Repositories.UserRepository;
using ProiectV1.Services.ProductServices;

namespace ProiectV1.Helpers.Extensions
{
    public static class ServiceExtension
    {
        public static IServiceCollection AddRepositories(this IServiceCollection services)
        {
            services.AddTransient<IProductRepository,ProductRepository>();
            services.AddTransient<IPromotionRepository,PromotionRepository>();
            services.AddTransient<IOrderRepository, OrderRepository>();
            services.AddTransient<IUserRepository, UserRepository>();

            return services;
        }

        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            services.AddTransient<IProductService, ProductService>();
            //services.AddTransient<IPromotionRepository, PromotionRepository>();
            //services.AddTransient<IOrderRepository, OrderRepository>();
            //services.AddTransient<I>

            return services;
        }

        public static IServiceCollection AddSeeders(this IServiceCollection services)
        {
            services.AddScoped<ProductSeeder>();
            return services;
        }

        public static IServiceCollection AddUtils(this IServiceCollection services)
        {
            services.AddScoped<IJwtUtils, JwtUtilsC>();
            return services;
        }
    }
}
