using Interf;
using System;
using System.Collections.Generic;
using System.IO;

public class CollectionType<T> : ICollectionOperations<T> where T : struct // Ограничение на обобщение
{
    private List<T> _items = new List<T>();
    public void Add(T item)
    {
        try
        {
            _items.Add(item);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Ошибка при добавлении элемента: {ex.Message}");
        }
    }

    public void Remove(T item)
    {
        try
        {
            _items.Remove(item);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Ошибка при удалении элемента: {ex.Message}");
        }
    }

    public T View(int index)
    {
        try
        {
            return _items[index];
        }
        catch (ArgumentOutOfRangeException)
        {
            Console.WriteLine("Коллекция пуста");
            return default;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Ошибка при просмотре элемента: {ex.Message}");
            return default;
        }
    }

    public void SaveToFile(string filePath)
    {
        try
        {
            using (StreamWriter writer = new StreamWriter(filePath))
            {
                foreach (var item in _items)
                {
                    writer.WriteLine(item.ToString());
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Ошибка при сохранении в файл: {ex.Message}");
        }
    }

    public void LoadFromFile(string filePath)
    {
        try
        {
            if (File.Exists(filePath))
            {
                using (StreamReader reader = new StreamReader(filePath))
                {
                    string line;
                    while ((line = reader.ReadLine()) != null)
                    {
                        if (typeof(T) == typeof(int) && int.TryParse(line, out int intValue))
                        {
                            _items.Add((T)(object)intValue);
                        }
                        else if (typeof(T) == typeof(double) && double.TryParse(line, out double doubleValue))
                        {
                            _items.Add((T)(object)doubleValue);
                        }

                    }
                }
            }
            else
            {
                Console.WriteLine("Файл не найден.");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Ошибка при загрузке из файла: {ex.Message}");
        }
    }
}

public class CollectionType1<T> : ICollectionOperations<T> where T : class // Ограничение на обобщение, T может быть только ссылочным
{
    private List<T> _items = new List<T>();
    public void Add(T item)
    {
        try
        {
            _items.Add(item);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Ошибка при добавлении элемента: {ex.Message}");
        }
    }

    public void Remove(T item)
    {
        try
        {
            _items.Remove(item);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Ошибка при удалении элемента: {ex.Message}");
        }
    }

    public T View(int index)
    {
        try
        {
            return _items[index];
        }
        catch (ArgumentOutOfRangeException)
        {
            Console.WriteLine("Коллекция пуста");
            return null;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Ошибка при просмотре элемента: {ex.Message}");
            return null;
        }
    }

    public void SaveToFile(string filePath)
    {
        try
        {
            using (StreamWriter writer = new StreamWriter(filePath))
            {
                foreach (var item in _items)
                {
                    writer.WriteLine(item.ToString());
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Ошибка при сохранении в файл: {ex.Message}");
        }
    }

    public void LoadFromFile(string filePath)
    {
        try
        {
            if (File.Exists(filePath))
            {
                using (StreamReader reader = new StreamReader(filePath))
                {
                    string line;
                    while ((line = reader.ReadLine()) != null)
                    {
                        if (typeof(T) == typeof(int) && int.TryParse(line, out int intValue))
                        {
                            _items.Add((T)(object)intValue);
                        }
                        else if (typeof(T) == typeof(double) && double.TryParse(line, out double doubleValue))
                        {
                            _items.Add((T)(object)doubleValue);
                        }

                    }
                }
            }
            else
            {
                Console.WriteLine("Файл не найден.");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Ошибка при загрузке из файла: {ex.Message}");
        }
    }
}
