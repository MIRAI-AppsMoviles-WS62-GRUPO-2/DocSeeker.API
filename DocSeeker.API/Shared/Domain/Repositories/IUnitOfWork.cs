namespace DocSeeker.API.Shared.Domain.Repositories;

// This is a design pattern (Unit of Work). That means this is a
// class that encapsulates transaction confirmation logic.
public interface IUnitOfWork
{
    // Its life purpose is transaction confirmations,
    // that's why we only have one function
    Task CompleteAsync();
}