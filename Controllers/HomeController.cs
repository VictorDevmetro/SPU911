using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Logging;
using SPU911.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace SPU911.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public override void OnActionExecuting(ActionExecutingContext context)
        {
            ViewData["List"] = new List<string> { "first", "second", "third" };
            base.OnActionExecuting(context);
        }

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            ViewData["Title"] = "Custom title";
            ViewData["Number"] = 1;

            ViewBag.BagTitle = "Bag title";

            var model = new HomeIndexImageModel
            {
                ImageUrl = "https://simple-fauna.ru/wp-content/uploads/2016/11/tukan-ptica_5.jpg",
                ImageAltText = "Alternative text",
                H = 150,
                W = 240,
                KByte = 12.5M
            };
            return View(model); 
        }

        /* /Home/Privacy */
        //public IActionResult Privacy()
        //{
        //    return View();
        //}

        /* /Home/Privacy/1 */
        public IActionResult Privacy(string id)
        {
            if (id == default)
            {
                return View();
            }
            ViewData["Number"] = id;
            return View("PrivacyNumber");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
