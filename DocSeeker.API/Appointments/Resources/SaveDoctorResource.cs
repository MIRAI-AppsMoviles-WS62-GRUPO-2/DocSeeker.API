using System.ComponentModel.DataAnnotations;

namespace DocSeeker.API.Appointments.Resources;

public class SaveDoctorResource
{
    [Required]
    public string Name { get; set; }
    
    [Required]
    public string Specialty { get; set; }
    
    [MaxLength(300)]
    public int Description { get; set; }
    
    [Required]
    [MaxLength(9)]
    public string Phone { get; set; }
    
    [Required]
    [MaxLength(40)]
    public string Email { get; set; }
}