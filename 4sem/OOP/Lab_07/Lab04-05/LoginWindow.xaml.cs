using System;
using System.Windows;

namespace Lab04_05
{
    public partial class LoginWindow : Window
    {
        public LoginWindow()
        {
            InitializeComponent();
        }

        private void AdminBtn_Click(object sender, RoutedEventArgs e)
        {
            var adminWindow = new MainWindow();
            adminWindow.Closed += (s, args) => this.Show(); 
            this.Hide(); 
            adminWindow.Show();
        }

        private void ClientBtn_Click(object sender, RoutedEventArgs e)
        {
            var clientWindow = new ClientWindow();
            clientWindow.Closed += (s, args) => this.Show(); 
            this.Hide(); 
            clientWindow.Show();
        }

        protected override void OnClosing(System.ComponentModel.CancelEventArgs e)
        {
            // Если окно скрыто, не закрываем приложение
            if (this.Visibility == Visibility.Hidden)
            {
                e.Cancel = true;
                return;
            }

            // Если это явное закрытие LoginWindow, закрываем приложение
            base.OnClosing(e);
            Application.Current.Shutdown();
        }
    }
}