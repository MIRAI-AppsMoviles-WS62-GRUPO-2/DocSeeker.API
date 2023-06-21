using System.ComponentModel.DataAnnotations;

namespace DocSeeker.API.Profiles.Resources;

public class SavePatientResource
{
    [Required]
    [MaxLength(20)]
    public string Username { get; set; }
    
    [Required]
    [MaxLength(20)]
    public string Name { get; set; }
    
    [Required]
    [MaxLength(25)]
    public string Lastname { get; set; }
    
    [Required]
    [MaxLength(25)]
    public string Middlename { get; set; }
    
    [Required]
    public string Gender { get; set; }
    
    [Required]
    public DateTime Birthdate { get; set; }
    
    [Required]
    [MaxLength(50)]
    public string Email { get; set; }
    
    [Required]
    [MaxLength(9)]
    public string Phone { get; set; }
    
    [Required]
    public string Password { get; set; }
}