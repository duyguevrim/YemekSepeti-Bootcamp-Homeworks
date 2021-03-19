

using GenericRepo.Data.Repositories.Derived;
using GenericRepo.Data.Repositories.Interface;
using GenericRepo.Services.Interfaces;
using GenericRepo.Services.Services;
using Microsoft.Extensions.DependencyInjection;

namespace GenericRepo.DI.Extensions
{
    public static class ServicesConfigurationExtensions
    {
        public static void AddProjectRepositories(this IServiceCollection services)
        {
            services.AddScoped<IProductRepository, ProductRepository>();
        }

        public static void AddProjectServices(this IServiceCollection services)
        {
            services.AddTransient<IProductService, ProductService>();
        }
    }
}