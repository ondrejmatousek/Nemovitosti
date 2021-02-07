using System;

namespace Nemovitosti.DomainModel.Model
{
    [Serializable]
    public class Uzivatel
    {
        public int IdUzivatel { get; set; }
        public string Heslo { get; set; }
        public string Email { get; set; }
        public string Jmeno { get; set; }
        public string Prijmeni { get; set; }

        public override bool Equals(object obj)
        {
            return obj is Uzivatel uzivatel &&
                   IdUzivatel == uzivatel.IdUzivatel &&
                   Heslo == uzivatel.Heslo &&
                   Email == uzivatel.Email &&
                   Jmeno == uzivatel.Jmeno &&
                   Prijmeni == uzivatel.Prijmeni;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(IdUzivatel, Heslo, Email, Jmeno, Prijmeni);
        }
    }
}
