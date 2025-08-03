using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using Newtonsoft.Json;

namespace Lab04_05
{
    public partial class ClientProductsPage : Page
    {
        private List<Product> _products;
        private List<ProductType> _productTypes;

        public ClientProductsPage()
        {
            InitializeComponent();
            LoadData();
            CreateProductCards();
        }

        private void LoadData()
        {
            try
            {
                string dataFolder = Path.Combine(Directory.GetCurrentDirectory(), "Data");

                if (!Directory.Exists(dataFolder))
                {
                    MessageBox.Show($"Папка Data не найдена: {dataFolder}");
                    return;
                }

                string productsPath = Path.Combine(dataFolder, "Products.json");
                string typesPath = Path.Combine(dataFolder, "ProductType.json");

                if (!File.Exists(productsPath) || !File.Exists(typesPath))
                {
                    MessageBox.Show($"Не найдены необходимые файлы в папке Data");
                    return;
                }

                string productsJson = File.ReadAllText(productsPath);
                string typesJson = File.ReadAllText(typesPath);

                _products = JsonConvert.DeserializeObject<List<Product>>(productsJson);
                _productTypes = JsonConvert.DeserializeObject<List<ProductType>>(typesJson);

                foreach (var product in _products)
                {
                    product.productType = _productTypes.FirstOrDefault(t => t.ProductTypeId == product.ProductType);
                }
            }
            catch (JsonException jsonEx)
            {
                MessageBox.Show($"Ошибка формата JSON: {jsonEx.Message}");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка загрузки данных: {ex.Message}");
            }
        }

        public void UpdateLanguage()
        {
            var hint = SearchField.Template.FindName("Hint", SearchField) as TextBlock;
            if (hint != null)
            {
                hint.Text = (string)Application.Current.TryFindResource("Search");
            }
            CreateProductCards();
        }

        private void CreateProductCards()
        {
            products.Children.Clear();
            if (_products == null || _productTypes == null) return;

            foreach (var product in _products.Where(p => p.isActive == 1))
            {
                products.Children.Add(CreateProductCard(product));
            }
        }

        private UIElement CreateProductCard(Product product)
        {
            var card = new Border
            {
                Background = Brushes.White,
                CornerRadius = new CornerRadius(5),
                Margin = new Thickness(10),
                Width = 200,
                Height = 300,
                Effect = new System.Windows.Media.Effects.DropShadowEffect
                {
                    BlurRadius = 10,
                    Color = Colors.Gray,
                    Direction = 270,
                    Opacity = 0.3,
                    ShadowDepth = 5
                }
            };

            var grid = new Grid();
            grid.RowDefinitions.Add(new RowDefinition { Height = new GridLength(1, GridUnitType.Star) });
            grid.RowDefinitions.Add(new RowDefinition { Height = GridLength.Auto });

            var contentStack = new StackPanel();
            Grid.SetRow(contentStack, 0);

            // Изображение продукта
            var image = new Image
            {
                Height = 120,
                Width = 180,
                Margin = new Thickness(10, 10, 10, 5),
                Stretch = Stretch.UniformToFill
            };

            try
            {
                image.Source = new System.Windows.Media.Imaging.BitmapImage(
                    new Uri($"pack://application:,,,/images/{product.PImage}"));
            }
            catch
            {
                image.Source = new System.Windows.Media.Imaging.BitmapImage(
                    new Uri("pack://application:,,,/images/default.jpg"));
            }
            contentStack.Children.Add(image);

            // Название продукта
            contentStack.Children.Add(new TextBlock
            {
                Text = Settings.Lang == Settings.Languages.EN ? product.PNameEn : product.PNameRus,
                FontWeight = FontWeights.Bold,
                Margin = new Thickness(10, 0, 10, 5),
                TextWrapping = TextWrapping.Wrap
            });

            // Тип продукта
            contentStack.Children.Add(new TextBlock
            {
                Text = product.productType?.PType ?? "Unknown",
                Foreground = Brushes.Gray,
                Margin = new Thickness(10, 0, 10, 5),
                FontSize = 12
            });

            // Цена
            contentStack.Children.Add(new TextBlock
            {
                Text = $"{product.Price} ₽",
                FontWeight = FontWeights.Bold,
                Margin = new Thickness(10, 0, 10, 5),
                Foreground = Brushes.DarkGreen
            });

            // Описание
            contentStack.Children.Add(new TextBlock
            {
                Text = Settings.Lang == Settings.Languages.EN ? product.PDescriptionEn : product.PDescriptionRus,
                Margin = new Thickness(10, 0, 10, 0),
                TextWrapping = TextWrapping.Wrap,
                FontSize = 12,
                MaxHeight = 40,
                TextTrimming = TextTrimming.CharacterEllipsis
            });

            // Кнопка "Записаться"
            var buttonContainer = new StackPanel
            {
                VerticalAlignment = VerticalAlignment.Bottom,
                Margin = new Thickness(0, 10, 0, 10)
            };
            Grid.SetRow(buttonContainer, 1);

            var bookButton = new Button
            {
                Content = Settings.Lang == Settings.Languages.EN ? "Book" : "Записаться",
                Style = (Style)FindResource("MidButton"),
                Margin = new Thickness(10, 0, 10, 0),
                Tag = product.ProductCode
            };

            bookButton.Click += (sender, e) =>
            {
                string serviceName = Settings.Lang == Settings.Languages.EN ? product.PNameEn : product.PNameRus;
                AppointmentForm appointmentForm = new AppointmentForm(serviceName);
                appointmentForm.Owner = Window.GetWindow(this);
                appointmentForm.ShowDialog();
            };

            buttonContainer.Children.Add(bookButton);
            grid.Children.Add(contentStack);
            grid.Children.Add(buttonContainer);
            card.Child = grid;

            return card;
        }

        private void SearchField_TextChanged(object sender, TextChangedEventArgs e)
        {
            FilterProducts(SearchField.Text.ToLower());
        }

        private void Search_KeyDown(object sender, System.Windows.Input.KeyEventArgs e)
        {
            if (e.Key == System.Windows.Input.Key.Enter)
            {
                FilterProducts(SearchField.Text.ToLower());
            }
        }

        private void FilterProducts(string searchText)
        {
            products.Children.Clear();

            if (string.IsNullOrWhiteSpace(searchText))
            {
                CreateProductCards();
                return;
            }

            var filteredProducts = _products.Where(p =>
                (p.PNameEn?.ToLower().Contains(searchText) ?? false) ||
                (p.PNameRus?.ToLower().Contains(searchText) ?? false) ||
                (p.PDescriptionEn?.ToLower().Contains(searchText) ?? false) ||
                (p.PDescriptionRus?.ToLower().Contains(searchText) ?? false) ||
                (p.productType?.PType?.ToLower().Contains(searchText) ?? false))
                .Where(p => p.isActive == 1)
                .ToList();

            if (filteredProducts.Count == 0)
            {
                products.Children.Add(new TextBlock
                {
                    Text = Settings.Lang == Settings.Languages.EN ? "No products found" : "Товары не найдены",
                    FontSize = 16,
                    HorizontalAlignment = HorizontalAlignment.Center,
                    Margin = new Thickness(0, 20, 0, 0)
                });
                return;
            }

            foreach (var product in filteredProducts)
            {
                products.Children.Add(CreateProductCard(product));
            }
        }
    }
}