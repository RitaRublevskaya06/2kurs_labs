using Microsoft.AspNetCore.HttpLogging;

internal class Program
{
    private static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);       // Создаём WebApplicationBuilder (паттерн builder), который используется для настройки веб-приложения

        // Добавляем сервис HTTPLogging
        builder.Services.AddHttpLogging(loggingBuilder =>
        {
            loggingBuilder.LoggingFields = HttpLoggingFields.All; // Настройка полей для логирования
        });

        var app = builder.Build();                              // Создаём экземпляр WebApplication

        // Используем middleware для HTTPLogging
        app.UseHttpLogging();

        app.MapGet("/", () => "Моё первое ASPA!");       // Задаём конечную точку
        app.MapGet("/g", () => "Моё !");

        app.Run();
    }

}










//internal class Program
//{
//    private static void Main(string[] args)
//    {
//        Main(args);

//        static void Main(string[] args)
//        {
//            var builder = WebApplication.CreateBuilder(args);       // Создаём WebApplicationBuilder (паттерн builder)
//            var app = builder.Build();                              // Создаём экземпляр WebApplication

//            app.MapGet("/", () => "Моё первое ASPA!");              // Задаём конечную точку

//            app.Run();
//        }
//    }
//}