namespace LQiW_Server.Classen;
using Newtonsoft.Json.Linq;


public static class Algorithmus
{
    public static void readJSON()
    {
        string json = System.IO.File.ReadAllText("OpenData/ARZTOGD.json");
        PrintHospitalInformation(json);
    }
    static void PrintHospitalInformation(string json)
    {
        List<string> Clinics = new List<string>();
        var data = JObject.Parse(json);

        using (var db = new ApplicationContext())
        {
            int id = 0;
            foreach (var item in data["features"])
            {
                if ((string)item["properties"]["FACH"] != "Allgemeinmedizin")
                    continue;
                if (Clinics.Contains((string)item["properties"]["NAME"]))
                    continue;
                else
                    Clinics.Add((string)item["properties"]["NAME"]);
            
                string name = (string)item["properties"]["NAME"];
                string address = (string)item["properties"]["ADRESSE"];
                
                Doctor CW = new Doctor()
                {
                    Id = id,
                    Name = (string)item["properties"]["NAME"],
                    Adresse = (string)item["properties"]["ADRESSE"]
                };
                db.Doctors.Add(CW);
                id++;
            }
            db.SaveChanges();
        }
    }
    
    public static int Count;
}