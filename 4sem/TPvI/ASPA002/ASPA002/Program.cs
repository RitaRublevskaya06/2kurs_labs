var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

// ���������� Middleware ��� �������������� ��������
app.MapGet("/aspnetcore", () => Results.Content("<h1>Welcome to ASP.NET Core!</h1>", "text/html"));

app.UseWelcomePage("/aspnetcore");

app.UseDefaultFiles();

app.UseStaticFiles(); // ��� ������ � ������� �� ����� wwwroot

app.Run();
