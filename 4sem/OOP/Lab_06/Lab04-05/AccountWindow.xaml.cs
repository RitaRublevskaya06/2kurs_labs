using System;
using System.Windows;
using System.Windows.Controls;
using MaterialDesignThemes.Wpf;
using System.Linq; 

namespace Lab04_05
{
    public partial class AccountWindow : Window
    {
        public AccountWindow()
        {
            InitializeComponent();

            // Инициализация ресурсов перед загрузкой данных
            this.Resources.MergedDictionaries.Add(Settings.ResourceStyles);
            this.Resources.MergedDictionaries.Add(Settings.GetCurrentLanguageDictionary());
            this.Resources.MergedDictionaries.Add(Settings.GetCurrentThemeDictionary());

            LoadUserData();
            InitializeThemeToggle();
            InitializeLanguageComboBox();

            // Подписка на события изменения языка и темы
            Settings.changeLang += OnLanguageChanged;
            Settings.changeTheme += OnThemeChanged;
        }

        private void LoadUserData()
        {
            txtUsername.Text = "user";
            txtFullName.Text = "Иванова Инна Ивановна";
            txtBirthDate.Text = "01.01.1990";
            txtPhone.Text = "+375 (29) 123-45-67";
            txtEmail.Text = "user@example.com";
        }

        private void InitializeThemeToggle()
        {
            themeToggle.IsChecked = Settings.CurrentTheme == Settings.Themes.Dark;
            themeToggle.Checked += ThemeToggle_Changed;
            themeToggle.Unchecked += ThemeToggle_Changed;
        }

        private void InitializeLanguageComboBox()
        {
            cmbLanguage.SelectedIndex = Settings.Lang == Settings.Languages.EN ? 1 : 0;
            cmbLanguage.SelectionChanged += LanguageComboBox_SelectionChanged;
        }

        private void SaveChanges_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show(
                (string)Application.Current.FindResource("ChangesSaved"),
                (string)Application.Current.FindResource("Information"),
                MessageBoxButton.OK,
                MessageBoxImage.Information
            );
        }

        private void ThemeToggle_Changed(object sender, RoutedEventArgs e)
        {
            Settings.CurrentTheme = themeToggle.IsChecked == true
                ? Settings.Themes.Dark
                : Settings.Themes.Teal;
        }

