using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Nemovitosti.DomainModel.Model;
using Nemovitosti.DomainModel.Model.Ciselniky;
using Nemovitosti.ServiceLayer.Interface;
using Nemovitosti.ServiceLayer.Interface.Ciselniky;
using Nemovitosti.Web.Mappers;
using Nemovitosti.Web.Models;
using Nemovitosti.Web.Models.CiselnikyViewModel;
using System;
using System.Collections.Generic;

namespace Nemovitosti.Web.Controllers
{
    public class PozemekController : Controller
    {
        private readonly IPozemekService _pozemekService;
        private readonly ICiselnikTypPozemkuService _ciselnikTypPozemkuService;
        private readonly ICiselnikProdejNeboPronajemService _ciselnikProdejNeboPronajemService;
        private readonly IMapperWeb _mapperWeb;
        public PozemekController(IPozemekService pozemekService, ICiselnikTypPozemkuService ciselnikTypPozemkuService, IMapperWeb mapperWeb, ICiselnikProdejNeboPronajemService ciselnikProdejNeboPronajemService)
        {
            _pozemekService = pozemekService;
            _ciselnikTypPozemkuService = ciselnikTypPozemkuService;
            _ciselnikProdejNeboPronajemService = ciselnikProdejNeboPronajemService;
            _mapperWeb = mapperWeb;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Vloz()
        {
            PozemekVM pozemekVM = new PozemekVM();
            pozemekVM.ciselnikTotalProPozemekVM = NactiCiselniky();

            return View("Edit", pozemekVM);
        }

        public IActionResult UlozInzerat(PozemekVM pozemekVM)
        {

            Pozemek pozemek = _mapperWeb.Map(pozemekVM);
            if (ModelState.IsValid == true)
            {
                TempData["colorBorder"] = "border-success";
                TempData["colorMessage"] = "alert-success";
                if (pozemekVM.IdPozemek == 0)
                {
                    try
                    {
                        _pozemekService.Insert(pozemek);
                        TempData["shortMessage"] = "Záznam byl úspěšně vytvořen";
                    }
                    catch (Exception Ex)
                    {
                        TempData["colorBorder"] = "border-warning";
                        TempData["shortMessage"] = Ex.Message;
                        TempData["colorMessage"] = "alert-warning";
                    }
                }
                else
                {
                    try
                    {
                        _pozemekService.Update(pozemek);
                        TempData["shortMessage"] = "Záznam byl úspěšně uložen";
                    }
                    catch (Exception Ex)
                    {
                        TempData["colorBorder"] = "border-warning";
                        TempData["shortMessage"] = Ex.Message;
                        TempData["colorMessage"] = "alert-warning";
                    }
                }
            }

            if (pozemek.IdPozemek == 0)
            {
                ViewBag.Message = TempData["shortMessage"];
                ViewBag.colorMessage = TempData["colorMessage"];
                ViewBag.colorBorder = TempData["colorBorder"];
                return View("Edit", pozemekVM);
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }

        }

        //Dokonči mapování číselníků z listuDM na listVM a
        public CiselnikTotalProPozemekVM NactiCiselniky()
        {
            CiselnikTotalProPozemekVM ciselnikTotalProPozemekVM = new CiselnikTotalProPozemekVM();

            //CiselnikTypuPozemku
            List<CiselnikTypPozemku> ciselnikTypPozemkuList = _ciselnikTypPozemkuService.GetAll();
            List<CiselnikTypPozemkuVM> ciselnikTypPozemkuVMList = _mapperWeb.Map(ciselnikTypPozemkuList);
            List<SelectListItem> selectListItemsTypPozemku = new List<SelectListItem>();
            foreach (var typPozemku in ciselnikTypPozemkuVMList)
            {
                selectListItemsTypPozemku.Add(new SelectListItem(text: typPozemku.Nazev, value: typPozemku.Id.ToString()));
            }
            ciselnikTotalProPozemekVM.CiselnikTypPozemkuVM = selectListItemsTypPozemku;

            //CiselnikProdejNeboPronajem
            List<CiselnikProdejNeboPronajem> ciselnikProdejNeboPronajemList = _ciselnikProdejNeboPronajemService.GetAll();
            List<CiselnikProdejNeboPronajemVM> ciselnikProdejNeboPronajemListVM = _mapperWeb.Map(ciselnikProdejNeboPronajemList);
            List<SelectListItem> selectListItemsProdejNeboPronajem = new List<SelectListItem>();
            foreach (var prodejNeboPronajemVM in ciselnikProdejNeboPronajemListVM)
            {
                selectListItemsProdejNeboPronajem.Add(new SelectListItem(text: prodejNeboPronajemVM.Nazev, value: prodejNeboPronajemVM.Id.ToString()));
            }
            ciselnikTotalProPozemekVM.CiselnikProdejNeboPronajemVM = selectListItemsProdejNeboPronajem;

            return ciselnikTotalProPozemekVM;
        }
    }
}
