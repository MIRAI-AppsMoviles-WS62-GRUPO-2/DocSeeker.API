namespace Docseeker.API.MedicalRecord.Resources;

public class RecordResource
{
    public int Id { get; set; }
    
    public float Height { get; set; }
    
    public float Weight { get; set; }
    
    public float BodyMass { get; set; }
    
    public int PatientId { get; set; }
}