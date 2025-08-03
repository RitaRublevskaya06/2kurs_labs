using Microsoft.AspNetCore.Diagnostics;
using Microsoft.Extensions.Logging;

internal class Program
{
    private static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Настройка фильтра логирования для исключений
        builder.Logging.AddFilter("Microsoft.AspNetCore.Diagnostics", LogLevel.None);  // фильтрация сообщений

        var app = builder.Build();

        // Подключение обработчика исключений
        app.UseExceptionHandler("/error"); // путь для обработчика ошибок

        // Обработчики для разных маршрутов
        app.MapGet("/", () => "Start "); // Главная страница

        app.MapGet("/test1", () =>
        {
            throw new Exception("-- Exeption Test --"); // Исключение с текстом
        });

        app.MapGet("/test2", () =>
        {
            int x = 0, y = 5, z = 0;
            z = y / x; // Исключение деления на ноль
            return "test2";
        });

        app.MapGet("/test3", () =>
        {
            int[] x = new int[3] { 1, 2, 3 };
            int y = x[3]; // Исключение выхода за пределы массива
            return "test3";
        });

        // Обработчик ошибок
        app.Map("/error", async (ILogger<Program> logger, HttpContext context) =>
        {
            IExceptionHandlerFeature? exobj = context.Features.Get<IExceptionHandlerFeature>();  // Получение исключения
            await context.Response.WriteAsync("<h1>Oops!</h1>"); // Отображение сообщения об ошибке
            logger.LogError(exobj?.Error, "ExceptionHandler"); // Логирование ошибки
        });

        app.Run(); // Запуск приложения
    }
}
