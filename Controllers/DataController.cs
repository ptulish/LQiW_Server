using LQiW_Server.Classen;
using LQiW_Server.OpenData;
using LQiW_Server.UserGroup;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Hosting.Internal;
using Newtonsoft.Json;

namespace LQiW_Server.Controllers;

[Route("api/[controller]")]
[ApiController]
public class DataController :  ControllerBase
{
    [HttpPost]
    public async Task<IActionResult> PostAsync([FromBody] dynamic data)
    {
        var httpClient = new HttpClient();
        GeocodingService geocodingService = new GeocodingService(httpClient, "AIzaSyAjk0lcOnuSDT6IpuikBvZJTOjWISWALIs");
        MessageFromClient messageFromClient = JsonConvert.DeserializeObject<MessageFromClient>(data.ToString());
        messageFromClient.ParseAddress();

        try
        {
            UserLocation userLocation= await geocodingService.GetLocationDetailsFromAddress(messageFromClient.Address);
            if (Controllers.Response.StatusCode == 409)
            {
                return BadRequest();
            }

            List<Bibliothek> Bibliotheks = new List<Bibliothek>();
            using (var db = new ApplicationContext())
            {
                Bibliotheks = db.Bibliotheks.ToList();
            }

            var nearestBibliotheks = LocationFinder.FindNearestLibraries(userLocation.Latitude,
                userLocation.Longitude, Bibliotheks, 5);
            List<Clinic> clinics = new List<Clinic>();
            using (var db = new ApplicationContext())
            {
                clinics = db.Clinics.ToList();
            }
            var nearestClinic = LocationFinder.FindNearestClinics(userLocation.Latitude, userLocation.Longitude, clinics, 5);
            
            foreach (var (hospital, distance) in nearestClinic)
            {
                Console.WriteLine($"ID: {hospital.Id}, Name: {hospital.Name}, Address: {hospital.Adresse}, Distance: {distance:F2} km");
            }

            foreach (var (library, distance) in nearestBibliotheks)
            {
                Console.WriteLine($"ID: {library.Id}, Name: {library.Name}, Address: {library.Adresse}, Distance: {distance:F2} km");
            }
            if (messageFromClient.UserGroup == "alone")
            {
                Console.WriteLine($"Formatted Address: {userLocation.FormattedAddress}");
                Console.WriteLine($"Latitude: {userLocation.Latitude}, Longitude: {userLocation.Longitude}");
                Console.WriteLine($"Country: {userLocation.Country}, Postal Code: {userLocation.PostalCode}");
            }
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
        
        
        var responseMessage = $"Hall von Server{Algorithmus.Count}";
        Algorithmus.Count++;
        // Gebe die Nachricht als Antwort zurück
        return Content(responseMessage, "text/plain");
    }
}