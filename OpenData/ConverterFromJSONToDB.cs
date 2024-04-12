using System.Net;
using LQiW_Server.Classen;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json.Linq;

namespace LQiW_Server.OpenData;

public static class ConverterFromJSONToDB
{
    public static void startSave()
    {
        string json = System.IO.File.ReadAllText("OpenData/ARZTOGD.json");
        SaveDoctorInformation(json);
        json = File.ReadAllText("OpenData/BEHINDERTENPARKPLATZOGD.json");
        SaveDisParkingInformation(json);
        json = File.ReadAllText("OpenData/BUECHEREIOGD.json");
        SaveBibliothekInformation(json);
        json = File.ReadAllText("OpenData/KRANKENHAUSOGD.json");
        SaveClinicInformation(json);
        json = File.ReadAllText("OpenData/KINDERGARTENOGD.json");
        SaveKinderGardenInformation(json);
        json = File.ReadAllText("OpenData/MUSEUMOGD.json");
        SaveMuseumInformation(json);
        json = File.ReadAllText("OpenData/MUSIKSINGSCHULEOGD.json");
        SaveMusikSchoolInformation(json);
        json = File.ReadAllText("OpenData/PARKINFOOGD.json");
        SaveParkInformation(json);
        json = File.ReadAllText("OpenData/POLIZEIOGD.json");
        SavePoliceStationInformation(json);
        json = File.ReadAllText("OpenData/SCHWIMMBADOGD.json");
        SavePoolInformation(json);
        json = File.ReadAllText("OpenData/SCHULEOGD.json");
        SaveSchoolInformation(json);
        json = File.ReadAllText("OpenData/UNIVERSITAETOGD.json");
        SaveUniversityInformation(json);
        json = File.ReadAllText("OpenData/OEFFHALTESTOGD.json");
        SavePublicTransportStop(json);
    }

    static void SavePublicTransportStop(string json)
    {
        List<PublicTransportStop> publicTransportStops = new List<PublicTransportStop>();
        var data = JObject.Parse(json);

        using (var db = new ApplicationContext())
        {
            var entries = db.PublicTransportStops.ToList();
            db.PublicTransportStops.RemoveRange(entries);
            db.SaveChanges();

            foreach (var item in data["features"])
            {
                string name = (string)item["properties"]["HTXT"];
                string lines = (string)item["properties"]["HLINIEN"];
                var coordinates = (JArray)item["geometry"]["coordinates"];

                PublicTransportStop publicTransportStop = new PublicTransportStop()
                {
                    Name = name, Lines = lines, Longitude = (double)coordinates[0], Latitude = (double)coordinates[1]
                };
                db.PublicTransportStops.Add(publicTransportStop);
                publicTransportStops.Add(publicTransportStop);
            }
            db.SaveChanges();
            PublicTransportStop.PublicTransportStopsCount = publicTransportStops.Count;
        }
    }

    static void SaveUniversityInformation(string json)
    {
        List<Univesity> universities = new List<Univesity>();
        List<string> uniNames = new List<string>();
        var data = JObject.Parse(json);

        using (var db = new ApplicationContext())
        {
            var entries = db.Universities.ToList();
            db.Universities.RemoveRange(entries);
            db.SaveChanges();
            
            foreach (var item in data["features"])
            {
                string name = (string)item["properties"]["NAME"];
                string address = (string)item["properties"]["ADRESSE"];
                string part = (string)item["properties"]["BEZEICHNUNG"];
                var coordinates = (JArray)item["geometry"]["coordinates"];
                
                Univesity univesity = new Univesity()
                {
                    Name = name, Adresse = address, Part = part,Latitude = (double)coordinates[1], Longitude = (double)coordinates[0],
                };
                db.Universities.Add(univesity);
                universities.Add(univesity);
                uniNames.Add(name);
            }
            db.SaveChanges();
            Univesity.UniversityCount = universities.Count;
        }
    }

    static void SaveSchoolInformation(string json)
    {
        List<School> schools = new List<School>();
        var data = JObject.Parse(json);

        using (var db = new ApplicationContext())
        {
            var entries = db.Schools.ToList();
            db.Schools.RemoveRange(entries);
            db.SaveChanges();
            
            foreach (var item in data["features"])
            {
                var coordinates = (JArray)item["geometry"]["coordinates"];
                string name = (string)item["properties"]["NAME"];
                string addresse = (string)item["properties"]["ADRESSE"];
                School school = new School()
                {
                    Name = name, Adresse = addresse, Latitude = (double)coordinates[1], Longitude = (double)coordinates[0],
                };
                db.Schools.Add(school);
                schools.Add(school);
            }
            db.SaveChanges();
            School.SchoolsCount = schools.Count;
        }
    }

