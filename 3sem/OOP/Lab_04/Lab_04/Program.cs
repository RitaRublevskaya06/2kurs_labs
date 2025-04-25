using System.Diagnostics.Metrics;
using System.Reflection;
using System.Runtime.CompilerServices;
using static System.Runtime.InteropServices.JavaScript.JSType;

public class Program
{
    public static void Main()
    {
        IPrintable[] geographies = new IPrintable[]
        {
            new Sea("Чёрное море"),
            new Continent("Евразия"),
            new Country("Беларусь"),
            new Island("Мадагаскар")
        };

        Printer printer = new Printer();

        foreach (IPrintable geography in geographies)
        {
            printer.IAmPrinting(geography);
        }
    }
}

