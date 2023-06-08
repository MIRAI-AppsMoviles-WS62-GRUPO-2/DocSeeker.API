namespace DocSeeker.API.Prescriptions.Resources;

// We don't put RelationShips because we can't expose entities to users
// that's why we use DoctorResource beside Doctor.
// With this file we are using DTO(Data Transfer Object) pattern. This is a DTO.
public class PrescriptionResource
{
    public int Id { get; set; }
    public string State { get; set; }
    public string Recommendation { get; set; }
    // We don't know if include the Medicine list or not. I don't think so.
}