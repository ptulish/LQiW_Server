using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LQiW_Server.Classen;

public class Bibliothek
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }
    public string Name { get; set; }
    public string Adresse { get; set; }
    public double Latitude  { get; set; }
    public double Longitude  { get; set; }
    public static int BibliothekCount;
    
    public static double CalculateAverageRatingBibliothek(List<(Bibliothek bibliothek, double distance)> bibliotheks)
    {
        var ratings = bibliotheks.Select(b => CalculateRating.CalculateRating500(b.distance)).ToList();
        return ratings.Average();
    }
}