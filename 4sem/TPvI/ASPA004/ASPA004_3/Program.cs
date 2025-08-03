using DAL004;
using Microsoft.AspNetCore.Diagnostics;


var builder = WebApplication.CreateBuilder(args);

// Добавляем сервисы в контейнер
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(); // Требует пакет Swashbuckle.AspNetCore

var app = builder.Build();

// Настройка конвейера HTTP-запросов
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();       // Требует пакет Microsoft.AspNetCore.OpenApi
    app.UseSwaggerUI();     // Требует пакет Swashbuckle.AspNetCore
}

app.UseHttpsRedirection();

Repository.JSONFileName = "Celebrities.json";
using (IRepository repository = Repository.Create("Celebrities"))
{
    app.UseExceptionHandler("/Celebrities/Error");

    app.MapGet("/Celebrities", () => repository.getAllCelebrities());

    app.MapGet("/Celebrities/{id:int}", (int id) =>
    {
        Celebrity? celebrity = repository.getCelebrityById(id);
        if (celebrity == null) throw new FoundByIdException($"/Celebrities, Celebrity Id = {id}");
        return celebrity;
    });

    app.MapPost("/Celebrities", (Celebrity celebrity) =>
    {
        int? id = repository.addCelebrity(celebrity);
        if (id == null) throw new AddCelebrityException("/Celebrities error, id null");
        if (repository.SaveChanges() <= 0) throw new SaveException("/Celebrities error, SaveChanges() <= 0");
        return new Celebrity((int)id, celebrity.Firstname, celebrity.Surname, celebrity.PhotoPath);
    });

    app.MapPut("/Celebrities/{id:int}", (int id, Celebrity updatedCelebrity) =>
    {
        var existing = repository.getCelebrityById(id);
        if (existing == null)
            throw new FoundByIdException($"Celebrity Id {id} not found for update");

        existing.Firstname = updatedCelebrity.Firstname;
        existing.Surname = updatedCelebrity.Surname;
        existing.PhotoPath = updatedCelebrity.PhotoPath;

        int? newId = repository.updCelebrityById(id, existing);
        if (newId == null)
            throw new UpdateException($"Failed to update celebrity with Id = {id}");

        if (repository.SaveChanges() <= 0)
            throw new SaveException("Failed to save after update");

        return Results.Ok(new
        {
            Message = $"Successfully updated celebrity with Id = {id}",
            Data = existing
        });
    });

    app.MapDelete("/Celebrities/{id:int}", (int id) =>
    {
        if (!repository.delCelebrityById(id))
            throw new DelByIdException($"DELETE /Celebrities error, Id = {id}");

        return Results.Ok($"Celebrity with Id = {id} deleted");
    });

    app.Map("/Celebrities/Error", (HttpContext ctx) =>
    {
        Exception? ex = ctx.Features.Get<IExceptionHandlerFeature>()?.Error;
        IResult rc = Results.Problem(
            detail: "Panic",
            instance: app.Environment.EnvironmentName,
            title: "ASPA004",
            statusCode: 500);

        if (ex != null)
        {
            if (ex is DelByIdException) rc = Results.NotFound(ex.Message); // не найден
            if (ex is FileNotFoundException) rc = Results.Problem(
                title: "ASPA004/FileNotFound",
                detail: ex.Message,
                instance: app.Environment.EnvironmentName,
                statusCode: 500);
            if (ex is FoundByIdException) rc = Results.NotFound(ex.Message);
            if (ex is BadHttpRequestException) rc = Results.BadRequest(ex.Message);
            if (ex is SaveException) rc = Results.Problem(
                title: "ASPA004/SaveChanges",
                detail: ex.Message,
                instance: app.Environment.EnvironmentName,
                statusCode: 500);
            if (ex is AddCelebrityException) rc = Results.Problem(
                title: "ASPA004/addCelebrity",
                detail: ex.Message,
                instance: app.Environment.EnvironmentName,
                statusCode: 500);
            if (ex is UpdateException) rc = Results.Problem(
                title: "ASPA004/Update",
                detail: ex.Message,
                instance: app.Environment.EnvironmentName,
                statusCode: 500);
        }
        return rc;
    });

    app.MapFallback((HttpContext ctx) =>
        Results.NotFound(new { error = $"path {ctx.Request.Path} not supported" }));

    app.Run();
}

public class UpdateException : Exception
{
    public UpdateException(string message) : base($"Update error: {message}") { }
};
public class DelByIdException : Exception
{
    public DelByIdException(string message) : base($"Delete by Id: {message}") { }
};
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