using _02_ChangePriceQuery.Contract.Product;
using _02_ChangePriceQuery.Query;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using ProductManagement.Application;
using ProductManagement.Application.Contract.ExchangeRate;
using ProductManagement.Application.Contract.Products;
using ProductManagement.Domain.ExchangeRateAgg;
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

            services.AddTransient<IExchangeRateRepository, ExchangeRateRepository>();
            services.AddTransient<IExchangeRateService, ExchangeRateService>();

            services.AddTransient<IProductQuery, ProductQuery>();

            services.AddDbContext<ProductContext>(x => x.UseSqlServer(connectionString));
        }
    }
}
