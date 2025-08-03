using System;
using System.Windows;
using System.Windows.Input;

namespace Lab04_05
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            // глобальная установка курсора
            try
            {
                Mouse.OverrideCursor = new Cursor(Application.GetResourceStream(
                    new Uri("pack://application:,,,/Cursors/AppStarting.ani")).Stream);

            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка при загрузке курсора: " + ex.Message);
            }
        }
    }
}
