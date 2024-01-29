﻿using EfcMappingExamples.Aggregates.FirstAggregate;
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
        Nested entities.
        List of multi valued VO 
        Enums. 
        Class enums thingy 
        List of simple FK references.
        List of strongly typed FK references.
        Value object of other value objects: Money (Amount, Currency), https://devblogs.microsoft.com/dotnet/announcing-ef8-rc1/#nested-complex-types
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
    public async Task PrivateValueObjectFieldOfTwoPropertiesUsingComplexTypes()
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
    // We use "owned entity" for the value object
    // This has another limitation though, you cannot have two fields of the same type, with the same value.
    // https://learn.microsoft.com/en-us/ef/core/modeling/owned-entities
    [Fact]
    public async Task PrivateOwnedEntityFieldOfTwoProperties()
    {
        await using MyDbContext context = SetupContext();
        MyId id = MyId.Create();
        SecondAggregate sa = new(id);
        TwoPropsValueObject twoPropsValueObject = TwoPropsValueObject.Create("Screws", 42);
        sa.SetTwoValued(twoPropsValueObject);

        OtherTwoPropsValueObject otherTwoPropsValueObject = OtherTwoPropsValueObject.Create("kg", 42);
        sa.SetOtherTwoValued(otherTwoPropsValueObject);
        
        await SaveAndClear(sa, context);
        
        SecondAggregate retrieved = await context.SecondAggregates.SingleAsync(x => x.Id == id);
        Assert.Equal(otherTwoPropsValueObject.Unit, retrieved.otherTwoValuedValueObject.Unit);
        Assert.Equal(otherTwoPropsValueObject.Count, retrieved.otherTwoValuedValueObject.Count);
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