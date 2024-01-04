using DCAExamples.Core.Domain.Aggregates.TeamAggregate.Entities;
using DCAExamples.Core.Domain.Common.Repositories;
using EfcDataAccess.Context;
using Microsoft.EntityFrameworkCore;

namespace EfcDataAccess.Repositories;

public class TeamRepositoryEfc(ProjectDbContext context) 
                                : ITeamRepository
{
    public async Task AddAsync(Team team)
    {
        await context.Set<Team>().AddAsync(team);
        await context.SaveChangesAsync();
    }

    public Task<Team> GetAsync(Guid id)
    {
        return context
            .Set<Team>()
            //.Include(team => team.Members)
            .SingleAsync(team => team.Id == id);
    }
    
    // ...

    public Task RemoveAsync(Guid id)
    {
        throw new NotImplementedException();
    }

    public Task UpdateAsync(Team team)
    {
        throw new NotImplementedException();
    }
}