using System;
using System.Collections.Generic;
using System.Linq;

public class Controller
{
    private Earth earth = new Earth();

    public void AddGeography(IPrintable item)
    {
        earth.AddGeographyItem(item);
    }

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
