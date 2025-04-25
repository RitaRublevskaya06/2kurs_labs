using System;
using System.Collections;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using OOP_lab9;

namespace OOP_Lab9
{
    class Program
    {
        static void Main(string[] args)
        {
            // Услуги
            Service service1 = new Service("Мойка автомобиля", 500);
            Service service2 = new Service("Замена масла", 1500);
            Service service3 = new Service("Ремонт кузова", 10000);
            Service service4 = new Service("Шиномонтаж", 3000);


            // Методы для работы с коллекцией
            MyDictionary<Service> serviceCollection = new MyDictionary<Service>();
            serviceCollection.Add(1, service1);
            serviceCollection.Add(2, service2);
            serviceCollection.Add(3, service3);
            serviceCollection.Add(4, service4);
            serviceCollection.Remove(4);
            Console.WriteLine("Объекты коллекции:");
            serviceCollection.Print();
            Console.WriteLine("Резултат поиска объекта {0} в коллекции: {1}\n", service4.Name, serviceCollection.Contains(service4));

            // Заполнить коллекцию данными встроенного типа
            Console.WriteLine("Коллекция типа int:");
            Dictionary<int, int> intCollection = new Dictionary<int, int>();

            for (int i = 0; i < 10; i++)
            {
                intCollection.Add(i, i);
            }

            foreach (var person in intCollection)
            {
                Console.WriteLine(person.Key + ". " + person.Value);
            }

            // Удалите из коллекции n последовательных элементов
            Console.WriteLine("\nУдаление последовательных элементов:");
            int n = 5;
            while (n >= 0)
            {
                intCollection.Remove(n);
                n--;
            }

            foreach (var person in intCollection)
            {
                Console.WriteLine(person.Key + ". " + person.Value);
            }

            // Используйте все возможные методы добавления для вашего типа коллекции
            Console.WriteLine("\nДобавление элементов разными способами:");
            intCollection.Add(0, 11);
            intCollection[1] = 13;
            intCollection.TryAdd(2, 5);

            // Создайте вторую коллекцию (из таблицы выберите другой тип коллекции) и заполните ее данными из первой коллекции
            Console.WriteLine("Вторая коллекция:");
            List<int> list = intCollection.Values.ToList();
            foreach (int item in list)
                Console.WriteLine(item);

            Console.WriteLine("\nВведите число для поиска в списке: ");
            int userInput;

            // Проверяем, что пользователь ввел корректное число
            while (!int.TryParse(Console.ReadLine(), out userInput))
            {
                Console.WriteLine("Пожалуйста, введите корректное целое число.");
            }

            bool found = false;
            foreach (int item in list)
            {
                if (item == userInput)
                {
                    found = true;
                    break; // Прерываем цикл, если элемент найден
                }
            }
            if (found)
            {
                Console.WriteLine($"В списке есть элемент {userInput}");
            }
            else
            {
                Console.WriteLine($"В списке нет элемента {userInput}");
            }


            // Создайте объект наблюдаемой коллекции ObservableCollection.
            Console.WriteLine("\nСобытия:");
            ObservableCollection<Service> coll = new ObservableCollection<Service>();
            coll.CollectionChanged += CollectionChanged;

            coll.Add(service1);
            coll.Remove(service1);

        }
        private static void CollectionChanged(object obj, NotifyCollectionChangedEventArgs e)
        {
            switch (e.Action)
            {
                case NotifyCollectionChangedAction.Add:
                    Console.WriteLine($"Добавлен новый объект");
                    break;

                case NotifyCollectionChangedAction.Remove:
                    Console.WriteLine($"Удален объект");
                    break;
            }
        }
    }
}