namespace Lab11;

public static class Program
{
    public static void Main()
    {
        Console.ForegroundColor = ConsoleColor.DarkMagenta;
        Reflector.GetNameOfTheAssembly("Lab11.Airline");
        Reflector.WriteAllFieldsAndProperties("Lab11.Airline");
        Reflector.WriteAllInterfaces("Lab11.Airline");
        Reflector.WriteAllClassMethodsWithParameter("Lab11.Airline", "amount");
        Reflector.IsTherePublicConstructor("Lab11.Airline");
        Reflector.WritePublicMethods("Lab11.Airline");
        Reflector.Invoke("Lab11.Airline", "Fly");
        Console.ResetColor();


        Console.ForegroundColor = ConsoleColor.DarkMagenta;
        Reflector.GetNameOfTheAssembly("Lab11.Book");
        Reflector.WriteAllFieldsAndProperties("Lab11.Book");
        Reflector.WriteAllInterfaces("Lab11.Book");
        Reflector.WriteAllClassMethodsWithParameter("Lab11.Book", "amount");
        Reflector.IsTherePublicConstructor("Lab11.Book");
        Reflector.WritePublicMethods("Lab11.Book");
        Console.ResetColor();


        Reflector.GetNameOfTheAssembly("System.String");
        Reflector.IsTherePublicConstructor("System.String");
        Reflector.WritePublicMethods("System.String");

        // Задание 2
        Console.ForegroundColor = ConsoleColor.Magenta;
        var belavia = Reflector.Create("Lab11.Airline");
        Console.WriteLine(belavia is Airline);
        Console.ResetColor();
    }
}