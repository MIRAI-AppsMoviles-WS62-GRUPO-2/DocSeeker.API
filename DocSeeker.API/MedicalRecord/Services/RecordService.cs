using DocSeeker.API.MedicalRecord.Domain.Models;
using DocSeeker.API.MedicalRecord.Domain.Repositories;
using DocSeeker.API.MedicalRecord.Domain.Services;
using DocSeeker.API.MedicalRecord.Domain.Services.Communication;
using DocSeeker.API.Shared.Domain.Repositories;

namespace DocSeeker.API.MedicalRecord.Services;

public class RecordService : IRecordService
{
    private readonly IRecordRepository _recordRepository;
    private readonly IUnitOfWork _unitOfWork;

    public RecordService(IRecordRepository recordRepository, IUnitOfWork unitOfWork)
    {
        _recordRepository = recordRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<IEnumerable<Record>> ListAsync()
    {
        return await _recordRepository.ListAsync();
    }

    public async Task<RecordResponse> SaveAsync(Record record)
    {
        try
        {
            await _recordRepository.AddAsync(record);
            await _unitOfWork.CompleteAsync();

            return new RecordResponse(record);
        }
        catch (Exception e)
        {
            return new RecordResponse($"An Error occurred when saving the record: {e.Message}");
        }
    }

    public async Task<RecordResponse> UpdateAsync(int id, Record record)
    {
        var existingRecord = await _recordRepository.FindByIdAsync(id);

        if (existingRecord == null)
            return new RecordResponse("Record not found");

        existingRecord.BodyMass = record.BodyMass;
        existingRecord.Height = record.Height;
        existingRecord.Weight = record.Weight;

        try
        {
            _recordRepository.Update(existingRecord);
            await _unitOfWork.CompleteAsync();

            return new RecordResponse(existingRecord);
        }
        catch (Exception e)
        {
            return new RecordResponse($"An Error occurred when updating the record: {e.Message}");
        }
    }

    public async Task<RecordResponse> DeleteAsync(int id)
    {
        var existingRecord = await _recordRepository.FindByIdAsync(id);

        if (existingRecord == null)
            return new RecordResponse("Record not found");

        try
        {
            _recordRepository.Remove(existingRecord);
            await _unitOfWork.CompleteAsync();

            return new RecordResponse(existingRecord);
        }
        catch (Exception e)
        {
            return new RecordResponse($"An Error occurred when deleting the record: {e.Message}");
        }
    }
}