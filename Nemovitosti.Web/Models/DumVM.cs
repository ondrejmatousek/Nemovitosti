using System;

namespace Nemovitosti.Web.Models
{
    public class DumVM
    {
        public int IdDum { get; set; }
        public string NazevInzeratu { get; set; }
        public int Cena { get; set; }
        public int VelikostPozemku { get; set; }
        public DateTime DatumVytvoreniInzeratu { get; set; }
    }
}
