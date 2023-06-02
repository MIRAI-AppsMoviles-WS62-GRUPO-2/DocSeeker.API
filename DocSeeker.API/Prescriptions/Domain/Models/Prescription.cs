namespace DocSeeker.API.Prescriptions.Domain.Models;

public class Prescription
{
    public Prescription(List<Medicine> medicines)
    {
        Medicines = medicines;
    }

    public int Id { get; set; }
    public string State { get; set; }
    public string Recommendation { get; set; }

    // Relationships
    public int DoctorId { get; set; }
    public Doctor Doctor { get; set;} 

    
    public List<Medicine> Medicines { get; set; }
}