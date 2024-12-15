using System;

public interface IPrintable
{
    void PrintDetails();
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
    public Continent(string name) : base(name) { }

    public override void PrintDetails()
    {
        Console.WriteLine($"Континент: {Name}");
    }
}

public class Country : Land
{
    public Country(string name) : base(name) { }

    public override void PrintDetails()
    {
        Console.WriteLine($"Государство: {Name}");
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