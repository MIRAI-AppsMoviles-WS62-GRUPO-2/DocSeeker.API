using System.ComponentModel.DataAnnotations;

namespace DocSeeker.API.Appointments.Resources;

public class SaveDoctorResource
{
    [Required]
    public string Name { get; set; }
    
    [Required]
    public string Specialization { get; set; }
    
    [Required]
    public string PhoneNumber { get; set; }
    
    [Required]
    public string Email { get; set; }
}