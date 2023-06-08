namespace Docseeker.API.Profiles.Domain.Models;

public class Patient
{
    public int Id { get; set; }
    
    public string Username { get; set; }
    
    public string Name { get; set; }
    
    public string Lastname { get; set; }
    
    public string Middlename { get; set; }
    
    public string Gender { get; set; }
    
    public DateTime Birthdate { get; set; }
    
    public string Email { get; set; }
    
    public string Phone { get; set; }
}