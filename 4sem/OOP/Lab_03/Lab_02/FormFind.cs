using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using System.IO;
using System.Xml.Serialization;
using System.Text.Json;
using System.Reflection;

namespace Lab_02
{
    public partial class FormFind : Form
    {
        List<Account> Accounts = new List<Account>();
        List<Account> SearchedAccounts = new List<Account>();

        public FormFind(List<Account> accounts)
        {
            InitializeComponent();
            Accounts = accounts;

            panel1.Hide();
            // listBox.Items.AddRange(accounts.ToArray());
            foreach (Account account in accounts)
            {
                listBox.Items.Add(account.ToString());
            }
        }

        private void Seriolaaze()
        {
            try
            {
                List<string> textList = new List<string>();

                foreach (var item in listBox.Items)
                {
                    if (item is string text)
                    {
                        textList.Add(text);
                    }
                }
                JsonSerializerOptions options = new JsonSerializerOptions
                {
                    WriteIndented = true
                };

                string json = JsonSerializer.Serialize(textList, options);
                File.WriteAllText("SearchedAccounts.json", json);

                MessageBox.Show("Данные успешно сохранены!", "Успех!");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка!");
            }
        }

        private void впередToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (listBox.SelectedIndex == -1)
            {
                listBox.SelectedIndex = 0;
                return;
            }

            if (listBox.SelectedIndex > 0)
            {
                listBox.SelectedIndex--;
            }
        }

        private void назадToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (listBox.SelectedIndex == -1)
            {
                listBox.SelectedIndex = 0;
                return;
            }

            if (listBox.SelectedIndex < listBox.Items.Count - 1)
            {
                listBox.SelectedIndex++;
            }
        }

        private void удалитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (listBox.SelectedIndex != -1)
            {
                Accounts.RemoveAt(listBox.SelectedIndex);

                listBox.Items.RemoveAt(listBox.SelectedIndex);
            }
        }

        private void очиститьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            listBox.Items.Clear();
        }

        private void сортировкаToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void фИОToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string searchPattern = searchTextBox.Text;

            listBox.Items.Clear();

            List<Account> searchedAccounts = Accounts.Where(account => Regex.IsMatch(account.Owner.FIO, $@"{searchPattern}\w*", RegexOptions.IgnoreCase)).ToList();
            foreach (Account account in searchedAccounts)
            {
                listBox.Items.Add(account.ToString());
            }
        }

        private void номеруСчетаToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string searchPattern = searchTextBox.Text;

            listBox.Items.Clear();

            List<Account> searchedAccounts = Accounts.Where(account => Regex.IsMatch(account.AccoyntNumber.ToString(), $@"^{searchPattern}", RegexOptions.IgnoreCase)).ToList();
            foreach (Account account in searchedAccounts)
            {
                listBox.Items.Add(account.ToString());
            }
        }

        private void балансToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string searchPattern = searchTextBox.Text;

            listBox.Items.Clear();

            List<Account> searchedAccounts;

            if (searchPattern.StartsWith(">"))
            {
                double balanceThreshold;
                if (double.TryParse(searchPattern.Substring(1), out balanceThreshold))
                {
                    searchedAccounts = Accounts.Where(account => account.Balance > balanceThreshold).ToList();
                }
                else
                {
                    return;
                }
            }
            else if (searchPattern.StartsWith("<"))
            {
                double balanceThreshold;
                if (double.TryParse(searchPattern.Substring(1), out balanceThreshold))
                {
                    searchedAccounts = Accounts.Where(account => account.Balance < balanceThreshold).ToList();
                }
                else
                {
                    return;
                }
            }
            else if (searchPattern.Contains("-"))
            {
                string[] balanceRange = searchPattern.Split('-');
                if (balanceRange.Length == 2 && double.TryParse(balanceRange[0], out double minBalance) && double.TryParse(balanceRange[1], out double maxBalance))
                {
                    searchedAccounts = Accounts.Where(account => account.Balance >= minBalance && account.Balance <= maxBalance).ToList();
                }
                else
                {
                    return;
                }
            }
            else if (Regex.IsMatch(searchPattern, @"^\d+(\.\d+)?$"))
            {
                double exactBalance;
                if (double.TryParse(searchPattern, out exactBalance))
                {
                    searchedAccounts = Accounts.Where(account => account.Balance == exactBalance).ToList();
                }
                else
                {
                    return;
                }
            }
            else
            {
                return;
            }

            foreach (Account account in searchedAccounts)
            {
                listBox.Items.Add(account.ToString());
            }
        }

        private void типВкладаToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string searchPattern = searchTextBox.Text;

            listBox.Items.Clear();

            List<Account> searchedAccounts = Accounts.Where(account => Regex.IsMatch(account.AccountType.ToString(), $@"^{searchPattern}", RegexOptions.IgnoreCase)).ToList();
            foreach (Account account in searchedAccounts)
            {
                listBox.Items.Add(account.ToString());
            }
        }

        private void конструкторПоискаToolStripMenuItem_Click(object sender, EventArgs e)
        {
            panel1.Show();


        }

        private void constructorFind_Click(object sender, EventArgs e)
        {
            string searchPatternFIO = constructorFIO.Text;
            string searchPatternNum = constructorNumber.Text;
            string searchPatternType = constrycterType.Text;

            listBox.Items.Clear();

            List<Account> searchedAccounts = Accounts.Where(account =>
                Regex.IsMatch(account.AccountType.ToString(), $@"^{searchPatternType}", RegexOptions.IgnoreCase) &&
                Regex.IsMatch(account.AccoyntNumber.ToString(), $@"^{searchPatternNum}", RegexOptions.IgnoreCase) &&
                Regex.IsMatch(account.Owner.FIO, $@"^{searchPatternFIO}", RegexOptions.IgnoreCase)
             ).ToList();

            foreach (Account account in searchedAccounts)
            {
                listBox.Items.Add(account.ToString());
            }

        }

        private void buttonShow_Click(object sender, EventArgs e)
        {
            menuStripSearch.Show();
        }

        private void buttonHide_Click(object sender, EventArgs e)
        {
            menuStripSearch.Hide();
        }

        private void типСчетаToolStripMenuItem_Click(object sender, EventArgs e)
        {
            listBox.Items.Clear();

            List<Account> sortedAccounts = Accounts.OrderBy(account => account.AccountType.ToString()).ToList();

            foreach (Account account in sortedAccounts)
            {
                listBox.Items.Add(account.ToString());
            }
        }

        private void датаToolStripMenuItem_Click(object sender, EventArgs e)
        {
            listBox.Items.Clear();

            List<Account> sortedAccounts = Accounts.OrderBy(account => account.OpenDate).ToList();

            foreach (Account account in sortedAccounts)
            {
                listBox.Items.Add(account.ToString());
            }
        }

        private void buttonSavee_Click(object sender, EventArgs e)
        {
            Seriolaaze();
        }

        private void Seriolaze()
        {
            try
            {
                foreach (var item in listBox.Items)
                {
                    if (item is Account account)
                    {
                        SearchedAccounts.Add(account);
                    }
                }
                using (FileStream fs = new FileStream("SearchedAccounts.xml", FileMode.Create))
                {
                    XmlSerializer xml = new XmlSerializer(SearchedAccounts.GetType());
                    xml.Serialize(fs, SearchedAccounts);
                }
                MessageBox.Show("Данные успешно сохранены!", "Успех!");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка!");
            }
        }
    }
}
