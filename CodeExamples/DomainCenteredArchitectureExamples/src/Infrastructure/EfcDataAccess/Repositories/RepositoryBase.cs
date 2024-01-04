using DCAExamples.Core.Domain.Common.Bases;
using DCAExamples.Core.Domain.Common.Repositories;
using EfcDataAccess.Context;

namespace EfcDataAccess.Repositories;

public abstract class RepositoryBase<T>(ProjectDbContext context) :
    IGenericRepository<T> where T : AggregateRoot
{
    public abstract Task<T> GetAsync(Guid id);

    public async Task RemoveAsync(Guid id)
    {
        T agg = await GetAsync(id);
        context.Set<T>().Remove(agg);
    }

    public async Task AddAsync(T aggregate)
        => await context.Set<T>().AddAsync(aggregate);
}