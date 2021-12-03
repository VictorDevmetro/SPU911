using Microsoft.AspNetCore.Mvc;

namespace SPU911.Controllers
{
    public class StoreController : Controller
    {
        public enum DemoEnum
        {
            empty = 0,
            first,
            second
        }


        public IActionResult Index(int id, string q, DemoEnum d, int? a = null)
        {
            var _id = Request.Query["id"].ToString();

            // Strore/Index
            //return Ok("success");

            return View();
        }
    }
}
