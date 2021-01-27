using Nemovitosti.Web.Models.CiselnikyViewModel;
using System;
using System.ComponentModel.DataAnnotations;

namespace Nemovitosti.Web.Models
{
    public class PozemekVM
    {
        public int IdPozemek { get; set; }
        [Required(ErrorMessage = "Tento údaj je povinný")]
        [Display(Name = "Název Inzerátu")]
        public string NazevInzeratu { get; set; }
        [Required(ErrorMessage = "Tento údaj je povinný")]
        [Display(Name = "Cena")]
        public int Cena { get; set; }
        [Required(ErrorMessage = "Tento údaj je povinný")]
        [Range(1, int.MaxValue)]
        [Display(Name = "Velikost pozemku")]
        public int VelikostPozemku { get; set; }
        public DateTime DatumVytvoreniInzeratu { get; set; }

        public CiselnikTotalProPozemekVM ciselnikTotalProPozemekVM { get; set; }
        public CiselnikTypPozemkuVM CiselnikTypPozemkuVM { get; set; }
        public CiselnikProdejNeboPronajemVM CiselnikProdejNeboPronajemVM { get; set; }

    }
}
