using Microsoft.AspNetCore.Mvc;
using SPU911.Services;
using SPU911.ViewModel;

namespace SPU911.Controllers
{
    public class ProductsController : Controller
    {
        private readonly ProductService _service;

        public ProductsController()
        {
            _service = new ProductService();
        }

        public IActionResult Index(int id)
        {
            var product = _service.GetProduct(id);

            if (product == null) return NotFound();

            var model = new ProductDetailsViewModel
            {
                Product = product,
                RelatedProducts = _service.GetProductsByType(product.ProductType)
            };

            return View(model);
        }
    }
}
