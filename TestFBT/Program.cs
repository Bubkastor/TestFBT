using Application;
using Microsoft.AspNetCore.Builder;
using Microsoft.OpenApi.Models;
using Persistance;
using PersistanceMigrations;

namespace TestFBT;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);
        builder.Services.ConfigureDb(builder.Configuration.GetSection("Database"));
        builder.Services.AddApplicationDependencies();
        builder.Services.AddControllers();
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen(options =>
        {
            options.SwaggerDoc("v1", new OpenApiInfo
            {
                Version = "v1",
                Title = "ToDo API",
                Description = "An ASP.NET Core Web API for managing ToDo items",
                TermsOfService = new Uri("https://example.com/terms"),
            });
        });

        var app = builder.Build();

        app.UpdatePawnDb(builder.Configuration);
        app.UseHttpsRedirection();
        app.UseAuthorization();
        app.MapControllers();

        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.Run();
    }
}
