using EfcMappingExamples.Aggregates.FirstAggregate;
using EfcMappingExamples.Aggregates.SecondAggregate;
using EfcMappingExamples.Aggregates.Values;
using Microsoft.EntityFrameworkCore;
using Xunit;

namespace EfcMappingExamples.Tests;

public class MappingTests
{
    [Fact]
    public async Task CanMapGuidPk()
    {
        await using MyDbContext context = SetupContext();

        Guid id = Guid.NewGuid();
        FirstAggregate fa = new(id);
        await Save(fa, context);
        
        FirstAggregate retrieved = await context.FirstAggregates.SingleAsync(x => x.Id == id);
        
        Assert.Equal(id, retrieved.Id);
    }

    [Fact]
    public async Task CanMapValueObjectAsId()
    {
        await using MyDbContext context = SetupContext();
        MyId id = MyId.Create();
        SecondAggregate sa = new(id);
        await Save(sa, context);
        
        SecondAggregate retrieved = await context.SecondAggregates.SingleAsync(x => x.Id == id);
        
        Assert.Equal(id.Get, retrieved.Id.Get);
    }

    private async Task Save<T>(T obj, MyDbContext context) where T : class
    {
        await context.Set<T>().AddAsync(obj);
        await context.SaveChangesAsync();
        context.ChangeTracker.Clear(); // making sure nothing is tracked.
    }
    
    [Fact]
    public async Task CanMapPrivateField()
    {
        await using MyDbContext context = SetupContext();
        Guid id = Guid.NewGuid();
        FirstAggregate fa = new(id);
        string value = "Hello world";
        fa.SetSomeStringValue(value);

        await Save(fa, context);
        
        FirstAggregate retrieved = await context.FirstAggregates.SingleAsync(x => x.Id == id);
        
        Assert.Equal(value, retrieved.someStringValue);
    }
    
    [Fact]
    public async Task CanMapPrivateValueObject()
    {
        
    }
    
    private static MyDbContext SetupContext()
    {
        MyDbContext context = new();
        context.Database.EnsureDeleted();
        context.Database.EnsureCreated();
        return context;
    }
}