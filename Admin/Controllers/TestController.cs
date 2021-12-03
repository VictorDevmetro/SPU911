using Microsoft.AspNetCore.Mvc;

namespace SPU911.Admin.Controllers
{
    public class TestController : Controller
    {
        public IActionResult Test(string id)
        {
            return Ok($"Admin Test {id}");
        }
    }
}
