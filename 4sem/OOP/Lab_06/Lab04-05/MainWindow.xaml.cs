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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Lab04_05
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            myFrame.Source = new Uri("pack://application:,,,/ProductsPage.xaml");
            Cursor = CursorCollection.GetCursor();

            // Подписываемся на событие изменения темы
            Settings.changeTheme += OnThemeChanged;

            // Инициализация переключателя темы
            ThemeToggle.IsChecked = Settings.CurrentTheme == Settings.Themes.Dark;

            // Применяем текущую тему при запуске
            ApplyTheme(Settings.CurrentTheme);
        }

        private void OnThemeChanged(object sender, EventArgs e)
        {
            ApplyTheme(Settings.CurrentTheme);
        }

        private void ApplyTheme(Settings.Themes theme)
        {
            // Удаляем текущую тему
            var dictionariesToRemove = Application.Current.Resources.MergedDictionaries
                .Where(d => d.Source != null &&
                       (d.Source.OriginalString.Contains("Dark") ||
                        d.Source.OriginalString.Contains("Teal")))
                .ToList();

            foreach (var dict in dictionariesToRemove)
            {
                Application.Current.Resources.MergedDictionaries.Remove(dict);
            }

            // Добавляем новую тему
            ResourceDictionary newTheme = theme switch
            {
                Settings.Themes.Dark => new ResourceDictionary
                {
                    Source = new Uri("Resources/Dark.xaml", UriKind.Relative)
                },
                _ => new ResourceDictionary
                {
                    Source = new Uri("Resources/Teal.xaml", UriKind.Relative)
                }
            };

            Application.Current.Resources.MergedDictionaries.Add(newTheme);
        }

        private void ThemeToggle_Click(object sender, RoutedEventArgs e)
        {
            // Обновляем тему через свойство (вызовет событие ThemeChanged)
            Settings.CurrentTheme = ThemeToggle.IsChecked == true
                ? Settings.Themes.Dark
                : Settings.Themes.Teal;
        }

        protected override void OnClosed(EventArgs e)
        {
            // Отписываемся от событий
            Settings.changeTheme -= OnThemeChanged;
            base.OnClosed(e);
        }

        private void ToRussian()
        {
            Application.Current.Resources.MergedDictionaries.Remove(Settings.ResourceEnLang);
            Application.Current.Resources.MergedDictionaries.Add(Settings.ResourceRusLang);
            Settings.Lang = Settings.Languages.RU;
        }

        private void ToEnglish()
        {
            Application.Current.Resources.MergedDictionaries.Remove(Settings.ResourceRusLang);
            Application.Current.Resources.MergedDictionaries.Add(Settings.ResourceEnLang);
            Settings.Lang = Settings.Languages.EN;
        }

       

        private void ShowProducts(object sender, RoutedEventArgs e)
        {
            myFrame.Source = new Uri("pack://application:,,,/ProductsPage.xaml");
        }
        private void SwitchLang(object sender, RoutedEventArgs e)
        {
            if ((bool)Lang.IsChecked)
                ToEnglish();
            else
                ToRussian();
        }

    }
}
