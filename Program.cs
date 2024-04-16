using LQiW_Server.Classen;
using LQiW_Server.OpenData;

var builder = WebApplication.CreateBuilder(args);

// Füge dies hinzu, um Unterstützung für Controller hinzuzufügen
builder.Services.AddControllers();

//function to update the jsons from opendata (has to be downloaded into the OpenData folder
//ConverterFromJSONToDB.startSave();

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", policy =>
    {
        policy.AllowAnyOrigin()
            .AllowAnyMethod()
            .AllowAnyHeader();
    });
});


var app = builder.Build();

app.UseCors("AllowAll");

// Middleware für Routing
app.UseRouting();

// CORS-Middleware
app.UseCors();

// Middleware, die Controller-Endpoints verfügbar macht
app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers(); // Registriert Controller-Endpoints
});

app.Run();