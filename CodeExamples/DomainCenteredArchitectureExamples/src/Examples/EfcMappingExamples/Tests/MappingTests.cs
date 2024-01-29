using EfcMappingExamples.Aggregates.FirstAggregate;
using EfcMappingExamples.Aggregates.SecondAggregate;
using EfcMappingExamples.Aggregates.Values;
using Microsoft.EntityFrameworkCore;
using Xunit;

namespace EfcMappingExamples.Tests;

public class MappingTests
{
    
    /*
      TODO:
        Simple Foreign key.
        Strongly typed Foreing Key 
        Multi value vo. 
        Nested entities.
        List of multi valued VO 
        Enums. 
        Class enums thingy 
        List of simple FK references.
        List of strongly typed FK references.
        Vo af vo. Dvs nested. Money, amount, currency, tal før og efter decimal, find formelle navne på dem
     */
    
    [Fact]
    public async Task GuidPk()
    {
        await using MyDbContext context = SetupContext();

        Guid id = Guid.NewGuid();
        FirstAggregate fa = new(id);
        await SaveAndClear(fa, context);
        
        FirstAggregate retrieved = await context.FirstAggregates.SingleAsync(x => x.Id == id);
        
        Assert.Equal(id, retrieved.Id);
    }

    [Fact]
    public async Task StronglyTypedId()
    {
        await using MyDbContext context = SetupContext();
        MyId id = MyId.Create();
        SecondAggregate sa = new(id);
        sa.SetTwoValued(TwoPropsValueObject.Create("dummy", 0));
        await SaveAndClear(sa, context);
        
        SecondAggregate retrieved = await context.SecondAggregates.SingleAsync(x => x.Id == id);
        
        Assert.Equal(id.Get, retrieved.Id.Get);
    }


    
    [Fact]
    public async Task PrivateSimpleField()
    {
        await using MyDbContext context = SetupContext();
        Guid id = Guid.NewGuid();
        FirstAggregate fa = new(id);
        string value = "Hello world";
        fa.SetSomeStringValue(value);

        await SaveAndClear(fa, context);
        
        FirstAggregate retrieved = await context.FirstAggregates.SingleAsync(x => x.Id == id);
        
        Assert.Equal(value, retrieved.someStringValue);
    }
    
    [Fact]
    public async Task PrivateValueObjectField()
    {
        await using MyDbContext context = SetupContext();
        Guid id = Guid.NewGuid();
        FirstAggregate fa = new(id);
        MyStringValueObject vo = MyStringValueObject.Create("Hello world");
        fa.SetFirstVo(vo);

        await SaveAndClear(fa, context);
        
        FirstAggregate retrieved = await context.FirstAggregates.SingleAsync(x => x.Id == id);
        Assert.Equal(vo, retrieved.firstValueObject);
    }

    [Fact]
    public async Task PrivateValueObjectFieldOfTwoProperties()
    {
        await using MyDbContext context = SetupContext();
        MyId id = MyId.Create();
        SecondAggregate sa = new(id);
        TwoPropsValueObject twoPropsValueObject = TwoPropsValueObject.Create("Screws", 42);
        sa.SetTwoValued(twoPropsValueObject);
        
        await SaveAndClear(sa, context);
        
        SecondAggregate retrieved = await context.SecondAggregates.SingleAsync(x => x.Id == id);
        Assert.Equal(twoPropsValueObject.Amount, retrieved.twoValuedValueObject.Amount);
        Assert.Equal(twoPropsValueObject.Type, retrieved.twoValuedValueObject.Type);
    }

    // This is an alternative to the above approach, which doesn't allow nullability
    [Fact]
    public async Task PrivateOwnedEntityFieldOfTwoProperties()
    {
        Assert.Fail("Implement this!");
    }
    
    private static MyDbContext SetupContext()
    {
        MyDbContext context = new();
        context.Database.EnsureDeleted();
        context.Database.EnsureCreated();
        return context;
    }
    
    private async Task SaveAndClear<T>(T obj, MyDbContext context) where T : class
    {
        await context.Set<T>().AddAsync(obj);
        await context.SaveChangesAsync();
        context.ChangeTracker.Clear(); // making sure nothing is tracked.
    }
}