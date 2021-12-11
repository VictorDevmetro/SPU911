using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Logging;
using SPU911.Models;
using SPU911.Services;
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
        private readonly ProductService _service;

        public override void OnActionExecuting(ActionExecutingContext context)
        {
            ViewData["List"] = new List<string> { "first", "second", "third" };
            base.OnActionExecuting(context);
        }

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
            _service = new ProductService();
        }

        public IActionResult Index()
        {
            ViewData["Title"] = "Custom title";
            ViewData["Number"] = 1;

            ViewBag.BagTitle = "Bag title";

            var model = _service.GetAllProducts();

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
