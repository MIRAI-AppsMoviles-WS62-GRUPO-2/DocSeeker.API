using DocSeeker.API.Prescriptions.Domain.Repositories;
using DocSeeker.API.Prescriptions.Domain.Services;
using DocSeeker.API.Prescriptions.Persistence.Repositories;
using DocSeeker.API.Prescriptions.Services;
using DocSeeker.API.Shared.Domain.Repositories;
using DocSeeker.API.Shared.Persistence.Contexts;
using DocSeeker.API.Shared.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

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
// Shared Bounded Contexts Injection Configuration
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();


// Learning Bounded Context Injection Configuration
builder.Services.AddScoped<IPrescriptionRepository, PrescriptionRepository>();
builder.Services.AddScoped<IPrescriptionService, PrescriptionService>();
builder.Services.AddScoped<IMedicineRepository, MedicineRepository>();
builder.Services.AddScoped<IMedicineService, MedicineService>();


// AutoMapper Configuration
builder.Services.AddAutoMapper(
    typeof(DocSeeker.API.Prescriptions.Mapping.ModelToResourceProfile),
    typeof(DocSeeker.API.Prescriptions.Mapping.ResourceToModelProfile));


// Application build
var app = builder.Build();


// Validation for ensuring Database Objects are created
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