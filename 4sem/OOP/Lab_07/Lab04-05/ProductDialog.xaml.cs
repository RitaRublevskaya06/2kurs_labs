using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace Lab04_05
{
    public partial class ProductDialog : Window
    {
        private Product _product;
        private string _imageFileName;
        private bool _isEditMode;
        private string _imagesDirectory;

        public ProductDialog()
        {
            InitializeComponent();
            SetupUI(false);
            InitializeImagesDirectory();
            InitializeProductTypes();
        }

        public ProductDialog(Product product) : this()
        {
            _product = product ?? throw new ArgumentNullException(nameof(product));
            _isEditMode = true;
            SetupUI(true);
            LoadProductData();
        }

        //private void InitializeImagesDirectory()
        //{
        //    try
        //    {
        //        var projectPath = Directory.GetCurrentDirectory();
        //        _imagesDirectory = Path.Combine(projectPath, "images");

        //        if (!Directory.Exists(_imagesDirectory))
        //        {
        //            Directory.CreateDirectory(_imagesDirectory);
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show($"Не удалось инициализировать папку для изображений: {ex.Message}",
        //            "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
        //    }
        //}
        private void InitializeImagesDirectory()
        {
            try
            {
                // Используйте абсолютный путь к папке проекта
                var projectPath = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.FullName;
                _imagesDirectory = Path.Combine(projectPath, "images");

                Console.WriteLine($"Папка изображений: {_imagesDirectory}");

                if (!Directory.Exists(_imagesDirectory))
                {
                    Directory.CreateDirectory(_imagesDirectory);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка инициализации папки изображений: {ex.Message}");
            }
        }

        private void InitializeProductTypes()
        {
            try
            {
                ProductType.Items.Clear();
                foreach (var type in StoreDb.ProductTypes)
                {
                    var listBoxItem = new ListBoxItem
                    {
                        Content = type.PType, // Используем PType вместо TypeNameRus
                        Tag = type.ProductTypeId // Используем ProductTypeId вместо TypeCode
                    };
                    ProductType.Items.Add(listBoxItem);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка загрузки типов продуктов: {ex.Message}",
                    "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void SetupUI(bool isEditMode)
        {
            EditBtn.Visibility = isEditMode ? Visibility.Visible : Visibility.Collapsed;
            AddBtn.Visibility = isEditMode ? Visibility.Collapsed : Visibility.Visible;
        }

        private void LoadProductData()
        {
            try
            {
                if (_product == null) return;

                nameFieldRus.Text = _product.PNameRus;
                nameFieldEn.Text = _product.PNameEn;
                descriptionFieldEn.Text = _product.PDescriptionEn;
                descriptionFieldRus.Text = _product.PDescriptionRus;
                priceField.Text = _product.Price.ToString();

                // Выбираем соответствующий тип продукта
                foreach (ListBoxItem item in ProductType.Items)
                {
                    if ((int)item.Tag == _product.ProductType)
                    {
                        ProductType.SelectedItem = item;
                        break;
                    }
                }

                if (!string.IsNullOrEmpty(_product.PImage))
                {
                    LoadProductImage(_product.PImage);
                }
            }
            catch (Exception ex)
            {
                ShowError($"Ошибка загрузки данных: {ex.Message}");
            }
        }

        private void LoadProductImage(string imageName)
        {
            try
            {
                var imagePath = Path.Combine(_imagesDirectory, imageName);
                if (!File.Exists(imagePath)) return;

                var imageSource = new BitmapImage();
                imageSource.BeginInit();
                imageSource.CacheOption = BitmapCacheOption.OnLoad;
                imageSource.UriSource = new Uri(imagePath);
                imageSource.EndInit();
                imageSource.Freeze();

                image.Fill = new ImageBrush(imageSource);
                _imageFileName = imageName;
                image.Stroke = Brushes.Transparent;
            }
            catch (Exception ex)
            {
                ShowError($"Ошибка загрузки изображения: {ex.Message}");
            }
        }

        private void AddImage(object sender, RoutedEventArgs e)
        {
            var filePicker = new OpenFileDialog
            {
                DefaultExt = ".jpg",
                Filter = "Image Files (*.jpg;*.jpeg;*.png)|*.jpg;*.jpeg;*.png",
                Title = "Выберите изображение продукта"
            };

            if (filePicker.ShowDialog() == true)
            {
                try
                {
                    string sourcePath = filePicker.FileName;
                    string extension = Path.GetExtension(sourcePath);
                    string uniqueFileName = $"{Guid.NewGuid()}{extension}";
                    string targetPath = Path.Combine(_imagesDirectory, uniqueFileName);

                    File.Copy(sourcePath, targetPath);
                    _imageFileName = uniqueFileName;
                    LoadProductImage(uniqueFileName);
                }
                catch (IOException ioEx)
                {
                    ShowError($"Файл занят другим процессом: {ioEx.Message}");
                }
                catch (Exception ex)
                {
                    ShowError($"Ошибка: {ex.Message}");
                }
            }
        }

        private void EditProductInfo(object sender, RoutedEventArgs e)
        {
            try
            {
                ValidateInputs();
                UpdateProduct();
                ValidateProduct();

                _product.RaisePropertyChanged("Price");
                _product.RaisePropertyChanged("PNameRus");
                _product.RaisePropertyChanged("PNameEn");

                StoreDb.SaveProducts();

                // Показываем кастомное сообщение
                new Message("Success").ShowDialog();
                this.DialogResult = true;
            }
            catch (ValidationException ex)
            {
                // Используем ключи из валидационных атрибутов
                new Message(ex.ValidationResult.ErrorMessage).ShowDialog();
            }
            catch (Exception ex)
            {
                new Message("UnknownError").ShowDialog();
            }
        }

        private void AddProduct(object sender, RoutedEventArgs e)
        {
            try
            {
                ValidateInputs();
                _product = new Product
                {
                    ProductCode = StoreDb.Products.Max(p => p.ProductCode) + 1,
                    isActive = 1
                };

                UpdateProduct();
                ValidateProduct();

                StoreDb.Products.Add(_product);
                StoreDb.SaveProducts();

                // Показываем кастомное сообщение
                new Message("Success").ShowDialog();
                this.DialogResult = true;
            }
            catch (ValidationException ex)
            {
                new Message(ex.ValidationResult.ErrorMessage).ShowDialog();
            }
            catch (Exception ex)
            {
                new Message("UnknownError").ShowDialog();
            }
        }

        private void ValidateInputs()
        {
            if (string.IsNullOrWhiteSpace(nameFieldRus.Text) ||
                string.IsNullOrWhiteSpace(nameFieldEn.Text))
                throw new ArgumentException("Заполните названия продукта");

            if (!decimal.TryParse(priceField.Text, out decimal price) || price <= 0)
                throw new FormatException("Некорректная цена продукта");

            if (ProductType.SelectedItem == null)
                throw new ArgumentException("Выберите тип продукта");

            if (string.IsNullOrEmpty(_imageFileName))
                throw new ArgumentException("Добавьте изображение продукта");
        }

        private void UpdateProduct()
        {
            _product.PNameRus = nameFieldRus.Text;
            _product.PNameEn = nameFieldEn.Text;
            _product.PDescriptionRus = descriptionFieldRus.Text;
            _product.PDescriptionEn = descriptionFieldEn.Text;
            _product.Price = decimal.Parse(priceField.Text);
            _product.ProductType = (int)((ListBoxItem)ProductType.SelectedItem).Tag;
            _product.PImage = _imageFileName;
        }

        private void ValidateProduct()
        {
            var results = new List<System.ComponentModel.DataAnnotations.ValidationResult>(); // Уточнение namespace
            var context = new ValidationContext(_product);

            if (!Validator.TryValidateObject(_product, context, results, true))
            {
                throw new ValidationException(results.First().ErrorMessage);
            }
        }

        //private void Close(object sender, RoutedEventArgs e)
        //{
        //    DialogResult = false;
        //    Close();
        //}
        private void Close(object sender, RoutedEventArgs e)
        {
            this.DialogResult = false; // Для отмены операции
        }

        private void ImagePanel_Drop(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                try
                {
                    string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);
                    if (files.Length == 0) return;

                    string sourcePath = files[0];
                    string extension = Path.GetExtension(sourcePath);
                    string uniqueFileName = $"{Guid.NewGuid()}{extension}";
                    string targetPath = Path.Combine(_imagesDirectory, uniqueFileName);

                    File.Copy(sourcePath, targetPath);
                    _imageFileName = uniqueFileName;
                    LoadProductImage(uniqueFileName);
                }
                catch (Exception ex)
                {
                    ShowError($"Ошибка при обработке изображения: {ex.Message}");
                }
            }
        }

        private void Drop_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                image.Fill = Application.Current.Resources["PrimaryHueLightBrush"] as Brush;
            }
        }

        private void Drop_DragLeave(object sender, DragEventArgs e)
        {
            image.Fill = Brushes.Transparent;
        }

        private void Border_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
            {
                DragMove();
            }
        }

        private void ShowError(string message)
        {
            MessageBox.Show(message, "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
        }

        private void ShowSuccess(string message)
        {
            MessageBox.Show(message, "Успех", MessageBoxButton.OK, MessageBoxImage.Information);
        }
    }
}