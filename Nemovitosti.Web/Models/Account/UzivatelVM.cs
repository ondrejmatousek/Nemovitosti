using Nemovitosti.Web.Models.DataAnotationCustomAtributy;
using System.ComponentModel.DataAnnotations;

namespace Nemovitosti.Web.Models.Account
{
    public class UzivatelVM
    {
        public int IdUzivatel { get; set; }
        [Display(Name = "Jméno")]
        [Required(ErrorMessage = "Toto pole je povinné")]
        [StringLength(300, ErrorMessage = "Maximální počet znaků je 300")]
        public string Jmeno { get; set; }

        [Display(Name = "Příjmení")]
        [Required(ErrorMessage = "Toto pole je povinné")]
        [StringLength(300, ErrorMessage = "Maximální počet znaků je 300")]
        public string Prijmeni { get; set; }

        [Display(Name = "Email")]
        [Required(ErrorMessage = "Toto pole je povinné")]
        //FrontEndValidace
        [EmailAddress(ErrorMessage = "Tento tvar Emailu není správný")]
        //Pro backend validaci
        [EmailOrPhone]
        public string Email { get; set; }
        [Display(Name = "Heslo")]
        [Required(ErrorMessage = "Toto pole je povinné")]
        [DataType(DataType.Password)]
        [RegularExpression("^((?=.*?[A-Z])(?=.*?[a-z])(?=.*?[0-9])|(?=.*?[A-Z])(?=.*?[a-z])(?=.*?[^a-zA-Z0-9])|(?=.*?[A-Z])(?=.*?[0-9])(?=.*?[^a-zA-Z0-9])|(?=.*?[a-z])(?=.*?[0-9])(?=.*?[^a-zA-Z0-9])).{8,}$", ErrorMessage = "Heslo musí mít minimálně 8 znaků a obsahovat alespoň 3 ze 4 následujícíh pravidel: velká písmen (A-Z), malá písmena (a-z), čísla (0-9), speciální znaky (např.: !@#$%^&*)")]
        public string Heslo { get; set; }
    }
}
