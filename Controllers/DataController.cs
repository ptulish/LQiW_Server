using LQiW_Server.Classen;
using LQiW_Server.OpenData;
using Microsoft.AspNetCore.Mvc;

namespace LQiW_Server.Controllers;

[ApiController]
[Route("[controller]")]
public class DataController :  ControllerBase
{
    [HttpPost]
    public async Task<IActionResult> PostAsync([FromBody] dynamic daten)
    {
        Console.WriteLine(daten.ToString());
        ConverterFromJSONToDB.startSave();
        // Simuliere eine asynchrone Operation, z.B. eine Datenbankabfrage oder einen externen API-Aufruf
        await Task.Delay(1000); // Entferne diese Zeile in der Produktionsumgebung. Es dient hier nur als Beispiel.
        
        var responseMessage = "Hall von Server";

        // Gebe die Nachricht als Antwort zurück
        return Content(responseMessage, "text/plain");
    }
}