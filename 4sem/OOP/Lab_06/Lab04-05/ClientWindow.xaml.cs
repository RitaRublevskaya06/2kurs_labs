using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace Lab04_05
{
    public partial class ClientWindow : Window
    {
        public ClientWindow()
        {
            InitializeComponent();
            Settings.changeLang += OnLanguageChanged;
            Settings.changeTheme += OnThemeChanged;
            Loaded += (s, e) => UpdateUI();
            ProductsBtn_Click(null, null);

            // Инициализация состояния переключателя темы
            ThemeToggle.IsChecked = Settings.CurrentTheme == Settings.Themes.Dark;
        }

        private void OnThemeChanged(object sender, EventArgs e)
        {
            ApplyTheme(Settings.CurrentTheme);
        }

        private void ApplyTheme(Settings.Themes theme)
        {
            // Удаляем только словари тем
            var dictionariesToRemove = Application.Current.Resources.MergedDictionaries
                .Where(d => d.Source != null &&
                       (d.Source.OriginalString.Contains("Dark.xaml") ||
                        d.Source.OriginalString.Contains("Teal.xaml")))
                .ToList();

            foreach (var dict in dictionariesToRemove)
            {
                Application.Current.Resources.MergedDictionaries.Remove(dict);
            }

            // Добавляем новый словарь темы
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
            Settings.CurrentTheme = ThemeToggle.IsChecked == true
                ? Settings.Themes.Dark
                : Settings.Themes.Teal;
        }

        protected override void OnClosed(EventArgs e)
        {
            //Settings.changeLang -= OnLanguageChanged;
            Settings.changeTheme -= OnThemeChanged;
            base.OnClosed(e);
        }

        private void UpdateUI()
        {
            Resources.MergedDictionaries.Clear();
            Resources.MergedDictionaries.Add(
                Settings.Lang == Settings.Languages.EN
                    ? Settings.ResourceEnLang
                    : Settings.ResourceRusLang);

            ProductsBtn.Content = TryFindResource("Products") ?? "Услуги";
            pageLabel.Content = TryFindResource("Products") ?? "Услуги";

            if (clientFrame.Content is ClientProductsPage page)
            {
                page.UpdateLanguage();
            }
        }

        private void OnLanguageChanged(object sender, EventArgs e)
        {
            UpdateUI();
        }

        private void ProductsBtn_Click(object sender, RoutedEventArgs e)
        {
            clientFrame.Content = new ClientProductsPage();
            UpdateUI();
        }

        private void SwitchLang(object sender, ExecutedRoutedEventArgs e)
        {
            Settings.Lang = Settings.Lang == Settings.Languages.EN
                ? Settings.Languages.RU
                : Settings.Languages.EN;
        }

        private void Product_Click(object sender, RoutedEventArgs e)
        {
            LoginAccountWindow loginWindow = new LoginAccountWindow();
            if (loginWindow.ShowDialog() == true)
            {
                AccountWindow accountWindow = new AccountWindow();
                accountWindow.ShowDialog();
            }
        }
    }
}


//using System;
//using System.Linq;
//using System.Windows;
//using System.Windows.Controls;
//using System.Windows.Input;

//namespace Lab04_05
//{
//    public partial class ClientWindow : Window
//    {
//        public ClientWindow()
//        {
//            InitializeComponent();
//            Settings.changeLang += OnLanguageChanged;
//            Settings.changeTheme += OnThemeChanged; // Добавляем подписку на событие смены темы
//            Loaded += (s, e) => UpdateUI();
//            ProductsBtn_Click(null, null);

//            //// Инициализация темы
//            //ThemeToggle.IsChecked = Settings.CurrentTheme == Settings.Themes.Dark;
//            ////ApplyTheme(Settings.CurrentTheme);

//        }

//        private void OnThemeChanged(object sender, EventArgs e)
//        {
//            ApplyTheme(Settings.CurrentTheme);
//        }

//        //private void ApplyTheme(Settings.Themes theme)
//        //{
//        //    // Удаляем текущую тему
//        //    var dictionariesToRemove = Application.Current.Resources.MergedDictionaries
//        //        .Where(d => d.Source != null &&
//        //               (d.Source.OriginalString.Contains("Dark") ||
//        //                d.Source.OriginalString.Contains("Teal")))
//        //        .ToList();

//        //    foreach (var dict in dictionariesToRemove)
//        //    {
//        //        Application.Current.Resources.MergedDictionaries.Remove(dict);
//        //    }

//        //    // Добавляем новую тему
//        //    ResourceDictionary newTheme = theme switch
//        //    {
//        //        Settings.Themes.Dark => new ResourceDictionary
//        //        {
//        //            Source = new Uri("Resources/Dark.xaml", UriKind.Relative)
//        //        },
//        //        _ => new ResourceDictionary
//        //        {
//        //            Source = new Uri("Resources/Teal.xaml", UriKind.Relative)
//        //        }
//        //    };

