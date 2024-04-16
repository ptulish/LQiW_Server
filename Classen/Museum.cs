using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LQiW_Server.Classen;

public class Museum
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }
    public string Name { get; set; }
    public string Adresse { get; set; }
    public static int MuseumsCount;
    public double Latitude  { get; set; }
    public double Longitude  { get; set; }
    public static double CalculateAverageRatingMuseum(List<(Museum museum, double distance)> museums)
    {
        var ratings = museums.Select(b => CalculateRating.CalculateRating500(b.distance)).ToList();
        return ratings.Average();
    }
}