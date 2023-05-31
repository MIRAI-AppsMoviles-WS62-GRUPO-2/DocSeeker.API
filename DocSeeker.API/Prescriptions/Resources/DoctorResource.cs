namespace DocSeeker.API.Prescriptions.Resources;

// With this file we are using DTO(Data Transfer Object) pattern. This is a DTO.
public class DoctorResource
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Specialty { get; set; }
    public int Description { get; set; }
    public string Phone { get; set; }
    public string Email { get; set; }
}