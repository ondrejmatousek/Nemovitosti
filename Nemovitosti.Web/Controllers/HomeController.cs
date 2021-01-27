using Microsoft.AspNetCore.Mvc;
using Nemovitosti.ServiceLayer.Interface;
using Nemovitosti.Web.Mappers;
using Nemovitosti.Web.Models;
using System.Diagnostics;

namespace Nemovitosti.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly IBytService bytService;
        private readonly IMapperWeb autoMapper;

        public HomeController(IBytService bytService, IMapperWeb autoMapper)
        {
            this.bytService = bytService;
            this.autoMapper = autoMapper;
        }

        public IActionResult Index()
        {
            //Když uložím pozemek, tak chci aby se to přesměrovalo sem, ale aby se zobrazila hláška, že se to správně uložilo.
            //Viewbag. tempdata fungujou jen po dobu jednoho requestu. proto to v pozemek uložim do tempdata, přesměruju to sem a tady teprve tempdata vložím do viewbagu a zobrazím.
            ViewBag.Message = TempData["shortMessage"];
            ViewBag.colorMessage = TempData["colorMessage"];
            ViewBag.colorBorder = TempData["colorBorder"];
            return View();
        }

        public IActionResult Vloz()
        {
            return View("Vlozvyber");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
