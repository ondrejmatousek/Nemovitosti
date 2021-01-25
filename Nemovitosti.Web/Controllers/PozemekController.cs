using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Nemovitosti.DomainModel.Model.Ciselniky;
using Nemovitosti.ServiceLayer.Interface;
using Nemovitosti.ServiceLayer.Interface.Ciselniky;
using Nemovitosti.Web.Mappers;
using Nemovitosti.Web.Models;
using Nemovitosti.Web.Models.CiselnikyViewModel;
using System.Collections.Generic;

namespace Nemovitosti.Web.Controllers
{
    public class PozemekController : Controller
    {
        private readonly IPozemekService _pozemekService;
        private readonly ICiselnikTypPozemkuService _ciselnikTypPozemkuService;
        private readonly IMapperWeb _mapperWeb;
        public PozemekController(IPozemekService pozemekService, ICiselnikTypPozemkuService ciselnikTypPozemkuService, IMapperWeb mapperWeb)
        {
            _pozemekService = pozemekService;
            _ciselnikTypPozemkuService = ciselnikTypPozemkuService;
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

        public IActionResult UlozInzerat()
        {

            return View("Edit");
        }

        //Dokonči mapování číselníků z listuDM na listVM a
        public CiselnikTotalProPozemekVM NactiCiselniky()
        {
            CiselnikTotalProPozemekVM ciselnikTotalProPozemekVM = new CiselnikTotalProPozemekVM();

            List<CiselnikTypPozemku> ciselnikTypPozemkuList = _ciselnikTypPozemkuService.GetAll();
            List<CiselnikTypPozemkuVM> ciselnikTypPozemkuVMList = _mapperWeb.Map(ciselnikTypPozemkuList);
            List<SelectListItem> selectListItemsTypPozemku = new List<SelectListItem>();
            foreach (var typPozemku in ciselnikTypPozemkuVMList)
            {
                selectListItemsTypPozemku.Add(new SelectListItem(text: typPozemku.Nazev, value: typPozemku.Id.ToString()));
            }
            ciselnikTotalProPozemekVM.CiselnikTypPozemkuVM = selectListItemsTypPozemku;
            return ciselnikTotalProPozemekVM;
        }
    }
}
