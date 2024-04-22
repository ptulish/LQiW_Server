using System.Diagnostics.Contracts;
using Microsoft.AspNetCore.Components.Server.Circuits;
using Microsoft.EntityFrameworkCore;

namespace LQiW_Server.Classen;

public class ApplicationContext : DbContext
{
    public DbSet<Clinic> Clinics { get; set; }
    public DbSet<Doctor> Doctors { get; set; }
    public DbSet<DisPark> DisParks { get; set; }
    public DbSet<Bibliothek> Bibliotheks { get; set; }
    public DbSet<Kindergarden> Kindergardens { get; set; }
    public DbSet<Museum> Museums { get; set; }
    public DbSet<MusikSchool> MusikSchools { get; set; }
    public DbSet<Park> Parks { get; set; }
    public DbSet<PoliceStation> PoliceStations { get; set; }
    public DbSet<Pool> Pools { get; set; }
    public DbSet<PublicTransportStop> PublicTransportStops { get; set; }
    public DbSet<School> Schools { get; set; }
    public DbSet<University> Universities { get; set; }
    public DbSet<Feedback> Feedbacks { get; set; }
    
    
    public ApplicationContext()
    {
        Database.EnsureCreated();
    }
    public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
    {
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            var connectionString = "Host=localhost" +
                                   ";Port=5432;Username=postgres;Password=2218;Database=LQiW_DB;";
            optionsBuilder.UseNpgsql(connectionString);
        }
    }
}