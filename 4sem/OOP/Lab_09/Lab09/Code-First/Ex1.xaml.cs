using System;
using System.Data.Entity;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace Lab09
{
    public partial class Ex1 : Page
    {
        private Context db;

        public Ex1()
        {
            InitializeComponent();
            InitializeDatabase();
        }

        private void InitializeDatabase()
        {
            db = new Context();
            db.Database.CreateIfNotExists();
            db.People.Load();
            peopleGrid.ItemsSource = db.People.Local.ToBindingList();
        }

        // Обновление данных
        private async void updateButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                await db.SaveChangesAsync();
                peopleGrid.ItemsSource = db.People.Local.ToBindingList();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        // Удаление
        private void deleteButton_Click(object sender, RoutedEventArgs e)
        {
            if (peopleGrid.SelectedItems.Count > 0)
            {
                foreach (Person person in peopleGrid.SelectedItems)
                {
                    using (var transaction = db.Database.BeginTransaction())
                    {
                        try
                        {
                            var orders = db.Orders.Where(o => o.PersonId == person.ID);
                            db.Orders.RemoveRange(orders);

                            db.People.Remove(person);

                            db.SaveChanges();
                            transaction.Commit();
                        }
                        catch (Exception ex)
                        {
                            transaction.Rollback();
                            MessageBox.Show(ex.Message);
                        }
                    }
                }
            }
        }

        // Добавление
        private async void addButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var newPerson = new Person
                {
                    Name = "Новый клиент",
                    Phone = "11111111"
                };

                db.People.Add(newPerson);
                await db.SaveChangesAsync(); // Сохранение в БД
                peopleGrid.ItemsSource = db.People.Local.ToBindingList(); // Обновление DataGrid
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка: {ex.Message}");
            }
        }

        // Редактирование
        private async void editButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (peopleGrid.SelectedItem is Person selectedPerson)
                {
                    selectedPerson.Name += " (изменено)";
                    db.Entry(selectedPerson).State = EntityState.Modified;
                    await db.SaveChangesAsync();
                    peopleGrid.ItemsSource = db.People.Local.ToBindingList();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка: {ex.Message}");
            }
        }
    }
}