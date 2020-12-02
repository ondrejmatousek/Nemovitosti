using System;

namespace Nemovitosti.DomainModel.Model
{
    public class Inzerat
    {
        public int IdInzerat { get; set; }
        public int KategorieId { get; set; }

        public override bool Equals(object obj)
        {
            return obj is Inzerat inzerat &&
                   IdInzerat == inzerat.IdInzerat &&
                   KategorieId == inzerat.KategorieId;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(IdInzerat, KategorieId);
        }
    }
}
