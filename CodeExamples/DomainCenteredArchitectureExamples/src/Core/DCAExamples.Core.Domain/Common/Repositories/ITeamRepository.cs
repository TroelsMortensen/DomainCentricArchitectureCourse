using DCAExamples.Core.Domain.Aggregates.TeamAggregate.Entities;

namespace DCAExamples.Core.Domain.Common.Repositories;

public interface ITeamRepository
{
    Task AddAsync(Team team);
    Task<Team> GetAsync(Guid id);
    Task RemoveAsync(Guid id);
    Task UpdateAsync(Team team);
}