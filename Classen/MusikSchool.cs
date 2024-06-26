﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LQiW_Server.Classen;

public class MusikSchool
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }
    public string Name { get; set; }
    public string Adresse { get; set; }
    public static int MusikSchoolsCount { get; set; }
    public double Latitude  { get; set; }
    public double Longitude  { get; set; }
    public static double CalculateAverageRatingMusikSchool(List<(MusikSchool musikSchool, double distance)> musikSchools)
    {
        var ratings = musikSchools.Select(b => CalculateRating.CalculateRating200(b.distance)).ToList();
        return ratings.Average();
    }
}