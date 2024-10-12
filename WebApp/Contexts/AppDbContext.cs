using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using WebApp.Entities;

namespace WebApp.Contexts;

public partial class AppDbContext : DbContext
{
    public AppDbContext()
    {
    }

    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Education> Educations { get; set; }

    public virtual DbSet<Person> People { get; set; }

    public virtual DbSet<Phone> Phones { get; set; }

    public virtual DbSet<Profession> Professions { get; set; }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Education>(entity =>
        {
            entity.HasKey(e => new { e.IdProfession, e.IdPerson }).HasName("PK__Educatio__C1AB0B4C2CCB2045");

            entity.HasOne(d => d.IdPersonNavigation).WithMany(p => p.Educations)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("EducationPersonFk");

            entity.HasOne(d => d.IdProfessionNavigation).WithMany(p => p.Educations)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("EducationProfessionFk");
        });

        modelBuilder.Entity<Person>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Person__3214EC07ADA335D1");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.Gender).IsFixedLength();
        });

        modelBuilder.Entity<Phone>(entity =>
        {
            entity.HasKey(e => e.Number).HasName("PK__Phone__78A1A19CDE3D8658");

            entity.HasOne(d => d.OwnerNavigation).WithMany(p => p.Phones)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("PhonePersonFk");
        });

        modelBuilder.Entity<Profession>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Professi__3214EC07A970F3E6");

            entity.Property(e => e.Id).ValueGeneratedNever();
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
