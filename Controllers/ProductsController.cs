using Microsoft.AspNetCore.Mvc;
using SPU911.Models;
using SPU911.Services;
using SPU911.Services.Mapper;
using SPU911.ViewModel;
using System.Linq;
using System.Threading.Tasks;

namespace SPU911.Controllers
{
    public class ProductsController : Controller
    {
        private readonly IProducControllerService _service;
        private readonly IImageDALService _imageService;

        public ProductsController(IProducControllerService service, IImageDALService imageService)
        {
            _service = service; // new ProductService()
            _imageService = imageService;
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

        public async Task<IActionResult> Create()
        {
            var imageList = (await _imageService.GetLIst()).Select(ImagesMapper.Create).ToList();
            ViewData["ImageList"] = imageList;

            return View(new ProductModel());
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromForm]ProductModel model)
        {
            var imageList = (await _imageService.GetLIst()).Select(ImagesMapper.Create).ToList();
            ViewData["ImageList"] = imageList;

            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var newProduct = _service.CreateOrUpdate(model);

            if (newProduct != null)
            {
                return RedirectToAction("Index", new { id = newProduct.Id });
            }

            return View(model);
        }

        public async Task<IActionResult> Edit(int id)
        {
            var product = _service.GetProduct(id);
            var imageList = (await _imageService.GetLIst()).Select(ImagesMapper.Create).ToList(); 
            ViewData["ImageList"] = imageList;
            if (product == null) return NotFound();

            return View(product);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, [FromForm] ProductModel model)
        {

            var imageList = (await _imageService.GetLIst()).Select(ImagesMapper.Create).ToList();
            ViewData["ImageList"] = imageList;

            if (!ModelState.IsValid)
            {
                return View(model);
            }

            if (model.ProductName.Length > 15)
            {
                ModelState.AddModelError(nameof(model.ProductName), "Занадто довга назва продукту");
            }

            if (model.Price < 0)
            {
                ModelState.AddModelError(nameof(model.Price), "Ціна повинна бути більша 0");
            }

            if (!ModelState.IsValid)
            {
                ModelState.AddModelError("", "Перевірте правильність внесених даних");

                return View(model);
            }

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

        public ActionResult DeleteAjax(int id)
        {
            var product = _service.GetProduct(id);

            if (product == null) return NotFound();

            return PartialView(product);
        }

    }
}
