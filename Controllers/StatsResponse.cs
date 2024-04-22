using LQiW_Server.Classen;

namespace LQiW_Server.Controllers;

public class StatsResponse
{
    public int BibliotheksCount { get; set; }
    public int ClinicsCount { get; set; }
    public int DisParkCount { get; set; }
    public int DoctorsCount { get; set; }
    public int KindergardensCount { get; set; }
    public int MuseumsCount { get; set; }
    public int MusikSchoolsCount { get; set; }
    public int ParksCount { get; set; }
    public int PoliceCount { get; set; }
    public int PoolCount { get; set; }
    public int StopsCount { get; set; }
    public int SchoolsCount { get; set; }
    public int UnisCount { get; set; }

    public void SaveCounts()
    {
        using (var context = new ApplicationContext())
        {
            BibliotheksCount = context.Bibliotheks.Count();
            ClinicsCount = context.Clinics.Count();
            DisParkCount = context.DisParks.Count();
            DoctorsCount = context.Doctors.Count();
            KindergardensCount = context.Kindergardens.Count();
            MuseumsCount = context.Museums.Count();
            MusikSchoolsCount = context.MusikSchools.Count();
            ParksCount = context.Parks.Count();
            PoliceCount = context.PoliceStations.Count();
            PoolCount = context.Pools.Count();
            StopsCount = context.PublicTransportStops.Count();
            SchoolsCount = context.Schools.Count();
            UnisCount = context.Universities.Count();
        }
        
    }
}