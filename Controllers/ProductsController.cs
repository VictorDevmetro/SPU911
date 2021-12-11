using Microsoft.AspNetCore.Mvc;
using SPU911.Services;
using SPU911.ViewModel;
using System.Linq;

namespace SPU911.Controllers
{
    public class ProductsController : Controller
    {
        private readonly IProducControllerService _service;

        public ProductsController(IProducControllerService service)
        {
            _service = service; // new ProductService()
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
