using DAL_Celebrity_MSSQL;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using ASPA007_1.Services;
using ASPA007_1.API;
internal class Program
{
    private static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        builder.AddCelebritiesConfiguration();
        //Загружает конфигурационный файл Celebrities.config.json, который содержит настройки подключения к БД и пути к фотографиям.

        builder.AddCelebritiesDatabase();
        //Регистрирует контекст базы данных и репозиторий, используя строку подключения из конфигурации.
        builder.Services.AddCelebritiesRouting();
        //Настраивает маршруты для Razor Pages, связывая URL с конкретными страницами.
        var app = builder.Build();

        app.UseMiddleware<CelebritiesError>();
        //Подключает кастомный middleware для обработки ошибок.
        app.UseCelebritiesMiddleware();
        //Настраивает статические файлы, обработку исключений, маршрутизацию и авторизацию.
        app.MapRazorPages();//Активирует Razor Pages.

        app.MapCelebrities();
        app.MapLifeevents();
        app.MapPhotoCelebrities();
        //Регистрирует API эндпоинты для работы с знаменитостями, событиями и фотографиями.
        app.Run();
    }
}
public class CelebritiesConfig
{
    public const string SectionName = "Celebrities";
    public string PhotosFolder { get; set; } = string.Empty;
    public string ConnectionString { get; set; } = string.Empty;
}
public static class AppConfig
{
    public static string ConnectionString { get; set; }
}