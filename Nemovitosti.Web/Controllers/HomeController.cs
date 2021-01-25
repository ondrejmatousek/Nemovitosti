﻿using Microsoft.AspNetCore.Mvc;
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