//        //    Application.Current.Resources.MergedDictionaries.Add(newTheme);
//        //}
//        private void ApplyTheme(Settings.Themes theme)
//        {
//            // Удаляем только словари тем (Dark.xaml и Teal.xaml)
//            var dictionariesToRemove = Application.Current.Resources.MergedDictionaries
//                .Where(d => d.Source != null &&
//                       (d.Source.OriginalString.Contains("Dark.xaml") ||
//                        d.Source.OriginalString.Contains("Teal.xaml")))
//                .ToList();

//            foreach (var dict in dictionariesToRemove)
//            {
//                Application.Current.Resources.MergedDictionaries.Remove(dict);
//            }

//            // Добавляем новый словарь темы
//            ResourceDictionary newTheme = theme switch
//            {
//                Settings.Themes.Dark => new ResourceDictionary
//                {
//                    Source = new Uri("Resources/Dark.xaml", UriKind.Relative)
//                },
//                _ => new ResourceDictionary
//                {
//                    Source = new Uri("Resources/Teal.xaml", UriKind.Relative)
//                }
//            };

//            Application.Current.Resources.MergedDictionaries.Add(newTheme);
//        }

//        private void ThemeToggle_Click(object sender, RoutedEventArgs e)
//        {
//            // Обновляем тему через свойство (вызовет событие ThemeChanged)
//            Settings.CurrentTheme = ThemeToggle.IsChecked == true
//                ? Settings.Themes.Dark
//                : Settings.Themes.Teal;
//        }

//        protected override void OnClosed(EventArgs e)
//        {
//            // Отписываемся от событий
//            Settings.ThemeChanged -= OnThemeChanged;
//            base.OnClosed(e);
//        }

//        ////private void OnThemeChanged()
//        ////{
//        ////    // Обновляем состояние переключателя
//        ////    ThemeToggle.IsChecked = Settings.CurrentTheme == Settings.Themes.Dark;
//        ////    ApplyTheme(Settings.CurrentTheme);
//        ////}

//        //private void ApplyTheme(Settings.Themes theme)
//        //{
//        //    // Удаляем только словари тем (Dark.xaml и Teal.xaml)
//        //    var dictionariesToRemove = Application.Current.Resources.MergedDictionaries
//        //        .Where(d => d.Source != null &&
//        //               (d.Source.OriginalString.Contains("Dark.xaml") ||
//        //                d.Source.OriginalString.Contains("Teal.xaml")))
//        //        .ToList();

//        //    foreach (var dict in dictionariesToRemove)
//        //    {
//        //        Application.Current.Resources.MergedDictionaries.Remove(dict);
//        //    }

//        //    // Добавляем новый словарь темы
//        //    ResourceDictionary newTheme = theme switch
//        //    {
//        //        Settings.Themes.Dark => new ResourceDictionary
//        //        {
//        //            Source = new Uri("Resources/Dark.xaml", UriKind.Relative)
//        //        },
//        //        _ => new ResourceDictionary
//        //        {
//        //            Source = new Uri("Resources/Teal.xaml", UriKind.Relative)
//        //        }
//        //    };

//        //    Application.Current.Resources.MergedDictionaries.Add(newTheme);
//        //}


//        private void UpdateUI()
//        {
//            Resources.MergedDictionaries.Clear();
//            Resources.MergedDictionaries.Add(
//                Settings.Lang == Settings.Languages.EN
//                    ? Settings.ResourceEnLang
//                    : Settings.ResourceRusLang);

//            ProductsBtn.Content = TryFindResource("Products") ?? "Услуги";
//            pageLabel.Content = TryFindResource("Products") ?? "Услуги";

//            if (clientFrame.Content is ClientProductsPage page)
//            {
//                page.UpdateLanguage();
//            }
//        }

//        private void OnLanguageChanged()
//        {
//            UpdateUI();
//        }

//        private void ProductsBtn_Click(object sender, RoutedEventArgs e)
//        {
//            clientFrame.Content = new ClientProductsPage();
//            UpdateUI();
//        }

//        private void SwitchLang(object sender, ExecutedRoutedEventArgs e)
//        {
//            Settings.Lang = Settings.Lang == Settings.Languages.EN
//                ? Settings.Languages.RU
//                : Settings.Languages.EN;
//        }

//        private void Product_Click(object sender, RoutedEventArgs e)
//        {
//            // Открываем окно входа в личный кабинет
//            LoginAccountWindow loginWindow = new LoginAccountWindow();
//            if (loginWindow.ShowDialog() == true)
//            {
//                // Если авторизация успешна, открываем личный кабинет
//                AccountWindow accountWindow = new AccountWindow();
//                accountWindow.ShowDialog();
//            }
//        }

//    }
//}