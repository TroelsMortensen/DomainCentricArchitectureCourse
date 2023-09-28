namespace DCAExamples.Core.Domain.Common.Repositories;

public interface IUnitOfWork
{
    Task SaveChangesAsync();
}