using System;
using System.Collections.Generic;
using System.Data.Entity;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Lab10
{
    /// <summary>
    /// Interaction logic for Ex2.xaml
    /// </summary>
    public partial class Ex2 : Page
    {
        private DatabaseUnit db;
        public Ex2()
        {
            InitializeComponent();

            db = new DatabaseUnit();
            db.Database.CreateIfNotExists();
            ordersGrid.ItemsSource = db.Orders.GetAll();
        }

        private async void updateButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                await db.SaveAsync();
                ordersGrid.ItemsSource = null;
                ordersGrid.ItemsSource = db.Orders.GetAll();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void deleteButton_Click(object sender, RoutedEventArgs e)
        {
            if (ordersGrid.SelectedItems.Count > 0)
            {
                for (int i = 0; i < ordersGrid.SelectedItems.Count; i++)
                {
                    Order order = ordersGrid.SelectedItems[i] as Order;
                    if (order != null)
                    {
                        using (var transaction = db.Database.BeginTransaction())
                        {
                            try
                            {
                                db.Orders.Delete(order.ID);
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
        }
        // Добавление
        private async void addButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var newOrder = new Order
                {
                    Order_price = 0,
                    Date_of_order = DateTime.Now,
                    PersonId = 1
                };

                db.Orders.Add(newOrder);
                await db.SaveAsync();
                ordersGrid.ItemsSource = db.Orders.GetAll();
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
                if (ordersGrid.SelectedItem is Order selectedOrder)
                {
                    selectedOrder.Order_price += 100;
                    db.Orders.Update(selectedOrder);
                    await db.SaveAsync();
                    ordersGrid.ItemsSource = db.Orders.GetAll();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка: {ex.Message}");
            }
        }
    }
}
