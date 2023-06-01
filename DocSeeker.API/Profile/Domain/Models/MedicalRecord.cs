namespace DocSeeker.API.Profile.Domain.Models;

public class MedicalRecord
{
    public MedicalRecord(List<Allergie> allergies)
    {
        Allergies = allergies;
    }
    
    public MedicalRecord(List<Pathological> pathologicals)
    {
        Pathologicals = pathologicals;
    }
    
    public int Id { get; set; }
    public List<Allergie> Allergies { get; set; }
    public List<Pathological> Pathologicals { get; set; }
}