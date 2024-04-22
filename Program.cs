using System.Net;
using System.Net.NetworkInformation;
using LQiW_Server.Classen;
using LQiW_Server.OpenData;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();


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

app.UseRouting();

app.UseCors();

app.UseAuthorization();

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllerRoute(
        name: "statsApi",
        pattern: "api/stats",
        defaults: new { controller = "Stats", action = "GetStats" });
    endpoints.MapControllerRoute(
        name: "feedbacksApi",
        pattern: "api/feedbacks",
        defaults: new { controller = "Feedbacks", action = "GetFeedback" });

    endpoints.MapControllerRoute(
        name: "default",
        pattern: "api/{controller}/{action=Index}/{id?}");
});

app.MapControllers();


using (var db = new ApplicationContext())
{
    Console.WriteLine("Checking Database");
    if (db.Bibliotheks.Count() == 0)
    {
        Console.WriteLine("DB is empty... filling...");
        //function to update the jsons from opendata (has to be downloaded into the OpenData folder
        ConverterFromJSONToDB.startSave();
    }

    Console.WriteLine("Check over");
    Console.WriteLine("Aktive TCP-Listener:");
    IPGlobalProperties ipProperties = IPGlobalProperties.GetIPGlobalProperties();
    IPEndPoint[] tcpListeners = ipProperties.GetActiveTcpListeners();

    foreach (var listener in tcpListeners)
    {
        Console.WriteLine($"Hört auf: {listener.Address} Port: {listener.Port}");
    }

    Console.WriteLine("Check over");
}


app.Run();