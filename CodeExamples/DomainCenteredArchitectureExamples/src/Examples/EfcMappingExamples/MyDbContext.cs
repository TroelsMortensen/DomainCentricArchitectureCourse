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
            .OwnsOne<MyStringValueObject>("firstValueObject").Property(vo => vo.Value);


        // ### SecondAggregate ###

        // mapping strongly typed ID
        mBuilder.Entity<SecondAggregate>()
            .HasKey(m => m.Id);
        mBuilder.Entity<SecondAggregate>() // here we define the conversion for the ID
            .Property(m => m.Id)
            .HasConversion(
                id => id.Get,
                value => MyId.FromGuid(value));

        // mapping a two valued Value Object
    }
}