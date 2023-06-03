using System.ComponentModel.DataAnnotations;

namespace DocSeeker.API.Prescriptions.Resources;

// With this file we are using DTO(Data Transfer Object) pattern. This is a DTO.
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
    
    [Required]
    public int PrescriptionId { get; set; }
}