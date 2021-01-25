using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;

namespace Nemovitosti.Web.Models.CiselnikyViewModel
{
    public class CiselnikTotalProPozemekVM
    {
        public CiselnikTotalProPozemekVM()
        {
            CiselnikProdejNeboPronajemVM = new List<SelectListItem>();
            CiselnikTypPozemkuVM = new List<SelectListItem>();
        }
        public List<SelectListItem> CiselnikProdejNeboPronajemVM { get; set; }
        public List<SelectListItem> CiselnikTypPozemkuVM { get; set; }
    }
}
