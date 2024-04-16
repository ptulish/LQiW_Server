namespace LQiW_Server.Classen;

public class LocationFinder
{
    public static double CalculateHaversineDistance(double lat1, double lon1, double lat2, double lon2)
    {
        var earthRadiusKm = 6371;

        var dLat = DegreesToRadians(lat2 - lat1);
        var dLon = DegreesToRadians(lon2 - lon1);

        lat1 = DegreesToRadians(lat1);
        lat2 = DegreesToRadians(lat2);

        var a = Math.Sin(dLat / 2) * Math.Sin(dLat / 2) +
                Math.Sin(dLon / 2) * Math.Sin(dLon / 2) * Math.Cos(lat1) * Math.Cos(lat2);
        var c = 2 * Math.Atan2(Math.Sqrt(a), Math.Sqrt(1 - a));
        return earthRadiusKm * c;
    }

    private static double DegreesToRadians(double degrees)
    {
        return degrees * Math.PI / 180.0;
    }

    public static List<(Bibliothek, double)> FindNearestLibraries(double currentLat, double currentLon, List<Bibliothek> libraries, int count = 5)
    {
        return libraries.Select(bibliothek => new
            {
                Library = bibliothek,
                Distance = CalculateHaversineDistance(currentLat, currentLon, bibliothek.Latitude, bibliothek.Longitude)
            })
            .OrderBy(x => x.Distance)
            .Take(count)
            .Select(x => (x.Library, x.Distance))
            .ToList();
    }
    public static List<(Clinic, double)> FindNearestClinics(double currentLat, double currentLon, List<Clinic> hospitals, int count = 5)
    {
        return hospitals.Select(clinic => new
            {
                Hospital = clinic,
                Distance = CalculateHaversineDistance(currentLat, currentLon, clinic.Latitude, clinic.Longitude)
            })
            .OrderBy(x => x.Distance)
            .Take(count)
            .Select(x => (x.Hospital, x.Distance))
            .ToList();
    }
    public static List<(DisPark, double)> FindNearestDisParkings(double currentLat, double currentLon, List<DisPark> parkings, int count = 5)
    {
        return parkings.Select(dispark => new
            {
                Parking = dispark,
                Distance = CalculateHaversineDistance(currentLat, currentLon, dispark.Latitude, dispark.Longitude)
            })
            .OrderBy(x => x.Distance)
            .Take(count)
            .Select(x => (x.Parking, x.Distance))
            .ToList();
    }
    public static List<(Doctor, double)> FindNearestDoctors(double currentLat, double currentLon, List<Doctor> doctors, int count = 5)
    {
        return doctors.Select(doctor => new
            {
                Doctor = doctor,
                Distance = CalculateHaversineDistance(currentLat, currentLon, doctor.Latitude, doctor.Longitude)
            })
            .OrderBy(x => x.Distance)
            .Take(count)
            .Select(x => (x.Doctor, x.Distance))
            .ToList();
    }
    public static List<(Kindergarden, double)> FindNearestKindergartens(double currentLat, double currentLon, List<Kindergarden> kindergartens, int count = 5)
    {
        return kindergartens.Select(kindergarden => new
            {
                Kindergarten = kindergarden,
                Distance = CalculateHaversineDistance(currentLat, currentLon, kindergarden.Latitude, kindergarden.Longitude)
            })
            .OrderBy(x => x.Distance)
            .Take(count)
            .Select(x => (x.Kindergarten, x.Distance))
            .ToList();
    }
    public static List<(Museum, double)> FindNearestMuseums(double currentLat, double currentLon, List<Museum> museums, int count = 5)
    {
        return museums.Select(museum => new
            {
                Museum = museum,
                Distance = CalculateHaversineDistance(currentLat, currentLon, museum.Latitude, museum.Longitude)
            })
            .OrderBy(x => x.Distance)
            .Take(count)
            .Select(x => (x.Museum, x.Distance))
            .ToList();
    }
    public static List<(MusikSchool, double)> FindNearestMusicSchools(double currentLat, double currentLon, List<MusikSchool> musicSchools, int count = 5)
    {
        return musicSchools.Select(school => new
            {
                School = school,
                Distance = CalculateHaversineDistance(currentLat, currentLon, school.Latitude, school.Longitude)
            })
            .OrderBy(x => x.Distance)
            .Take(count)
            .Select(x => (x.School, x.Distance))
            .ToList();
    }
    public static List<(Park, double)> FindNearestParks(double currentLat, double currentLon, List<Park> parks, int count = 5)
    {
        return parks.Select(park => new
            {
                Park = park,
                Distance = CalculateHaversineDistance(currentLat, currentLon, park.Latitude, park.Longitude)
            })
            .OrderBy(x => x.Distance)
            .Take(count)
            .Select(x => (x.Park, x.Distance))
            .ToList();
    }
    public static List<(PoliceStation, double)> FindNearestPoliceStations(double currentLat, double currentLon, List<PoliceStation> policeStations, int count = 5)
    {
        return policeStations.Select(station => new
            {
                Station = station,
                Distance = CalculateHaversineDistance(currentLat, currentLon, station.Latitude, station.Longitude)
            })
            .OrderBy(x => x.Distance)
            .Take(count)
            .Select(x => (x.Station, x.Distance))
            .ToList();
    }
    public static List<(Pool, double)> FindNearestPools(double currentLat, double currentLon, List<Pool> pools, int count = 5)
    {
        return pools.Select(pool => new
            {
                Pool = pool,
                Distance = CalculateHaversineDistance(currentLat, currentLon, pool.Latitude, pool.Longitude)
            })
            .OrderBy(x => x.Distance)
            .Take(count)
            .Select(x => (x.Pool, x.Distance))
            .ToList();
    }
    public static List<(PublicTransportStop, double)> FindNearestPublicTransportStops(double currentLat, double currentLon, List<PublicTransportStop> stops, int count = 5)
    {
        return stops.Select(stop => new
            {
                Stop = stop,
                Distance = CalculateHaversineDistance(currentLat, currentLon, stop.Latitude, stop.Longitude)
            })
            .OrderBy(x => x.Distance)
            .Take(count)
            .Select(x => (x.Stop, x.Distance))
            .ToList();
    }
    public static List<(School, double)> FindNearestSchools(double currentLat, double currentLon, List<School> schools, int count = 5)
    {
        return schools.Select(school => new
            {
                School = school,
                Distance = CalculateHaversineDistance(currentLat, currentLon, school.Latitude, school.Longitude)
            })
            .OrderBy(x => x.Distance)
            .Take(count)
            .Select(x => (x.School, x.Distance))
            .ToList();
    }
    public static List<(University, double)> FindNearestUniversities(double currentLat, double currentLon, List<University> universities, int count = 5)
    {
        return universities.Select(university => new
            {
                University = university,
                Distance = CalculateHaversineDistance(currentLat, currentLon, university.Latitude, university.Longitude)
            })
            .OrderBy(x => x.Distance)
            .Take(count)
            .Select(x => (x.University, x.Distance))
            .ToList();
    }

}