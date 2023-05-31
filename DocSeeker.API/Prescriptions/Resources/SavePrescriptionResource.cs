using System.ComponentModel.DataAnnotations;

namespace DocSeeker.API.Prescriptions.Resources;

public class SavePrescriptionResource
{
    // State should be a new Entity because the input could be written incorrectly
    [Required]
    public string State { get; set; }
    
    [MaxLength(500)]
    public string Recommendation { get; set; }
    
    public int DoctorId { get; set; }
}