using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LQiW_Server.Classen;

public class Clinic
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }
    public string Name { get; set; }
    public string Adresse { get; set; }
    public double Latitude  { get; set; }
    public double Longitude  { get; set; }
    public static int ClinicCount;
    public static double CalculateAverageRatingClinic(List<(Clinic clinic, double distance)> clinics)
    {
        var ratings = clinics.Select(b => CalculateRating.CalculateRating500(b.distance)).ToList();
        return ratings.Average();
    }
}