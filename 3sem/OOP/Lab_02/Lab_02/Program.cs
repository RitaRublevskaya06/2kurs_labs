using System;
using System.Collections.Generic;
using System.Linq;

public partial class Airline
{
    private static int instanceCount = 0;
    private readonly int id;
    public const string AirlineType = "Коммерческий"; // Пример константы
    public string Destination { get; set; }
    public string FlightNumber { get; set; }
    public string AircraftType { get; set; }
    public DateTime DepartureTime { get; set; }
    public DayOfWeek[] DaysOfWeek { get; set; }

    // Статический конструктор
    static Airline()
    {
        instanceCount = 0;
    }

    // Закрытый конструктор
    private Airline(string flightNumber)
    {
        FlightNumber = flightNumber;
        id = GetHashCode(); // Уникальный идентификатор
    }

    // Конструкторы
    public Airline(string flightNumber, string destination, string aircraftType, DateTime departureTime, DayOfWeek[] days)
    {
        FlightNumber = flightNumber;
        Destination = destination;
        AircraftType = aircraftType;
        DepartureTime = departureTime;
        DaysOfWeek = days;
        id = GetHashCode();
        instanceCount++;
    }

    public Airline() : this("NNN", "Неизвестно", "Неизвестно", DateTime.Now, new DayOfWeek[] { })
    {
    }

    public Airline(string flightNumber, string destination) : this(flightNumber, destination, "Неизвестно", DateTime.Now, new DayOfWeek[] { })
    {
    }

    // Статический метод
    public static void ShowInfo()
    {
        Console.WriteLine($"\nКоличество созданных рейсов: {instanceCount}");
    }

    // Метод для работы с ref и out параметрами
    public void GetFlightInfo(out string flightInfo, ref bool isInternational)
    {
        flightInfo = $"Рейс: {FlightNumber}, Направление: {Destination}, Тип самолета: {AircraftType}, Время: {DepartureTime}";
        isInternational = Destination.ToLower() != "внутренний"; 
    }

    // Переопределения методов
    public override bool Equals(object obj)
    {
        if (obj is Airline)
        {
            return FlightNumber == ((Airline)obj).FlightNumber;
        }
        return false;
    }

    public override int GetHashCode()
    {
        return FlightNumber.GetHashCode();
    }

    public override string ToString()
    {
        return $"{FlightNumber} -> {Destination} ({AircraftType}), {DepartureTime}";
    }
}

class Program
{
    static void Main(string[] args)
    {
        // Создание массива объектов Airline
        var flights = new Airline[]
        {
            new Airline("SU101", "Санкт-Петербург", "Аэробус A320", new DateTime(2024, 10, 1, 8, 20,0), new [] { DayOfWeek.Monday, DayOfWeek.Wednesday }),
            new Airline("SU102", "Москва", "Боинг 737", new DateTime(2024, 10, 5, 9, 30, 0), new [] { DayOfWeek.Tuesday }),
            new Airline("SU103", "Сочи", "Аэробус A335", new DateTime(2024, 10, 6, 10, 15, 0), new [] { DayOfWeek.Monday, DayOfWeek.Friday }),
            new Airline("SU104", "Москва", "Боинг 879", new DateTime(2024, 11, 1, 10, 45, 0), new [] { DayOfWeek.Wednesday }),
            new Airline("SU105", "Санкт-Петербург", "Боинг 258", new DateTime(2024, 12, 1, 10, 30, 0), new [] { DayOfWeek.Tuesday }),
            new Airline("SU106", "Краснодар", "Боинг 1289", new DateTime(2024, 9, 25, 8, 30, 0), new [] { DayOfWeek.Monday, DayOfWeek.Tuesday }),
            new Airline("SU107", "Санкт-Петербург", "Боинг 239", new DateTime(2024, 10, 12, 15, 30, 0), new [] { DayOfWeek.Wednesday }),
            new Airline("SU108", "Владимир", "Боинг 458", new DateTime(2024, 10, 12, 16, 30, 0), new [] { DayOfWeek.Wednesday }),
            new Airline("SU109", "Санкт-Петербург", "Боинг 158", new DateTime(2024, 10, 4, 18, 25, 0), new [] { DayOfWeek.Monday, DayOfWeek.Tuesday })
        };

        // Вывод списка рейсов для заданного пункта назначения
        string desiredDestination = "Санкт-Петербург";
        var flightsToDestination = flights.Where(f => f.Destination == desiredDestination);
        Console.WriteLine($"Рейсы для пункта назначения '{desiredDestination}':");
        foreach (var flight in flightsToDestination)
        {
            Console.WriteLine(flight);
        }

        // Вывод списка рейсов для заданного дня недели
        DayOfWeek desiredDay = DayOfWeek.Monday;
        var flightsOnDay = flights.Where(f => f.DaysOfWeek.Contains(desiredDay));
        Console.WriteLine($"\nРейсы для дня недели '{desiredDay}':");
        foreach (var flight in flightsOnDay)
        {
            Console.WriteLine(flight);
        }

        // Статическая информация о классах
        Airline.ShowInfo();

        // Создание и вывод анонимного типа
        var anonymousFlight = new
        {
            FlightNumber = "SU115",
            Destination = "Псков",
            AircraftType = "Боинг 747",
            DepartureTime = "01.12.2024 10:55:00"
        };

        Console.WriteLine($"\nАнонимный рейс: Номер {anonymousFlight.FlightNumber}, Направление: {anonymousFlight.Destination}, Тип самолета: {anonymousFlight.AircraftType}, Время: {anonymousFlight.DepartureTime} ");
    }
}
