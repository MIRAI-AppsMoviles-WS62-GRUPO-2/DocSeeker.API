namespace Docseeker.API.MedicalAppointment.Domain.Models;

public class Appointment
{
    public int Id { get; set; }

    public DateTime Date { get; set; }

    public int DoctorId { get; set; }

    public int PatientId { get; set; }
}