using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace Lab_02
{
    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field, AllowMultiple = false)]
    class PassportAttribute : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            if (value != null)
            {
                string passport = value.ToString();
                if (Regex.IsMatch(passport, @"^[a-zA-Z]{2}\d{7}$"))
                    return true;
                else
                    ErrorMessage = "Серия паспорта содержит только A-Z!";
            }
            return false;
        }
    }
}
