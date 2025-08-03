using Microsoft.Win32;
using System;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Windows;
using System.Windows.Media.Imaging;

namespace Lab08
{
    public partial class Planet : Window
    {
        private string filePath; // Храним путь к выбранному файлу
        private string connectionString;

        public Planet()
        {
            InitializeComponent();
            connectionString = MainWindow.connectionString;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                OpenFileDialog openFileDialog = new OpenFileDialog();
                openFileDialog.Filter = "Image Files (*.jpg; *.jpeg; *.png)|*.jpg; *.jpeg; *.png";
                if (openFileDialog.ShowDialog() == true)
                {
                    filePath = openFileDialog.FileName; // Сохраняем путь к файлу

                    // Показываем превью изображения
                    var bitmap = new BitmapImage();
                    using (var stream = new FileStream(filePath, FileMode.Open, FileAccess.Read, FileShare.Read))
                    {
                        bitmap.BeginInit();
                        bitmap.CacheOption = BitmapCacheOption.OnLoad;
                        bitmap.StreamSource = stream;
                        bitmap.EndInit();
                    }
                    bitmap.Freeze();
                    imgDynamic.Source = bitmap;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка: {ex.Message}");
            }
        }

        private void Button_Click1(object sender, RoutedEventArgs e)
        {
            string script = @"INSERT INTO PLANETS 
                    (Name, Radius, Core_Temperature, Have_Atmosphere, Have_Life, Image) 
                    VALUES
                    (@name, @radius, @temp, @atm, @life, @image)";

            byte[] imageBytes = null;

            // Читаем файл изображения в байтовый массив
            if (!string.IsNullOrEmpty(filePath) && File.Exists(filePath))
            {
                try
                {
                    imageBytes = File.ReadAllBytes(filePath);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Ошибка чтения файла: {ex.Message}");
                    return;
                }
            }

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    using (SqlTransaction transaction = connection.BeginTransaction())
                    {
                        try
                        {
                            using (SqlCommand command = new SqlCommand(script, connection, transaction))
                            {
                                command.Parameters.AddWithValue("@name", Name.Text);
                                command.Parameters.AddWithValue("@radius", Convert.ToDouble(Radius.Text));
                                command.Parameters.AddWithValue("@temp", Convert.ToDouble(Temp.Text));
                                command.Parameters.AddWithValue("@atm", Atm.IsChecked ?? false);
                                command.Parameters.AddWithValue("@life", Life.IsChecked ?? false);

                                // Добавляем параметр изображения
                                SqlParameter imageParam = command.Parameters.Add("@image", SqlDbType.VarBinary, -1);
                                if (imageBytes != null && imageBytes.Length > 0)
                                {
                                    imageParam.Value = imageBytes;
                                }
                                else
                                {
                                    imageParam.Value = DBNull.Value;
                                }

                                command.ExecuteNonQuery();
                                transaction.Commit();
                                this.Close();
                            }
                        }
                        catch (Exception ex)
                        {
                            transaction.Rollback();
                            MessageBox.Show($"Ошибка сохранения: {ex.Message}");
                        }
                    }
                }
                catch (SqlException ex)
                {
                    MessageBox.Show($"Ошибка подключения: {ex.Message}");
                }
            }
        }
    }
}
