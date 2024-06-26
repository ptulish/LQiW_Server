﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LQiW_Server.Classen;

public class Doctor
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }
    public string Name { get; set; }
    public string Adresse { get; set; }
    public static int DoctorCount;
    public double Latitude  { get; set; }
    public double Longitude  { get; set; }
    public static double CalculateAverageRatingDoctor(List<(Doctor doctor, double distance)> doctors)
    {
        var ratings = doctors.Select(b => CalculateRating.CalculateRating100(b.distance)).ToList();
        return ratings.Average();
    }
}