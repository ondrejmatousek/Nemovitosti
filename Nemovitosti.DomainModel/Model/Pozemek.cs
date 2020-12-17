using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Nemovitosti.DomainModel.Model
{
    [Serializable]
    [Table("Pozemek")]
    public class Pozemek
    {
        public int IdPozemek { get; set; }
        public string NazevInzeratu { get; set; }
        public int Cena { get; set; }
        public int VelikostPozemku { get; set; }
        public DateTime DatumVytvoreniInzeratu { get; set; }

        public override bool Equals(object obj)
        {
            return obj is Pozemek pozemek &&
                   IdPozemek == pozemek.IdPozemek &&
                   NazevInzeratu == pozemek.NazevInzeratu &&
                   Cena == pozemek.Cena &&
                   VelikostPozemku == pozemek.VelikostPozemku &&
                   DatumVytvoreniInzeratu == pozemek.DatumVytvoreniInzeratu;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(IdPozemek, NazevInzeratu, Cena, VelikostPozemku, DatumVytvoreniInzeratu);
        }
    }
}