    static void SavePoolInformation(string json)
    {
        List<Pool> pools = new List<Pool>();
        var data = JObject.Parse(json);

        using (var db = new ApplicationContext())
        {
            var entries = db.Pools.ToList();
            db.Pools.RemoveRange(entries);
            db.SaveChanges();
            
            foreach (var item in data["features"])
            {
                var coordinates = (JArray)item["geometry"]["coordinates"];
                string name = (string)item["properties"]["NAME"];
                string address = (string)item["properties"]["ADRESSE"];

                Pool pool = new Pool()
                {
                    Name = name, Adresse = address, Latitude = (double)coordinates[1], Longitude = (double)coordinates[0],
                };
                db.Pools.Add(pool);
                pools.Add(pool);
            }
            db.SaveChanges();
            Pool.PoolsCount = pools.Count;
        }
    }

    static void SavePoliceStationInformation(string json)
    {
        List<PoliceStation> policeStations = new List<PoliceStation>();
        var data = JObject.Parse(json);

        using (var db = new ApplicationContext())
        {
            var entries = db.PoliceStations.ToList();
            db.PoliceStations.RemoveRange(entries);
            db.SaveChanges();
            
            foreach (var item in data["features"])
            {
                var coordinates = (JArray)item["geometry"]["coordinates"];
                string name = (string)item["properties"]["NAME"];
                string addresse = (string)item["properties"]["ADRESSE"];

                PoliceStation policeStation = new PoliceStation()
                {
                    Name = name, Adresse = addresse, Latitude = (double)coordinates[1], Longitude = (double)coordinates[0],
                };
                db.PoliceStations.Add(policeStation);
                policeStations.Add(policeStation);
            }
            db.SaveChanges();
            PoliceStation.PolicestationCount = policeStations.Count;
        }
    }

    static void SaveParkInformation(string json)
    {
        List<Park> parks = new List<Park>();
        var data = JObject.Parse(json);

        using (var db  = new ApplicationContext())
        {
            var entries = db.Parks.ToList();
            db.Parks.RemoveRange(entries);
            db.SaveChanges();
            
            foreach (var item in data["features"])
            {
                string name = (string)item["properties"]["ANL_NAME"];
                var coordinates = (JArray)item["geometry"]["coordinates"];
                string square1 = (string)item["properties"]["FLAECHE"];
                string[] hi = square1.Split(" ");
                double square = Convert.ToDouble(hi[0]);
                bool forChildren = (string)item["properties"]["SPIELEN_IM_PARK"] == "Ja";
                bool drink = (string)item["properties"]["WASSER_IM_PARK"] == "Ja";
                bool dogs = (string)item["properties"]["HUNDE_IM_PARK"] == "Ja";

                Park park = new Park()
                {
                    Name = name, Latitude = (double)coordinates[1], Longitude = (double)coordinates[0], Square = square, ForChildren = forChildren, Drink = drink, Dogs = dogs
                };
                db.Parks.Add(park);
                parks.Add(park);
            }
            db.SaveChanges();
            Park.ParkCount = parks.Count;
        }
    }

    static void SaveMusikSchoolInformation(string json)
    {
        List<MusikSchool> musikSchools = new List<MusikSchool>();
        var data = JObject.Parse(json);

        using (var db = new ApplicationContext())
        {
            var entries = db.MusikSchools.ToList();
            db.MusikSchools.RemoveRange(entries);
            db.SaveChanges();
            
            foreach (var item in data["features"])
            {
                var coordinates = (JArray)item["geometry"]["coordinates"];
                string name = (string)item["properties"]["NAME"];
                string address = (string)item["properties"]["ADRESSE"];

                MusikSchool musikSchool = new MusikSchool()
                {
                    Name = name, Adresse = address, Latitude = (double)coordinates[1], Longitude = (double)coordinates[0],
                };
                db.MusikSchools.Add(musikSchool);
                musikSchools.Add(musikSchool);
            }
            db.SaveChanges();
            MusikSchool.MusikSchoolsCount = musikSchools.Count;
        }
    }

    static void SaveMuseumInformation(string json)
    {
        List<Museum> museums = new List<Museum>();
        var data = JObject.Parse(json);
        
        using (var db = new ApplicationContext())
        {
            var entries = db.Museums.ToList();
            db.Museums.RemoveRange(entries);
            db.SaveChanges();
            
            foreach (var item in data["features"])
            {
                string name = (string)item["properties"]["NAME"];
                string address = (string)item["properties"]["ADRESSE"];
                var coordinates = (JArray)item["geometry"]["coordinates"];
                
                Museum museum = new Museum()
                {
                    Name = name, Adresse = address, Latitude = (double)coordinates[1], Longitude = (double)coordinates[0],
                };
                db.Museums.Add(museum);
                museums.Add(museum);
            }
            db.SaveChanges();
            Museum.MuseumsCount = museums.Count;
        }

    }

