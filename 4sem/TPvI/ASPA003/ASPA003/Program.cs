using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.FileProviders;
using System.IO;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

// ��������� ��� ����������� ������ ����� �������
app.UseDirectoryBrowser(new DirectoryBrowserOptions
{
    FileProvider = new PhysicalFileProvider(Path.Combine(Directory.GetCurrentDirectory(), "Celebrities")),
    RequestPath = "/download"  // ���� ��� ��������� ������ � ��������
});

// ��������� ��� ����������� ������
app.UseStaticFiles(new StaticFileOptions
{
    FileProvider = new PhysicalFileProvider(Path.Combine(Directory.GetCurrentDirectory(), "Celebrities")),
    RequestPath = "/Photo"  // ���� ��� ������� � �����������
});

// ��������� ��� ���������� �����������
app.UseStaticFiles(new StaticFileOptions
{
    FileProvider = new PhysicalFileProvider(Path.Combine(Directory.GetCurrentDirectory(), "Celebrities")),
    RequestPath = "/download",  // ���� ��� ������� � �����������
    OnPrepareResponse = ctx =>
    {
        // ��������� ��������� ��� ���������� �����������
        ctx.Context.Response.Headers.Append("Content-Disposition", "attachment; filename=" + ctx.File.Name);
        ctx.Context.Response.Headers.Append("Content-Type", "application/octet-stream"); // �������������� ����������
    }
});


using (IRepository repository = new Repository("Celebrities", "Celebrities.json"))
{
    app.MapGet("/Celebrities", () => repository.GetAllCelebrities());
    app.MapGet("/Celebrities/{id:int}", (int id) => repository.GetCelebrityById(id));
    app.MapGet("/Celebrities/BySurname/{surname}", (string surname) => repository.GetCelebritiesBySurname(surname));
    app.MapGet("/Celebrities/PhotoPathById/{id:int}", (int id) => repository.GetPhotoPathById(id));
}

app.MapGet("/", () => "Hello World");

app.Run();
