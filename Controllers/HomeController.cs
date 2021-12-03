using Microsoft.AspNetCore.Mvc;
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

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        /* /Home/Privacy */
        //public IActionResult Privacy()
        //{
        //    return View();
        //}

        /* /Home/Privacy/1 */
        public IActionResult Privacy(int id)
        {
            if (id == default)
            {
                return View();
            }
            return Ok(new { id = id});
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
