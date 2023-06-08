using Docseeker.API.MedicalAppointment.Domain.Repositories;
using Docseeker.API.MedicalAppointment.Domain.Services;
using Docseeker.API.MedicalAppointment.Persistence.Repositories;
using Docseeker.API.MedicalAppointment.Services;

using Docseeker.API.Profiles.Domain.Repositories;
using Docseeker.API.Profiles.Domain.Services;
using Docseeker.API.Profiles.Persistence.Repositories;
using Docseeker.API.Profiles.Services;
using DocSeeker.API.Shared.Domain.Repositories;
using DocSeeker.API.Shared.Persistence.Contexts;
using DocSeeker.API.Shared.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args); // Create a builder object 

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Add Database Connection
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

builder.Services.AddDbContext<AppDbContext>(
    options => options.UseMySQL(connectionString)
        .LogTo(Console.WriteLine, LogLevel.Information)
        .EnableSensitiveDataLogging()
        .EnableDetailedErrors());

// Lowercase URLs configuration
builder.Services.AddRouting(options => options.LowercaseUrls = true);

// Dependency Injection Configuration

builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

// Shared Bounded Contexts Injection Configuration

// Bounded Context Injection Configuration

builder.Services.AddScoped<IDoctorRepository, DoctorRepository>();
builder.Services.AddScoped<IDoctorService, DoctorService>();
builder.Services.AddScoped<IPatientRepository, PatientRepository>();
builder.Services.AddScoped<IPatientService, PatientService>();
builder.Services.AddScoped<IAppointmentRepository, AppointmentRepository>();
builder.Services.AddScoped<IAppointmentService, AppointmentService>();


// Automapper Configuration

builder.Services.AddAutoMapper(
    typeof(Docseeker.API.Profiles.Mapping.ModelToResourceProfile),
    typeof(Docseeker.API.Profiles.Mapping.ResourceToModelProfile),
    typeof(Docseeker.API.MedicalAppointment.Mapping.ModelToResourceProfile),
    typeof(Docseeker.API.MedicalAppointment.Mapping.ResourceToModelProfile));
// Application Build

var app = builder.Build();

// Validation for ensuring Databe Objects are created

using (var scope = app.Services.CreateScope())
using (var context = scope.ServiceProvider.GetService<AppDbContext>())
{
    context.Database.EnsureCreated();
}

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();