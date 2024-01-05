using EfcMappingExamples.Aggregates.FirstAggregate;
using Microsoft.EntityFrameworkCore;
using Xunit;

namespace EfcMappingExamples.Tests;

public class MappingTests
{
    [Fact]
    public async Task CanMapGuidPk()
    {
        using MyDbContext context = new();
        context.Database.EnsureDeleted();
        context.Database.EnsureCreated();

        Guid id = Guid.NewGuid();
        FirstAggregate fa = new(id);
        await context.FirstAggregates.AddAsync(fa);
        await context.SaveChangesAsync();
        FirstAggregate retrieved = await context.FirstAggregates.SingleAsync(x => x.Id.Equals(id));
        Assert.Equal(id, retrieved.Id);
    }

    [Fact]
    public async Task CanMapValueObjectAsId()
    {
        
    }
}