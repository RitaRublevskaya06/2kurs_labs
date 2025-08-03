using System;
using System.Configuration;
using System.Data;
using System.Data.OleDb;
using System.Data.Odbc;
using System.Windows;
using System.Data.SqlClient;
using System.IO;

namespace Lab08
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public static string str;
        string script = "";
        public static string connectionString;
        bool connectionChecked = false;
        DataTable planetsTable;
        DataTable satellitesTable;
        SqlConnection connection;
        SqlCommand command;
        SqlDataAdapter adapter1;
        SqlDataAdapter adapter2;
        public MainWindow()
        {
            InitializeComponent();
            Sort_Planets.Items.Add("Все строки и столбцы");
            Sort_Planets.Items.Add("По названию");
            Sort_Planets.Items.Add("По радиусу (возрастанию)");
            Sort_Planets.Items.Add("По радиусу (убыванию)");
            Sort_Planets.Items.Add("По температуре ядра (возрастанию)");
            Sort_Planets.Items.Add("По температуре ядра (убыванию)");

            Sort_Satellites.Items.Add("Все строки и столбцы");
            Sort_Satellites.Items.Add("По названию");
            Sort_Satellites.Items.Add("По радиусу (возрастанию)");
            Sort_Satellites.Items.Add("По радиусу (убыванию)");
            Sort_Satellites.Items.Add("По расстоянию от планеты (возрастанию)");
            Sort_Satellites.Items.Add("По расстоянию от планеты (убыванию)");
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            if(!connectionChecked)
                CheckConnection();
            try
            {
                connection = new SqlConnection(connectionString);
                connection.Open();

                string sqlExpression = "SELECT * FROM PLANETS";
                planetsTable = new DataTable();
                command = new SqlCommand(sqlExpression, connection);
                adapter1 = new SqlDataAdapter(command);
                adapter1.Fill(planetsTable);
                PlanetsGrid.ItemsSource = planetsTable.DefaultView;
                sqlExpression = "SELECT * FROM SATELLITES";
                satellitesTable = new DataTable();
                command = new SqlCommand(sqlExpression, connection);
                adapter2 = new SqlDataAdapter(command);
                adapter2.Fill(satellitesTable);
                SatellitesGrid.ItemsSource = satellitesTable.DefaultView;

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

        private void CheckConnection()
        {
            string masterConnectionString = "Data Source=127.0.0.1,1433;Integrated Security=True";
            connectionString = "Data Source=127.0.0.1,1433;Initial Catalog=Planets;Integrated Security=True";

            // Создание БД, если не существует
            using (var masterConnection = new SqlConnection(masterConnectionString))
            {
                masterConnection.Open();
                if (!DatabaseExists(masterConnection, "Planets"))
                {
                    new SqlCommand("CREATE DATABASE Planets", masterConnection).ExecuteNonQuery();
                }
            }

            // Инициализация таблиц и данных
            using (var planetsConnection = new SqlConnection(connectionString))
            {
                planetsConnection.Open();

                // Объявляем projectPath здесь, чтобы он был доступен во всех блоках
                var projectPath = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.FullName;

                // Создание таблиц, если они не существуют
                if (!TableExists(planetsConnection, "PLANETS"))
                {
                    string createTablesScript = File.ReadAllText(projectPath + @"\CreateScripts\SQLQuery1.sql");
                    new SqlCommand(createTablesScript, planetsConnection).ExecuteNonQuery();
                }

                // СОЗДАНИЕ ТРИГГЕРОВ
                if (!TriggerExists(planetsConnection, "trg_Planets_BeforeInsert"))
                {
                    string createTriggersScript = File.ReadAllText(projectPath + @"\CreateScripts\SQLQuery3.sql");
                    new SqlCommand(createTriggersScript, planetsConnection).ExecuteNonQuery();
                }

                // Вставка данных только при первом запуске
                if (IsTableEmpty(planetsConnection, "PLANETS"))
                {
                    string insertDataScript = File.ReadAllText(projectPath + @"\CreateScripts\SQLQuery2.sql");
                    new SqlCommand(insertDataScript, planetsConnection).ExecuteNonQuery();
                }
            }
        }

        private bool TriggerExists(SqlConnection connection, string triggerName)
        {
            var cmd = new SqlCommand(
                $"SELECT 1 FROM sys.triggers WHERE name = '{triggerName}'",
                connection
            );
            return cmd.ExecuteScalar() != null;
        }

        private bool IsTableEmpty(SqlConnection connection, string tableName)
        {
            var cmd = new SqlCommand($"SELECT COUNT(*) FROM {tableName}", connection);
            return (int)cmd.ExecuteScalar() == 0;
        }

        // Вспомогательные методы
        private bool DatabaseExists(SqlConnection connection, string dbName)
        {
            var cmd = new SqlCommand($"SELECT DB_ID('{dbName}')", connection);
            return cmd.ExecuteScalar() != DBNull.Value;
        }

        private bool TableExists(SqlConnection connection, string tableName)
        {
            var cmd = new SqlCommand(
                $"SELECT 1 FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = '{tableName}'",
                connection);
            return cmd.ExecuteScalar() != null;
        }

        private bool ProcedureExists(SqlConnection connection, string procedureName)
        {
            var cmd = new SqlCommand(
                $"SELECT 1 FROM sys.objects WHERE type = 'P' AND name = '{procedureName}'",
                connection);
            return cmd.ExecuteScalar() != null;
        }

        //private bool DatabaseExists(SqlConnection connection, string dbName)
        //{
        //    var cmd = new SqlCommand(
        //        $"SELECT database_id FROM sys.databases WHERE Name = '{dbName}'",
        //        connection);
        //    return cmd.ExecuteScalar() != null;
        //}

        private void ExecuteSqlFile(SqlTransaction transaction, string filePath)
        {
            string script = File.ReadAllText(filePath);
            new SqlCommand(script, transaction.Connection, transaction).ExecuteNonQuery();
        }



        private void Procedure1_Click(object sender, RoutedEventArgs e)
        {
            string sqlExpression = "PROC_COUNT_PLANETS";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(sqlExpression, connection);
                command.CommandType = System.Data.CommandType.StoredProcedure;
                var reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    str = $"{reader.GetName(0)}\t\n";

                    while (reader.Read())
                    {
                        object count = reader.GetValue(0);
                        str += $"{count}\t\n";
                    }
                }
                MessageBox.Show(str);
                reader.Close();
                Window_Loaded(new object(), new RoutedEventArgs());
            }
        }
        private void Procedure2_Click(object sender, RoutedEventArgs e)
        {
            string sqlExpression = "PROC_COUNT_SATELLITES";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(sqlExpression, connection);
                command.CommandType = System.Data.CommandType.StoredProcedure;
                var reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    str = $"{reader.GetName(0)}\t\n";

                    while (reader.Read())
                    {
                        object count = reader.GetValue(0);
                        str += $"{count}\t\n";
                    }
                }
                MessageBox.Show(str);
                reader.Close();
                Window_Loaded(new object(), new RoutedEventArgs());
            }
        }


        private void Update_Click(object sender, RoutedEventArgs e)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlTransaction transaction = connection.BeginTransaction();

                try
                {
                    var cmd1 = new SqlCommand("SELECT * FROM PLANETS", connection, transaction);
                    var localAdapter1 = new SqlDataAdapter(cmd1);
                    var builder1 = new SqlCommandBuilder(localAdapter1);

                    var cmd2 = new SqlCommand("SELECT * FROM SATELLITES", connection, transaction);
                    var localAdapter2 = new SqlDataAdapter(cmd2);
                    var builder2 = new SqlCommandBuilder(localAdapter2);

                    localAdapter1.Update(planetsTable);
                    localAdapter2.Update(satellitesTable);

                    transaction.Commit();
                    MessageBox.Show("Данные успешно обновлены!");
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    MessageBox.Show($"Ошибка обновления: {ex.Message}");
                }
            }

            Window_Loaded(sender, e);
        }


        //private void Delete_Planet_Click(object sender, RoutedEventArgs e)
        //{
        //    if (PlanetsGrid.SelectedItems != null)
        //    {
        //        using (SqlConnection connection = new SqlConnection(connectionString))
        //        {
        //            connection.Open();
        //            SqlTransaction transaction = connection.BeginTransaction();

        //            try
        //            {
        //                // Удаление строк из DataTable
        //                for (int i = 0; i < PlanetsGrid.SelectedItems.Count; i++)
        //                {
        //                    DataRowView datarowView = PlanetsGrid.SelectedItems[i] as DataRowView;
        //                    if (datarowView != null)
        //                    {
        //                        DataRow dataRow = (DataRow)datarowView.Row;
        //                        dataRow.Delete();
        //                    }
        //                }

        //                // Создание локального адаптера с транзакцией
        //                var adapter = new SqlDataAdapter("SELECT * FROM PLANETS", connection);
        //                adapter.SelectCommand.Transaction = transaction;
        //                var builder = new SqlCommandBuilder(adapter);

        //                // Обновление данных
        //                adapter.Update(planetsTable);

        //                transaction.Commit();
        //                MessageBox.Show("Планеты удалены!");
        //            }
        //            catch (Exception ex)
        //            {
        //                transaction.Rollback();
        //                MessageBox.Show($"Ошибка удаления: {ex.Message}");
        //            }
        //        }
        //    }
        //    Window_Loaded(sender, e);
        //}
        private void Delete_Planet_Click(object sender, RoutedEventArgs e)
        {
            if (PlanetsGrid.SelectedItems != null)
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    SqlTransaction transaction = connection.BeginTransaction();

                    try
                    {
                        // Удаление строк из DataTable
                        for (int i = 0; i < PlanetsGrid.SelectedItems.Count; i++)
                        {
                            DataRowView datarowView = PlanetsGrid.SelectedItems[i] as DataRowView;
                            if (datarowView != null)
                            {
                                DataRow dataRow = (DataRow)datarowView.Row;
                                dataRow.Delete();
                            }
                        }

                        // Создание локального адаптера с транзакцией
                        var adapter = new SqlDataAdapter("SELECT * FROM PLANETS", connection);
                        adapter.SelectCommand.Transaction = transaction;
                        var builder = new SqlCommandBuilder(adapter);

                        // Обновление данных
                        adapter.Update(planetsTable);

                        transaction.Commit();
                        MessageBox.Show("Планеты удалены!");
                    }
                    catch (SqlException ex)
                    {
                        transaction.Rollback();

                        // Обработка ошибок триггера
                        if (ex.Number >= 50000 && ex.Number <= 51000)
                        {
                            // Это пользовательская ошибка из RAISERROR
                            MessageBox.Show($"Ошибка триггера: {ex.Message}");
                        }
                        else
                        {
                            MessageBox.Show($"Ошибка SQL: {ex.Message}");
                        }
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        MessageBox.Show($"Общая ошибка: {ex.Message}");
                    }
                }
            }
            Window_Loaded(sender, e);
        }
        private void Delete_Satellite_Click(object sender, RoutedEventArgs e)
        {
            if (SatellitesGrid.SelectedItems != null)
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    SqlTransaction transaction = connection.BeginTransaction();

                    try
                    {
                        for (int i = 0; i < SatellitesGrid.SelectedItems.Count; i++)
                        {
                            DataRowView datarowView = SatellitesGrid.SelectedItems[i] as DataRowView;
                            if (datarowView != null)
                            {
                                DataRow dataRow = (DataRow)datarowView.Row;
                                dataRow.Delete();
                            }
                        }

                        // Создание локального адаптера с транзакцией
                        var adapter = new SqlDataAdapter("SELECT * FROM SATELLITES", connection);
                        adapter.SelectCommand.Transaction = transaction;
                        var builder = new SqlCommandBuilder(adapter);

                        adapter.Update(satellitesTable);

                        transaction.Commit();
                        MessageBox.Show("Спутники удалены!");
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        MessageBox.Show($"Ошибка удаления: {ex.Message}");
                    }
                }
            }
            Window_Loaded(sender, e);
        }

        private void SortSatellites(object sender, RoutedEventArgs e)
        {
            switch (Sort_Satellites.SelectedIndex)
            {
                case 0:
                    script = "Name ASC";
                    break;
                case 1:
                    script = "Name ASC";
                    break;
                case 2:
                    script = "Radius ASC";
                    break;
                case 3:
                    script = "Radius DESC";
                    break;
                case 4:
                    script = "Planetary_Distance ASC";
                    break;
                case 5:
                    script = "Planetary_Distance DESC";
                    break;
            }
            satellitesTable.DefaultView.Sort = script;
            SatellitesGrid.ItemsSource = satellitesTable.DefaultView;
        }
        private void SortPlanets(object sender, RoutedEventArgs e)
        {
            switch (Sort_Planets.SelectedIndex)
            {
                case 0:
                    script = "Name ASC";
                    break;
                case 1:
                    script = "Name ASC";
                    break;
                case 2:
                    script = "Radius ASC";
                    break;
                case 3:
                    script = "Radius DESC";
                    break;
                case 4:
                    script = "Core_Temperature ASC";
                    break;
                case 5:
                    script = "Core_Temperature DESC";
                    break;
            }
            planetsTable.DefaultView.Sort = script;
            PlanetsGrid.ItemsSource = planetsTable.DefaultView;
        }
        private void Add_Planet_Click(object sender, RoutedEventArgs e)
        {
            var pl = new Planet();
            try
            {
                pl.ShowDialog();
                Window_Loaded(sender, e);
            }
            catch (InvalidOperationException ex)
            {
                MessageBox.Show(ex.Message);
                pl.Close();
            }
        }

        private void Add_Satellite_Click(object sender, RoutedEventArgs e)
        {
            var sat = new Satellite();
            try
            {
                sat.ShowDialog();
                Window_Loaded(sender, e);
            }
            catch(InvalidOperationException ex)
            {
                MessageBox.Show(ex.Message);
                sat.Close();
            }
        }
    }
}
