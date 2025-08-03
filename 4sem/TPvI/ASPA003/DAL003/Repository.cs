using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;

public interface IRepository : IDisposable
{
    string BasePath { get; }
    Celebrity[] GetAllCelebrities();
    Celebrity? GetCelebrityById(int id);
    Celebrity[] GetCelebritiesBySurname(string surname);
    string? GetPhotoPathById(int id);
}

public record Celebrity(int Id, string Firstname, string Surname, string PhotoPath);

public class Repository : IRepository
{
    public string JSONFileName { get; }
    public string BasePath { get; }
    private List<Celebrity> _celebrities;

    public Repository(string directoryPath, string jsonFileName)
    {
        BasePath = Path.Combine(Directory.GetCurrentDirectory(), directoryPath);
        JSONFileName = jsonFileName;
        var jsonFilePath = Path.Combine(BasePath, JSONFileName);

        if (File.Exists(jsonFilePath))
        {
            var jsonData = File.ReadAllText(jsonFilePath);
            _celebrities = JsonSerializer.Deserialize<List<Celebrity>>(jsonData) ?? new List<Celebrity>();
        }
        else
        {
            _celebrities = new List<Celebrity>();
        }
    }

    public Celebrity[] GetAllCelebrities()
    {
        Console.WriteLine($"Loaded {_celebrities.Count} celebrities");
        return _celebrities.ToArray();
    }


    public Celebrity? GetCelebrityById(int id) => _celebrities.FirstOrDefault(c => c.Id == id);

    public Celebrity[] GetCelebritiesBySurname(string surname)
    {
        var results = _celebrities.Where(c => c.Surname.Equals(surname, StringComparison.OrdinalIgnoreCase)).ToArray();
        Console.WriteLine($"Searching for {surname}, found {results.Length} results");
        return results;
    }
    public string? GetPhotoPathById(int id) => _celebrities.FirstOrDefault(c => c.Id == id)?.PhotoPath;

    public void Dispose() { }
}
