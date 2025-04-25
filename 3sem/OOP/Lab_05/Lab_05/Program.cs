using System.ComponentModel;
using System.Diagnostics.Metrics;
using System.Reflection;
using System.Runtime.CompilerServices;
using static System.Runtime.InteropServices.JavaScript.JSType;

public class Program
{
    public static void Main()
    {
        Console.WriteLine("--- Географические объекты ---");

        Controller controller = new Controller();
        var coordinates = new Coordinates(55.0, 37.0); // Пример координат для Евразии
        controller.AddGeography(new Continent("Евразия", coordinates));
        controller.AddGeography(new Country("Беларусь", ContinentType.Eurasia));
        controller.AddGeography(new Country("Россия", ContinentType.Eurasia));
        controller.AddGeography(new Country("Китай", ContinentType.Eurasia));
        controller.AddGeography(new Country("Египет", ContinentType.Africa));
        controller.AddGeography(new Country("Канада", ContinentType.NorthAmerica));
        controller.AddGeography(new Sea("Мраморное море"));
        controller.AddGeography(new Sea("Красное море"));
        controller.AddGeography(new Sea("Чёрное море"));
        controller.AddGeography(new Island("Мадагаскар"));
        controller.AddGeography(new Island("Филиппины"));
        controller.AddGeography(new Island("Бали"));


        controller.DisplayAll();

        Console.WriteLine("\n--- Классификации ---");
        controller.DisplayCountriesOnContinent(ContinentType.Eurasia);
        controller.CountSeas();
        controller.DisplayIslandsAlphabetically();
    }
}
