using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LQiW_Server.Classen;

public class University
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }
    public string Name { get; set; }
    public string Adresse { get; set; }
    public string Part { get; set; }
    public double Latitude  { get; set; }
    public double Longitude  { get; set; }
    public static int UniversityCount { get; set; }
    public static double CalculateAverageRatingUniversity(List<(University university, double distance)> universities)
    {
        var ratings = universities.Select(b => CalculateRating.CalculateRating200(b.distance)).ToList();
        return ratings.Average();
    }

}