using System;
using System.Buffers;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net.Mime;

public class Controller
{
    private Earth earth = new Earth();



    /************************************************************************/

    //public void AddGeography(IPrintable item)
    //{
    //    earth.AddGeographyItem(item);
    //}

    public void AddGeography(IPrintable item)
    {
        try
        {
            if (item == null)
            {
                throw new InvalidGeographyItemException("Geography item cannot be null.");
            }

            earth.AddGeographyItem(item);
        }
        catch (InvalidGeographyItemException ex)
        {
            Console.WriteLine($"Ошибка: {ex.Message}");
        }
    }

    //public void AddGeography(IPrintable item)
    //{
    //    Debug.Assert(item != null, "Geography item cannot be null.");

    //    if (item == null)
    //    {
    //        throw new InvalidGeographyItemException("Geography item cannot be null.");
    //    }

    //    earth.AddGeographyItem(item);
    //}

    /************************************************************************/

    public void DisplayAll()
    {
        earth.PrintGeographyItems();
    }

    public void DisplayCountriesOnContinent(ContinentType continentType)
    {
        var countries = earth.GetCountriesByContinent(continentType);
        Console.WriteLine($"Государства на континенте {continentType}:");

        foreach (var country in countries)
        {
            country.PrintDetails();
        }
    }


    public void CountSeas()
    {
        var seas = earth.GetSeas().Count;
        Console.WriteLine($"Количество морей: {seas}");
    }

    public void DisplayIslandsAlphabetically()
    {
        var islands = earth.GetIslands();
        var sortedIslands = islands.OrderBy(i => i.Name).ToList();

        Console.WriteLine("Острова в алфавитном порядке:");
        foreach (var island in sortedIslands)
        {
            island.PrintDetails();
        }
    }
}
