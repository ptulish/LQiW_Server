using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

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
}