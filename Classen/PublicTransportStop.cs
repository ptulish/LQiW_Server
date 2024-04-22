using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using LQiW_Server.Controllers;

namespace LQiW_Server.Classen;

public class PublicTransportStop
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }
    public string Name { get; set; }
    public double Longitude { get; set; }
    public double Latitude { get; set; }
    public string Lines { get; set; }

    public static int PublicTransportStopsCount;
    
    public static double CalculateAverageRatingPublicTransportStop(
        List<(PublicTransportStop publicTransportStop, double distance)> publicTransportStops, List<string> list,
        List<string> linesKm)
    {
        List<string> lines1 = new List<string>();
        var ratings = publicTransportStops.Select(b =>
        {
            var rating = (double)CalculateRating.CalculateRating30(b.distance);
            var lines = b.publicTransportStop.Lines.Split(", ");

            foreach (var line in lines)
            {
                if (list.Contains(line))
                {
                    continue;
                }
                list.Add(line);
                linesKm.Add(b.distance.ToString());

                if (line[0] == 'U')
                {
                    rating += 2;
                }
                else if (line.StartsWith("S") || line.StartsWith("REX") || 
                         line.StartsWith("SV") || line.StartsWith("R") || 
                         line.StartsWith("CJX") || line.StartsWith("WLB") ||
                         line.StartsWith("B"))
                {
                    rating += 1;
                }
                else if (line.StartsWith("N")) // Проверка на начало строки с 'N'
                {
                    rating += 0.8;
                }
                else if (char.IsDigit(line[0])) // Проверка, является ли первый символ цифрой
                {
                    rating += 0.2;
                }
            }

            return rating > 5 ? 5 : rating;

        }).ToList();
        return ratings.Average();
    }
}