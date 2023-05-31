namespace DocSeeker.API.Appointments.Resources;

public class AppointmentResource
{
    public int Id { get; set; }
    
    public DateTime Date { get; set; }
    
    public DoctorResource Doctor { get; set; }
    
    public PatientResource Patient { get; set; }
}