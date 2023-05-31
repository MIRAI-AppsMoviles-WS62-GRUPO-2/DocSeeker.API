namespace DocSeeker.API.Appointments.Domain.Models;

public class Patient
{
    public Patient()
    {
        Appointments = new List<Appointment>();
    }

    public int Id { get; set; }
    
    public string Name { get; set; }
    
    public string Address { get; set; }
    
    public string PhoneNumber { get; set; }
    
    public string Email { get; set; }
    
    //Relationships
    
    public List<Appointment> Appointments { get; set; }
}