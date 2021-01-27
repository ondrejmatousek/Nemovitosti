using System.ComponentModel.DataAnnotations;

namespace Nemovitosti.Web.Models.CiselnikyViewModel
{
    public class CiselnikProdejNeboPronajemVM
    {
        [Required(ErrorMessage = "Vyber jednu z možností")]
        public int Id { get; set; }
        public string Nazev { get; set; }
    }
}
