using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SPU911.Services;
using SPU911.Services.Mapper;
using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace SPU911.Controllers
{
    public class ImagesController : Controller
    {
        private readonly IImageService _imageService;
        private readonly IImageDALService _imageDALService;

        public ImagesController(IImageService imageService, IImageDALService imageDALService)
        {
            _imageService = imageService;
            _imageDALService = imageDALService;
        }

        public async Task<IActionResult> Index()
        {
            var list = (await _imageDALService.GetLIst())
                    .OrderByDescending(x => x.Id).Select(ImagesMapper.Create).ToList();
            return View(list);
        }

        [HttpPost]
        public async Task<IActionResult> Index(IFormFile file)
        {
            try
            {
                var fileName = await _imageService.Upload(file.FileName, file.OpenReadStream());
                var entity = await _imageDALService.Add(fileName);
                return RedirectToAction("Index");
            }
            catch (System.Exception ex)
            {

                throw;
            }
        }

        public async Task<IActionResult> Get(int id)
        {
            var image = await _imageDALService.Get(id);

            var url = new Uri(image.ImageUrl);
            string name = Path.GetFileName(url.AbsolutePath);

            var file = await _imageService.GetFile(name);

            return File(file.Bytes, file.ContentType);
        }
    }
}
