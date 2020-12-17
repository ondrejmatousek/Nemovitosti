using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Nemovitosti.DomainModel.Model
{
    [Serializable]
    [Table("Byt")]
    public class Byt
    {
        public int IdByt { get; set; }
        public string NazevInzeratu { get; set; }
        public int Cena { get; set; }
        public int VelikostBytu { get; set; }

        public override bool Equals(object obj)
        {
            return obj is Byt byt &&
                   IdByt == byt.IdByt &&
                   NazevInzeratu == byt.NazevInzeratu &&
                   Cena == byt.Cena &&
                   VelikostBytu == byt.VelikostBytu;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(IdByt, NazevInzeratu, Cena, VelikostBytu);
        }

        public override string ToString()
        {
            return IdByt + " " + NazevInzeratu + " " + Cena + " " + VelikostBytu;
        }
    }
}
