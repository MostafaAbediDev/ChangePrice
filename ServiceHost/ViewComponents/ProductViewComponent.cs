using _02_ChangePriceQuery.Contract.Product;
using Microsoft.AspNetCore.Mvc;
using ProductManagement.Application.Contract.ExchangeRate;

namespace ServiceHost.ViewComponents
{
    public class ProductViewComponent : ViewComponent
    {
        private readonly IProductQuery _productQuery;

        public ProductViewComponent(IProductQuery productQuery)
        {
            _productQuery = productQuery;
        }

        public IViewComponentResult Invoke()
        {
            var products = _productQuery.GetProducts();
            return View(products);
        }
    }
}

