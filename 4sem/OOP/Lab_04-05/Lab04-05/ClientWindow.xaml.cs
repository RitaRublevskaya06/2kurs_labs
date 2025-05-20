using System;
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
            Loaded += (s, e) => UpdateUI();
            ProductsBtn_Click(null, null);
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

        private void OnLanguageChanged()
        {
            UpdateUI();
        }

        private void ProductsBtn_Click(object sender, RoutedEventArgs e)
        {
            clientFrame.Content = new ClientProductsPage();
            UpdateUI(); // Используем общий метод обновления
        }

        private void SwitchLang(object sender, ExecutedRoutedEventArgs e)
        {
            // Переключаем язык (вызовет событие changeLang)
            Settings.Lang = Settings.Lang == Settings.Languages.EN
                ? Settings.Languages.RU
                : Settings.Languages.EN;
        }

        protected override void OnClosed(EventArgs e)
        {
            Settings.changeLang -= OnLanguageChanged; // Отписываемся от события
            base.OnClosed(e);
        }
    }
}