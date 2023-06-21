using DocSeeker.API.Prescriptions.Domain.Models;
using DocSeeker.API.MedicalAppointment.Domain.Models;
using DocSeeker.API.MedicalRecord.Domain.Models;
using DocSeeker.API.News.Domain.Models;
using DocSeeker.API.Profiles.Domain.Models;
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

    public DbSet<Patient> Patients { get; set; }
    public DbSet<Doctor> Doctors { get; set; }
    public DbSet<Appointment> Appointments { get; set; }
    public DbSet<Prescription> Prescriptions { get; set; }
    public DbSet<Medicine> Medicines { get; set; }
    public DbSet<Record> Records { get; set; }
    
    public DbSet<New> News { get; set; }

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
        
        builder.Entity<Record>().ToTable("Records");
        builder.Entity<Record>().HasKey(r => r.Id);
        builder.Entity<Record>().Property(r => r.Id).IsRequired().ValueGeneratedOnAdd();
        builder.Entity<Record>().Property(r => r.Weight).IsRequired();
        builder.Entity<Record>().Property(r => r.Height).IsRequired();
        builder.Entity<Record>().Property(r => r.BodyMass).IsRequired();
        builder.Entity<Record>().Property(r => r.PatientId).IsRequired();
        
        // News Configuration
        
        builder.Entity<New>().ToTable("News");
        builder.Entity<New>().HasKey(n => n.Id);
        builder.Entity<New>().Property(n => n.Id).IsRequired().ValueGeneratedOnAdd();
        builder.Entity<New>().Property(n => n.Title).IsRequired().HasMaxLength(50);
        builder.Entity<New>().Property(n => n.ImageUrl).IsRequired().HasMaxLength(500);
        builder.Entity<New>().Property(n => n.Description).IsRequired();
        


        // Relationships

        builder.Entity<Prescription>()
            .HasMany(p => p.Medicines)
            .WithOne(m => m.Prescription)
            .HasForeignKey(m => m.PrescriptionId);


        // Apply Snake Case Naming Convention

        builder.UseSnakeCaseNamingConvention();
    }
}