using System.Windows;

namespace Lab04_05
{
    public partial class AppointmentForm : Window
    {
        public AppointmentForm(string serviceName)
        {
            InitializeComponent();
            ServiceName.Text = serviceName;
        }

        private void ConfirmAppointment_Click(object sender, RoutedEventArgs e)
        {
            // Здесь будет логика сохранения записи
            MessageBox.Show("Запись успешно оформлена!", "Успех", MessageBoxButton.OK, MessageBoxImage.Information);
            this.Close();
        }

    }
}