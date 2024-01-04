using DCAExamples.Core.Domain.Common.Bases;

namespace DCAExamples.Core.Domain.Common.Repositories;

public interface IGenericRepository<T>
    where T : AggregateRoot
{
    Task<T> GetAsync(Guid id);
    Task RemoveAsync(Guid id);
    Task AddAsync(T aggregate);
}