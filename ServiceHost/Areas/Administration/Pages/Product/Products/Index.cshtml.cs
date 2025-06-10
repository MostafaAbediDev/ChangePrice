using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ProductManagement.Application.Contract;

namespace ServiceHost.Areas.Administration.Pages.Product.Products
{
    public class IndexModel : PageModel
    {

        public ProductSearchModel SearchModel;
        public List<ProductViewModel> Products;

        private readonly IProductApplication _productApplication;

        public IndexModel(IProductApplication productApplication)
        {
            _productApplication = productApplication;
        }

        public void OnGet(ProductSearchModel searchModel)
        {
            Products = _productApplication.Search(searchModel);

        }

        public IActionResult OnGetCreate()
        {
            var command = new CreateProduct
            {
            };
            return Partial("./Create", command);
        }

        public JsonResult OnPostCreate(CreateProduct command)
        {
            var result = _productApplication.Create(command);
            return new JsonResult(result);
        }

        public IActionResult OnGetEdit(long id)
        {
            var product = _productApplication.GetDetails(id);
            return Partial("Edit", product);
        }

        public JsonResult OnPostEdit(EditProduct command)
        {
            var result = _productApplication.Edit(command);
            return new JsonResult(result);
        }
    }
}
