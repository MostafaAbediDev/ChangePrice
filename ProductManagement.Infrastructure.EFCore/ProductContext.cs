using Microsoft.EntityFrameworkCore;
using ProductManagement.Domain.ExchangeRateAgg;
using ProductManagement.Domain.ProductAgg;
using ProductManagement.Infrastructure.EFCore.Mapping;

namespace ProductManagement.Infrastructure.EFCore
{
    public class ProductContext : DbContext
    {
        public DbSet<Product> Products { get; set; }
        public DbSet<ExchangeRate> ExchangeRates { get; set; }

        public ProductContext(DbContextOptions<ProductContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var assembly = typeof(ProductMapping).Assembly;
            modelBuilder.ApplyConfigurationsFromAssembly(assembly);

            base.OnModelCreating(modelBuilder);
        }
    }
}
