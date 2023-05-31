using System.ComponentModel.DataAnnotations;

namespace DocSeeker.API.Appointments.Resources;

public class SavePatientResource
{
    [Required]
    public string Name { get; set; }
    
    [Required]
    public string Address { get; set; }
    
    [Required]
    public string PhoneNumber { get; set; }
    
    [Required]
    public string Email { get; set; }
    
}