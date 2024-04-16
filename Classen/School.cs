using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LQiW_Server.Classen;

public class School
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }
    public string Name { get; set; }
    public string Adresse { get; set; }
    public double Latitude  { get; set; }
    public double Longitude  { get; set; }

    public static int SchoolsCount;
    
    public static double CalculateAverageRatingSchool(List<(School school, double distance)> schools)
    {
        var ratings = schools.Select(b => CalculateRating.CalculateRating100(b.distance)).ToList();
        return ratings.Average();
    }
}