﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LQiW_Server.Classen;

public class Kindergarden
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }
    public string Owner { get; set; }
    public string Adresse { get; set; }
    public static int KinderGardenCount;
    public double Latitude  { get; set; }
    public double Longitude  { get; set; }
    public static double CalculateAverageRatingKindergarden(List<(Kindergarden kindergarden, double distance)> kindergardens)
    {
        var ratings = kindergardens.Select(b => CalculateRating.CalculateRating200(b.distance)).ToList();
        return ratings.Average();
    }
}