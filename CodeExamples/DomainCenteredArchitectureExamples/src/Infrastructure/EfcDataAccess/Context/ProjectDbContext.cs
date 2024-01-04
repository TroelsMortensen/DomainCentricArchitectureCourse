using DCAExamples.Core.Domain.Aggregates.TeamAggregate.Entities;
using Microsoft.EntityFrameworkCore;

namespace EfcDataAccess.Context;

public class ProjectDbContext : DbContext
{
    public DbSet<Team> Teams => Set<Team>();
}