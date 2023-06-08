using System.ComponentModel.DataAnnotations;

namespace DocSeeker.API.Profiles.Resources;

public class SaveDoctorResource
{
    [Required]
    [MaxLength(30)]
    public string Username { get; set; }
    
    [Required]
    [MaxLength(30)]
    public string Name { get; set; }
    
    [Required]
    [MaxLength(30)]
    public string Lastname { get; set; }
    
    [Required]
    [MaxLength(30)]
    public string Middlename { get; set; }
    
    [Required]
    public string Speciality { get; set; }
    
    [Required]
    public string Gender { get; set; }
    
    [Required]
    [MaxLength(50)]
    public string Email { get; set; }
    
    [Required]
    [MaxLength(9)]
    public string Phone { get; set; }
}