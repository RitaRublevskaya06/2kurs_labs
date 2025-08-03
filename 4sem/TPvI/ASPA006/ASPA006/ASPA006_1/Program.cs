using DAL_Celebrity;
using DAL_Celebrity_MSSQL;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.Extensions.Diagnostics.HealthChecks;
using Microsoft.Extensions.FileProviders;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;



var builder = WebApplication.CreateBuilder(args);

builder.Configuration.AddJsonFile("Celebrities.config.json", optional: false, reloadOnChange: true);

builder.Services.Configure<CelebritiesConfig>(
    builder.Configuration.GetSection(CelebritiesConfig.SectionName));

builder.Services.AddScoped<IRepository, Repository>((IServiceProvider p) =>
{
    CelebritiesConfig config = p.GetRequiredService<IOptions<CelebritiesConfig>>().Value;
    return new Repository(config.ConnectionString);
});

var app = builder.Build();
app.UseStaticFiles();
//app.UseExceptionHandler("/Error");
app.UseExceptionHandler(appError => {
    appError.Run(async context => {
        var ex = context.Features.Get<IExceptionHandlerFeature>()?.Error;
        if (ex is DeleteError deleteEx)
        {
            await context.Response.WriteAsJsonAsync(new
            {
                type = "https://tools.ietf.org/html/rfc7231#section-6.5.4",
                title = "Not Found",
                status = 404,
                detail = deleteEx.Message,
                instance = "ANC25"
            });
        }
        else if (ex is NullError nullError)
        {
            await context.Response.WriteAsJsonAsync(new
            {
                title = "Not Found Info",
                status = 404,
                detail = nullError.Message
            });
        }
        else if (ex is FileError fileError)
        {
            await context.Response.WriteAsJsonAsync(new
            {
                title = "Not Found file",
                statusCode = 404,
                detail = fileError.Message
            });
        }
        else if (ex is MinusIdError minusIdError)
        {
            await context.Response.WriteAsJsonAsync(new
            {
                title = "Negative index",
                statusCode = 404,
                detail = minusIdError.Message
            });
        }
        else
        {
            await context.Response.WriteAsJsonAsync(new
            {
                title = "Not Found this error",
                status = 500
            });
        }
    });
});

// --- ������ ���������� ��� ������ �� �������������� ---
var celebrities = app.MapGroup("/api/Celebrities");

//celebrities.MapGet("/", async (HttpContext context) => {
//    context.Response.ContentType = "text/html";
//    await context.Response.SendFileAsync("wwwroot/index.html");
//});

// �������� ���� �������������
celebrities.MapGet("/", (IRepository repo) =>
{
    var celebrities = repo.GetAllCelebrities();
    if (celebrities == null)
    {
        throw new NullError("GetAllCelebrities ������ null");
    }
    return repo.GetAllCelebrities();
});

// �������� ������������ �� ID
celebrities.MapGet("/{id:int:min(1)}", (IRepository repo, int id) =>
{
    if (id < 0)
    {
        throw new MinusIdError($"Negative id {id}");
    }
    // ���������� ��������� ������������ �� ID
    var celebrity = repo.GetCelebrityById(id);
    if (celebrity == null)
    {
        throw new NullError("GetCelebrityById ������ null");
    }
    return repo.GetCelebrityById(id);
});

// �������� ������������ �� ID �������
celebrities.MapGet("/LifeEvents/{eventId:int:min(1)}", (IRepository repo, int eventId) =>
{
    // ���������� ��������� ������������ �� ID �������
    if (eventId < 0)
    {
        throw new MinusIdError($"Negative id {eventId}");
    }
    var celebrity = repo.GetCelebrityByLifeeventId(eventId);
    if (celebrity == null)
    {
        throw new NullError("GetCelebrityById ������ null");
    }
    return repo.GetCelebrityByLifeeventId(eventId);
});

// ������� ������������ �� ID
celebrities.MapDelete("/{id:int:min(1)}", (IRepository repo, int id) =>
{
    if (id < 0)
    {
        throw new MinusIdError($"Negative id {id}");
    }
    var celebrity = repo.GetCelebrityById(id);
    if (celebrity == null)
    {
        throw new DeleteError($"404002:Celebrity Id = {id}");
    }
    repo.DelCelebrity(id);
    return celebrity;
});

// �������� ����� ������������
celebrities.MapPost("/", (IRepository repo, Celebrity celebrity) =>
{
    // ���������� ���������� ����� ������������
    repo.AddCelebrity(celebrity);
    if (repo.GetCelebrityIdByName(celebrity.FullName) == -1)
    {
        throw new NullError("GetCelebrityIdByName ������ null");
    }
    return repo.GetCelebrityIdByName(celebrity.FullName);
});

// �������� ������������ �� ID
celebrities.MapPut("/{id:int:min(1)}", (IRepository repo, int id, Celebrity celebrity) =>
{
    // ���������� ���������� ������������
    if (id < 0)
    {
        throw new MinusIdError($"Negative id {id}");
    }
    repo.UpdCelebrity(id, celebrity);
    return repo.GetCelebrityById(id);
});

