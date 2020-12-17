using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Nemovitosti.DomainModel.Model
{
    [Serializable]
    [Table("Dum")]
    public class Dum
    {
        public int IdDum { get; set; }
        public string NazevInzeratu { get; set; }
        public int Cena { get; set; }
        public int VelikostPozemku { get; set; }
        public DateTime DatumVytvoreniInzeratu { get; set; }

        public override bool Equals(object obj)
        {
            return obj is Dum dum &&
                   IdDum == dum.IdDum &&
                   NazevInzeratu == dum.NazevInzeratu &&
                   Cena == dum.Cena &&
                   VelikostPozemku == dum.VelikostPozemku &&
                   DatumVytvoreniInzeratu == dum.DatumVytvoreniInzeratu;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(IdDum, NazevInzeratu, Cena, VelikostPozemku, DatumVytvoreniInzeratu);
        }
    }
}