        private void LanguageComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (cmbLanguage.SelectedIndex == 0)
                Settings.Lang = Settings.Languages.RU;
            else if (cmbLanguage.SelectedIndex == 1)
                Settings.Lang = Settings.Languages.EN;
        }

        private void OnLanguageChanged(object sender, EventArgs e)
        {
            // Полностью перезагружаем ресурсы окна
            this.Resources.MergedDictionaries.Clear();

            // Добавляем словарь стилей (обязательно должен быть первым)
            this.Resources.MergedDictionaries.Add(Settings.ResourceStyles);

            // Добавляем языковой словарь
            this.Resources.MergedDictionaries.Add(Settings.GetCurrentLanguageDictionary());

            // Добавляем словарь темы
            this.Resources.MergedDictionaries.Add(Settings.GetCurrentThemeDictionary());

            // Обновляем UI
            UpdateUI();
        }

        ////private void OnThemeChanged(object sender, EventArgs e)
        ////{
        ////    // Обновляем тему для этого окна
        ////    var themeDictionaries = this.Resources.MergedDictionaries
        ////        .Where(d => d.Source != null &&
        ////               (d.Source.OriginalString.Contains("Dark.xaml") ||
        ////                d.Source.OriginalString.Contains("Teal.xaml")))
        ////        .ToList();

        ////    foreach (var dict in themeDictionaries)
        ////    {
        ////        this.Resources.MergedDictionaries.Remove(dict);
        ////    }

        ////    this.Resources.MergedDictionaries.Add(Settings.GetCurrentThemeDictionary());
        ////}  
        //private void OnThemeChanged(object sender, EventArgs e)
        //{
        //    // Удаляем все связанные с темой ресурсы
        //    var themeDictionaries = this.Resources.MergedDictionaries
        //        .Where(d => d.Source != null && d.Source.ToString().Contains("Theme"))
        //        .ToList();

        //    foreach (var dict in themeDictionaries)
        //    {
        //        this.Resources.MergedDictionaries.Remove(dict);
        //    }

        //    // Добавляем новую тему
        //    this.Resources.MergedDictionaries.Add(Settings.GetCurrentThemeDictionary());

        //    // Принудительное обновление стилей
        //    this.UpdateResources();
        //}
        private void OnThemeChanged(object sender, EventArgs e)
        {
            // Удаляем все связанные с темой ресурсы
            var themeDictionaries = this.Resources.MergedDictionaries
                .Where(d => d.Source != null &&
                       (d.Source.OriginalString.Contains("Dark.xaml") ||
                        d.Source.OriginalString.Contains("Teal.xaml")))
                .ToList();

            foreach (var dict in themeDictionaries)
            {
                this.Resources.MergedDictionaries.Remove(dict);
            }

            // Добавляем новую тему
            this.Resources.MergedDictionaries.Add(Settings.GetCurrentThemeDictionary());

            // Вместо UpdateVisualTree вызываем метод принудительного обновления ресурсов
            this.InvalidateVisual();
            UpdateResources(); // Явное обновление ресурсов элементов
        }
        private void UpdateResources()
        {
            // Обновляем ресурсы для всех элементов
            var labels = new[] { txtUsernameLabel, txtFullNameLabel, txtBirthDateLabel,
                         txtPhoneLabel, txtEmailLabel, txtLanguageLabel, txtThemeLabel };

            foreach (var label in labels)
            {
                label.SetResourceReference(TextBlock.ForegroundProperty, "MaterialDesignBody");
            }

            // Обновляем TextBox
            var textBoxes = new[] { txtUsername, txtFullName, txtBirthDate, txtPhone, txtEmail };
            foreach (var box in textBoxes)
            {
                box.SetResourceReference(Control.ForegroundProperty, "MaterialDesignBody");
                box.SetResourceReference(Control.BorderBrushProperty, "MaterialDesignTextBoxBorder");
            }

            // Обновляем ComboBox
            cmbLanguage.SetResourceReference(Control.ForegroundProperty, "MaterialDesignBody");
        }

        private void UpdateUI()
        {
            // Обновление заголовка окна
            Title = (string)this.TryFindResource("PersonalAccount");

            // Обновление текстов в ComboBox
            if (cmbLanguage.Items.Count > 0)
            {
                cmbLanguage.Items[0] = new ComboBoxItem
                {
                    Content = (string)this.TryFindResource("Russian")
                };
                cmbLanguage.Items[1] = new ComboBoxItem
                {
                    Content = (string)this.TryFindResource("English")
                };
            }
            else
            {
                cmbLanguage.Items.Add(new ComboBoxItem { Content = (string)this.TryFindResource("Russian") });
                cmbLanguage.Items.Add(new ComboBoxItem { Content = (string)this.TryFindResource("English") });
            }

            // Устанавливаем текущий выбор комбобокса
            cmbLanguage.SelectedIndex = Settings.Lang == Settings.Languages.EN ? 1 : 0;

            // Обновление текстовых элементов
            txtUsernameLabel.Text = (string)this.TryFindResource("Username");
            txtFullNameLabel.Text = (string)this.TryFindResource("FullName");
            txtBirthDateLabel.Text = (string)this.TryFindResource("BirthDate");
            txtPhoneLabel.Text = (string)this.TryFindResource("Phone");
            txtEmailLabel.Text = (string)this.TryFindResource("Email");
            txtLanguageLabel.Text = (string)this.TryFindResource("InterfaceLanguage");
            txtThemeLabel.Text = (string)this.TryFindResource("Theme");
            btnSave.Content = (string)this.TryFindResource("SaveChanges");

            // Обновление подсказок
            HintAssist.SetHint(txtUsername, (string)this.TryFindResource("Username"));
            HintAssist.SetHint(txtFullName, (string)this.TryFindResource("FullName"));
            HintAssist.SetHint(txtBirthDate, (string)this.TryFindResource("BirthDate"));
            HintAssist.SetHint(txtPhone, (string)this.TryFindResource("Phone"));
            HintAssist.SetHint(txtEmail, (string)this.TryFindResource("Email"));
        }

        protected override void OnClosed(EventArgs e)
        {
            Settings.changeLang -= OnLanguageChanged;
            Settings.changeTheme -= OnThemeChanged;
            base.OnClosed(e);
        }
    }
}