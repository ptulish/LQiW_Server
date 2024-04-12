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
}