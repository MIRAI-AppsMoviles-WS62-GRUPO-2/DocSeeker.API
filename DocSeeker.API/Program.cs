using DocSeeker.API.MedicalAppointment.Domain.Repositories;
using DocSeeker.API.MedicalAppointment.Domain.Services;
using DocSeeker.API.MedicalAppointment.Persistence.Repositories;
using DocSeeker.API.MedicalAppointment.Services;
using DocSeeker.API.MedicalRecord.Domain.Repositories;
using DocSeeker.API.MedicalRecord.Domain.Services;
using DocSeeker.API.MedicalRecord.Persistence.Repositories;
using DocSeeker.API.MedicalRecord.Services;
using DocSeeker.API.News.Domain.Repositories;
using DocSeeker.API.News.Domain.Services;
using DocSeeker.API.News.Persistence.Repositories;
using DocSeeker.API.News.Services;
using DocSeeker.API.Profiles.Domain.Repositories;
using DocSeeker.API.Profiles.Domain.Services;
using DocSeeker.API.Profiles.Persistence.Repositories;
using DocSeeker.API.Profiles.Services;
using DocSeeker.API.Prescriptions.Domain.Repositories;
using DocSeeker.API.Prescriptions.Domain.Services;
using DocSeeker.API.Prescriptions.Persistence.Repositories;
using DocSeeker.API.Prescriptions.Services;
using DocSeeker.API.Shared.Domain.Repositories;
using DocSeeker.API.Shared.Persistence.Contexts;
using DocSeeker.API.Shared.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;


var builder = WebApplication.CreateBuilder(args); // Create a builder object 

// Add services to the container.


builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo()
    {
        Version = "v1",
        Title = "ACME DocSeeker API",
        Description = "ACME DocSeeker RESTful API",
        TermsOfService = new Uri("https://vuesharp-aplicaciones-web-sw52-grupo-2.github.io/Landing-Page-DocSeeker/#aboutUs"),// landing page
        Contact = new OpenApiContact
        {
            Name = "ACME.studio",
            Url = new Uri("https://vuesharp-aplicaciones-web-sw52-grupo-2.github.io/Landing-Page-DocSeeker/")
        },
        License = new OpenApiLicense
        {
            Name   = "ACME DocSeeker Resources License",
            Url = new Uri("https://vuesharp-aplicaciones-web-sw52-grupo-2.github.io/Landing-Page-DocSeeker/license")
        }
            
    });
    options.EnableAnnotations();
});

// Configuration CORS
builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(builder =>
    {
        builder.WithOrigins("http://localhost:5173")
            .AllowAnyHeader()
            .AllowAnyMethod();
    });
});


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
builder.Services.AddScoped<IRecordRepository, RecordRepository>();
builder.Services.AddScoped<IRecordService, RecordService>();
builder.Services.AddScoped<IPrescriptionRepository, PrescriptionRepository>();
builder.Services.AddScoped<IPrescriptionService, PrescriptionService>();
builder.Services.AddScoped<IMedicineRepository, MedicineRepository>();
builder.Services.AddScoped<IMedicineService, MedicineService>();
builder.Services.AddScoped<INewRepository, NewRepository>();
builder.Services.AddScoped<INewService, NewService>();

// Automapper Configuration

builder.Services.AddAutoMapper(
    typeof(DocSeeker.API.Profiles.Mapping.ModelToResourceProfile),
    typeof(DocSeeker.API.Profiles.Mapping.ResourceToModelProfile),
    typeof(DocSeeker.API.Prescriptions.Mapping.ModelToResourceProfile),
    typeof(DocSeeker.API.Prescriptions.Mapping.ResourceToModelProfile),
    typeof(DocSeeker.API.MedicalAppointment.Mapping.ModelToResourceProfile),
    typeof(DocSeeker.API.MedicalAppointment.Mapping.ResourceToModelProfile),
    typeof(DocSeeker.API.MedicalRecord.Mapping.ModelToResourceProfile),
    typeof(DocSeeker.API.MedicalRecord.Mapping.ResourceToModelProfile),
    typeof(DocSeeker.API.News.Mapping.ModelToResourceProfile),
    typeof(DocSeeker.API.News.Mapping.ResourceToModelProfile));
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
    app.UseSwaggerUI(options =>
    {
        options.SwaggerEndpoint("v1/swagger.json", "v1");
        options.RoutePrefix = "swagger";
    });
}
// Configuración de CORS
app.UseCors();

// Configuración de enrutamiento y otros middleware
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

//public partial class Program {}
