namespace DocSeeker.API.Prescriptions.Resources;

// We don't put RelationShips because we can't expose entities to users
// that's why we use PrescriptionResource beside Prescription
// With this file we are using DTO(Data Transfer Object) pattern. This is a DTO.
public class MedicineResource
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Dose { get; set; }
    public string Period { get; set; }
    public string RouteOfAdministration { get; set; }
    public string Duration { get; set; }
    public string SpecialInstructions { get; set; }
    public PrescriptionResource Prescription { get; set; }
}