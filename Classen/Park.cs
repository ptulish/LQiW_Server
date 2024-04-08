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
}