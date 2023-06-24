using DocSeeker.API.News.Domain.Models;
using DocSeeker.API.News.Domain.Repositories;
using DocSeeker.API.News.Domain.Services;
using DocSeeker.API.News.Domain.Services.Communication;
using DocSeeker.API.Shared.Domain.Repositories;

namespace DocSeeker.API.News.Services;

public class NewService : INewService
{
    private readonly INewRepository _newRepository;
    private readonly IUnitOfWork _unitOfWork;

    public NewService(INewRepository newRepository, IUnitOfWork unitOfWork)
    {
        _newRepository = newRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<IEnumerable<New>> ListAsync()
    {
        return await _newRepository.ListAsync();
    }

    public async Task<NewResponse> SaveAsync(New news)
    {
        try
        {
            await _newRepository.AddAsync(news);
            await _unitOfWork.CompleteAsync();
            
            return new NewResponse(news);
        }
        catch (Exception e)
        {
            return new NewResponse($"An error occurred when saving the new: {e.Message}");
        }
    }

    public async Task<NewResponse> UpdateAsync(int id, New news)
    {
        var existingNew = await _newRepository.FindByIdAsync(id);
        
        if (existingNew == null)
            return new NewResponse("New not found.");
        
        existingNew.Title = news.Title;
        existingNew.Description = news.Description;
        existingNew.ImageUrl = news.ImageUrl;
        
        try
        {
            _newRepository.Update(existingNew);
            await _unitOfWork.CompleteAsync();
            
            return new NewResponse(existingNew); 
        }
        catch (Exception e)
        {
            return new NewResponse($"An error occurred when updating the new: {e.Message}");  
        }
    }

    public async Task<NewResponse> DeleteAsync(int id)
    {
        var existingNew = await _newRepository.FindByIdAsync(id);

        if (existingNew == null)
            return new NewResponse("New not found.");

        try
        {
            _newRepository.Remove(existingNew);
            await _unitOfWork.CompleteAsync();

            return new NewResponse(existingNew);
        }
        catch (Exception e)
        {
            return new NewResponse($"An error occurred when deleting the new: {e.Message}");
        }
    }
}