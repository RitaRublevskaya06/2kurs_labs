using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main()
    {
        // Массив месяцев
        string[] months = { "January", "February", "March", "April", "May", "June", "July", "August", "September", "October", "November", "December" };

        int n = 5; // Например, длина строки равная 5

        // Запрос 1: Месяцы с длиной строки равной n
        var monthsWithLengthN = months.Where(m => m.Length == n);

        Console.WriteLine("Месяцы с длиной строки равной {0}:", n);
        foreach (var month in monthsWithLengthN)
        {
            Console.WriteLine(month);
        }

        // Запрос 2: Летние и зимние месяцы
        string[] summerMonths = { "June", "July", "August" };
        string[] winterMonths = { "December", "January", "February" };

        Console.WriteLine("\nЛетние и зимние месяцы:");

        foreach (string month in months)
        {
            if (Array.Exists(summerMonths, element => element == month) ||
                Array.Exists(winterMonths, element => element == month))
            {
                Console.WriteLine(month);
            }
        }

        // Запрос 3: Месяцы в алфавитном порядке
        var sortedMonths = months.OrderBy(m => m);

        Console.WriteLine("\nМесяцы в алфавитном порядке:");
        foreach (var month in sortedMonths)
        {
            Console.WriteLine(month);
        }

        // Запрос 4: Месяцы, содержащие букву «u» и длиной не менее 4-х
        var monthsWithU = months.Where(m => m.Contains('u') && m.Length >= 4);

        Console.WriteLine("\nМесяцы, содержащие букву 'u' и длиной не менее 4-х:");
        foreach (var month in monthsWithU)
        {
            Console.WriteLine(month);
        }



        Console.WriteLine("\n--------------------------------------------------------------------------------------------------------------\n");
        
        Airline airline = new Airline();

        // Заполнение списка рейсов
        airline.Flights.Add(new Flight { FlightNumber = 101, Destination = "New York", DayOfWeek = "Monday", DepartureTime = new TimeSpan(10, 30, 0), AircraftType = "Boeing 737" });
        airline.Flights.Add(new Flight { FlightNumber = 102, Destination = "Los Angeles", DayOfWeek = "Monday", DepartureTime = new TimeSpan(14, 50, 0), AircraftType = "Boeing 747" });
        airline.Flights.Add(new Flight { FlightNumber = 103, Destination = "New York", DayOfWeek = "Tuesday", DepartureTime = new TimeSpan(11, 35, 0), AircraftType = "Airbus A380" });
        airline.Flights.Add(new Flight { FlightNumber = 104, Destination = "Chicago", DayOfWeek = "Wednesday", DepartureTime = new TimeSpan(8, 0, 0), AircraftType = "Boeing 767" });
        airline.Flights.Add(new Flight { FlightNumber = 105, Destination = "New York", DayOfWeek = "Thursday", DepartureTime = new TimeSpan(15, 15, 0), AircraftType = "Airbus A330" });
        airline.Flights.Add(new Flight { FlightNumber = 106, Destination = "New Orleans", DayOfWeek = "Monday", DepartureTime = new TimeSpan(18, 50, 0), AircraftType = "Boeing 737" });
        airline.Flights.Add(new Flight { FlightNumber = 107, Destination = "San Diego", DayOfWeek = "Thursday", DepartureTime = new TimeSpan(14, 20, 0), AircraftType = "Airbus A340" });
        airline.Flights.Add(new Flight { FlightNumber = 108, Destination = "Washington", DayOfWeek = "Friday", DepartureTime = new TimeSpan(20, 00, 0), AircraftType = "Airbus A320" });
        airline.Flights.Add(new Flight { FlightNumber = 109, Destination = "New York", DayOfWeek = "Saturday", DepartureTime = new TimeSpan(16, 30, 0), AircraftType = "Boeing 737" });
        airline.Flights.Add(new Flight { FlightNumber = 110, Destination = "New Orleans", DayOfWeek = "Sunday", DepartureTime = new TimeSpan(21, 0, 0), AircraftType = "Boeing 777" });

        // Пример использования LINQ
        // Запрос 1: список рейсов для заданного пункта назначения
        var flightsToNY = airline.GetFlightsByDestination("New York");
        Console.WriteLine("Рейсы в New York:");
        foreach (var flight in flightsToNY)
        {
            Console.WriteLine($"Рейс {flight.FlightNumber} в {flight.DepartureTime}, самолёт {flight.AircraftType}");
        }

        // Запрос с использованием метода Count,
        // Запрос 2: количество рейсов для заданного типа самолета
        int boeingFlightsCount = airline.CountFlightsByAircraftType("Boeing 737");
        Console.WriteLine($"\nКоличество рейсов для типа самолета Boeing 737: {boeingFlightsCount}");

        // Запрос 3: список рейсов для заданного дня недели
        string filterDay = "Monday";
        var flightsOnDay = airline.Flights.Where(f => f.DayOfWeek == filterDay).ToList();
        Console.WriteLine($"\nРейсы на {filterDay}:");
        foreach (var flight in flightsOnDay)
        {
            Console.WriteLine($"Рейс: {flight.FlightNumber}, Направление: {flight.Destination}, Время вылета: {flight.DepartureTime}");
        }

        // Запрос 4: максимально по дню недели рейс (количество)
        var flightsGrouped = airline.Flights.GroupBy(f => f.DayOfWeek)
            .Select(g => new
            {
                DayOfWeek = g.Key,
                FlightCount = g.Count()
            });

        var maxFlightsDay = flightsGrouped.OrderByDescending(g => g.FlightCount).First();
        Console.WriteLine($"\nМаксимальное количество рейсов по дню недели: {maxFlightsDay.DayOfWeek} ({maxFlightsDay.FlightCount} рейсов)");

        // Запрос 5: все рейсы в определенный день недели и с самым поздним временем вылета
        var latestFlightOnDay = airline.Flights
            .Where(f => f.DayOfWeek == filterDay)
            .OrderByDescending(f => f.DepartureTime)
            .FirstOrDefault();

        Console.WriteLine($"\nСамый поздний рейс на {filterDay}: Рейс: {latestFlightOnDay?.FlightNumber}, Время вылета: {latestFlightOnDay?.DepartureTime}");

        // Запрос 6: упорядоченные по дню и времени рейсы
        var orderedByDay = airline.Flights.OrderBy(f => f.DayOfWeek).ThenBy(f => f.DepartureTime);
        Console.WriteLine("\nРейсы, упорядоченные по дню недели:");
        foreach (var flight in orderedByDay)
        {
            Console.WriteLine($"Рейс: {flight.FlightNumber}, Направление: {flight.Destination}, Время вылета: {flight.DepartureTime}, День: {flight.DayOfWeek}");
        }

        //// Запрос 7: упорядоченные по времени рейсы
        //var orderedByTime = airline.Flights.OrderBy(f => f.DepartureTime);
        //Console.WriteLine("\nРейсы, упорядоченные по времени вылета:");
        //foreach (var flight in orderedByTime)
        //{
        //    Console.WriteLine($"Рейс: {flight.FlightNumber}, Направление: {flight.Destination}, Время вылета: {flight.DepartureTime}, День: {flight.DayOfWeek}");
        //}


        // Предположим, у нас есть список аэропортов
        List<Airport> airports = new List<Airport>
        {
            new Airport { Name = "JFK", Location = "New York" },
            new Airport { Name = "LAX", Location = "Los Angeles" },
            new Airport { Name = "JWS", Location = "Paris" },
            new Airport { Name = "BTE", Location = "New Orleans" },
        };

        // Соединение данных о рейсах и аэропортах
        var flightAirportInfo = from flight in airline.Flights
                                join airport in airports on flight.Destination equals airport.Location
                                select new
                                {
                                    FlightNumber = flight.FlightNumber,
                                    AirportName = airport.Name,
                                    DepartureTime = flight.DepartureTime
                                };

        Console.WriteLine("\nРейсы и соответствующие аэропорты:");
        foreach (var info in flightAirportInfo)
        {
            Console.WriteLine($"Рейс {info.FlightNumber} в аэропорт {info.AirportName} в {info.DepartureTime}");
        }


    }
}
