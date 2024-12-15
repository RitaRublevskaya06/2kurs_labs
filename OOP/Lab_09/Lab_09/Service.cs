using System;
using System.Collections;

namespace OOP_lab9
{
    interface IOrderedDictionary<T>
    {
        void Add(int key, T value); // Добавление элемента в коллекцию
        void Clear(); // Очистка коллекции
        bool Contains(T value); // Проверка наличия элемента в коллекции
        void Remove(int key); // Удаление элемента из коллекции
        ICollection Keys { get; } // Возвращает список ключей
        ICollection Values { get; } // Возвращает список значений

    }

    public class Service
    {
        public string Name { get; set; }
        public int Price { get; set; }

        public Service(string name, int price)
        {
            Name = name;
            Price = price;
        }
    }


    public class MyDictionary<T> : IOrderedDictionary<T>
    {
        public Dictionary<int, T> list { get; set; }

        public MyDictionary()
        {
            list = new Dictionary<int, T>();
        }
        public void Clear()
        {
            list.Clear();
        }
        public void Print()
        {
            foreach (KeyValuePair<int, T> item in list)
                if (item.Value is Service)
                {
                    Service service = item.Value as Service;
                    Console.WriteLine("{0}. {1} – {2}$", item.Key, service.Name, service.Price);
                }
                else
                {
                    Console.WriteLine("{0}. {1}", item.Key, item.Value);
                }

        }
        public void Add(int key, T value)
        {
            list.Add(key, value);
        }
        public void Remove(int key)
        {
            list.Remove(key);
        }
        public bool Contains(T serviceSearch) // Проверка наличия элемента в коллекции
        {
            foreach (KeyValuePair<int, T> item in list)
            {
                if (item.Value.Equals(serviceSearch))
                    return true;
            }
            return false;
        }

        public ICollection Keys => list.ToArray();

        public ICollection Values => list.ToArray();
    }

}