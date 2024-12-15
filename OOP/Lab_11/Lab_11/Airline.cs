namespace Lab11;

public class Airline
{
    public string? Engine { get; set; }
    public int Fuel { get; set; }

    public Airline()
    {

    }
    public Airline(string videoCard, string processor, int amountOfRam, int amountOfStorage)
    {
        Engine = videoCard;
        Fuel = amountOfRam;
    }

    public void IsWorking()
    {
        Console.WriteLine("Airline работает.\n");
    }

    public void AddingRam(int amount)
    {
        Console.WriteLine("Добавление " + amount + "ГБ оперативной памяти для вашей системы.\n");
        Fuel += amount;
    }

    public void AddingStorage(int amountOfStorage)
    {
        Console.WriteLine("Добавление " + amountOfStorage + "ГБ SSD-накопителя для вашей системы.\n");
    }

    public void Fly(List<string> nameOfVideoCard)
    {
        foreach (var name in nameOfVideoCard)
        {
            Console.WriteLine($"Вы летите на {name}");
        }
    }
}