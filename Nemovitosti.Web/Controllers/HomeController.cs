using Microsoft.AspNetCore.Mvc;
using Nemovitosti.DomainModel.Model;
using Nemovitosti.ServiceLayer.Interface;
using Nemovitosti.Web.Models;
using System.Diagnostics;

namespace Nemovitosti.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly IBytService bytService;

        public HomeController(IBytService bytService)
        {
            this.bytService = bytService;
        }

        public IActionResult Index()
        {
            var byt = new Byt() { IdByt = 0, Cena = 1, NazevInzeratu = "Byt", VelikostBytu = 3 };
            bytService.Insert(byt);
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
