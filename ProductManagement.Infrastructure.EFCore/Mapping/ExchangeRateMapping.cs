using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProductManagement.Domain.ExchangeRateAgg;

namespace ProductManagement.Infrastructure.EFCore.Mapping
{
    public class ExchangeRateMapping : IEntityTypeConfiguration<ExchangeRate>
    {
        public void Configure(EntityTypeBuilder<ExchangeRate> builder)
        {
            builder.ToTable("ExchangeRates");
            builder.HasKey(x => x.Id);
        }
    }
}
