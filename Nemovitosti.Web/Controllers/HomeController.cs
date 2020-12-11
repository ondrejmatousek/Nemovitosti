using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Nemovitosti.ServiceLayer.Interface;
using Nemovitosti.Web.Models;
using System.Diagnostics;

namespace Nemovitosti.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IBytService bytService;

        public HomeController(ILogger<HomeController> logger, IBytService bytService)
        {
            _logger = logger;
            this.bytService = bytService;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
