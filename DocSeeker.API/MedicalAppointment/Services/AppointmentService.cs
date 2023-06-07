using Docseeker.API.MedicalAppointment.Domain.Models;
using Docseeker.API.MedicalAppointment.Domain.Repositories;
using Docseeker.API.MedicalAppointment.Domain.Services;
using DocSeeker.API.Shared.Domain.Repositories;

namespace Docseeker.API.MedicalAppointment.Services;

public class AppointmentService : IAppointmentService
{
    private readonly IAppointmentRepository _appointmentRepository;
    private readonly IUnitOfWork _unitOfWork;

    public AppointmentService(IAppointmentRepository appointmentRepository, IUnitOfWork unitOfWork)
    {
        _appointmentRepository = appointmentRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<IEnumerable<Appointment>> ListAsync()
    {
        return await _appointmentRepository.ListAsync();
    }

    public async Task<AppointmentResponse> SaveAsync(Appointment appointment)
    {
        try
        {
            await _appointmentRepository.AddAsync(appointment);
            await _unitOfWork.CompleteAsync();

            return new AppointmentResponse(appointment);
        }
        catch (Exception e)
        {
            return new AppointmentResponse($"An Error occurred when saving the appointment: {e.Message}");
        }
    }

    public async Task<AppointmentResponse> UpdateAsync(int id, Appointment appointment)
    {
        var existingAppointment = await _appointmentRepository.FindByIdAsync(id);

        if (existingAppointment == null)
            return new AppointmentResponse("Appointment not found");

        existingAppointment.Date = appointment.Date;

        try
        {
            _appointmentRepository.Update(existingAppointment);
            await _unitOfWork.CompleteAsync();

            return new AppointmentResponse(existingAppointment);
        }
        catch (Exception e)
        {
            return new AppointmentResponse($"An Error occurred when updating the appointment: {e.Message}");
        }
    }

    public async Task<AppointmentResponse> DeleteAsync(int id)
    {
        var existingAppointment = await _appointmentRepository.FindByIdAsync(id);

        if (existingAppointment == null)
            return new AppointmentResponse("Appointment not found");

        try
        {
            _appointmentRepository.Remove(existingAppointment);
            await _unitOfWork.CompleteAsync();

            return new AppointmentResponse(existingAppointment);
        }
        catch (Exception e)
        {
            return new AppointmentResponse($"An Error occurred when deleting the appointment: {e.Message}");
        }
    }
}