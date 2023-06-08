using Docseeker.API.MedicalAppointment.Domain.Models;

using Docseeker.API.Profiles.Domain.Models;
using DocSeeker.API.Shared.Extensions;
using Microsoft.EntityFrameworkCore;

namespace DocSeeker.API.Shared.Persistence.Contexts;

// We are going to work with the persistence of the core entity framework.
// This file is the middleman with the entire persistence framework.
public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions options) : base(options)
    {
    }

    // We don't use this properties in this file but this properties save all
    // configuration that we are setting. Later, in another file we call this properties


    public DbSet<Patient> Patients { get; set; }
    public DbSet<Doctor> Doctors { get; set; }
    public DbSet<Appointment> Appointments { get; set; }
    
   


    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        // Since in the entity models we don't use the Data Annotation Attributes
        // (Required, etc), then we use the following functions that fulfill the
        // function of those DAAs and that's called Fluent API.

        // Prescriptions Configuration


        // Doctors Configuration
        
        builder.Entity<Doctor>().ToTable("Doctors");
        builder.Entity<Doctor>().HasKey(d => d.Id);
        builder.Entity<Doctor>().Property(d => d.Id).IsRequired().ValueGeneratedOnAdd();
        builder.Entity<Doctor>().Property(d => d.Username).IsRequired().HasMaxLength(30);
        builder.Entity<Doctor>().Property(d => d.Name).IsRequired().HasMaxLength(30);
        builder.Entity<Doctor>().Property(d => d.Lastname).IsRequired().HasMaxLength(30);
        builder.Entity<Doctor>().Property(d => d.Middlename).IsRequired().HasMaxLength(30);
        builder.Entity<Doctor>().Property(d => d.Speciality).IsRequired();
        builder.Entity<Doctor>().Property(d=> d.Gender).IsRequired();
        builder.Entity<Doctor>().Property(d => d.Email).IsRequired().HasMaxLength(50);
        builder.Entity<Doctor>().Property(d => d.Phone).IsRequired().HasMaxLength(9);

        // Patients Configuration
        
        builder.Entity<Patient>().ToTable("Patients");
        builder.Entity<Patient>().HasKey(p => p.Id);
        builder.Entity<Patient>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
        builder.Entity<Patient>().Property(p => p.Username).IsRequired().HasMaxLength(30);
        builder.Entity<Patient>().Property(p => p.Name).IsRequired().HasMaxLength(30);
        builder.Entity<Patient>().Property(p => p.Lastname).IsRequired().HasMaxLength(30);
        builder.Entity<Patient>().Property(p => p.Middlename).IsRequired().HasMaxLength(30);
        builder.Entity<Patient>().Property(p => p.Gender).IsRequired();
        builder.Entity<Patient>().Property(p => p.Birthdate).IsRequired();
        builder.Entity<Patient>().Property(p => p.Email).IsRequired().HasMaxLength(50);
        builder.Entity<Patient>().Property(p => p.Phone).IsRequired().HasMaxLength(9);


        // Appointments Configuration

        builder.Entity<Appointment>().ToTable("Appointments");
        builder.Entity<Appointment>().HasKey(a => a.Id);
        builder.Entity<Appointment>().Property(a => a.Id).IsRequired().ValueGeneratedOnAdd();
        builder.Entity<Appointment>().Property(a => a.Date).IsRequired();
        builder.Entity<Appointment>().Property(a => a.DoctorId).IsRequired();
        builder.Entity<Appointment>().Property(a => a.PatientId).IsRequired();
        
        // Records Configuration
        
        

        // Relationships


        // Apply Snake Case Naming Convention

        builder.UseSnakeCaseNamingConvention();
    }
}