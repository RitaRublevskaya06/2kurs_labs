using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading.Tasks;
using System.Xml.Serialization;
using System.ComponentModel.DataAnnotations;

namespace Lab_02
{
    [Serializable]
    public class Account
    {
        [XmlElement]
        public Owner Owner { get; set; }
        [Range(1, 600000, ErrorMessage = "Ошибка: нет такого номера счета")]
        public int AccoyntNumber { get; set; }
        public string AccountType { get; set; }
        public double? Balance { get; set; }
        public DateTime OpenDate { get; set; }
        public bool SMSNotifications { get; set; }
        public bool InternetBanking { get; set; }

        public Account(Owner _Owner, string accountType, int accNum, double balance, DateTime openDate, bool SMS, bool Banking)
        {
            Owner = _Owner;
            AccountType = accountType;
            AccoyntNumber = accNum;
            SMSNotifications = SMS;
            InternetBanking = Banking;
            OpenDate = openDate;
            Balance = balance;

        }

        public Account()
        {

        }

        static public bool Toggle(Panel toggle)
        {
            var RadioButton = (RadioButton)toggle.Controls[0];
            if (RadioButton.Checked && RadioButton.Text == "Нет")
                return false;
            else return true;
        }

        public override string ToString()
        {
            return $"{Owner.FIO},\t {Owner.Passport},\t {AccountType}, \t {AccoyntNumber},\t\t {Balance},\t{OpenDate.ToString()}";
        }
    }
}
