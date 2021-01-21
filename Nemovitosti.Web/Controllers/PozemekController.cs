using Microsoft.AspNetCore.Mvc;

namespace Nemovitosti.Web.Controllers
{
    public class PozemekController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Vloz()
        {

            return View("Edit");
        }

    }
}
