using System.Runtime.InteropServices.JavaScript;
using System.Security.Cryptography.X509Certificates;
using LQiW_Server.Classen;
using LQiW_Server.OpenData;
using LQiW_Server.UserGroup;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Hosting.Internal;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Mvc;

namespace LQiW_Server.Controllers;


[Route("api/[controller]")]
[ApiController]
public class FeedbacksController : ControllerBase
{
    [HttpGet]
    public ActionResult GetFeedback()
    {
        using (var context = new ApplicationContext())
        {
            if (context.Feedbacks.Count() == 0)
            {
                return StatusCode(209, "Keine Feedbacks");
            }
            else
            {
                return Ok(JsonConvert.SerializeObject(context.Feedbacks));
            }
        }
    }

    [HttpPost]
    public async Task<IActionResult> PostAsync([FromBody] dynamic data)
    {
        Console.WriteLine(data);
        return Ok("post feedback");
    }
}

[Route("api/[controller]")]
[ApiController]
public class StatsController : ControllerBase
{
    [HttpGet]
    public ActionResult GetStats()
    {
        StatsResponse statsResponse = new StatsResponse();
        statsResponse.SaveCounts();
        var response = JsonConvert.SerializeObject(statsResponse);
        return Ok(response);
    }
}

[Route("api/[controller]")]
[ApiController]
public class DataController :  ControllerBase
{
    [HttpPost]
    public async Task<IActionResult> PostAsync([FromBody] dynamic data)
    {
        RatingResponse ratingResponse = new RatingResponse();
        var httpClient = new HttpClient();
        GeocodingService geocodingService = new GeocodingService(httpClient, "AIzaSyAjk0lcOnuSDT6IpuikBvZJTOjWISWALIs");
        MessageFromClient messageFromClient = JsonConvert.DeserializeObject<MessageFromClient>(data.ToString());
        messageFromClient.ParseAddress();
        ratingResponse.Address = messageFromClient.Address;
        
        
        
        try
        {
            UserLocation userLocation= await geocodingService.GetLocationDetailsFromAddress(messageFromClient.Address);
            ratingResponse.DistrictName = userLocation.District;
            if (messageFromClient.UserGroup == "alone")
            {
                Alone alone = new Alone(userLocation, ratingResponse);
            }

            switch (messageFromClient.UserGroup)
            {
                case "alone":
                    Alone alone = new Alone(userLocation, ratingResponse);
                    break;
                case "family":
                    Family family = new Family(userLocation, ratingResponse);
                    break;
                case "student":
                    Student student = new Student(userLocation, ratingResponse);
                    break;
                case "young-couple":
                    YoungCouple youngCouple = new YoungCouple(userLocation, ratingResponse);
                    break;
                case "pensioneur":
                    Pension pension = new Pension(userLocation, ratingResponse);
                    break;
                case "invalid":
                    Disabled disabled = new Disabled(userLocation, ratingResponse);
                    break;
                default:
                    return StatusCode(402);
                    
            }
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            if (e.Message == "notAT")
            {
                return StatusCode(405, "Address is not in Vienna");
            } 
            throw;
        }
        var response = JsonConvert.SerializeObject(ratingResponse);
        return Ok(response);
    }
}