namespace DocSeeker.API.Appointment.Domain.Models;

public class Appointment
{
    public int Id { get; set; }
    
    public DateTime DateTime { get; set; }
    
    // Relationships
    
    public int DoctorId { get; set; }
    
    public Doctor Doctor { get; set; }
    
    public int PatientId { get; set; }
    
    public Patient Patient { get; set; }
}