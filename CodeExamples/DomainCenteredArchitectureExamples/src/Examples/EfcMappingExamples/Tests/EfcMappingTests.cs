﻿using EfcMappingExamples.Aggregates.FifthAggregate;
using EfcMappingExamples.Aggregates.FirstAggregate;
using EfcMappingExamples.Aggregates.FourthAggregate;
using EfcMappingExamples.Aggregates.SecondAggregate;
using EfcMappingExamples.Aggregates.SeventhAggregate;
using EfcMappingExamples.Aggregates.SixthAggregate;
using EfcMappingExamples.Aggregates.ThirdAggregate;
using EfcMappingExamples.Aggregates.Values;
using EfcMappingExamples.Cases.AHasListOfGuidsReferencingB;
using Microsoft.EntityFrameworkCore;
using Xunit;

namespace EfcMappingExamples.Tests;

public class EfcMappingTests
{
    /*
      TODO:
        List of multi valued VO
        Class enums thingy
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
        await SaveAndClearAsync(fa, context);

        FirstAggregate retrieved = await context.FirstAggregates.SingleAsync(x => x.Id == id);

        Assert.Equal(id, retrieved.Id);
    }

    [Fact]
    public async Task StronglyTypedId()
    {
        await using MyDbContext context = SetupContext();
        SecondAggId id = SecondAggId.Create();
        SecondAggregate sa = new(id);
        sa.SetTwoValued(TwoPropsValueObject.Create("dummy", 0));
        await SaveAndClearAsync(sa, context);

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

        await SaveAndClearAsync(fa, context);

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

        await SaveAndClearAsync(fa, context);

        FirstAggregate retrieved = await context.FirstAggregates.SingleAsync(x => x.Id == id);
        Assert.Equal(vo, retrieved.firstValueObject);
    }

    [Fact]
    public async Task PrivateValueObjectFieldOfTwoPropertiesUsingComplexTypes()
    {
        await using MyDbContext context = SetupContext();
        SecondAggId id = SecondAggId.Create();
        SecondAggregate sa = new(id);
        TwoPropsValueObject twoPropsValueObject = TwoPropsValueObject.Create("Screws", 42);
        sa.SetTwoValued(twoPropsValueObject);

        await SaveAndClearAsync(sa, context);

        SecondAggregate retrieved = await context.SecondAggregates.SingleAsync(x => x.Id == id);
        Assert.Equal(twoPropsValueObject.Amount, retrieved.twoValuedValueObject.Amount);
        Assert.Equal(twoPropsValueObject.Type, retrieved.twoValuedValueObject.Type);
    }

    // This is an alternative to the above approach, which doesn't allow nullability
    // Here we use "owned entity" for the value object
    // This has another limitation though, you cannot have two fields of the same type, with the same instance.
    // It's _probably_ not a problem. Generally. 
    // The Value Objects are actually also stored as entities, with keys, which we just don't define.
    // https://learn.microsoft.com/en-us/ef/core/modeling/owned-entities
    [Fact]
    public async Task PrivateOwnedEntityFieldOfTwoProperties()
    {
        await using MyDbContext context = SetupContext();
        SecondAggId id = SecondAggId.Create();
        SecondAggregate sa = new(id);
        TwoPropsValueObject twoPropsValueObject = TwoPropsValueObject.Create("Screws", 42);
        sa.SetTwoValued(twoPropsValueObject);

        OtherTwoPropsValueObject otherTwoPropsValueObject = OtherTwoPropsValueObject.Create("kg", 42);
        sa.SetOtherTwoValued(otherTwoPropsValueObject);

        await SaveAndClearAsync(sa, context);

        SecondAggregate retrieved = await context.SecondAggregates.SingleAsync(x => x.Id == id);
        Assert.Equal(otherTwoPropsValueObject.Unit, retrieved.otherTwoValuedValueObject!.Unit);
        Assert.Equal(otherTwoPropsValueObject.Count, retrieved.otherTwoValuedValueObject!.Count);
    }

    [Fact]
    public async Task EnumWithConversion()
    {
        await using MyDbContext context = SetupContext();
        Guid id = Guid.NewGuid();
        ThirdAggregate ta = new ThirdAggregate(id);
        Status newStatus = Status.Validated;
        ta.SetStatus(newStatus);

        await SaveAndClearAsync(ta, context);

        ThirdAggregate retrieved = await context.ThirdAggregates.SingleAsync(x => x.Id == id);
        Assert.Equal(newStatus, retrieved.currentStatus);
    }

    [Fact]
    public async Task SimpleTypeForeignKeyWithReferentialIntegrity_OneToMany_RejectsEmptyValue()
    {
        await using MyDbContext context = SetupContext();
        Guid id = Guid.NewGuid();
        FourthAggregate ta = new FourthAggregate(id);
        context.FourthAggregates.Add(ta);
        Action exp = () => context.SaveChanges();

        Assert.ThrowsAny<Exception>(exp);
    }

    [Fact]
    public async Task SimpleTypeForeignKeyWithReferentialIntegrity_OneToMany_SuccessWhenValidFk()
    {
        await using MyDbContext context = SetupContext();
        Guid faGuid = Guid.NewGuid();
        FirstAggregate fa = new FirstAggregate(faGuid);

        await SaveAndClearAsync(fa, context);

        Guid otherGuid = Guid.NewGuid();
        FourthAggregate fourthAggregate = new(otherGuid);
        fourthAggregate.SetFirstAggregateForeignKey(faGuid);

        context.FourthAggregates.Add(fourthAggregate);

        Exception exceptionThrown = Record.Exception(() => context.SaveChanges());

        Assert.Null(exceptionThrown);
    }

    [Fact]
    public async Task SimpleTypeForeignKeyWithReferentialIntegrity_OneToOne_RejectsEmptyValue()
    {
        await using MyDbContext context = SetupContext();
        Guid id = Guid.NewGuid();
        FifthAggregate ta = new FifthAggregate(id);
        context.FifthAggregates.Add(ta);
        Action exp = () => context.SaveChanges();

        Assert.ThrowsAny<Exception>(exp);
    }

    [Fact]
    public async Task SimpleTypeForeignKeyWithReferentialIntegrity_OneToOne_SuccessWhenValidFk()
    {
        await using MyDbContext context = SetupContext();
        Guid faGuid = Guid.NewGuid();
        FirstAggregate fa = new FirstAggregate(faGuid);

        await SaveAndClearAsync(fa, context);

        Guid otherGuid = Guid.NewGuid();
        FifthAggregate fifthAggregate = new(otherGuid);
        fifthAggregate.SetFirstAggregateForeignKey(faGuid);

        context.FifthAggregates.Add(fifthAggregate);

        Exception exceptionThrown = Record.Exception(() => context.SaveChanges());

        Assert.Null(exceptionThrown);
    }

    [Fact]
    public async Task StronglyTypedForeignKeyWithReferentialIntegrity_OneToMany_FailureWhenInvalidFkValue()
    {
        await using MyDbContext context = SetupContext();
        Guid id = Guid.NewGuid();
        SixthAggregate ta = new(id);
        context.SixthAggregates.Add(ta);
        Action exp = () => context.SaveChanges();

        Assert.ThrowsAny<Exception>(exp);
    }

    [Fact]
    public async Task StronglyTypedForeignKeyWithReferentialIntegrity_OneToMany_SuccessWhenValidFkValue()
    {
        await using MyDbContext context = SetupContext();
        // insert Second Aggregate, i.e. fk target
        SecondAggId strongId = SecondAggId.Create();
        SecondAggregate sa = new(strongId);
        sa.SetTwoValued(TwoPropsValueObject.Create("dummy", 0));
        await SaveAndClearAsync(sa, context);

        Guid id = Guid.NewGuid();
        SixthAggregate sixth = new(id);
        context.SixthAggregates.Add(sixth);
        sixth.SetFirstAggregateForeignKey(strongId);
        Action exp = () => context.SaveChanges();

        Exception exceptionThrown = Record.Exception(exp);

        Assert.Null(exceptionThrown);
    }

    [Fact]
    public async Task StronglyTypedForeignKey_OneToOne_FailsWithInvalidValue()
    {
        await using MyDbContext context = SetupContext();
        Guid thirdId = Guid.NewGuid();
        ThirdAggregate third = new ThirdAggregate(thirdId);
        third.SetSecondAggFk(SecondAggId.Create());

        context.ThirdAggregates.Add(third);

        Action exp = () => context.SaveChanges();

        Assert.ThrowsAny<Exception>(exp);
    }

    [Fact]
    public async Task StronglyTypedForeignKey_OneToOne_SuccessWithNullFk()
    {
        await using MyDbContext context = SetupContext();
        Guid thirdId = Guid.NewGuid();
        ThirdAggregate third = new ThirdAggregate(thirdId);
        third.SetSecondAggFk(SecondAggId.Create());


        Action exp = () => context.SaveChanges();

        Exception? exception = Record.Exception(exp);
        Assert.Null(exception);
    }

    [Fact]
    public async Task StronglyTypedForeignKey_OneToOne_SuccessWithValidFk()
    {
        await using MyDbContext context = SetupContext();

        SecondAggId secondAggId = SecondAggId.Create();
        SecondAggregate second = new(secondAggId);
        await SaveAndClearAsync(second, context);

        Guid thirdId = Guid.NewGuid();
        ThirdAggregate third = new ThirdAggregate(thirdId);
        third.SetSecondAggFk(secondAggId);

        context.ThirdAggregates.Add(third);


        Action exp = () => context.SaveChanges();
        Exception? exception = Record.Exception(exp);
        Assert.Null(exception);
    }

    [Fact]
    public async Task SingleNestedEntityWithSimpleIdOnParent()
    {
        await using MyDbContext context = SetupContext();
        Guid thirdId = Guid.NewGuid();
        ThirdAggregate third = new(thirdId);
        Guid entGuid = Guid.NewGuid();
        SomeEntity someEntity = new(entGuid);
        third.SetNestedEntity(someEntity);

        await SaveAndClearAsync(third, context);

        ThirdAggregate retrieved = context.ThirdAggregates
            .Include("nestedEntity") // have to use string, because no access to "private" (internal) members. 
            .Single(t => t.Id == thirdId);

        Assert.NotNull(retrieved.nestedEntity);
        Assert.Equal(entGuid, retrieved.nestedEntity.Id);
    }

    // Multiple nested entities with simple ID on parent.
    [Fact]
    public async Task MultipleNestedEntitiesWithSimpleIdOnParent_CanLoadEntities()
    {
        await using MyDbContext context = SetupContext();
        Guid seventhId = Guid.NewGuid();
        SeventhAggregate seventh = new(seventhId);

        SomeEntity one = new(Guid.NewGuid());
        SomeEntity two = new(Guid.NewGuid());
        SomeEntity three = new(Guid.NewGuid());
        seventh.AddEntity(one);
        seventh.AddEntity(two);
        seventh.AddEntity(three);

        await SaveAndClearAsync(seventh, context);

        SeventhAggregate retrieved = context.SeventhAggregates
            .Include("nestedEntities")
            .Single(s => s.Id == seventhId);

        Assert.Equal(3, retrieved.nestedEntities.Count);
        Assert.Contains(retrieved.nestedEntities, e => e.Id == one.Id);
        Assert.Contains(retrieved.nestedEntities, e => e.Id == two.Id);
        Assert.Contains(retrieved.nestedEntities, e => e.Id == three.Id);
    }

    [Fact]
    public async Task MultipleNestedEntitiesWithSimpleIdOnParent_EntitiesStoredInOwnTable()
    {
        await using MyDbContext context = SetupContext();
        Guid seventhId = Guid.NewGuid();
        SeventhAggregate seventh = new(seventhId);

        SomeEntity one = new(Guid.NewGuid());
        SomeEntity two = new(Guid.NewGuid());
        SomeEntity three = new(Guid.NewGuid());
        seventh.AddEntity(one);
        seventh.AddEntity(two);
        seventh.AddEntity(three);

        await SaveAndClearAsync(seventh, context);

        SomeEntity? oneRetrieved = context.Set<SomeEntity>().SingleOrDefault(e => e.Id == one.Id);
        SomeEntity? twoRetrieved = context.Set<SomeEntity>().SingleOrDefault(e => e.Id == two.Id);
        SomeEntity? threeRetrieved = context.Set<SomeEntity>().SingleOrDefault(e => e.Id == three.Id);

        Assert.NotNull(oneRetrieved);
        Assert.NotNull(twoRetrieved);
        Assert.NotNull(threeRetrieved);
    }

    // single nested entity with strong Id on parent.

    [Fact]
    public async Task SingleNestedEntityWithStrongIdOnParent_CanLoadNestedEntity()
    {
        await using MyDbContext ctx = SetupContext();
        SomeEntity ent = new SomeEntity(Guid.NewGuid());
        SecondAggId secondId = SecondAggId.Create();
        SecondAggregate second = new(secondId);
        second.SetNestedEntity(ent);

        await SaveAndClearAsync(second, ctx);

        SecondAggregate retrieved = ctx.SecondAggregates
            .Include("nestedEntity")
            .Single(s => s.Id == secondId);

        Assert.NotNull(retrieved.nestedEntity);
        Assert.Equal(ent.Id, retrieved.nestedEntity.Id);
    }

    // multiple nested entities with strong Id on parent.

    [Fact]
    public async Task ManyNestedEntityWithStrongIdOnParent_CanLoadNestedEntities()
    {
        await using MyDbContext ctx = SetupContext();
        OtherEntity ent1 = new(Guid.NewGuid());
        OtherEntity ent2 = new(Guid.NewGuid());
        OtherEntity ent3 = new(Guid.NewGuid());
        SecondAggId secondId = SecondAggId.Create();
        SecondAggregate second = new(secondId);

        second.AddManyNestedEntities(ent1, ent2, ent3);

        await SaveAndClearAsync(second, ctx);

        SecondAggregate retrieved = ctx.SecondAggregates
            .Include("nestedEntities")
            .Single(s => s.Id == secondId);

        Assert.NotEmpty(retrieved.nestedEntities);
        Assert.Contains(retrieved.nestedEntities, x => x.Id == ent1.Id);
        Assert.Contains(retrieved.nestedEntities, x => x.Id == ent2.Id);
        Assert.Contains(retrieved.nestedEntities, x => x.Id == ent3.Id);
    }

    // List of Value Objects.

    [Fact]
    public async Task ListOfValueObjects()
    {
        await using MyDbContext ctx = SetupContext();

        MyStringValueObject vo1 = MyStringValueObject.Create("Hello");
        MyStringValueObject vo2 = MyStringValueObject.Create("world");
        MyStringValueObject vo3 = MyStringValueObject.Create("again");

        SeventhAggregate seventh = new(Guid.NewGuid());

        seventh.AddValues(vo1, vo2, vo3);
        await SaveAndClearAsync(seventh, ctx);

        SeventhAggregate retrieved = ctx.SeventhAggregates.Single(x => x.Id == seventh.Id);

        Assert.NotEmpty(retrieved.values);
        Assert.Contains(retrieved.values, x => x == vo1);
        Assert.Contains(retrieved.values, x => x == vo2);
        Assert.Contains(retrieved.values, x => x == vo3);
    }

    // TODO    List of simple FK references.

    [Fact]
    public async Task ListOfGuidFkReferences()
    {
        await using MyDbContext ctx = SetupContext();
        
        // adding reference entities
        EntityB b1 = new(Guid.NewGuid());
        EntityB b2 = new(Guid.NewGuid());
        EntityB b3 = new(Guid.NewGuid());

        ctx.EntityBs.AddRange(b1, b2, b3);
        await ctx.SaveChangesAsync();
        ctx.ChangeTracker.Clear();
        
        
        EntityA a1 = new(Guid.NewGuid());
        a1.AddFks(b1.Id, b2.Id, b3.Id);

        await SaveAndClearAsync(a1, ctx);

        
        EntityA retrieved = ctx.EntityAs
            .Include("foreignKeysToB")
            .Single(x => x.Id == a1.Id);
        
        Assert.NotEmpty(retrieved.foreignKeysToB);
        Assert.Contains(retrieved.foreignKeysToB, x => x.FkToB == b1.Id);
        Assert.Contains(retrieved.foreignKeysToB, x => x.FkToB == b2.Id);
        Assert.Contains(retrieved.foreignKeysToB, x => x.FkToB == b3.Id);
    }

    #region Helper methods

    private static MyDbContext SetupContext()
    {
        MyDbContext context = new();
        context.Database.EnsureDeleted();
        context.Database.EnsureCreated();
        return context;
    }

    private static async Task SaveAndClearAsync<T>(T obj, MyDbContext context) where T : class
    {
        await context.Set<T>().AddAsync(obj);
        await context.SaveChangesAsync();
        context.ChangeTracker.Clear(); // making sure nothing is tracked.
    }

    #endregion
}