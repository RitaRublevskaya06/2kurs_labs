using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Lab04_05
{
    public partial class LoginAccountWindow : Window
    {
        // Предопределенные учетные данные
        private const string ValidUsername = "user";
        private const string ValidPassword = "password";

        public LoginAccountWindow()
        {
            InitializeComponent();
        }

        private void LoginButton_Click(object sender, RoutedEventArgs e)
        {
            string username = txtUsername.Text;
            string password = txtPassword.Password;

            if (username == ValidUsername && password == ValidPassword)
            {
                //// Открываем личный кабинет
                //AccountWindow accountWindow = new AccountWindow();
                //accountWindow.Show();
                //this.Close();
                // Устанавливаем DialogResult = true для индикации успеха
                this.DialogResult = true;
                this.Close();
            }
            else
            {
                MessageBox.Show("Неверный логин или пароль", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
