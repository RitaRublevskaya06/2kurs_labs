using Microsoft.AspNetCore.HttpLogging;

internal class Program
{
    private static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);       // ������ WebApplicationBuilder (������� builder), ������� ������������ ��� ��������� ���-����������

        // ��������� ������ HTTPLogging
        builder.Services.AddHttpLogging(loggingBuilder =>
        {
            loggingBuilder.LoggingFields = HttpLoggingFields.All; // ��������� ����� ��� �����������
        });

        var app = builder.Build();                              // ������ ��������� WebApplication

        // ���������� middleware ��� HTTPLogging
        app.UseHttpLogging();

        app.MapGet("/", () => "�� ������ ASPA!");       // ����� �������� �����
        app.MapGet("/g", () => "�� !");

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
//            var builder = WebApplication.CreateBuilder(args);       // ������ WebApplicationBuilder (������� builder)
//            var app = builder.Build();                              // ������ ��������� WebApplication

//            app.MapGet("/", () => "�� ������ ASPA!");              // ����� �������� �����

//            app.Run();
//        }
//    }
//}