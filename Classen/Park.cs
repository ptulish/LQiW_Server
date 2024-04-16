using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LQiW_Server.Classen;

public class Park
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }
    public string Name { get; set; }
    public double Longitude { get; set; }
    public double Latitude { get; set; }
    public double Square { get; set; }
    public bool ForChildren { get; set; }
    public bool Drink { get; set; }
    public bool Dogs { get; set; }
    
    public static int ParkCount;
    
    public static double CalculateAverageRatingPark(string group, List<(Park park, double distance)> parks)
    {
        var ratings = parks.Select(b =>
        {
            Console.WriteLine($"{b.park.Name}    {b.park.Square}");
            var rating = (double)CalculateRating.CalculateRating100(b.distance);

            if (b.park.Square < 150)
            {
            }
            else if(b.park.Square < 1000)
                rating += 0.1;
            else if (b.park.Square < 3000)
                rating += 0.3;
            else if (b.park.Square < 6000)
                rating += 0.6;
            else if (b.park.Square < 12000)
                rating += 0.9;
            else if (b.park.Square < 20000)
                rating += 1.4;
            else if (b.park.Square < 40000)
                rating += 2;
            
            if (b.park.Drink)
                rating += 0.5;
            if (b.park.Dogs)
                rating += 0.2;
            if (group == "family")
            {
                if (b.park.ForChildren)
                    rating += 0.7;
            }

            if (group == "couple")
            {
                if (b.park.Dogs)
                    rating += 0.5;
            }

            if (group == "alone")
            {
                if (b.park.Dogs)
                    rating += 0.5;
            }

            if (group == "rente")
            {
                if (b.park.Dogs)
                    rating += 0.4; 
            }
            return rating >= 5 ? 5 : rating;
        }).ToList();
        return ratings.Average();
    }
}