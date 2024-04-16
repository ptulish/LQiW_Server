using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LQiW_Server.Classen;

public class PoliceStation
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }
    public string Name { get; set; }
    public string Adresse { get; set; }
    public double Latitude  { get; set; }
    public double Longitude  { get; set; }
    public static int PolicestationCount;
    public static double CalculateAverageRatingPoliceStation(List<(PoliceStation policeStation, double distance)> policeStations)
    {
        var ratings = policeStations.Select(b => CalculateRating.CalculateRating200(b.distance)).ToList();
        return ratings.Average();
    }
}