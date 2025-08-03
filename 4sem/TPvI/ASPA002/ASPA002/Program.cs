var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

// Добавление Middleware для приветственной страницы
app.MapGet("/aspnetcore", () => Results.Content("<h1>Welcome to ASP.NET Core!</h1>", "text/html"));

app.UseWelcomePage("/aspnetcore");

app.UseDefaultFiles();

app.UseStaticFiles(); // Для работы с файлами из папки wwwroot

app.Run();
