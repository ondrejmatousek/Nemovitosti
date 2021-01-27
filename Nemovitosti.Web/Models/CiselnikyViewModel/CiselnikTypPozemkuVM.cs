using System.ComponentModel.DataAnnotations;

namespace Nemovitosti.Web.Models.CiselnikyViewModel
{
    public class CiselnikTypPozemkuVM
    {
        [Required(ErrorMessage = "Vyber jednu z možností")]
        public int Id { get; set; }
        public string Nazev { get; set; }
    }
}
