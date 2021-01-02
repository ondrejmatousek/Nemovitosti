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
            BytVM bytVM = new BytVM();
            //var byt = new Byt() { IdByt = 0, Cena = 1, NazevInzeratu = "Byt", VelikostBytu = 3 };
            //bytService.Insert(byt);
            var bytZDb = bytService.GetById(2);
            bytVM = autoMapper.Map(bytZDb);
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
