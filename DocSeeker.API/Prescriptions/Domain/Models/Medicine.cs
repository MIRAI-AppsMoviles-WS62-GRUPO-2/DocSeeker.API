namespace DocSeeker.API.Prescriptions.Domain.Models;

public class Medicine
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Dose { get; set; }
    public string Period { get; set; }
    public string RouteOfAdministration { get; set; }
    public string Duration { get; set; }
    public string SpecialInstructions { get; set; }

    // RelationShips
    public int PrescriptionId { get; set; }
    public Prescription Prescription { get; set; }
}