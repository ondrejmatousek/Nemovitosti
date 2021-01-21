using Nemovitosti.DomainModel.Model.Ciselniky;
using System;
using System.Collections.Generic;
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
        public CiselnikTypPozemku TypPozemku { get; set; } //číselník Nemovitosti.dbo.TypPozemku
        public CiselnikProdejNeboPronajem ProdejNeboPronajem { get; set; } //číselník Nemovitosti.dbo.ProdejNeboPronajem
        public DateTime DatumVytvoreniInzeratu { get; set; }

        public override bool Equals(object obj)
        {
            return obj is Pozemek pozemek &&
                   IdPozemek == pozemek.IdPozemek &&
                   NazevInzeratu == pozemek.NazevInzeratu &&
                   Cena == pozemek.Cena &&
                   VelikostPozemku == pozemek.VelikostPozemku &&
                   EqualityComparer<CiselnikTypPozemku>.Default.Equals(TypPozemku, pozemek.TypPozemku) &&
                   EqualityComparer<CiselnikProdejNeboPronajem>.Default.Equals(ProdejNeboPronajem, pozemek.ProdejNeboPronajem) &&
                   DatumVytvoreniInzeratu == pozemek.DatumVytvoreniInzeratu;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(IdPozemek, NazevInzeratu, Cena, VelikostPozemku, TypPozemku, ProdejNeboPronajem, DatumVytvoreniInzeratu);
        }

        public override string ToString()
        {
            return base.ToString();
        }
    }
}
