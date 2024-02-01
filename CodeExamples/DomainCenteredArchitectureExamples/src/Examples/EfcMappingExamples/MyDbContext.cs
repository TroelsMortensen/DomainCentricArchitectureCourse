using EfcMappingExamples.Aggregates.FifthAggregate;
using EfcMappingExamples.Aggregates.FirstAggregate;
using EfcMappingExamples.Aggregates.FourthAggregate;
using EfcMappingExamples.Aggregates.SecondAggregate;
using EfcMappingExamples.Aggregates.SixthAggregate;
using EfcMappingExamples.Aggregates.ThirdAggregate;
using EfcMappingExamples.Aggregates.Values;
using Microsoft.EntityFrameworkCore;

namespace EfcMappingExamples;

public class MyDbContext : DbContext
{
    public DbSet<FirstAggregate> FirstAggregates => Set<FirstAggregate>();
    public DbSet<SecondAggregate> SecondAggregates => Set<SecondAggregate>();

    public DbSet<ThirdAggregate> ThirdAggregates => Set<ThirdAggregate>();
    public DbSet<FourthAggregate> FourthAggregates => Set<FourthAggregate>();
    public DbSet<FifthAggregate> FifthAggregates => Set<FifthAggregate>();
    public DbSet<SixthAggregate> SixthAggregates => Set<SixthAggregate>();

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite(@"Data Source = Test.db");
    }

    protected override void OnModelCreating(ModelBuilder mBuilder)
    {
        // ##### FirstAggregate##### 

        ConfigurePkAsGuid(mBuilder);

        ConfigurePrivateFieldPrimitiveType(mBuilder);

        ConfigurePrivateFieldValueObject(mBuilder);

        // ##### SecondAggregate #####

        ConfigureStronglyTypedId(mBuilder);

        ConfigureTwoValuedValueObjectAsComplexType(mBuilder);

        ConfigureTwoValuedValueObjectAsOwnedEntity(mBuilder);

        // ##### ThirdAggregate##### 

        ConfigureEnumWithStringConversion(mBuilder);

        // ##### FourthAggregate##### 

        ConfigureForeignKeyConstraintOfOneToMany(mBuilder);

        // ##### FifthAggregate##### 

        ConfigureForeignKeyConstraintOfOneToOne(mBuilder);

        // ##### SixthAggregate##### 

        ConfigureForeignKeyConstraintOfOneToManyWithStronglyTypedId(mBuilder);
        // It should be simple enough to do the same as above with 1:1
        
        
        
    }

    private void ConfigureForeignKeyConstraintOfOneToManyWithStronglyTypedId(ModelBuilder mBuilder)
    {
        mBuilder.Entity<SixthAggregate>(b =>
            {
                // seems to not be necessary.
                // b.Property<SecondAggId>("secondAggregateFk")
                //     .HasConversion(
                //         id => id.Get, // how to convert ID type to simple value, EFC can understand
                //         value => SecondAggId.FromGuid(value)); // how to convert simple EFC value to strong ID.

                b.Property("secondAggregateFk")
                    .IsRequired();

                b.HasOne<SecondAggregate>()
                    .WithMany()
                    .HasForeignKey("secondAggregateFk");
            }
        );
    }

    private void ConfigureForeignKeyConstraintOfOneToOne(ModelBuilder mBuilder)
    {
        // In this example FourthAggregate references FirstAggregate.
        // Explained here: https://stackoverflow.com/questions/20886049/ef-code-first-foreign-key-without-navigation-property
        mBuilder.Entity<FifthAggregate>(entityTypeBuilder =>
            {
                // not strictly necessary. Can leave out for nullable FK
                entityTypeBuilder.Property("firstAggregateFk")
                    .IsRequired();

                // making this "FirstAggregate 1:1 ThirdAggregate"
                entityTypeBuilder.HasOne<FirstAggregate>()
                    .WithOne()
                    .HasForeignKey<FifthAggregate>("firstAggregateFk");
            }
        );
    }

    private void ConfigureForeignKeyConstraintOfOneToMany(ModelBuilder mBuilder)
    {
        // In this example FourthAggregate references FirstAggregate.
        // Explained here: https://stackoverflow.com/questions/20886049/ef-code-first-foreign-key-without-navigation-property
        mBuilder.Entity<FourthAggregate>(entityTypeBuilder =>
        {
            // not strictly necessary. Can leave out for nullable FK
            entityTypeBuilder.Property("firstAggregateFk")
                .IsRequired();

            // making this "FirstAggregate 1:* ThirdAggregate"
            entityTypeBuilder.HasOne<FirstAggregate>()
                .WithMany()
                .HasForeignKey("firstAggregateFk");
        });
    }

    private static void ConfigureEnumWithStringConversion(ModelBuilder mBuilder)
    {
        // -- Mapping enum with string conversion --
        // https://learn.microsoft.com/en-us/ef/core/modeling/value-conversions?tabs=data-annotations
        // You can define your own conversion, or use a built in. See above link.
        mBuilder.Entity<ThirdAggregate>()
            .Property<Status>("currentStatus") // or instead of string arg, use "x => x.currentStatus", if your Context has access
            .HasConversion(
                status => status.ToString(), // converting the enum value to a string name for database
                value => (Status)Enum.Parse(typeof(Status), value) // converting string from database back to enum
            );
    }

    private static void ConfigureTwoValuedValueObjectAsOwnedEntity(ModelBuilder mBuilder)
    {
        // -- Mapping a two valued Value Object as Owned Entity --
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
                        navBuilder.Property(valueObject => valueObject.Count)
                            .HasColumnName("Count"); // Not strictly necessary. Just renames column
                        navBuilder.Property(valueObject => valueObject.Unit)
                            .HasColumnName("Unit");
                    });
            }
        );

        // closing comment: If you must allow null, use Owned Entity.
        // If the same instance should be allowed in multiple fields of an entity (maybe even different entities), use Complex Type.
    }

    private static void ConfigureTwoValuedValueObjectAsComplexType(ModelBuilder mBuilder)
    {
        // -- mapping a two valued Value Object as Complex Type--
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
                        propertyBuilder.Property(valueObject => valueObject.Amount)
                            .HasColumnName("Amount"); // this just renames the column in the db from "twoValuedValueObject_Amount" to "Amount". Not strictly necessary.
                        propertyBuilder.Property(valueObject => valueObject.Type)
                            .HasColumnName("Type");
                    }
                );
            }
        );
    }

    private static void ConfigureStronglyTypedId(ModelBuilder mBuilder)
    {
        // -- mapping strongly typed ID --
        mBuilder.Entity<SecondAggregate>()
            .HasKey(m => m.Id);
        mBuilder.Entity<SecondAggregate>() // here we define the conversion for the ID
            .Property(m => m.Id)
            .HasConversion(
                id => id.Get, // how to convert ID type to simple value, EFC can understand
                value => SecondAggId.FromGuid(value)); // how to convert simple EFC value to strong ID.
    }

    private static void ConfigurePrivateFieldValueObject(ModelBuilder mBuilder)
    {
        // -- Mapping private field Value Object --
        mBuilder.Entity<FirstAggregate>()
            .OwnsOne<MyStringValueObject>("firstValueObject")
            .Property(vo => vo.Value); // specifying the value from the Value Object to EFC.
    }

    private static void ConfigurePrivateFieldPrimitiveType(ModelBuilder mBuilder)
    {
        // -- Mapping private field primitive type --
        mBuilder.Entity<FirstAggregate>()
            .Property<string>("someStringValue");
    }

    private static void ConfigurePkAsGuid(ModelBuilder mBuilder)
    {
        // -- Mapping simple ID of type Guid --
        mBuilder.Entity<FirstAggregate>()
            .HasKey(m => m.Id);

        mBuilder.Entity<ThirdAggregate>()
            .HasKey(m => m.Id);
    }
}