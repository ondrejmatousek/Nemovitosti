using System;

namespace Nemovitosti.DomainModel.Model
{
    public class Uzivatel
    {
        public int IdUzivatel { get; set; }
        public string UzivatelskeJmeno { get; set; }
        public string Heslo { get; set; }

        public override bool Equals(object obj)
        {
            return obj is Uzivatel uzivatel &&
                   IdUzivatel == uzivatel.IdUzivatel &&
                   UzivatelskeJmeno == uzivatel.UzivatelskeJmeno &&
                   Heslo == uzivatel.Heslo;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(IdUzivatel, UzivatelskeJmeno, Heslo);
        }
    }
}
