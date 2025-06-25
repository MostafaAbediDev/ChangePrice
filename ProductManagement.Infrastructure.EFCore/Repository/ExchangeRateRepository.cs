using _0_FrameWork.Infrastructure;
using ProductManagement.Application.Contract.ExchangeRate;
using ProductManagement.Domain.ExchangeRateAgg;

namespace ProductManagement.Infrastructure.EFCore.Repository
{
    public class ExchangeRateRepository : RepositoryBase<long, ExchangeRate>, IExchangeRateRepository
    {
        private readonly ProductContext _context;

        public ExchangeRateRepository(ProductContext context) : base(context)
        {
            _context = context;
        }

        public List<ExchangeRateViewModel> GetRate()
        {
            return _context.ExchangeRates.Select(x => new ExchangeRateViewModel
            {
                Id = x.Id,
                Usd = x.Usd,
                UsdChange = x.UsdChange,
                UsdDate = x.UsdDate.ToString(),
                Aed = x.Aed,
                AedChange = x.AedChange,
                AedDate = x.AedDate.ToString(),
                CreationDate = x.CreationDate.ToString()
            }).ToList();
        }
    }
}
