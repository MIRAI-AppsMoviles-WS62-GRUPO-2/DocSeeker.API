using System.ComponentModel.DataAnnotations;

namespace DocSeeker.API.Prescriptions.Resources;

public class SaveMedicineResource
{
    [Required]
    [MaxLength(30)]
    public string Name { get; set; }
    
    [Required]
    [MaxLength(30)]
    public string Dose { get; set; }
    
    [Required]
    [MaxLength(30)]
    public string Period { get; set; }
    
    [Required]
    [MaxLength(30)]
    public string RouteOfAdministration { get; set; }
    
    [Required]
    [MaxLength(30)]
    public string Duration { get; set; }
    
    [MaxLength(300)]
    public string SpecialInstructions { get; set; }
    
    
    public int PrescriptionId { get; set; }
}