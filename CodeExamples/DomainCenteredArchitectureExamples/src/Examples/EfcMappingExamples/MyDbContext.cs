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
        // ### FirstAggregate### 

        // Mapping simple ID of type Guid
        mBuilder.Entity<FirstAggregate>()
            .HasKey(m => m.Id);

        // Mapping private field primitive type
        mBuilder.Entity<FirstAggregate>()
            .Property<string>("someStringValue");

        // Mapping private field Value Object
        mBuilder.Entity<FirstAggregate>()
            .OwnsOne<MyStringValueObject>("firstValueObject")
            .Property(vo => vo.Value); // specifying the value from the Value Object to EFC.


        // ### SecondAggregate ###

        // mapping strongly typed ID
        mBuilder.Entity<SecondAggregate>()
            .HasKey(m => m.Id);
        mBuilder.Entity<SecondAggregate>() // here we define the conversion for the ID
            .Property(m => m.Id)
            .HasConversion(
                id => id.Get, // how to convert ID type to simple value, EFC can understand
                value => MyId.FromGuid(value)); // how to convert simple EFC value to strong ID.


        // mapping a two valued Value Object
        // inconveniently, this property cannot be nullable. DaFuq!?
        // https://github.com/dotnet/efcore/issues/31376
        // Maybe alternative? https://learn.microsoft.com/en-us/ef/core/modeling/owned-entities
        // though also with limits.
        mBuilder.Entity<SecondAggregate>(entityBuilder =>
            {
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
    }
}