    static void SaveKinderGardenInformation(string json)
    {
        List<Kindergarden> kindergardens = new List<Kindergarden>();
        var data = JObject.Parse(json);
        
        using (var db = new ApplicationContext())
        {
            var entries = db.Kindergardens.ToList();
            db.Kindergardens.RemoveRange(entries);
            db.SaveChanges();
            
            foreach (var item in data["features"])
            {
                var coordinates = (JArray)item["geometry"]["coordinates"];
                string name = (string)item["properties"]["BETREIBER"];
                string adress = (string)item["properties"]["ADRESSE"];

                Kindergarden kindergarden = new Kindergarden()
                {
                    Owner = name, Adresse = adress, Latitude = (double)coordinates[1], Longitude = (double)coordinates[0],
                };
                db.Kindergardens.Add(kindergarden);
                kindergardens.Add(kindergarden);
            }
            db.SaveChanges();
            Kindergarden.KinderGardenCount = kindergardens.Count;
        }
    }
    
    static void SaveBibliothekInformation(string json)
    {
        List<Bibliothek> bibliotheks = new List<Bibliothek>();
        var data = JObject.Parse(json);

        using (var db = new ApplicationContext())
        {
            var entries = db.Bibliotheks.ToList();
            db.Bibliotheks.RemoveRange(entries);
            db.SaveChanges();
            
            foreach (var item in data["features"])
            {
                var coordinates = (JArray)item["geometry"]["coordinates"];
                string name = (string)item["properties"]["NAME"];
                string address = (string)item["properties"]["ADRESSE"];

                Bibliothek bibliothek = new Bibliothek()
                {
                    Name = name, Adresse = address, Latitude = (double)coordinates[1], Longitude = (double)coordinates[0],
                };
                bibliotheks.Add(bibliothek);
                db.Bibliotheks.Add(bibliothek);
            }
            db.SaveChanges();
            Bibliothek.BibliothekCount = bibliotheks.Count;
        }
    }

    static void SaveClinicInformation(string json)
    {
        List<Clinic> clinics = new List<Clinic>();
        var data = JObject.Parse(json);

        using (var db = new ApplicationContext())
        {
            var entries = db.Clinics.ToList();
            db.Clinics.RemoveRange(entries);
            db.SaveChanges();
            
            foreach (var item in data["features"])
            {
                var coordinates = (JArray)item["geometry"]["coordinates"];
                string name = (string)item["properties"]["BEZEICHNUNG"];
                string adress = (string)item["properties"]["ADRESSE"];
                Clinic clinic = new Clinic()
                {
                    Name = name,
                    Latitude = (double)coordinates[1],
                    Longitude = (double)coordinates[0],
                    Adresse = adress
                };
                clinics.Add(clinic);
                db.Clinics.Add(clinic);
            }
            db.SaveChanges();
            Clinic.ClinicCount = clinics.Count;
        }
    }
    static void SaveDisParkingInformation(string json)
    {
        List<DisPark> DisParkings = new List<DisPark>();
        var data = JObject.Parse(json);

        using (var db = new ApplicationContext())
        {
            var entries = db.DisParks.ToList();
            db.DisParks.RemoveRange(entries);
            db.SaveChanges();
            
            foreach (var item in data["features"])
            {
                var streetName = (string)item["properties"]["STRNAM"];
                var coordinates = (JArray)item["geometry"]["coordinates"];
                var parksCount = (int)item["properties"]["STELLPL_ANZ"];

                DisPark disPark = new DisPark()
                {
                    StreetName = streetName,
                    Latitude = (double)coordinates[1],
                    Longitude = (double)coordinates[0],
                    ParkCount = parksCount
                };
                DisParkings.Add(disPark);
                db.DisParks.Add(disPark);
            }
            db.SaveChanges();
            DisPark.ParkCountInCity = DisParkings.Count;
        }
    }
    static void SaveDoctorInformation(string json)
    {
        List<string> Doctors = new List<string>();
        var data = JObject.Parse(json);

        using (var db = new ApplicationContext())
        {
            var entries = db.Doctors.ToList();
            db.Doctors.RemoveRange(entries);
            db.SaveChanges();
            
            foreach (var item in data["features"])
            {
                if ((string)item["properties"]["FACH"] != "Allgemeinmedizin")
                    continue;
                if (Doctors.Contains((string)item["properties"]["NAME"]))
                    continue;
                else
                    Doctors.Add((string)item["properties"]["NAME"]);
                var coordinates = (JArray)item["geometry"]["coordinates"];
                
                Doctor doc = new Doctor()
                {
                    Name = (string)item["properties"]["NAME"],
                    Latitude = (double)coordinates[1],
                    Longitude = (double)coordinates[0],
                    Adresse = (string)item["properties"]["ADRESSE"]
                };
                db.Doctors.Add(doc);
            }
            db.SaveChanges();
            Doctor.DoctorCount = Doctors.Count;
        }
    }
}