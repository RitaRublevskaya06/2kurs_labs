using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Lab_02
{
    [Serializable]
    public class Account
    {

        public Owner Owner { get; set; }
        public int AccoyntNumber { get; set; }
        public string AccountType { get; set; }
        public double? Balance { get; set; }
        public DateTime OpenDate { get; set; }
        public bool SMSNotifications { get; set; }
        public bool InternetBanking { get; set; }

        public Account(Owner _Owner, string accountType, double balance, DateTime openDate, bool SMS, bool Banking)
        {
            Owner = _Owner;
            AccountType = accountType;
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
    }
}
