using Microsoft.AspNetCore.Mvc;
using SPU911.Models;
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

        public IActionResult Create()
        {
            return View(new ProductModel());
        }

        [HttpPost]
        public IActionResult Create([FromForm]ProductModel model)
        {
            var newProduct = _service.CreateOrUpdate(model);

            if (newProduct != null)
            {
                return RedirectToAction("Index", new { id = newProduct.Id });
            }

            return View(model);
        }

        public IActionResult Edit(int id)
        {
            var product = _service.GetProduct(id);

            if (product == null) return NotFound();

            return View(product);
        }

        [HttpPost]
        public IActionResult Edit(int id, [FromForm] ProductModel model)
        {
            var newProduct = _service.CreateOrUpdate(model);

            if (newProduct != null)
            {
                return RedirectToAction("Index", new { id });
            }

            return View(model);
        }

        public ActionResult Delete(int id)
        {
            var product = _service.GetProduct(id);

            if (product == null) return NotFound();

            return View(product);
        }

        // POST: CRUDController/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, ProductModel model)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
