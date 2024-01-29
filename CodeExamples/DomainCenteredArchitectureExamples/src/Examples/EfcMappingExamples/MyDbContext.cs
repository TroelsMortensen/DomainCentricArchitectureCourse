using EfcMappingExamples.Aggregates.FirstAggregate;
using EfcMappingExamples.Aggregates.SecondAggregate;
using EfcMappingExamples.Aggregates.Values;
using Microsoft.EntityFrameworkCore;

namespace EfcMappingExamples;

public class MyDbContext : DbContext
{
    public DbSet<FirstAggregate> FirstAggregates => Set<FirstAggregate>();
    public DbSet<SecondAggregate> SecondAggregates => Set<SecondAggregate>();

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite(@"Data Source = Test.db");
    }

    protected override void OnModelCreating(ModelBuilder mBuilder)
    {
        // ##### FirstAggregate##### 

        // -- Mapping simple ID of type Guid --
        mBuilder.Entity<FirstAggregate>()
            .HasKey(m => m.Id);

        // -- Mapping private field primitive type --
        mBuilder.Entity<FirstAggregate>()
            .Property<string>("someStringValue");

        // -- Mapping private field Value Object --
        mBuilder.Entity<FirstAggregate>()
            .OwnsOne<MyStringValueObject>("firstValueObject")
            .Property(vo => vo.Value); // specifying the value from the Value Object to EFC.


        // ##### SecondAggregate #####

        // -- mapping strongly typed ID --
        mBuilder.Entity<SecondAggregate>()
            .HasKey(m => m.Id);
        mBuilder.Entity<SecondAggregate>() // here we define the conversion for the ID
            .Property(m => m.Id)
            .HasConversion(
                id => id.Get, // how to convert ID type to simple value, EFC can understand
                value => MyId.FromGuid(value)); // how to convert simple EFC value to strong ID.


        // -- mapping a two valued Value Object --
        // inconveniently, this property cannot be nullable. DaFuq!?
        // https://github.com/dotnet/efcore/issues/31376
        // Maybe alternative? https://learn.microsoft.com/en-us/ef/core/modeling/owned-entities
        // though also with limits.
        // MOre here https://devblogs.microsoft.com/dotnet/announcing-ef8-rc1/
        mBuilder.Entity<SecondAggregate>(entityBuilder =>
            {
                // if you add a private set; to your properties in the Value Object, you can do with the following line:
                // entityBuilder.ComplexProperty(agg => agg.twoValuedValueObject); 

                // If you don't have a private set; you must be explicit, like the following.
                entityBuilder.ComplexProperty<TwoPropsValueObject>(
                    // can also give it a string for the field name
                    aggregate => aggregate.twoValuedValueObject, propertyBuilder =>
                    {
                        propertyBuilder.Property(valueObject => valueObject.Amount);
                        propertyBuilder.Property(valueObject => valueObject.Type);
                    }
                );
            }
        );

        // -- Mapping a two valued Value Object as owned entity --
        // Alternative way to map a multi valued Value Object. You need private setters for your properties, though.
        // https://learn.microsoft.com/en-us/dotnet/architecture/microservices/microservice-ddd-cqrs-patterns/implement-value-objects

        // You can use the below two lines if you have private set; properties for each property. Alternatively see below
        // mBuilder.Entity<SecondAggregate>()
        // .OwnsOne<OtherTwoPropsValueObject>("otherTwoValuedValueObject");

        // This approach does not require a private set; property. 
        mBuilder.Entity<SecondAggregate>(entityBuilder =>
            {
                entityBuilder.OwnsOne<OtherTwoPropsValueObject>(
                    aggregate => aggregate.otherTwoValuedValueObject,
                    navBuilder =>
                    {
                        navBuilder.Property(valueObject => valueObject.Count);
                        navBuilder.Property(valueObject => valueObject.Unit);
                    });
            }
        );
    }
}