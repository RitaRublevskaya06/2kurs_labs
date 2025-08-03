using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Windows;

namespace Lab04_05
{
    public static class StoreDb
    {
        private static readonly string ProductsPath =
            Path.Combine(Directory.GetCurrentDirectory(), "Data", "Products.json");

        private static readonly string TypesPath =
            Path.Combine(Directory.GetCurrentDirectory(), "Data", "ProductType.json");

        public static ObservableCollection<Product> Products { get; private set; } = new ObservableCollection<Product>();
        public static ObservableCollection<ProductType> ProductTypes { get; private set; } = new ObservableCollection<ProductType>();

        //public static ObservableCollection<Product> products { get; set; } // Название с маленькой буквы

        private static readonly JsonSerializerOptions Options = new JsonSerializerOptions
        {
            WriteIndented = true,
            ReferenceHandler = ReferenceHandler.Preserve,
            Encoder = System.Text.Encodings.Web.JavaScriptEncoder.UnsafeRelaxedJsonEscaping
        };

        static StoreDb()
        {
            LoadData();
            Products.CollectionChanged += Products_CollectionChanged;
        }



        public static void LoadData()
        {
            try
            {
                // Загрузка продуктов
                if (File.Exists(ProductsPath))
                {
                    string json = File.ReadAllText(ProductsPath);
                    Products = JsonSerializer.Deserialize<ObservableCollection<Product>>(json, Options)
                               ?? new ObservableCollection<Product>();
                }

                // Загрузка типов продуктов
                if (File.Exists(TypesPath))
                {
                    string json = File.ReadAllText(TypesPath);
                    ProductTypes = JsonSerializer.Deserialize<ObservableCollection<ProductType>>(json, Options)
                                  ?? new ObservableCollection<ProductType>();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка загрузки данных: {ex.Message}");
            }
        }

        private static void Products_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            SaveProducts();
            if (e.NewItems != null)
            {
                foreach (Product item in e.NewItems)
                {
                    item.PropertyChanged += Product_PropertyChanged;
                }
            }
        }

        private static void Product_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            SaveProducts();
        }

        //public static void SaveProducts()
        //{
        //    try
        //    {
        //        Directory.CreateDirectory(Path.GetDirectoryName(ProductsPath));
        //        string json = JsonSerializer.Serialize(Products, Options);
        //        File.WriteAllText(ProductsPath, json);
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show($"Ошибка сохранения: {ex.Message}");
        //    }
        //}
        public static void SaveProducts()
        {
            try
            {
                Console.WriteLine($"Пытаюсь сохранить в: {ProductsPath}");
                Directory.CreateDirectory(Path.GetDirectoryName(ProductsPath));
                string json = JsonSerializer.Serialize(Products, Options);
                File.WriteAllText(ProductsPath, json);
                Console.WriteLine("Успешно сохранено");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка сохранения: {ex.Message}");
                MessageBox.Show($"Ошибка сохранения: {ex.Message}");
            }
        }
    }
}