using Microsoft.Extensions.DependencyInjection;
using ProiectBackendPetcuMircea.DAL.Services.OrderServices;
using ProiectV1.Helpers.JwtUtils;
using ProiectV1.Helpers.Seeders;
using ProiectV1.Repositories.DeliveryAdressRepository;
using ProiectV1.Repositories.OrderRepository;
using ProiectV1.Repositories.ProductRepository;
using ProiectV1.Repositories.PromotionRepository;
using ProiectV1.Repositories.UserRepository;
using ProiectV1.Services.DeliveryAdressServices;
using ProiectV1.Services.OrderServices;
using ProiectV1.Services.ProductServices;
using ProiectV1.Services.UserServices;

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
            services.AddTransient<IDeliveryAdressRepository,DeliveryAdressRepository>();


            return services;
        }

        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            services.AddTransient<IProductService, ProductService>();
            //services.AddTransient<IPromotionRepository, PromotionRepository>();
            //services.AddTransient<IOrderRepository, OrderRepository>();
            //services.AddTransient<I>
            services.AddTransient<IUserService, UserService>();
            services.AddTransient<IOrderService, OrderService>();
            services.AddTransient<IDeliveryAdressService,DeliveryAdressService>();


            return services;
        }

        public static IServiceCollection AddSeeders(this IServiceCollection services)
        {
            services.AddScoped<ProductSeeder>();
            services.AddScoped<OrderSeeder>();
            return services;
        }

        public static IServiceCollection AddUtils(this IServiceCollection services)
        {
            services.AddScoped<IJwtUtils, JwtUtilsC>();
            return services;
        }
    }
}
