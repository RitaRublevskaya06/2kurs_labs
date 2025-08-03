using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

namespace Lab09
{
    /// <summary>
    /// Interaction logic for Ex2.xaml
    /// </summary>
    public partial class Ex2 : Page
    {
        private readonly Context db;
        private ObservableCollection<Order> _orders;
        public Ex2()
        {
            InitializeComponent();

            var context = new Context();
            context.Database.CreateIfNotExists();

            db = new Context();
            db.Orders.Load();
            ordersGrid.ItemsSource = db.Orders.Local.ToBindingList();
            _orders = new ObservableCollection<Order>(db.Orders.Local);
        }

        private async void updateButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                // Асинхронность
                await db.SaveChangesAsync();
                ordersGrid.ItemsSource = null;
                ordersGrid.ItemsSource = db.Orders.Local.ToBindingList();
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
                        // Транзакции
                        using (var transaction = db.Database.BeginTransaction())
                        {
                            try
                            {
                                db.Orders.Remove(order);
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
                await db.SaveChangesAsync();
                _orders.Add(newOrder);
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
                    await db.SaveChangesAsync();
                    var index = _orders.IndexOf(selectedOrder);
                    _orders[index] = selectedOrder;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка: {ex.Message}");
            }
        }
    }
}
