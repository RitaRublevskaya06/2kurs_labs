using DAL004;
using Microsoft.AspNetCore.Diagnostics;
using System.Text.Json;

var builder = WebApplication.CreateBuilder(args);

// ��������� ������� � ���������
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(); // ������� ����� Swashbuckle.AspNetCore

var app = builder.Build();

// ��������� ��������� HTTP-��������
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();       // ������� ����� Microsoft.AspNetCore.OpenApi
    app.UseSwaggerUI();     // ������� ����� Swashbuckle.AspNetCore
}

app.UseHttpsRedirection();

// ��������� ����������� � ���������
Repository.JSONFileName = "Celebrities.json";
using (IRepository repository = Repository.Create("Celebrities"))
{
    // ���������� ���������� ����������
    app.UseExceptionHandler("/Celebrities/Error");

    // �������� API
    app.MapGet("/Celebrities", () => repository.getAllCelebrities());

    app.MapGet("/Celebrities/{id:int}", (int id) =>
    {
        Celebrity? celebrity = repository.getCelebrityById(id);
        if (celebrity == null) throw new FoundByIdException($"Celebrity Id = {id}");
        return celebrity;
    });

    app.MapPost("/Celebrities", (Celebrity celebrity) =>
    {
        // �������� ������� ������������ �����
        if (string.IsNullOrWhiteSpace(celebrity.Firstname) ||
            string.IsNullOrWhiteSpace(celebrity.Surname) ||
            string.IsNullOrWhiteSpace(celebrity.PhotoPath))
        {
            throw new BadHttpRequestException(
                "Required fields 'firstname', 'surname', or 'photopath' are missing or empty.",
                StatusCodes.Status400BadRequest
            );
        }

        int? id = repository.addCelebrity(celebrity);
        if (id == null) throw new AddCelebrityException("/Celebrities error, id == null");
        if (repository.SaveChanges() <= 0) throw new SaveException("/Celebrities error, SaveChanges() <= 0");
        return new Celebrity((int)id, celebrity.Firstname, celebrity.Surname, celebrity.PhotoPath);
    });

    app.MapPost("/Celebrities/not-found", () =>
    {
        string filePath = Path.Combine("Celebrities", "Celebrities.json");
        string jsonContent = File.ReadAllText(filePath);
        return Results.Ok(jsonContent);
    });

    //app.Run();   
    app.MapFallback((HttpContext ctx) =>
        Results.NotFound(new { error = $"path {ctx.Request.Path} not supported" }));

    app.Map("/Celebrities/Error", (HttpContext ctx) =>
    {
        Exception? ex = ctx.Features.Get<IExceptionHandlerFeature>()?.Error;
        string detailedMessage = "An unexpected error occurred.";
        string errorType = "GenericError";
        int statusCode = 500;

        if (ex != null)
        {
            // ����������� ��� �������
            Console.WriteLine($"Error Type: {ex.GetType().Name}");
            Console.WriteLine($"Message: {ex.Message}");
            Console.WriteLine($"StackTrace: {ex.StackTrace}");

            // ����������� ������
            switch (ex)
            {
                case FileNotFoundException fileEx:
                    detailedMessage = $"Could not find file: '{fileEx.FileName}'. " +
                                    $"Ensure the file exists in the 'Celebrities' directory.";
                    errorType = "FileNotFound";
                    statusCode = 404;
                    break;

                case DirectoryNotFoundException dirEx:
                    detailedMessage = $"Directory not found: '{dirEx.Message}'. " +
                                    $"Required directory: 'Celebrities' in the application root.";
                    errorType = "DirectoryNotFound";
                    statusCode = 404;
                    break;

                case JsonException jsonEx:
                    detailedMessage = $"Invalid JSON data: {jsonEx.Message}. " +
                                    $"Check the format of 'Celebrities.json'.";
                    errorType = "InvalidJson";
                    statusCode = 400;
                    break;

                case BadHttpRequestException badReqEx:
                    detailedMessage = badReqEx.Message;
                    errorType = "BadRequest";
                    statusCode = badReqEx.StatusCode;
                    break;

                case FoundByIdException foundEx:
                    detailedMessage = $"Celebrity not found: {foundEx.Message}";
                    errorType = "NotFound";
                    statusCode = 404;
                    break;

                case SaveException saveEx:
                    detailedMessage = $"Save failed: {saveEx.Message}. " +
                                    $"Check file permissions for 'Celebrities.json'.";
                    errorType = "SaveError";
                    break;

                case AddCelebrityException addEx:
                    detailedMessage = $"Add failed: {addEx.Message}. " +
                                    $"Possible duplicate or invalid data.";
                    errorType = "AddError";
                    break;

                default:
                    detailedMessage = ex.Message;
                    break;
            }
        }

        // ������ ������ (��� � ����� �������)
        var response = new
        {
            type = $"https://tools.ietf.org/html/rfc7231#section-6.5.{statusCode}",
            title = "ASPA004",
            status = statusCode,
            detail = detailedMessage,
            instance = app.Environment.EnvironmentName,
            errorType = errorType // �������������� ���� ��� ���� ������
        };

        return Results.Json(response, statusCode: statusCode);
    });

    app.Run();
}

// ������ ����������
public class FoundByIdException : Exception
{
    public FoundByIdException(string message) : base($"Found by Id: {message}") { }
};

public class SaveException : Exception
{
    public SaveException(string message) : base($"SaveChanges error: {message}") { }
};

public class AddCelebrityException : Exception
{
    public AddCelebrityException(string message) : base($"AddCelebrityException error: {message}") { }
};
