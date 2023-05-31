namespace DocSeeker.API.Prescriptions.Resources;

// We don't put RelationShips because we can't expose entities to users
// that's why we use DoctorResource beside Doctor
public class PrescriptionResource
{
    public int Id { get; set; }
    public string State { get; set; }
    public string Recommendation { get; set; }
    public DoctorResource Doctor { get; set; }
    // We don't know if include the Medicine list or not. I don't think so.
}