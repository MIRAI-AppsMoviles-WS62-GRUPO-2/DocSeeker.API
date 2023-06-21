using DocSeeker.API.News.Domain.Models;
using DocSeeker.API.News.Domain.Services.Communication;

namespace DocSeeker.API.News.Domain.Services;

public interface INewService
{
    Task<IEnumerable<New>> ListAsync(); 
    Task<NewResponse> SaveAsync(New news); 
    Task<NewResponse> UpdateAsync(int id, New news); 
    Task<NewResponse> DeleteAsync(int id); 
}