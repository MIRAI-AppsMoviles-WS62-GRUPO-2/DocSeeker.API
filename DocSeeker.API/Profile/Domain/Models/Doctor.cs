using DocSeeker.API.Prescriptions.Domain.Models;

namespace DocSeeker.API.Profile.Domain.Models;

public class Doctor
{
    public Doctor(List<Prescription> prescriptions)
    {
        Prescriptions = prescriptions;
    }

    public int Id { get; set; }
    public string Name { get; set; }
    public string Specialty { get; set; }
    public int Description { get; set; }
    public string Phone { get; set; }
    public string Email { get; set; }

    public List<Prescription> Prescriptions { get; set; }
}