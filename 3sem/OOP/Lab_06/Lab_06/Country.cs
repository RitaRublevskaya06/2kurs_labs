using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mime;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

public partial class Country : Land
{
    public ContinentType Continent { get; set; }

    public Country(string name, ContinentType continent) : base(name)
    {
        Continent = continent;
    }

    public override void PrintDetails()
    {
        Console.WriteLine($"Государство: {Name}, Континент: {Continent}");
    }
}