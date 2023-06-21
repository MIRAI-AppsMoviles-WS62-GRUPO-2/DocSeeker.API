

using DocSeeker.API.News.Domain.Models;

namespace DocSeeker.API.News.Domain.Repositories;

public interface INewRepository
{
    Task<IEnumerable<New>> ListAsync(); 
   
    Task AddAsync(New news); 
    
    Task<New> FindByIdAsync(int id); 
    
    void Update(New news); 
        
    void Remove(New news);
}