using _0_Framework.Application;
using _0_FrameWork.Application;
using ProductManagement.Application.Contract;
using ProductManagement.Domain.ProductAgg;

namespace ProductManagement.Application
{
    public class ProductApplication : IProductApplication
    {
        private readonly IFileUploader _fileUploader;
        private readonly IProductRepository _productRepository;

        public ProductApplication(IFileUploader fileUploader, IProductRepository productRepository)
        {
            _fileUploader = fileUploader;
            _productRepository = productRepository;
        }

        public OperationResult Create(CreateProduct command)
        {
            var operation = new OperationResult();
            if (_productRepository.Exists(x => x.Name == command.Name))
                return operation.Failed(ApplicationMessages.DuplicatedRecord);

            var picturePath = "ProductPicture";
            var fileName = _fileUploader.Upload(command.Picture, picturePath);

            var product = new Product(fileName, command.PictureAlt, command.PictureTitle, 
                command.Name, command.UnitOfMeasurement, command.PriceInIran);

            _productRepository.Create(product);
            _productRepository.SaveChanges();

            return operation.Succedded();
        }

        public OperationResult Edit(EditProduct command)
        {
            var operation = new OperationResult();
            var product = _productRepository.Get(command.Id);
            if (product == null)
                return operation.Failed(ApplicationMessages.RecordNotFound);


            if (_productRepository.Exists(x => x.Name == command.Name && x.Id != command.Id))
                return operation.Failed(ApplicationMessages.DuplicatedRecord);

            var picturePath = "ProductPicture";
            var fileName = _fileUploader.Upload(command.Picture, picturePath);

            product.Edit(fileName, command.PictureAlt, command.PictureTitle, command.Name, command.UnitOfMeasurement, command.PriceInIran);

            _productRepository.SaveChanges();
            return operation.Succedded();
        }

        public EditProduct GetDetails(long id)
        {
            return _productRepository.GetDetails(id);
        }

        public List<ProductViewModel> GetProducts()
        {
            return _productRepository.GetProducts();
        }

        public List<ProductViewModel> Search(ProductSearchModel searchModel)
        {
            return _productRepository.Search(searchModel);
        }
    }
}
