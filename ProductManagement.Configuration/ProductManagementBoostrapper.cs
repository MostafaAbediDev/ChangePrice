using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using ProductManagement.Application;
using ProductManagement.Application.Contract;
using ProductManagement.Domain.ProductAgg;
using ProductManagement.Infrastructure.EFCore;
using ProductManagement.Infrastructure.EFCore.Repository;

namespace ProductManagement.Configuration
{
    public class ProductManagementBoostrapper
    {
        public static void Configure(IServiceCollection services, string connectionString)
        {
            services.AddTransient<IProductRepository, ProductRepository>();
            services.AddTransient<IProductApplication, ProductApplication>();

            services.AddDbContext<ProductContext>(x => x.UseSqlServer(connectionString));
        }
    }
}
