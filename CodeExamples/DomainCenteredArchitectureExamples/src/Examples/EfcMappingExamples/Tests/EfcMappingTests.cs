using EfcMappingExamples.Cases.AHasListOfGuidsReferencingB;
using EfcMappingExamples.Cases.CHasListOfStrongIdReferencingD;
using EfcMappingExamples.Cases.ClassAsEnum;
using EfcMappingExamples.Cases.EHasListOfMultiValuedValueObjects;
using EfcMappingExamples.Cases.GuidAsFk;
using EfcMappingExamples.Cases.GuidAsPk;
using EfcMappingExamples.Cases.ListOfNestedEntities;
using EfcMappingExamples.Cases.ListOfNestedValueObjects;
using EfcMappingExamples.Cases.ListOfValueObjects;
using EfcMappingExamples.Cases.NestedValueObjects;
using EfcMappingExamples.Cases.NonNullableMultiValuedValueObject;
using EfcMappingExamples.Cases.NonNullableNestedValueObjects;
using EfcMappingExamples.Cases.NonNullableSingleValuedValueObject;
using EfcMappingExamples.Cases.NullableMultiValuedValueObject;
using EfcMappingExamples.Cases.NullableNestedValueObjects;
using EfcMappingExamples.Cases.NullableSingleValuedValueObject;
using EfcMappingExamples.Cases.SingleNestedEntity;
using EfcMappingExamples.Cases.StronglyTypedForeignKey;
using EfcMappingExamples.Cases.StronglyTypedId;
using Microsoft.EntityFrameworkCore;
using Xunit;
using Xunit.Abstractions;

namespace EfcMappingExamples.Tests;

public class EfcMappingTests
{
    private readonly ITestOutputHelper testOutputHelper;

    public EfcMappingTests(ITestOutputHelper testOutputHelper)
    {
        this.testOutputHelper = testOutputHelper;
    }
    /*
        collections of primitives: https://learn.microsoft.com/en-us/ef/core/what-is-new/ef-core-8.0/whatsnew#primitive-collection-properties
     */

    
    // List of simple FK references.

    [Fact]
    public async Task ListOfGuidFkReferences_ValidValues()
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
        a1.AddForeignKey(b1.Id);
        a1.AddForeignKey(b2.Id);
        a1.AddForeignKey(b3.Id);

        await SaveAndClearAsync(a1, ctx);


        EntityA retrieved = ctx.EntityAs
            .Include("foreignKeysToB") // I have to include, because this was not done with Owned Entity Types.
            .Single(x => x.Id == a1.Id);

