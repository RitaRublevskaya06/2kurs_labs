using System;
using System.Collections.Generic;
using System.Linq;
using static Develop;
class Program
{
    static void Main()
    {
        // Пример использования для целых чисел
        var intCollection = new CollectionType<int>();
        intCollection.Add(1);
        intCollection.Add(2);
        Console.WriteLine(intCollection.View(0)); // Вывод: 1
        intCollection.SaveToFile("intCollection.txt");

        // Пример использования для вещественных чисел
        var doubleCollection = new CollectionType<double>();
        doubleCollection.Add(1.5599885);
        doubleCollection.Add(2.5545165);
        Console.WriteLine(doubleCollection.View(1)); // Вывод: 2.5545165
        doubleCollection.SaveToFile("doubleCollection.txt");

        // Пример использования для пользовательского класса
        var developerCollection = new CollectionType1<Developer>();
        developerCollection.Add(new Developer("Иванов И.И.", 1, "Тестир"));
        Console.WriteLine(developerCollection.View(0)?.FullName); // Вывод: Иванов И.И.
        developerCollection.SaveToFile("developers.txt");
        

        // Загрузка из файла
        var newDeveloperCollection = new CollectionType1<Developer>();
        newDeveloperCollection.LoadFromFile("developers.txt");
        Console.WriteLine(newDeveloperCollection.View(0)?.FullName); // Вывод: Коллекция пуста
    }
}
