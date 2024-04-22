using System.Runtime.CompilerServices;
using LQiW_Server.Classen;
using LQiW_Server.Controllers;
using Microsoft.EntityFrameworkCore;

namespace LQiW_Server.UserGroup;

public class Alone
{
    List<Bibliothek> bibliotheks = new List<Bibliothek>();
    List<DisPark> disParks = new List<DisPark>();
    List<Doctor> doctors = new List<Doctor>();
    List<Kindergarden> kindergardens = new List<Kindergarden>();
    List<Museum> museums = new List<Museum>();
    List<MusikSchool> musikSchools = new List<MusikSchool>();
    List<Park> parks = new List<Park>();
    List<PoliceStation> policeStations = new List<PoliceStation>();
    List<Pool> pools = new List<Pool>();
    List<PublicTransportStop> publicTransportStops = new List<PublicTransportStop>();
    List<School> schools = new List<School>();
    List<University> universities = new List<University>();
    List<Clinic> clinics = new List<Clinic>();
    int count = 5;
    public static List<double> weights = new List<double>() { 1, 1, 0, 1.5, 0, 0, 0, 1, 1, 0.5, 2, 0, 1 };
    public List<double> Rankings = new List<double>();

    public Alone(UserLocation userLocation, RatingResponse ratingResponse)
    {
        LoadInfoFromDB();
        var nearestBibliotheks = LocationFinder.FindNearestLibraries(userLocation.Latitude, userLocation.Longitude, bibliotheks, 3);
        var nearestClinic = LocationFinder.FindNearestClinics(userLocation.Latitude, userLocation.Longitude, clinics, 3);
        var nearestParkings = LocationFinder.FindNearestDisParkings(userLocation.Latitude, userLocation.Longitude, disParks, 1);
        var nearestDoctors = LocationFinder.FindNearestDoctors(userLocation.Latitude, userLocation.Longitude, doctors, count);
        var nearestKindergartens = LocationFinder.FindNearestKindergartens(userLocation.Latitude, userLocation.Longitude, kindergardens, 1);
        var nearestMuseums = LocationFinder.FindNearestMuseums(userLocation.Latitude, userLocation.Longitude, museums, count);
        var nearestMusicSchools = LocationFinder.FindNearestMusicSchools(userLocation.Latitude, userLocation.Longitude, musikSchools, 1);
        var nearestParks = LocationFinder.FindNearestParks(userLocation.Latitude, userLocation.Longitude, parks, count);
        var nearestPoliceStations = LocationFinder.FindNearestPoliceStations(userLocation.Latitude, userLocation.Longitude, policeStations, 3);
        var nearestPools = LocationFinder.FindNearestPools(userLocation.Latitude, userLocation.Longitude, pools, 3);
        var nearestStops = LocationFinder.FindNearestPublicTransportStops(userLocation.Latitude, userLocation.Longitude, publicTransportStops, 10);
        var nearestSchools = LocationFinder.FindNearestSchools(userLocation.Latitude, userLocation.Longitude, schools, 1);
        var nearestUniversities = LocationFinder.FindNearestUniversities(userLocation.Latitude, userLocation.Longitude, universities, 2);

        ratingResponse.SaveRating("alone", nearestBibliotheks, nearestClinic, nearestParkings, nearestDoctors, nearestKindergartens, nearestMuseums, nearestMusicSchools, nearestParks, nearestPoliceStations, nearestPools, nearestStops, nearestSchools, nearestUniversities);

        AddRatingsToList(ratingResponse);
        ratingResponse.AverageRating = CalculateRating.CalculateWeightedAverage(Rankings, weights);

    }

    private void AddRatingsToList(RatingResponse ratingResponse)
    {
        Rankings.Add(ratingResponse.BibliothekRating);
        Rankings.Add(ratingResponse.ClinicRating);
        Rankings.Add(ratingResponse.DisParkRating);
        Rankings.Add(ratingResponse.DoctorRating);
        Rankings.Add(ratingResponse.KinderGartenRating);
        Rankings.Add(ratingResponse.MuseumRating);
        Rankings.Add(ratingResponse.MusikSchoolRating);
        Rankings.Add(ratingResponse.ParkRating);
        Rankings.Add(ratingResponse.PoliceStationRating);
        Rankings.Add(ratingResponse.PoolRating);
        Rankings.Add(ratingResponse.PublicTransportRating);
        Rankings.Add(ratingResponse.SchoolRating);
        Rankings.Add(ratingResponse.UniversityRating);
    }
    

    private void LoadInfoFromDB()
    {
        using (var db = new ApplicationContext())
        {
            bibliotheks = db.Bibliotheks.ToList();
            disParks = db.DisParks.ToList();
            doctors = db.Doctors.ToList();
            kindergardens = db.Kindergardens.ToList();
            museums = db.Museums.ToList();
            musikSchools = db.MusikSchools.ToList();
            parks = db.Parks.ToList();
            policeStations = db.PoliceStations.ToList();
            pools = db.Pools.ToList();
            publicTransportStops = db.PublicTransportStops.ToList();
            universities = db.Universities.ToList();
            schools = db.Schools.ToList();
            clinics = db.Clinics.ToList();
        }
    }
}