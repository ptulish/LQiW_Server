using LQiW_Server.Classen;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace LQiW_Server.Controllers;

public class RatingResponse
{
    public int StatusCode { get; set; }
    public string Address { get; set; }
    public string DistrictName { get; set; }
    public double BibliothekRating { get; set; }
    public double ClinicRating { get; set; }
    public double DisParkRating { get; set; }
    public double DoctorRating { get; set; }
    public double KinderGartenRating { get; set; }
    public double MuseumRating { get; set; }
    public double MusikSchoolRating { get; set; }
    public double ParkRating { get; set; }
    public double PoliceStationRating { get; set; }
    public double PoolRating { get; set; }
    public double PublicTransportRating { get; set; }
    public double SchoolRating { get; set; }
    public double UniversityRating { get; set; }
    public double AverageRating { get; set; }

    public List<string> Lines = new List<string>();
    public List<string> LinesKM = new List<string>();
    public List<string> ParkNames = new List<string>();
    public List<bool> ParkDrink = new List<bool>();
    public List<bool> ParkDog = new List<bool>();
    public List<bool> ParkPlay = new List<bool>();
    public List<double> ParkDistances = new List<double>();
    
    public void SaveRating(string group, List<(Bibliothek, double)> nearestBibliotheks, List<(Clinic, double)> nearestClinic, List<(DisPark, double)> nearestParkings, List<(Doctor, double)> nearestDoctors, List<(Kindergarden, double)> nearestKindergartens, List<(Museum, double)> nearestMuseums, List<(MusikSchool, double)> nearestMusicSchools, List<(Park, double)> nearestParks, List<(PoliceStation, double)> nearestPoliceStations, List<(Pool, double)> nearestPools, List<(PublicTransportStop, double)> nearestStops, List<(School, double)> nearestSchools, List<(University, double)> nearestUniversities)
    {

        BibliothekRating = nearestBibliotheks.Count > 0 ? Bibliothek.CalculateAverageRatingBibliothek(nearestBibliotheks) : -1;
        ClinicRating = nearestClinic.Count > 0 ? Clinic.CalculateAverageRatingClinic(nearestClinic) : -1;
        DisParkRating = nearestParkings.Count > 0 ? DisPark.CalculateAverageRatingDisPark(nearestParkings) : -1;
        DoctorRating = nearestDoctors.Count > 0 ? Doctor.CalculateAverageRatingDoctor(nearestDoctors) : -1;
        KinderGartenRating = nearestKindergartens.Count > 0 ? Kindergarden.CalculateAverageRatingKindergarden(nearestKindergartens) : -1;
        MuseumRating = nearestMuseums.Count > 0 ? Museum.CalculateAverageRatingMuseum(nearestMuseums) : -1;
        MusikSchoolRating = nearestMusicSchools.Count > 0 ? MusikSchool.CalculateAverageRatingMusikSchool(nearestMusicSchools) : -1;
        ParkRating = nearestParks.Count > 0 ? Park.CalculateAverageRatingPark(group, nearestParks, ParkNames, ParkDrink, ParkDog, ParkPlay, ParkDistances) : -1;
        PoliceStationRating = nearestPoliceStations.Count > 0 ? PoliceStation.CalculateAverageRatingPoliceStation(nearestPoliceStations) : -1;
        PoolRating = nearestPools.Count > 0 ? Pool.CalculateAverageRatingPool(nearestPools) : -1;
        PublicTransportRating = nearestStops.Count > 0 ? PublicTransportStop.CalculateAverageRatingPublicTransportStop(nearestStops, this.Lines, this.LinesKM) : -1;
        SchoolRating = nearestSchools.Count > 0 ? School.CalculateAverageRatingSchool(nearestSchools) : -1;
        UniversityRating = nearestUniversities.Count > 0 ? University.CalculateAverageRatingUniversity(nearestUniversities) : -1;
    }
}