using System;
using System.Diagnostics;
using System.Windows;

namespace Lab04_05
{
    public static class Settings
    {
        ////public static event Action changeLang;
        //public static event EventHandler changeLang;
        ////public static event Action changeTheme;
        //public static event EventHandler changeTheme;

        //public enum Languages { RU, EN }
        //public enum Themes { Light, Dark, Teal }
        //private static Themes _currentTheme = Themes.Teal; // По умолчанию светлая тема

        //private static Languages _lang = Languages.RU;
        ////private static Themes _currentTheme = Themes.Teal;

        //public static Languages Lang
        //{
        //    get => _lang;
        //    set
        //    {
        //        _lang = value;
        //        ThemeChanged?.Invoke(null, EventArgs.Empty); // Вызываем событие при изменении
        //        //changeLang?.Invoke();
        //    }
        //}

        //public static Themes CurrentTheme
        //{
        //    get => _currentTheme;
        //    set
        //    {
        //        _currentTheme = value;
        //        ThemeChanged?.Invoke(null, EventArgs.Empty); // Вызываем событие при изменении
        //        //changeTheme?.Invoke(); // Вызываем событие при изменении
        //    }
        //}

        //public static event EventHandler ThemeChanged;

        public static event EventHandler changeLang;
        public static event EventHandler changeTheme;

        public enum Languages { RU, EN }
        public enum Themes { Teal, Dark }

        private static Languages _lang = Languages.RU;
        private static Themes _currentTheme = Themes.Teal;

        public static Languages Lang
        {
            get => _lang;
            set
            {
                //_lang = value;

                if (_lang == value) return;
                _lang = value;
                changeLang?.Invoke(null, EventArgs.Empty);
            }
        }

        public static Themes CurrentTheme
        {
            get => _currentTheme;
            set
            {
                _currentTheme = value;
                changeTheme?.Invoke(null, EventArgs.Empty);
            }
        }

        private static ResourceDictionary LoadResource(string path)
        {
            try
            {
                return new ResourceDictionary { Source = new Uri(path) };
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Ошибка загрузки ресурса {path}: {ex.Message}");
                return new ResourceDictionary();
            }
        }

        public static ResourceDictionary ResourceLights { get; } =
            LoadResource("pack://application:,,,/MaterialDesignThemes.Wpf;component/Themes/MaterialDesignTheme.Light.xaml");

        public static ResourceDictionary ResourceDefaults { get; } =
            LoadResource("pack://application:,,,/MaterialDesignThemes.Wpf;component/Themes/MaterialDesignTheme.Defaults.xaml");

        public static ResourceDictionary ResourcePrimaryTeal { get; } =
            LoadResource("pack://application:,,,/MaterialDesignColors;component/Themes/Recommended/Primary/MaterialDesignColor.Teal.xaml");

        public static ResourceDictionary ResourceAccentTeal { get; } =
            LoadResource("pack://application:,,,/MaterialDesignColors;component/Themes/Recommended/Accent/MaterialDesignColor.Teal.xaml");

        public static ResourceDictionary ResourceTeal { get; } =
            LoadResource("pack://application:,,,/Lab04-05;component/Resources/Teal.xaml");

        public static ResourceDictionary ResourceDark { get; } =
            LoadResource("pack://application:,,,/Lab04-05;component/Resources/Dark.xaml");

        public static ResourceDictionary ResourceStyles { get; } =
            LoadResource("pack://application:,,,/Lab04-05;component/Resources/Styles.xaml");

        public static ResourceDictionary ResourceEnLang { get; } =
            LoadResource("pack://application:,,,/Lab04-05;component/Resources/StringResources.En.xaml");

        public static ResourceDictionary ResourceRusLang { get; } =
            LoadResource("pack://application:,,,/Lab04-05;component/Resources/StringResources.Rus.xaml");


        public static ResourceDictionary GetCurrentLanguageDictionary()
        {
            try
            {
                return Lang switch
                {
                    Languages.EN => new ResourceDictionary { Source = new Uri("Resources/StringResources.En.xaml", UriKind.Relative) },
                    Languages.RU => new ResourceDictionary { Source = new Uri("Resources/StringResources.Rus.xaml", UriKind.Relative) },
                    _ => new ResourceDictionary { Source = new Uri("Resources/StringResources.Rus.xaml", UriKind.Relative) }
                };
            }
            catch
            {
                return new ResourceDictionary();
            }
        }

        public static ResourceDictionary GetCurrentThemeDictionary()
        {
            try
            {
                return CurrentTheme switch
                {
                    Themes.Teal => new ResourceDictionary { Source = new Uri("Resources/Teal.xaml", UriKind.Relative) },
                    Themes.Dark => new ResourceDictionary { Source = new Uri("Resources/Dark.xaml", UriKind.Relative) },
                    _ => new ResourceDictionary { Source = new Uri("Resources/Teal.xaml", UriKind.Relative) }
                };
            }
            catch
            {
                return new ResourceDictionary();
            }
        }

        //public static ResourceDictionary GetCurrentThemeDictionary()
        //{
        //    try
        //    {
        //        return CurrentTheme switch
        //        {
        //            Themes.Teal => ResourceTeal,
        //            Themes.Dark => ResourceDark,
        //            _ => ResourceTeal
        //        };
        //    }
        //    catch
        //    {
        //        return new ResourceDictionary();
        //    }
        //}

        //public static ResourceDictionary GetCurrentLanguageDictionary()
        //{
        //    try
        //    {
        //        return Lang switch
        //        {
        //            Languages.EN => ResourceEnLang,
        //            Languages.RU => ResourceRusLang,
        //            _ => ResourceRusLang
        //        };
        //    }
        //    catch
        //    {
        //        return new ResourceDictionary();
        //    }
        //}
    }
}