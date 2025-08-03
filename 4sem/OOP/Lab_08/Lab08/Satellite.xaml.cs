using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
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
using System.Windows.Shapes;

namespace Lab08
{
    /// <summary>
    /// Interaction logic for Owner.xaml
    /// </summary>
    public partial class Satellite : Window
    {
        public string path; 
        string script = "";
        string connectionString;
        SqlConnection connection;
        SqlCommand command;
        SqlDataAdapter adapter1;
        public Satellite()
        {
            InitializeComponent();
            connectionString = MainWindow.connectionString;
        }
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            try
            {
                List<string> planets = new List<string>();
                using (connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    string sqlExpression = "SELECT Name FROM PLANETS";
                    command = new SqlCommand(sqlExpression, connection);
                    adapter1 = new SqlDataAdapter(command);
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                object name = reader.GetValue(0);
                                planets.Add(name.ToString());
                            }
                        }
                    }
                    Planets.ItemsSource = planets;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                connection.Close();
            }
        }
        //private void Button_Click(object sender, RoutedEventArgs e)
        //{
        //    try
        //    {
        //        OpenFileDialog openFileDialog = new OpenFileDialog();
        //        openFileDialog.Filter = "JPG Files (*.jpg)|*.jpg|JPEG Files (*.jpeg)|*.jpeg|PNG Files (*.png)|*.png";
        //        if (openFileDialog.ShowDialog() == true)
        //        {
        //            string filePath = openFileDialog.FileName;

        //            string[] parts = filePath.Split('\\');

        //            path = parts[parts.Length - 1];
        //            var projectPath = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.FullName;

        //            File.Copy(filePath, projectPath + "/images/" + path, true);

        //            var bitmap = new BitmapImage();
        //            using (var stream = new FileStream(projectPath + "/images/" + path, FileMode.Open, FileAccess.Read, FileShare.Read))
        //            {
        //                bitmap.BeginInit();
        //                bitmap.CacheOption = BitmapCacheOption.OnLoad;
        //                bitmap.StreamSource = stream;
        //                bitmap.EndInit();
        //            }
        //            imgDynamic.Source = bitmap;

        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show(ex.Message);
        //    }

        //}

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                OpenFileDialog openFileDialog = new OpenFileDialog();
                openFileDialog.Filter = "Image Files (*.jpg; *.jpeg; *.png)|*.jpg; *.jpeg; *.png";
                if (openFileDialog.ShowDialog() == true)
                {
                    string sourcePath = openFileDialog.FileName;
                    string fileName = System.IO.Path.GetFileName(sourcePath);
                    var projectPath = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.FullName;
                    string destPath = System.IO.Path.Combine(projectPath, "images", fileName);

                    // Создание папки, если её нет
                    Directory.CreateDirectory(System.IO.Path.GetDirectoryName(destPath));

                    // Копирование с перезаписью
                    File.Copy(sourcePath, destPath, true);

                    // Загрузка изображения без блокировки файла
                    var bitmap = new BitmapImage();
                    using (var stream = new FileStream(destPath, FileMode.Open, FileAccess.Read, FileShare.Read))
                    {
                        bitmap.BeginInit();
                        bitmap.CacheOption = BitmapCacheOption.OnLoad;
                        bitmap.StreamSource = stream;
                        bitmap.EndInit();
                    }
                    bitmap.Freeze(); // Для потокобезопасности
                    imgDynamic.Source = bitmap;
                    path = fileName;
                }
            }
            catch (IOException ioEx)
            {
                MessageBox.Show($"Файл занят: {ioEx.Message}");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка: {ex.Message}");
            }
        }

        private void Button_Click1(object sender, RoutedEventArgs e)
        {
            string script = @"INSERT INTO SATELLITES 
                    (Name, Planet_Name, Radius, Planetary_Distance, Image) 
                    VALUES
                    (@name, @planet, @radius, @distance, @image)";

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
                                command.Parameters.AddWithValue("@planet", Planets.SelectedItem != null
                                                                                                ? (object)Planets.SelectedItem.ToString()
                                                                                                : DBNull.Value);
                                command.Parameters.AddWithValue("@radius", Radius.Text);
                                command.Parameters.AddWithValue("@distance", Distance.Text);
                                command.Parameters.AddWithValue("@image", !string.IsNullOrEmpty(path) ? (object)path : DBNull.Value);

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
