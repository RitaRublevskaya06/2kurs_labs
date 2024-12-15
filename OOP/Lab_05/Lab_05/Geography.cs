using System;
public enum ContinentType
{
    Eurasia,
    Africa,
    NorthAmerica,
    SouthAmerica,
    Australia,
    Antarctica,
    Asia
}
public struct Coordinates
{
    public double Latitude { get; set; }
    public double Longitude { get; set; }

    public Coordinates(double latitude, double longitude)
    {
        Latitude = latitude;
        Longitude = longitude;
    }

    public override string ToString()
    {
        return $"({Latitude}, {Longitude})";
    }
}

public interface IPrintable
{
    void PrintDetails();
    string Name { get; }
}

public abstract class Land : IPrintable
{
    public string Name { get; set; }
    public Land(string name)
    {
        Name = name;
    }

    public abstract void PrintDetails();
    public override string ToString()
    {
        return $"{GetType().Name}: {Name}";
    }
}

public class Continent : Land
{
    public Coordinates Location { get; set; }

    public Continent(string name, Coordinates location) : base(name)
    {
        Location = location;
    }

    public override void PrintDetails()
    {
        Console.WriteLine($"Континент: {Name}, Координаты: {Location}");
    }
}

public class Island : Land
{
    public Island(string name) : base(name) { }

    public override void PrintDetails()
    {
        Console.WriteLine($"Остров: {Name}");
    }
}

public abstract class Water : IPrintable
{
    public string Name { get; set; }

    public Water(string name)
    {
        Name = name;
    }

    public abstract void PrintDetails();
    public override string ToString()
    {
        return $"{GetType().Name}: {Name}";
    }
}

public sealed class Sea : Water
{
    public Sea(string name) : base(name) { }

    public override void PrintDetails()
    {
        Console.WriteLine($"Море: {Name}");
    }
}

public class Printer
{
    public void IAmPrinting(IPrintable obj)
    {
        Console.WriteLine(obj.ToString());
        obj.PrintDetails();
    }
}