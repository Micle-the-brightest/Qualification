using System.Text.Json;
using Dormitory.Entityes;
using FastEndpoints;
using FastEndpoints.Swagger;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

/*var  MyAllowSpecificOrigins = "_myAllowSpecificOrigins"; //додав #1#*/

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

builder.Services.AddCors();
var app = builder.Build();



        
        app.UseCors(options =>
        {
            options.WithOrigins(new []{"http://localhost:3000"});
            options.AllowAnyMethod();
            options.AllowAnyHeader();
        });
        
        
        app.UseCors(options => options.WithOrigins("http://localhost:3000/").AllowAnyHeader().AllowAnyMethod());
        


        /*app.UseCors(opt => opt.AllowCredentials().AllowAnyHeader().AllowAnyMethod()); //додав
        #1#*/
        
//app cors
 


app.MapGet("/", () =>"AmazingDormitory");

app.UseFastEndpoints(configuration =>
{
    configuration.SerializerOptions = options =>
    {
        options.PropertyNamingPolicy = JsonNamingPolicy.CamelCase;//для співставлення
    };
});
app.UseOpenApi();
app.UseSwaggerUi3(s => s.ConfigureDefaults());
app.Run(); 

