using System.Text.Json;
using Dormitory.Entityes;
using FastEndpoints;
using FastEndpoints.Swagger;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

var connectionString = builder.Configuration.GetConnectionString("BloggingContext");
builder.Services.AddDbContext<DormitoryContext>(options =>
    options.UseNpgsql(connectionString));

builder.Services.AddFastEndpoints();
builder.Services.AddSwaggerDoc(settings =>
{
    settings.Title = "UMSystem Rating Service API";
    settings.Version = "v1";
});

var app = builder.Build();

app.UseFastEndpoints(configuration =>
{
    configuration.SerializerOptions = options =>
    {
        options.PropertyNamingPolicy = JsonNamingPolicy.CamelCase;
    };
});

app.UseOpenApi();
app.UseSwaggerUi3(s => s.ConfigureDefaults());

app.Run(); 