// �������� ���� ���������� �� �����
celebrities.MapGet("/photo/{fileName}", async (IOptions<CelebritiesConfig> config, IWebHostEnvironment env, string fileName) =>
{
    var webRootPath = env.WebRootPath;

    var filePath = Path.Combine(webRootPath, "photo", fileName);

    if (!File.Exists(filePath))
    {
        throw new FileError($"File - {fileName} not found");
    }

    return Results.File(filePath, "image/jpeg");
});

// --- ������ ���������� ��� ������ � ��������� ---
var lifeEvents = app.MapGroup("/api/LifeEvents");

// �������� ��� �������
lifeEvents.MapGet("/", (IRepository repo) =>
{
    // ���������� ��������� ���� �������
    var lifeevents = repo.GetAllLifeevents();
    if (lifeevents == null)
    {
        throw new NullError("GetAllLifeevents ������ null");
    }
    return repo.GetAllLifeevents();
});

// �������� ������� �� ID
lifeEvents.MapGet("/{id:int:min(1)}", (IRepository repo, int id) =>
{
    // ���������� ��������� ������� �� ID
    if (id < 0)
    {
        throw new MinusIdError($"Negative id {id}");
    }
    var lifeevents = repo.GetLifeeventById(id);
    if (lifeevents == null)
    {
        throw new NullError("GetLifeeventById ������ null");
    }
    return repo.GetLifeeventById(id);
});

// �������� ��� ������� �� ID ������������
lifeEvents.MapGet("/Celebrities/{celebrityId:int:min(1)}", (IRepository repo, int celebrityId) =>
{
    // ���������� ��������� ������� ������������
    if (celebrityId < 0)
    {
        throw new MinusIdError($"Negative id {celebrityId}");
    }
    var lifeevents = repo.GetLifeeventsByCelebrityId(celebrityId);
    if (lifeevents == null)
    {
        throw new NullError("GetLifeeventsByCelebrityId ������ null");
    }
    return repo.GetLifeeventsByCelebrityId(celebrityId);
});

// ������� ������� �� ID
lifeEvents.MapDelete("/{id:int:min(1)}", (IRepository repo, int id) =>
{
    if (id < 0)
    {
        throw new MinusIdError($"Negative id {id}");
    }
    var celebrity = repo.GetLifeeventById(id);
    if (celebrity == null)
    {
        throw new DeleteError($"404002:Lifeevent Id = {id}");
    }
    repo.DelLifeevent(id);
    return celebrity;
});

// �������� ����� �������
lifeEvents.MapPost("/", (IRepository repo, Lifeevent lifeEvent) =>
{
    // ���������� ���������� ������ �������
    repo.AddLifeevent(lifeEvent);
    if (repo.GetLifeeventsByCelebrityId(lifeEvent.CelebrityId) == null)
    {
        throw new NullError("GetLifeeventsByCelebrityId ������ null");
    }
    return repo.GetLifeeventsByCelebrityId(lifeEvent.CelebrityId);
});

// �������� ������� �� ID
lifeEvents.MapPut("/{id:int:min(1)}", (IRepository repo, int id, Lifeevent lifeEvent) =>
{
    // ���������� ���������� �������
    if (id < 0)
    {
        throw new MinusIdError($"Negative id {id}");
    }
    repo.UpdLifeevent(id, lifeEvent);
    return repo.GetLifeeventById(id);
});

app.Map("/Error", (HttpContext ctx) =>
{
    var ex = ctx.Features.Get<IExceptionHandlerFeature>()?.Error;
    if (ex is DeleteError deleteError)
    {
        return Results.Problem(
            type: "https://tools.ietf.org/html/rfc7231#section-6.5.4",
            title: "Not Found",
            statusCode: 404,
            detail: deleteError.Message,
            instance: "ANC25"
        );
    }
    else if (ex is NullError nullError)
    {
        return Results.Problem(
            title: "Not Found Info",
            statusCode: 404,
            detail: nullError.Message
        );
    }
    else if (ex is FileError fileError)
    {
        return Results.Problem(
            title: "Not Found file",
            statusCode: 404,
            detail: fileError.Message
        );
    }
    else if (ex is MinusIdError minusIdError)
    {
        return Results.Problem(
            title: "Negative index",
            statusCode: 404,
            detail: minusIdError.Message
        );
    }

    return Results.Problem(
        title: "Not Found this error",
        statusCode: StatusCodes.Status500InternalServerError
    );
});
app.Run();
public class DeleteError : Exception
{
    public DeleteError(string message) : base($"Delete by Id: {message}") { }
}
public class NullError : Exception
{
    public NullError(string message) : base($"Null info: {message}") { }
}
public class FileError : Exception
{
    public FileError(string message) : base($"File not found: {message}") { }
}
public class MinusIdError : Exception
{
    public MinusIdError(string message) : base($"Negative index: {message}") { }
}
public class CelebritiesConfig
{
    public const string SectionName = "Celebrities";

    public string PhotosFolder { get; set; } = string.Empty;
    public string ConnectionString { get; set; } = string.Empty;
}


