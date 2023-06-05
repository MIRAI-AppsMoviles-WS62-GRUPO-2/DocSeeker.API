using System.ComponentModel.DataAnnotations;

namespace DocSeeker.API.Profiles.Resources;

// With this file we are using DTO(Data Transfer Object) pattern. This is a DTO.
public class SaveDoctorResource
{
    [Required]
    public string Name { get; set; }
    
    // Specialty should be a new Entity because the input could be written incorrectly
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