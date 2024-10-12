
using Microsoft.EntityFrameworkCore;

namespace WebApp.Models.Entities;

public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
{
    public DbSet<Person> Persons { get; set; }
    public DbSet<Profession> Professions { get; set; }
    public DbSet<Education> Educations { get; set; }
    public DbSet<Phone> Phones { get; set; }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // Define the composite key for the Education entity
        modelBuilder.Entity<Education>()
            .HasKey(e => new { e.IdProfession, e.IdPerson });

        // Map the Person entity to the Profession table
        modelBuilder.Entity<Person>()
            .ToTable("Person");
        
        // Map the Profession entity to the Profession table
        modelBuilder.Entity<Profession>()
            .ToTable("Profession");
        
        // Map the Education entity to the Education table
        modelBuilder.Entity<Education>()
            .ToTable("Education");
        
        // Map the Phone entity to the Phone table
        modelBuilder.Entity<Phone>()
            .ToTable("Phone");

    }
    
}