namespace Docseeker.API.MedicalAppointment.Resources;

public class AppointmentResource
{
    public int Id { get; set; }

    public DateTime Date { get; set; }

    public int DoctorId { get; set; }

    public int PatientId { get; set; }
}