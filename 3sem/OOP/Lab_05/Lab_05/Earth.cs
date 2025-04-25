using System.Collections.Generic;
using System.Linq;

public class Earth
{
    private List<IPrintable> geographyItems = new List<IPrintable>();

    public void AddGeographyItem(IPrintable item)
    {
        geographyItems.Add(item);
    }

    public void RemoveGeographyItem(IPrintable item)
    {
        geographyItems.Remove(item);
    }

    public void PrintGeographyItems()
    {
        foreach (var item in geographyItems)
        {
            Console.WriteLine(item);
            item.PrintDetails();
        }
    }

    public List<Country> GetCountriesByContinent(ContinentType continentType)
    {
        return geographyItems
            .Where(item => item is Country country && country.Continent == continentType)
            .Select(item => (Country)item)
            .ToList();
    }


    public List<Sea> GetSeas()
    {
        return geographyItems
            .Where(item => item is Sea)
            .Select(item => (Sea)item)
            .ToList();
    }

    public List<Island> GetIslands()
    {
        return geographyItems
            .Where(item => item is Island)
            .Select(item => (Island)item)
            .ToList();
    }
}
