using DocSeeker.API.Profiles.Domain.Models;
using DocSeeker.API.Prescriptions.Domain.Models;
using DocSeeker.API.Shared.Extensions;
using Microsoft.EntityFrameworkCore;

namespace DocSeeker.API.Shared.Persistence.Contexts;

// We are going to work with the persistence of the core entity framework.
// This file is the middleman with the entire persistence framework.
public class AppDbContext: DbContext
{
    public AppDbContext(DbContextOptions options) : base(options)
    {
    }
    
    // We don't use this properties in this file but this properties save all
    // configuration that we are setting. Later, in another file we call this properties
    public DbSet<Prescription> Prescriptions { get; set; }
    public DbSet<Medicine> Medicines { get; set; }
    //public DbSet<Doctor> Doctors { get; set; }
    
    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        
        // Since in the entity models we don't use the Data Annotation Attributes
        // (Required, etc), then we use the following functions that fulfill the
        // function of those DAAs and that's called Fluent API.
        
        // Prescriptions Configuration
        
        builder.Entity<Prescription>().ToTable("Prescriptions");
        builder.Entity<Prescription>().HasKey(p => p.Id);
        builder.Entity<Prescription>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
        builder.Entity<Prescription>().Property(p => p.State).IsRequired();
        builder.Entity<Prescription>().Property(p => p.Recommendation).HasMaxLength(500);
        
        // Medicines Configuration

        builder.Entity<Medicine>().ToTable("Medicines");
        builder.Entity<Medicine>().HasKey(m=>m.Id);
        builder.Entity<Medicine>().Property(m=>m.Id).IsRequired().ValueGeneratedOnAdd();
        builder.Entity<Medicine>().Property(m => m.Name).IsRequired().HasMaxLength(30);
        builder.Entity<Medicine>().Property(m=>m.Dose).IsRequired().HasMaxLength(30);
        builder.Entity<Medicine>().Property(m=>m.Period).IsRequired().HasMaxLength(30);
        builder.Entity<Medicine>().Property(m=>m.RouteOfAdministration).IsRequired().HasMaxLength(30);
        builder.Entity<Medicine>().Property(m=>m.Duration).IsRequired().HasMaxLength(30);
        builder.Entity<Medicine>().Property(m=>m.SpecialInstructions).HasMaxLength(300);
        
        // Doctors Configuration

        builder.Entity<Doctor>().ToTable("Doctors");
        builder.Entity<Doctor>().HasKey(d => d.Id);
        builder.Entity<Doctor>().Property(d => d.Id).IsRequired();
        builder.Entity<Doctor>().Property(d => d.Name).IsRequired();
        builder.Entity<Doctor>().Property(d => d.Specialty).IsRequired();
        builder.Entity<Doctor>().Property(d => d.Description).HasMaxLength(300);
        builder.Entity<Doctor>().Property(d => d.Phone).IsRequired().HasMaxLength(9);
        builder.Entity<Doctor>().Property(d => d.Email).IsRequired().HasMaxLength(40);

        // Relationships

        // I don't know how configure one-to-many relationship with different bounded context
        
        /*builder.Entity<Doctor>()
            .HasMany(d => d.Prescriptions)
            .WithOne(p => p.Doctor)
            .HasForeignKey(p => p.DoctorId);*/

        builder.Entity<Prescription>()
            .HasMany(p => p.Medicines)
            .WithOne(m => m.Prescription)
            .HasForeignKey(m => m.PrescriptionId);
        
        // Apply Snake Case Naming Convention

        builder.UseSnakeCaseNamingConvention();
    }
}