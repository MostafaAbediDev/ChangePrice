using _02_ChangePriceQuery.Contract.Product;
using ProductManagement.Application.Contract.ExchangeRate;
using ProductManagement.Infrastructure.EFCore;

namespace _02_ChangePriceQuery.Query
{
    public class ProductQuery : IProductQuery
    {
        private readonly ProductContext _context;
        private readonly IExchangeRateService  _exchangeRateService;

        public ProductQuery(ProductContext context, IExchangeRateService exchangeRateService)
        {
            _context = context;
            _exchangeRateService = exchangeRateService;
        }

        public List<ProductQueryModel> GetProducts()
        {
            //_exchangeRateService.GetAndSaveExchangeRateAsync().GetAwaiter().GetResult();

            var exchangeRate = _exchangeRateService.GetRate().OrderByDescending(x => x.Id).FirstOrDefault();

            var products = _context.Products.Where(x => x.IsRemoved == false).ToList();

            var query = products.Select(x => new ProductQueryModel
            {
                Id = x.Id,
                Picture = x.Picture,
                PictureAlt = x.PictureAlt,
                PictureTitle = x.PictureTitle,
                Name = x.Name,
                UnitOfMeasurement = x.UnitOfMeasurement,
                DefaultCount = x.DefaultCount,
                PriceInIran = x.PriceInIran,
                UsdRate = exchangeRate.Usd,
                AedRate = exchangeRate.Aed
            }).ToList();

            return query;
        }

    }
}
