using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Serialization;
using System.IO;
using System.Text.RegularExpressions;
using Lab_02;

namespace Lab_02
{
    public partial class Form1 : Form
    {
        private List<Account> Accounts = new List<Account>();
        private List<Operation> Operation = new List<Operation>();

        public Form1()
        {
            InitializeComponent();

        }

        private void DataGridRowAdd(DataGridView dataGridView, DateTime? Date = null)
        {
            int Index = dataGridView.Rows.Add();
            dataGridView.Rows[Index].Cells["FIO"].Value = Accounts[Index].Owner.FIO;
            dataGridView.Rows[Index].Cells["Passport"].Value = Accounts[Index].Owner.Passport;
            dataGridView.Rows[Index].Cells["Birth"].Value = Accounts[Index].Owner.BirthDate;
            dataGridView.Rows[Index].Cells["AccountType"].Value = Accounts[Index].AccountType;
            dataGridView.Rows[Index].Cells["Balance"].Value = Accounts[Index].Balance;
            dataGridView.Rows[Index].Cells["OpenDate"].Value = Accounts[Index].OpenDate;
            dataGridView.Rows[Index].Cells["SMS"].Value = Accounts[Index].SMSNotifications ? "+" : "-";
            dataGridView.Rows[Index].Cells["Banking"].Value = Accounts[Index].InternetBanking ? "+" : "-";

            Operation.Add(new Operation("Создание счета", null, Date != null ? Convert.ToDateTime(Date) : DateTime.Now));
        }

        private void ClearFields()
        {
            FIOField.ResetText();
            passportField.ResetText();
            dateTimePicker.ResetText();
            AccountTypeField.SelectedIndex = -1;
            balanceText.ResetText();
            trackBarBalanse.Value = trackBarBalanse.Minimum;
            trackBarBalanse.ResetText();
            foreach (RadioButton rb in SMSPanel.Controls)
                rb.Checked = true;
            checkBoxInternet.Checked = false;
            numberOfAccount.ResetText();
        }

        private void validateFilds(object sender, CancelEventArgs e)
        {
            if (FIOField.Text == "")
            {
                errorProviderFIO.SetError(FIOField, "Введены некорректные данные!");
            }
        }

        private void AddButton_Click(object sender, EventArgs e)
        {
            if (ValidateChildren())
            {
                Accounts.Add(new Account(new Owner(FIOField.Text, passportField.Text, dateTimePicker.Value),
                    AccountTypeField.Text,
                    Convert.ToDouble(trackBarBalanse.Value > 0 ? trackBarBalanse.Value : 0),
                    DateTime.Now,
                    Account.Toggle(SMSPanel),
                    checkBoxInternet.Checked));

                DataGridRowAdd(dataGridView);
                ClearFields();
            }
        }

        private void trackBarBalanse_Scroll(object sender, EventArgs e)
        {
            balanceText.Text = trackBarBalanse.Value.ToString();
        }


        private void FIOField_Validating(object sender, CancelEventArgs e)
        {
            string[] words = FIOField.Text.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            if (words.Length != 3 || !Regex.IsMatch(FIOField.Text, @"^[a-zA-Zа-яА-Я\s]+$"))
            {
                errorProviderFIO.SetError(FIOField, "Введите полное ФИО");
                e.Cancel = true;
            }
        }

        private void FIOField_Validated(object sender, EventArgs e)
        {
            errorProviderFIO.SetError(FIOField, "");
        }

        private void numberOfAccount_Validating(object sender, CancelEventArgs e)
        {
            if (!numberOfAccount.MaskCompleted)
            {
                errorProviderNumberAcc.SetError(numberOfAccount, "Заполните правильно поле");
                e.Cancel = true;
            }
        }

        private void numberOfAccount_Validated(object sender, EventArgs e)
        {
            errorProviderNumberAcc.SetError(numberOfAccount, "");

        }

        private void passportField_Validated(object sender, EventArgs e)
        {
            errorProviderPassport.SetError(passportField, "");
        }

        private void passportField_Validating(object sender, CancelEventArgs e)
        {
            if (!passportField.MaskCompleted)
            {
                errorProviderPassport.SetError(passportField, "Заполните правильно поле");
                e.Cancel = true;
            }
        }

        private void AccountTypeField_Validated(object sender, EventArgs e)
        {
            errorProviderTypeOfAcc.SetError(AccountTypeField, "");
        }

        private void AccountTypeField_Validating(object sender, CancelEventArgs e)
        {
            if (AccountTypeField.SelectedIndex == -1)
            {
                errorProviderTypeOfAcc.SetError(AccountTypeField, "Выберите тип");
                e.Cancel = true;
            }
        }

        private void RestoreButton_Click(object sender, EventArgs e)
        {
            try
            {
                using (FileStream fs = new FileStream("Accounts.xml", FileMode.Open))
                {
                    XmlSerializer xml = new XmlSerializer(Accounts.GetType());
                    List<Account> accs = new List<Account>();
                    accs = xml.Deserialize(fs) as List<Account>;
                    foreach (var acc in accs)
                        Accounts.Add(acc);
                }
                RewriteDataGrid(dataGridView);
                MessageBox.Show("Данные успешно восстановлены!", "Успех!");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка!");
            }
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            try
            {
                if (dataGridView.Rows[0].Cells["FIO"].Value != null)
                {
                    using (FileStream fs = new FileStream("Accounts.xml", FileMode.Create))
                    {
                        XmlSerializer xml = new XmlSerializer(Accounts.GetType());
                        xml.Serialize(fs, Accounts);
                    }
                    MessageBox.Show("Данные успешно сохранены!", "Успех!");
                }
                else throw new Exception("Нет данных");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка!");
            }

        }

        private void RewriteDataGrid(DataGridView dgv)
        {
            foreach (DataGridViewRow row in dgv.Rows)
            {
                dataGridView.Rows.Clear();
                row.Dispose();
            }
            foreach (var acc in Accounts)
            {
                DataGridRowAdd(dgv);

                Operation.Add(new Operation("Создание счета", null, acc.OpenDate));

                HistoryAdd(HistoryGridView);
            }
        }

        private void HistoryAdd(DataGridView dgv)
        {
            int Index = HistoryGridView.Rows.Add();
            dgv.Rows[Index].Cells["DateGridView"].Value = Operation[Index].Date;
            dgv.Rows[Index].Cells["OperationTypeGridView"].Value = Operation[Index].OperationType;
            dgv.Rows[Index].Cells["TotalGridView"].Value = Operation[Index].Total != null ? Operation[Index].Total.ToString() : "-";
        }

        private void Transaction_Click(object sender, EventArgs e)
        {
            if (!ValidateChildren())
            {
                OperationType.SelectedIndex = 0;

            }
            else
            {
                Operation.Add(new Operation(OperationType.Text, Convert.ToDouble(Total.Text), DateTime.Now));
                HistoryAdd(HistoryGridView);
            }
        }

        private void Total_Validated_1(object sender, EventArgs e)
        {
            errorProviderTotal.SetError(Total, "");
        }

        private void Total_Validating_1(object sender, CancelEventArgs e)
        {
            if (trackBarBalanse.Value < Total.Value && OperationType.Text != "Пополнение")
            {
                errorProviderTotal.SetError(Total, "Не хватает средств на балансе");
                e.Cancel = true;
            }
        }
    }
}
