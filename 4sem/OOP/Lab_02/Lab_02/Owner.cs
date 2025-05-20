using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_02
{
    [Serializable]
    public class Owner
    {
        public string FIO { get; set; }
        public string Passport { get; set; }
        public DateTime BirthDate { get; set; }

        public Owner()
        {

        }

        public Owner(string fio, string passport, DateTime birthDate)
        {
            FIO = fio;
            Passport = passport;
            BirthDate = birthDate;
        }
    }
}
