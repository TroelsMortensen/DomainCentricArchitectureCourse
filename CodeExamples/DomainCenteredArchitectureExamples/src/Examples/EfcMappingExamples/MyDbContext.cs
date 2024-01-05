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
        // FirstAggregate
        mBuilder.Entity<FirstAggregate>(builder =>
            {
                builder.HasKey(m => m.Id); // setting primary key
                builder.Property<string>("someStringValue"); // mapping private field
            }
        );

        
        // SecondAggregate
        mBuilder.Entity<SecondAggregate>()
            .HasKey(m => m.Id);
        mBuilder.Entity<SecondAggregate>()
            .Property(m => m.Id)
            .HasConversion(
                id => id.Get,
                value => MyId.FromGuid(value));
    }
}