        Assert.NotEmpty(retrieved.foreignKeysToB);
        Assert.Contains(retrieved.foreignKeysToB, x => x.FkToB == b1.Id);
        Assert.Contains(retrieved.foreignKeysToB, x => x.FkToB == b2.Id);
        Assert.Contains(retrieved.foreignKeysToB, x => x.FkToB == b3.Id);
    }

    [Fact]
    public async Task ListOfGuidFkReferences_InvalidValues()
    {
        await using MyDbContext ctx = SetupContext();
        EntityA a1 = new(Guid.NewGuid());
        a1.AddForeignKey(Guid.NewGuid());
        a1.AddForeignKey((Guid.NewGuid()));
        a1.AddForeignKey((Guid.NewGuid()));

        ctx.EntityAs.Add(a1);
        
        Action exp = () => ctx.SaveChanges();

        Exception? exception = Record.Exception(exp);
        Assert.NotNull(exception);
    }

    // List of strongly typed FK references.
    [Fact]
    public async Task ListOfStrongIdFkReferences()
    {
        await using MyDbContext ctx = SetupContext();

        EntityD d1 = new (DId.Create());
        EntityD d2 = new (DId.Create());
        EntityD d3 = new (DId.Create());

        await ctx.EntityDs.AddRangeAsync(d1, d2, d3);
        await ctx.SaveChangesAsync();
        ctx.ChangeTracker.Clear();

        EntityC c = new EntityC(Guid.NewGuid());
        c.AddFk(d1.Id);
        c.AddFk(d2.Id);
        c.AddFk(d3.Id);

        await SaveAndClearAsync(c, ctx);

        EntityC retrieved = ctx.EntityCs
            .Include("foreignKeysToD")
            .Single(x => x.Id == c.Id);

        Assert.NotEmpty(retrieved.foreignKeysToD);
        Assert.Contains(retrieved.foreignKeysToD, x => x.FkToD.Value == d1.Id.Value);
        Assert.Contains(retrieved.foreignKeysToD, x => x.FkToD.Value == d2.Id.Value);
        Assert.Contains(retrieved.foreignKeysToD, x => x.FkToD.Value == d3.Id.Value);
    }

    [Fact]
    public async Task ListOfStrongIdFkReferences_FailWithInvalidFk()
    {
        await using MyDbContext ctx = SetupContext();
        EntityC c = new (Guid.NewGuid());
        c.AddFk(DId.Create());

        ctx.EntityCs.Add(c);

        Action exp = () => ctx.SaveChanges();
        Exception? exception = Record.Exception(exp);

        Assert.NotNull(exception);
    }

    // List of strongly typed FK references, by Amichai.
    // https://www.youtube.com/watch?v=B3Iq346KwUQ
    // This does not create the correct constraints.

    [Fact]
    public async Task ListOfStrongIdFkReferencesByAmichai()
    {
        // ... can't make this work, currently.
    }

    // List of multi valued VO
    [Fact]
    public async Task ListOfMultiValuedValueObjects()
    {
        await using MyDbContext ctx = SetupContext();

        ValueObjectE vo1 = ValueObjectE.Create("Hello", 42);
        ValueObjectE vo2 = ValueObjectE.Create("World", 47);

        EntityE e = new(Guid.NewGuid());
        e.AddValues(vo1, vo2);

        await SaveAndClearAsync(e, ctx);

        EntityE retrieved = ctx.EntityEs
            .Include("values")
            .Single(x => x.Id == e.Id);

        Assert.NotEmpty(retrieved.values);
        Assert.Contains(retrieved.values, x => x.Equals(vo1));
        Assert.Contains(retrieved.values, x => x.Equals(vo2));
    }

    // Class as enum

    [Fact]
    public async Task ClassAsEnum()
    {
        await using MyDbContext ctx = SetupContext();
        EntityH h = new(Guid.NewGuid());

        await SaveAndClearAsync(h, ctx);

        EntityH retrieved = ctx.EntityHs.Single(x => x.Id == h.Id);

        Assert.Equal(MyStatusEnum.First, retrieved.status);
    }

    // Nested single value object
    // Value object of other value objects: Money (Amount, Currency), https://devblogs.microsoft.com/dotnet/announcing-ef8-rc1/#nested-complex-types
    // Vo af vo. Dvs nested. Money, amount, currency, tal før og efter decimal, find formelle navne på dem

    [Fact]
    public async Task NestedValueObjects()
    {
        await using MyDbContext ctx = SetupContext();
        FirstNestedVO first = FirstNestedVO.Create("Stuff", 42);
        SecondNestedVO second = SecondNestedVO.Create("Type");
        TopValueObject top = TopValueObject.Create(first, second);

        EntityJ j = new EntityJ(Guid.NewGuid());
        j.SetValue(top);
        await SaveAndClearAsync(j, ctx);

        EntityJ retrieved = ctx.EntityJs.Single(x => x.Id == j.Id);
        Assert.Equal(retrieved.myValue.First.Number, first.Number);
        Assert.Equal(retrieved.myValue.First.Stuff, first.Stuff);
        Assert.Equal(retrieved.myValue.Second.Type, second.Type);
    }

    [Fact]
    public async Task ListOfNestedValueObjects()
    {
        await using MyDbContext ctx = SetupContext();

        FirstNestedVO first1 = FirstNestedVO.Create("Stuff", 42);
        SecondNestedVO second1 = SecondNestedVO.Create("Type");
        TopValueObject top1 = TopValueObject.Create(first1, second1);

        FirstNestedVO first2 = FirstNestedVO.Create("Stuff2", 422);
        SecondNestedVO second2 = SecondNestedVO.Create("Type2");
        TopValueObject top2 = TopValueObject.Create(first2, second2);

        EntityK k = new EntityK(Guid.NewGuid());
        k.AddValues(top1, top2);

        await SaveAndClearAsync(k, ctx);

        EntityK retrieved = ctx.EntityKs.Single(x => x.Id == k.Id);

        Assert.NotEmpty(retrieved.values);
    }

    [Fact]
    public async Task GuidAsPk()
    {
        await using MyDbContext ctx = SetupContext();
        Guid id = Guid.NewGuid();
        EntityL entity = new(id);
        await SaveAndClearAsync(entity, ctx);

        EntityL? retrieved = ctx.EntityLs.SingleOrDefault(x => x.Id == id);
        Assert.NotNull(retrieved);
    }

    [Fact]
    public async Task StrongIdAsPk()
    {
        await using MyDbContext ctx = SetupContext();

        MId id = MId.Create();
        EntityM entity = new(id);

        await SaveAndClearAsync(entity, ctx);

        EntityM? retrieved = ctx.EntityMs.SingleOrDefault(x => x.Id.Equals(id));
        Assert.NotNull(retrieved);
    }

    [Fact]
    public async Task NonNullableSinglePrimitiveValuedValueObject()
    {
        await using MyDbContext ctx = SetupContext();
        ValueObjectN value = ValueObjectN.Create("Hello world");
        EntityN entity = new(Guid.NewGuid());
        entity.SetValue(value);

        await SaveAndClearAsync(entity, ctx);

        EntityN retrieved = ctx.EntityNs.Single(x => x.Id == entity.Id);
        Assert.NotNull(retrieved.someValue);
        Assert.Equal(value.Value, retrieved.someValue.Value);
    }

    [Fact]
    public async Task NonNullableSinglePrimitiveValuedValueObject_FailWhenNull()
    {
        await using MyDbContext ctx = SetupContext();
        EntityN entity = new(Guid.NewGuid());
        await ctx.EntityNs.AddAsync(entity);

        Assert.Throws<InvalidOperationException>(() => ctx.SaveChanges());
    }

    [Fact]
    public async Task NullableSinglePrimitiveValuedValueObject()
    {
        await using MyDbContext ctx = SetupContext();
        ValueObjectO value = ValueObjectO.Create("Hello world");
        EntityO entity = new(Guid.NewGuid());
        entity.SetValue(value);

        await SaveAndClearAsync(entity, ctx);

        EntityO retrieved = ctx.EntityOs.Single(x => x.Id == entity.Id);
        Assert.NotNull(retrieved.someValue);
        Assert.Equal(value.Value, retrieved.someValue.Value);
    }

    [Fact]
    public async Task NullableSinglePrimitiveValuedValueObject_SaveWhenNulled()
    {
        await using MyDbContext ctx = SetupContext();
        EntityO entity = new(Guid.NewGuid());

        await SaveAndClearAsync(entity, ctx);

        EntityO retrieved = ctx.EntityOs.Single(x => x.Id == entity.Id);
        Assert.Null(retrieved.someValue);
    }

    [Fact]
    public async Task NonNullableMultiPrimitiveValuedValueObject()
    {
        await using MyDbContext ctx = SetupContext();
        EntityP entity = new(Guid.NewGuid());
        ValueObjectP valueObject = ValueObjectP.Create("Hello world", 42);
        entity.SetValue(valueObject);

        await SaveAndClearAsync(entity, ctx);

        EntityP retrieved = ctx.EntityPs.Single(x => x.Id == entity.Id);
        Assert.NotNull(retrieved.someValue);
        Assert.Equal(valueObject.First, retrieved.someValue.First);
        Assert.Equal(valueObject.Second, retrieved.someValue.Second);
    }


    [Fact]
    public async Task NullableMultiValuedValueObject_NoneAreNull()
    {
        await using MyDbContext ctx = SetupContext();
        EntityQ entity = new(Guid.NewGuid());
        ValueObjectQ valueObject = ValueObjectQ.Create("Hello world", 42);
        entity.SetValue(valueObject);

        await SaveAndClearAsync(entity, ctx);

        EntityQ retrieved = ctx.EntityQs.Single(x => x.Id == entity.Id);
        Assert.NotNull(retrieved.someValue);
        Assert.Equal(valueObject.First, retrieved.someValue.First);
        Assert.Equal(valueObject.Second, retrieved.someValue.Second);
    }

    [Fact]
    public async Task NullableMultiValuedValueObject_EntityPropertyIsNull()
    {
        await using MyDbContext ctx = SetupContext();
        EntityQ entity = new(Guid.NewGuid());

        await SaveAndClearAsync(entity, ctx);

        EntityQ retrieved = ctx.EntityQs.Single(x => x.Id == entity.Id);
        Assert.Null(retrieved.someValue);
    }

    [Fact]
    public async Task NullableMultiValuedValueObject_OneValueObjectPropertyIsNull()
    {
        await using MyDbContext ctx = SetupContext();
        EntityQ entity = new(Guid.NewGuid());
        entity.SetValue(ValueObjectQ.Create("Hello world", null));

        await SaveAndClearAsync(entity, ctx);

        EntityQ retrieved = ctx.EntityQs.Single(x => x.Id == entity.Id);
        Assert.NotNull(retrieved.someValue);
        Assert.Null(retrieved.someValue!.Second);
        Assert.Equal("Hello world", retrieved.someValue!.First);
    }

    [Fact]
    public async Task NonNullableNestedValueObject()
    {
        await using MyDbContext ctx = SetupContext();
        EntityR entity = new(Guid.NewGuid());
        NestedValueObjectR2 nested1 = NestedValueObjectR2.Create(42);
        NestedValueObjectR1 nested2 = NestedValueObjectR1.Create("Hello world");
        ValueObjectR valueObject = ValueObjectR.Create(nested2, nested1);
        entity.SetValue(valueObject);

        await SaveAndClearAsync(entity, ctx);

        EntityR retrieved = ctx.EntityRs.Single(x => x.Id == entity.Id);
        Assert.NotNull(retrieved.someValue);
        Assert.Equal(valueObject.First.Value, retrieved.someValue.First.Value);
        Assert.Equal(valueObject.Second.Value, retrieved.someValue.Second.Value);
    }

    [Fact]
    public async Task NullableNestedValueObject_AllNonNull()
    {
        await using MyDbContext ctx = SetupContext();
        EntityS entity = new(Guid.NewGuid());
        NestedValueObjectS1 nested1 = NestedValueObjectS1.Create("Hello world");
        NestedValueObjectS2 nested2 = NestedValueObjectS2.Create(42);
        ValueObjectS valueObject = ValueObjectS.Create(nested1, nested2);

        entity.SetValue(valueObject);

        await SaveAndClearAsync(entity, ctx);

        EntityS retrieved = ctx.EntitySs.Single(x => x.Id == entity.Id);
        Assert.NotNull(retrieved.someValue);
        Assert.Equal(valueObject.First!.Value, retrieved.someValue.First!.Value);
        Assert.Equal(valueObject.Second!.Value, retrieved.someValue.Second!.Value);
    }

    [Fact]
    public async Task NullableNestedValueObject_NullProp()
    {
        await using MyDbContext ctx = SetupContext();
        EntityS entity = new(Guid.NewGuid());

        await SaveAndClearAsync(entity, ctx);

        EntityS retrieved = ctx.EntitySs.Single(x => x.Id == entity.Id);
        Assert.Null(retrieved.someValue);
    }

    [Fact]
    public async Task NullableNestedValueObject_OneNestedValueIsNull()
    {
        await using MyDbContext ctx = SetupContext();
        EntityS entity = new(Guid.NewGuid());
        NestedValueObjectS1 nested1 = NestedValueObjectS1.Create("Hello world");
        NestedValueObjectS2? nested2 = null; // <<<----
        ValueObjectS valueObject = ValueObjectS.Create(nested1, nested2);

        entity.SetValue(valueObject);

        await SaveAndClearAsync(entity, ctx);

        EntityS retrieved = ctx.EntitySs.Single(x => x.Id == entity.Id);
        Assert.NotNull(retrieved.someValue);
        Assert.Equal(valueObject.First!.Value, retrieved.someValue.First!.Value);
        Assert.Null(retrieved.someValue.Second);
    }

    [Fact]
    public async Task NullableNestedValueObject_OnePropertyOnNestedValueIsNull()
    {
        await using MyDbContext ctx = SetupContext();
        EntityS entity = new(Guid.NewGuid());
        NestedValueObjectS1 nested1 = NestedValueObjectS1.Create("Hello world");
        NestedValueObjectS2 nested2 = NestedValueObjectS2.Create(null); // <<<----
        ValueObjectS valueObject = ValueObjectS.Create(nested1, nested2);

        entity.SetValue(valueObject);

        await SaveAndClearAsync(entity, ctx);

        EntityS retrieved = ctx.EntitySs.Single(x => x.Id == entity.Id);
        Assert.NotNull(retrieved.someValue);
        Assert.Equal(valueObject.First!.Value, retrieved.someValue.First!.Value);
        Assert.Null(retrieved.someValue.Second);
    }

    [Fact]
    public async Task ListOfValueObjects()
    {
        await using MyDbContext ctx = SetupContext();
        EntityT entity = new(Guid.NewGuid());
        ValueObjectT vo1 = ValueObjectT.Create("Hello world");
        ValueObjectT vo2 = ValueObjectT.Create("Hello world2");
        ValueObjectT vo3 = ValueObjectT.Create("Hello world3");

        entity.AddValue(vo1);
        entity.AddValue(vo2);
        entity.AddValue(vo3);

        await SaveAndClearAsync(entity, ctx);

        EntityT retrieved = ctx.EntityTs
            .Single(x => x.Id == entity.Id);

        Assert.NotEmpty(retrieved.someValues);
        Assert.Contains(retrieved.someValues, x => x.Value == vo1.Value);
        Assert.Contains(retrieved.someValues, x => x.Value == vo2.Value);
        Assert.Contains(retrieved.someValues, x => x.Value == vo3.Value);
    }

    [Fact]
    public async Task GuidAsFk_ValidTarget()
    {
        await using MyDbContext ctx = SetupContext();
        EntityV entityV = new(Guid.NewGuid());

        await SaveAndClearAsync(entityV, ctx);

        EntityU entityU = new(Guid.NewGuid());
        entityU.SetEntityVId(entityV.Id);

        await SaveAndClearAsync(entityU, ctx);

        EntityU retrievedU = ctx.EntityUs
            .Single(x => x.Id == entityU.Id);

        EntityV? retrievedV = ctx.EntityVs.SingleOrDefault(x => x.Id == retrievedU.entityVId);
        Assert.NotNull(retrievedV);
    }

    [Fact]
    public async Task GuidAsFk_InValidTarget()
    {
        await using MyDbContext ctx = SetupContext();
        EntityU entityU = new(Guid.NewGuid());
        entityU.SetEntityVId(Guid.NewGuid());
        ctx.EntityUs.Add(entityU);
        Action exp = () => ctx.SaveChanges();

        Exception? exception = Record.Exception(exp);

        Assert.NotNull(exception);
    }

    [Fact]
    public async Task StrongIdAsFk_ValidTarget()
    {
        await using MyDbContext ctx = SetupContext();
        EntityY entityY = new (YId.Create());
        await SaveAndClearAsync(entityY, ctx);

        EntityX entityX = new(Guid.NewGuid());
        entityX.SetFk(entityY.Id);

        await SaveAndClearAsync(entityX, ctx);

        EntityX retrievedX = ctx.EntityXs.Single(x => x.Id == entityX.Id);

        EntityY? retrievedY = ctx.EntityYs
            .SingleOrDefault(y => y.Id == retrievedX.foreignKeyToY);

        Assert.NotNull(retrievedY);
    }

    [Fact]
    public async Task StrongIdAsFk_InvalidTarget()
    {
        await using MyDbContext ctx = SetupContext();
        YId yId = YId.Create();
        EntityX entityX = new(Guid.NewGuid());
        entityX.SetFk(yId);

        ctx.EntityXs.Add(entityX);

        Action exp = () => ctx.SaveChanges();

        Exception? exception = Record.Exception(exp);
        Assert.NotNull(exception);
    }

    [Fact]
    public async Task SingleNestedEntity()
    {
        await using MyDbContext ctx = SetupContext();
        EntityRootA root = new(Guid.NewGuid());
        EntityChildA child = new(Guid.NewGuid());
        root.SetChild(child);

        await SaveAndClearAsync(root, ctx);

        EntityRootA retrievedRoot = ctx.EntityRootAs
            .Include("child")
            .Single(x => x.Id == root.Id);

        Assert.NotNull(retrievedRoot.child);
        Assert.Equal(child.Id, retrievedRoot.child.Id);
    }

    [Fact]
    public async Task MultipleNestedEntities()
    {
        await using MyDbContext ctx = SetupContext();
        EntityRootB root = new(Guid.NewGuid());
        EntityChildB child1 = new(Guid.NewGuid());
        EntityChildB child2 = new(Guid.NewGuid());
        root.AddChild(child1);
        root.AddChild(child2);

        await SaveAndClearAsync(root, ctx);
        
        EntityRootB retrievedRoot = ctx.EntityRootBs
            .Include("children")
            .Single(x => x.Id == root.Id);
        
        Assert.NotEmpty(retrievedRoot.children);
        Assert.Contains(retrievedRoot.children, x => x.Id == child1.Id);
        Assert.Contains(retrievedRoot.children, x => x.Id == child2.Id);
    }
    
    #region Helper methods

    private static MyDbContext SetupContext()
    {
        DbContextOptionsBuilder<MyDbContext> optionsBuilder = new();
        optionsBuilder.UseSqlite(@"Data Source = Test.db");
        MyDbContext context = new(optionsBuilder.Options);
        context.Database.EnsureDeleted();
        context.Database.EnsureCreated();
        return context;
    }

    private static async Task SaveAndClearAsync<T>(T entity, MyDbContext context) where T : class
    {
        await context.Set<T>().AddAsync(entity);
        await context.SaveChangesAsync();
        context.ChangeTracker.Clear();
    }

    #endregion
}