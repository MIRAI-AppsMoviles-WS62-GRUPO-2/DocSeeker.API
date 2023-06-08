namespace DocSeeker.API.MedicalRecord.Domain.Models;

public class Record
{
    public int Id { get; set; }
    
    public float Height { get; set; }
    
    public float Weight { get; set; }
    
    public float BodyMass { get; set; }
    
    public int PatientId { get; set; }
}