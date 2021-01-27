using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Nemovitosti.Web.Models.CiselnikyViewModel
{
    public class CiselnikTotalProPozemekVM
    {
        public CiselnikTotalProPozemekVM()
        {
            CiselnikProdejNeboPronajemVM = new List<SelectListItem>();
            CiselnikTypPozemkuVM = new List<SelectListItem>();
        }
        [Display(Name = "Typ nabídky")]
        public List<SelectListItem> CiselnikProdejNeboPronajemVM { get; set; }
        [Display(Name = "Typ Pozemku")]
        public List<SelectListItem> CiselnikTypPozemkuVM { get; set; }
    }
}
