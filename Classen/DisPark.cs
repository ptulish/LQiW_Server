using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LQiW_Server.Classen;

public class DisPark
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }
    public double Latitude  { get; set; }
    public double Longitude  { get; set; }
    public string StreetName { get; set; }
    public int ParkCount { get; set; }
    public static int ParkCountInCity;
    public static double CalculateAverageRatingDisPark(List<(DisPark disPark, double distance)> disParks)
    {
        var ratings = disParks.Select(b => CalculateRating.CalculateRating30(b.distance)).ToList();
        return ratings.Average();
    }
}