using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;


namespace Lab_02
{
    [Serializable]
    public class Owner
    {
        [RegularExpression(@"^[a-zA-Zа-яА-ЯёЁ\s-]+$", ErrorMessage = "Некорректные данные!")]
        public string FIO { get; set; }
        [Passport]
        public string Passport { get; set; }
        [Required(ErrorMessage = "Введите данные!")]
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
