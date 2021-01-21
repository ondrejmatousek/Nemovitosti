using System;

namespace Nemovitosti.DomainModel.Model.Ciselniky
{
    [Serializable]
    public class CiselnikTypPozemku
    {
        public int Id { get; set; }
        public string Nazev { get; set; }

        public override bool Equals(object obj)
        {
            return obj is CiselnikTypPozemku pozemku &&
                   Id == pozemku.Id &&
                   Nazev == pozemku.Nazev;
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
