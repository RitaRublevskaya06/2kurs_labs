using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;

namespace DAL004
{
    public class Repository : IRepository
    {
        private List<Celebrity> _celebrities;
        private string _jsonFilePath;
        private bool _disposed = false;

        public static string JSONFileName { get; set; } = "Celebrities.json";
        public string BasePath { get; }

        public static IRepository Create(string directory)
        {
            return new Repository(directory);
        }

        private Repository(string directory)
        {
            BasePath = Path.Combine(Directory.GetCurrentDirectory(), directory);
            if (!Directory.Exists(BasePath))
            {
                Directory.CreateDirectory(BasePath);
            }

            _jsonFilePath = Path.Combine(BasePath, JSONFileName);
            _celebrities = LoadCelebrities();
        }

        private List<Celebrity> LoadCelebrities()
        {
            if (File.Exists(_jsonFilePath))
            {
                var json = File.ReadAllText(_jsonFilePath);
                return JsonSerializer.Deserialize<List<Celebrity>>(json) ?? new List<Celebrity>();
            }
            return new List<Celebrity>();
        }

        public Celebrity[] getAllCelebrities() => _celebrities.ToArray();

        public Celebrity? getCelebrityById(int id) => _celebrities.FirstOrDefault(c => c.Id == id);

        public Celebrity[] getCelebritiesBySurname(string surname) =>
            _celebrities.Where(c => c.Surname.Equals(surname, StringComparison.OrdinalIgnoreCase)).ToArray();

        public string? getPhotoPathById(int id) => getCelebrityById(id)?.PhotoPath;

        public int? addCelebrity(Celebrity celebrity)
        {
            if (celebrity == null) return null;

            int newId = _celebrities.Count > 0 ? _celebrities.Max(c => c.Id) + 1 : 1;
            celebrity.Id = newId;
            _celebrities.Add(celebrity);
            return newId;
        }

        public bool delCelebrityById(int id)
        {
            var celebrity = getCelebrityById(id);
            if (celebrity == null) return false;

            return _celebrities.Remove(celebrity);
        }

        public int? updCelebrityById(int id, Celebrity celebrity)
        {
            var existing = getCelebrityById(id);
            if (existing == null) return null;

            existing.Firstname = celebrity.Firstname;
            existing.Surname = celebrity.Surname;
            existing.PhotoPath = celebrity.PhotoPath;
            return id;
        }

        public int SaveChanges()
        {
            var json = JsonSerializer.Serialize(_celebrities, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(_jsonFilePath, json);
            return _celebrities.Count;
        }

        public void Dispose()
        {
            if (!_disposed)
            {
                SaveChanges();
                _disposed = true;
            }
        }
    }
}