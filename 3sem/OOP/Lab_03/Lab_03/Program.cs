using System;
using System.Collections.Generic;
using System.Linq;
using static Stack;

public class Stack
{
    internal List<int> _elements = new List<int>();

    // Конструктор
    public Stack() { }

    // Индексатор
    public int this[int index]
    {
        get => _elements[index];
        set => _elements[index] = value;
    }

    // Перегрузка операторов
    public static Stack operator +(Stack stack, int element)
    {
        stack._elements.Add(element);
        return stack;
    }

    public static Stack operator --(Stack stack)
    {
        if (stack._elements.Count > 0)
        {
            stack._elements.RemoveAt(stack._elements.Count - 1);
        }
        return stack;
    }

    public static bool operator true(Stack stack)
    {
        return stack._elements.Count == 0;
    }

    public static bool operator false(Stack stack)
    {
        return stack._elements.Count != 0;
    }

    public static Stack operator >(Stack stack1, Stack stack2)
    {
        var sortedElements = stack1._elements.Concat(stack2._elements).OrderBy(x => x).ToList();
        return new Stack { _elements = sortedElements };
    }
    public static Stack operator <(Stack stack1, Stack stack2)
    {
        return stack1 > stack2;
    }

    //  Класс Company
    public class Company
    {
        public string Name { get; set; }
        public List<Production> Productions { get; set; }

        public Company(string name)
        {
            Name = name;
            Productions = new List<Production>();
        }

        // Вложенный класс Production
        public class Production
        {
            public int Id { get; set; }
            public string OrganizationName { get; set; }

            public Production(int id, string organizationName)
            {
                Id = id;
                OrganizationName = organizationName;
            }
        }

        public void AddProduction(int id, string organizationName)
        {
            Productions.Add(new Production(id, organizationName));
        }
    }



    // Вложенный класс Developer
    public class Developer
    {
        public string FullName { get; set; }
        public int Id { get; set; }
        public string Department { get; set; }

        public Developer(string fullName, int id, string department)
        {
            FullName = fullName;
            Id = id;
            Department = department;
        }
    }
}

public static class StatisticOperation
{
    public static int Sum(Stack stack)
    {
        return stack._elements.Sum();
    }

    public static int DifferenceBetweenMaxAndMin(Stack stack)
    {
        return stack._elements.Max() - stack._elements.Min();
    }

    public static int CountElements(Stack stack)
    {
        return stack._elements.Count;
    }

    public static string CountSentences(this string text)
    {
        return text.Split('.').Length.ToString();
    }

    public static double AverageElement(this Stack stack)
    {
        return stack._elements.Count > 0 ? stack._elements.Average() : 0;
    }
}

class Program
{
    static void Main()
    {
        Stack myStack = new Stack();
        myStack += 5; // Добавление элемента
        myStack += 10;
        myStack += 2;
        myStack += 15;
        myStack += 1;

        Console.WriteLine("Сумма элементов: " + StatisticOperation.Sum(myStack));
        Console.WriteLine("Разница между максимальным и минимальным элементами: " + StatisticOperation.DifferenceBetweenMaxAndMin(myStack));
        Console.WriteLine("Количество элементов: " + StatisticOperation.CountElements(myStack));

        // Проверка стека
        Console.WriteLine("Пустой ли стек: " + (myStack ? "Да" : "Нет"));

        // Извлечение элемента
        myStack--;
        Console.WriteLine("После извлечения, количество элементов: " + StatisticOperation.CountElements(myStack));

        var company = new Company("Технологические инновации");
        company.AddProduction(1, "Фабрика A");
        company.AddProduction(2, "Фабрика B");

        foreach (var production in company.Productions)
        {
            Console.WriteLine($"Id: {production.Id}, Организация: {production.OrganizationName}");
        }

    }
}