using System.ComponentModel.DataAnnotations;

namespace Docseeker.API.MedicalRecord.Resources;

public class SaveRecordResource
{
    [Required]
    public float Height { get; set; }
    
    [Required]
    public float Weight { get; set; }
    
    [Required]
    public float BodyMass { get; set; }
    
    [Required]
    public int PatientId { get; set; }
}