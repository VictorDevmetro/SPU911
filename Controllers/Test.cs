using Microsoft.AspNetCore.Mvc;

namespace SPU911.Controllers
{
    [Route("admin/{controller}")]
    public class TestController : Controller
    {
        [Route("v1/index")]
        public IActionResult Index(string article = "")
        {
            return Ok($"Test index {article}");
//            return View();
        }

        [Route("v2/index")]
        public IActionResult Index2(string article = "")
        {
            return Ok($"Test index {article}");
            //            return View();
        }

        public IActionResult Index()
        {
            return Ok($"Test index");
            //            return View();
        }

    }
}
