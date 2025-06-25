using _0_FrameWork.Infrastructure;
using ProductManagement.Application.Contract.Products;
using ProductManagement.Domain.ProductAgg;

namespace ProductManagement.Infrastructure.EFCore.Repository
{
    public class ProductRepository : RepositoryBase<long, Product>, IProductRepository
    {
        private readonly ProductContext _context;

        public ProductRepository(ProductContext context) : base(context)
        {
            _context = context;
        }

        public EditProduct GetDetails(long id)
        {
            return _context.Products.Select(x => new EditProduct
            {
                Id = x.Id,
                Name = x.Name,
                PictureAlt = x.PictureAlt,
                PictureTitle = x.PictureTitle,
                UnitOfMeasurement = x.UnitOfMeasurement,
                PriceInIran = x.PriceInIran,
                DefaultCount = x.DefaultCount

            }).FirstOrDefault(x => x.Id == id);
        }

        public List<ProductViewModel> GetProducts()
        {
            return _context.Products.Select(x => new ProductViewModel
            {
                Id = x.Id,
                Name = x.Name,
                Picture = x.Picture,
                UnitOfMeasurement = x.UnitOfMeasurement,
                PriceInIran = x.PriceInIran,
                DefaultCount = x.DefaultCount
            }).ToList();
        }

        public List<ProductViewModel> Search(ProductSearchModel searchModel)
        {
            var query = _context.Products.Select(x => new ProductViewModel
            {
                Id = x.Id,
                Name = x.Name,
                Picture = x.Picture,
                PriceInIran = x.PriceInIran,
                UnitOfMeasurement = x.UnitOfMeasurement,
                DefaultCount = x.DefaultCount,
                CreationDate = x.CreationDate.ToString()
            });

            if (!string.IsNullOrWhiteSpace(searchModel.Name))
                query = query.Where(x => x.Name.Contains(searchModel.Name));

            if (!string.IsNullOrWhiteSpace(searchModel.UnitOfMeasurement))
                query = query.Where(x => x.UnitOfMeasurement.Contains(searchModel.UnitOfMeasurement));

            return query.OrderByDescending(x => x.Id).ToList();
        }
    }
}
