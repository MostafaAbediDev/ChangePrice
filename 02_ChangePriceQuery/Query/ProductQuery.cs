using _02_ChangePriceQuery.Contract.Product;
using ProductManagement.Infrastructure.EFCore;

namespace _02_ChangePriceQuery.Query
{
    public class ProductQuery : IProductQuery
    {
        private readonly ProductContext _context;

        public ProductQuery(ProductContext context)
        {
            _context = context;
        }

        public List<ProductQueryModel> GetProducts()
        {
            return _context.Products.Select(x=>new ProductQueryModel
            {
                Id = x.Id,
                Picture = x.Picture,
                PictureAlt = x.PictureAlt,
                PictureTitle = x.PictureTitle,
                Name = x.Name,
                UnitOfMeasurement = x.UnitOfMeasurement,
                PriceInIran = x.PriceInIran,
            }).ToList();
        }
    }
}
