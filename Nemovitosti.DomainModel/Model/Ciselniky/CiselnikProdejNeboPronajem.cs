using System;

namespace Nemovitosti.DomainModel.Model.Ciselniky
{
    [Serializable]
    public class CiselnikProdejNeboPronajem
    {
        public int Id { get; set; }
        public string Nazev { get; set; }

        public override bool Equals(object obj)
        {
            return obj is CiselnikProdejNeboPronajem pronajem &&
                   Id == pronajem.Id &&
                   Nazev == pronajem.Nazev;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Id, Nazev);
        }

        public override string ToString()
        {
            return Id + Nazev;
        }
    }
}
