namespace DCAExamples.Core.Application.Common.Repositories;

public interface IUnitOfWork
{
    Task SaveChangesAsync();
}