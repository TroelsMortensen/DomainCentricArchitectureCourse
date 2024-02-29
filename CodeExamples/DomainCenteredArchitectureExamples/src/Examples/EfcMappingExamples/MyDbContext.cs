using EfcMappingExamples.Aggregates.FifthAggregate;
using EfcMappingExamples.Aggregates.FirstAggregate;
using EfcMappingExamples.Aggregates.FourthAggregate;
using EfcMappingExamples.Aggregates.SecondAggregate;
using EfcMappingExamples.Aggregates.SeventhAggregate;
using EfcMappingExamples.Aggregates.SixthAggregate;
using EfcMappingExamples.Aggregates.ThirdAggregate;
using EfcMappingExamples.Aggregates.Values;
using EfcMappingExamples.Cases.AHasListOfGuidsReferencingB;
using EfcMappingExamples.Cases.CHasListOfStrongIdReferencingD;
using EfcMappingExamples.Cases.ClassAsEnum;
using EfcMappingExamples.Cases.EHasListOfMultiValuedValueObjects;
using EfcMappingExamples.Cases.GuidAsFk;
using EfcMappingExamples.Cases.GuidAsPk;
using EfcMappingExamples.Cases.ListOfGuidForeignKeys;
using EfcMappingExamples.Cases.ListOfNestedValueObjects;
using EfcMappingExamples.Cases.ListOfValueObjects;
using EfcMappingExamples.Cases.NestedValueObjects;
using EfcMappingExamples.Cases.NonNullableMultiValuedValueObject;
using EfcMappingExamples.Cases.NonNullableNestedValueObjects;
using EfcMappingExamples.Cases.NonNullableSingleValuedValueObject;
using EfcMappingExamples.Cases.NullableMultiValuedValueObject;
using EfcMappingExamples.Cases.NullableNestedValueObjects;
using EfcMappingExamples.Cases.NullableSingleValuedValueObject;
using EfcMappingExamples.Cases.StronglyTypedForeignKey;
using EfcMappingExamples.Cases.StronglyTypedId;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EfcMappingExamples;

public class MyDbContext(DbContextOptions<MyDbContext> options) : DbContext(options)
{
    public DbSet<FirstAggregate> FirstAggregates => Set<FirstAggregate>();
    public DbSet<SecondAggregate> SecondAggregates => Set<SecondAggregate>();

    public DbSet<ThirdAggregate> ThirdAggregates => Set<ThirdAggregate>();
    public DbSet<FourthAggregate> FourthAggregates => Set<FourthAggregate>();
    public DbSet<FifthAggregate> FifthAggregates => Set<FifthAggregate>();
    public DbSet<SixthAggregate> SixthAggregates => Set<SixthAggregate>();
    public DbSet<SeventhAggregate> SeventhAggregates => Set<SeventhAggregate>();

    public DbSet<EntityA> EntityAs => Set<EntityA>();
    public DbSet<EntityB> EntityBs => Set<EntityB>();
    public DbSet<EntityC> EntityCs => Set<EntityC>();
    public DbSet<EntityD> EntityDs => Set<EntityD>();
    public DbSet<EntityE> EntityEs => Set<EntityE>();
    public DbSet<EntityH> EntityHs => Set<EntityH>();
    public DbSet<EntityJ> EntityJs => Set<EntityJ>();
    public DbSet<EntityK> EntityKs => Set<EntityK>();
    public DbSet<EntityL> EntityLs => Set<EntityL>();
    public DbSet<EntityM> EntityMs => Set<EntityM>();
    public DbSet<EntityN> EntityNs => Set<EntityN>();
    public DbSet<EntityO> EntityOs => Set<EntityO>();
    public DbSet<EntityP> EntityPs => Set<EntityP>();
    public DbSet<EntityQ> EntityQs => Set<EntityQ>();
    public DbSet<EntityR> EntityRs => Set<EntityR>();
    public DbSet<EntityS> EntitySs => Set<EntityS>();
    public DbSet<EntityT> EntityTs => Set<EntityT>();
    public DbSet<EntityU> EntityUs => Set<EntityU>();
    public DbSet<EntityV> EntityVs => Set<EntityV>();
    public DbSet<EntityY> EntityYs => Set<EntityY>();
    public DbSet<EntityX> EntityXs => Set<EntityX>();
    public DbSet<Entity1> Entity1s => Set<Entity1>();
    public DbSet<Entity2> Entity2s => Set<Entity2>();


    public MyDbContext() : this(new DbContextOptions<MyDbContext>())
    {
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            optionsBuilder.UseSqlite(@"Data Source = Test.db");
        }
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

        ConfigureSingleNestedEntityWithStrongParentId(mBuilder);

        ConfigureManyNestedEntitiesWithStrongParentId(mBuilder);

        // ##### ThirdAggregate##### 

        ConfigureEnumWithStringConversion(mBuilder);

        ConfigureForeignKeyConstraintOfOneToOneWithStronglyTypedId(mBuilder);

        ConfigureSingleNestedEntity(mBuilder);

        // ##### FourthAggregate##### 

        ConfigureForeignKeyConstraintOfOneToMany(mBuilder);

        // ##### FifthAggregate##### 

        ConfigureForeignKeyConstraintOfOneToOne(mBuilder);

        // ##### SixthAggregate##### 

        ConfigureForeignKeyConstraintOfOneToManyWithStronglyTypedId(mBuilder);
        // It should be simple enough to do the same as above with 1:1. Did I do this?

        // ##### SeventhAggregate##### 
        ConfigureManyNestedEntitiesWithGuids(mBuilder);

        ConfigureListValueObjectsOnSeventhAgg(mBuilder);

        // ##### Cases ######
        ConfigureAHasListOfGuidsReferencingB(mBuilder);

        ConfigureCHasListOfStrongFksReferencingDUsingWrapper(mBuilder);

        ConfigureFHasListOfStrongFksReferencingGByAmichai(mBuilder);

        ConfigureEHasListOfMultiValuedValueObjects(mBuilder);

        ConfigureEnumAsClass(mBuilder);

        ConfigureSingleNestedValueObjects(mBuilder);

        ConfigureListOfNestedValueObjects(mBuilder);

        ConfigureGuidAsPk(mBuilder.Entity<EntityL>());

        ConfigureStronglyTypedId(mBuilder.Entity<EntityM>());

        ConfigureNonNullableSinglePrimitiveValuedValueObject(mBuilder.Entity<EntityN>());

        ConfigureNullableSinglePrimitiveValuedValueObject(mBuilder.Entity<EntityO>());

        ConfigureNonNullableMultiPrimitiveValuedValueObject(mBuilder.Entity<EntityP>());

        ConfigureNullableMultiPrimitiveValuedValueObject(mBuilder.Entity<EntityQ>());

        ConfigureNonNullableNestedValueObjects(mBuilder.Entity<EntityR>());

        ConfigureNullableNestedValueObjects(mBuilder.Entity<EntityS>());

        ConfigureListValueObjects(mBuilder.Entity<EntityT>());

        ConfigureGuidAsFk(mBuilder.Entity<EntityU>(), mBuilder.Entity<EntityV>());

        ConfigureStronglyTypedFk(mBuilder.Entity<EntityX>(), mBuilder.Entity<EntityY>());
        
        ConfigureListOfGuidsAsFks(mBuilder.Entity<Entity1>(), mBuilder.Entity<Entity2>());
    }

    private void ConfigureListOfGuidsAsFks(EntityTypeBuilder<Entity1> entityBuilder1, EntityTypeBuilder<Entity2> entityBuilder2)
    { 
        
    }

    private void ConfigureStronglyTypedFk(EntityTypeBuilder<EntityX> entityBuilderX, EntityTypeBuilder<EntityY> entityBuilderY)
    {
        entityBuilderX.HasKey(x => x.Id);

        entityBuilderY.HasKey(y => y.Id);
        entityBuilderY.Property(y => y.Id)
            .HasConversion(
                yId => yId.Value,
                dbValue => YId.FromGuid(dbValue)
            );

        entityBuilderX.HasOne<EntityY>()
            .WithMany()
            .HasForeignKey("foreignKeyToY");
    }

    private void ConfigureGuidAsFk(EntityTypeBuilder<EntityU> entityUBuilder, EntityTypeBuilder<EntityV> entityVBuilder)
    {
        entityUBuilder.HasKey(x => x.Id);
        entityVBuilder.HasKey(x => x.Id);

        entityUBuilder.Property<Guid>("entityVId");

        entityUBuilder.HasOne<EntityV>()
            .WithMany()
            .HasForeignKey("entityVId");
    }

    private void ConfigureListValueObjects(EntityTypeBuilder<EntityT> entityBuilder)
    {
        entityBuilder.HasKey(x => x.Id);

        entityBuilder.OwnsMany<ValueObjectT>("someValues", vob =>
        {
            vob.Property<int>("Id").ValueGeneratedOnAdd();
            vob.HasKey("Id");
            vob.Property(x => x.Value);
        });
    }

    private void ConfigureNullableNestedValueObjects(EntityTypeBuilder<EntityS> entityBuilder)
    {
        entityBuilder.HasKey(x => x.Id);

        entityBuilder.OwnsOne<ValueObjectS>("someValue", ownedNavigationBuilder =>
        {
            ownedNavigationBuilder.ToTable("ValueObjectS");

            ownedNavigationBuilder.OwnsOne<NestedValueObjectS1>("First", fvo =>
            {
                fvo.Property(x => x.Value)
                    .HasColumnName("First");
            });
            ownedNavigationBuilder.OwnsOne<NestedValueObjectS2>("Second", svo =>
            {
                svo.Property(x => x.Value)
                    .HasColumnName("Second");
            });
        });

        entityBuilder.Navigation("someValue");
    }

    private void ConfigureNonNullableNestedValueObjects(EntityTypeBuilder<EntityR> entityBuilder)
    {
        entityBuilder.HasKey(x => x.Id);

        entityBuilder.ComplexProperty<ValueObjectR>("someValue", propBuilder =>
        {
            propBuilder.ComplexProperty(x => x.First)
                .Property(x => x.Value)
                .HasColumnName("First");

            propBuilder.ComplexProperty(x => x.Second)
                .Property(x => x.Value)
                .HasColumnName("Second");
        });
    }

    private void ConfigureNullableMultiPrimitiveValuedValueObject(EntityTypeBuilder<EntityQ> entityBuilder)
    {
        entityBuilder.HasKey(x => x.Id);

        entityBuilder.OwnsOne<ValueObjectQ>("someValue", ownedNavigationBuilder =>
        {
            ownedNavigationBuilder.Property(valueObject => valueObject.First)
                .HasColumnName("First");

            ownedNavigationBuilder.Property(valueObjectP => valueObjectP.Second)
                .HasColumnName("Second");
        });
    }

    private void ConfigureNonNullableMultiPrimitiveValuedValueObject(EntityTypeBuilder<EntityP> entityBuilder)
    {
        entityBuilder.HasKey(x => x.Id);

        entityBuilder.ComplexProperty<ValueObjectP>("someValue", propBuilder =>
        {
            propBuilder.Property(valueObject => valueObject.First)
                .HasColumnName("First");

            propBuilder.Property(valueObjectP => valueObjectP.Second)
                .HasColumnName("Second");
        });
    }

    private void ConfigureNullableSinglePrimitiveValuedValueObject(EntityTypeBuilder<EntityO> entityBuilder)
    {
        entityBuilder.HasKey(x => x.Id);

        entityBuilder
            .OwnsOne<ValueObjectO>("someValue")
            .Property(vo => vo.Value)
            .HasColumnName("value");
    }

    private void ConfigureNonNullableSinglePrimitiveValuedValueObject(EntityTypeBuilder<EntityN> entityBuilder)
    {
        entityBuilder.HasKey(x => x.Id);

        entityBuilder.ComplexProperty<ValueObjectN>(
            "someValue",
            propBuilder =>
            {
                propBuilder.Property(vo => vo.Value)
                    .HasColumnName("value");
            }
        );
    }

    private void ConfigureStronglyTypedId(EntityTypeBuilder<EntityM> entityBuilder)
    {
        entityBuilder.HasKey(x => x.Id);

        entityBuilder
            .Property(m => m.Id)
            .HasConversion(
                mId => mId.Value,
                dbValue => MId.FromGuid(dbValue)
            );
    }

    private void ConfigureGuidAsPk(EntityTypeBuilder<EntityL> entityBuilder)
    {
        entityBuilder.HasKey(entity => entity.Id);
    }

    private void ConfigureListOfNestedValueObjects(ModelBuilder mBuilder)
    {
        mBuilder.Entity<EntityK>(b =>
        {
            b.HasKey(x => x.Id);

            b.OwnsMany<TopValueObject>("values", vob =>
            {
                vob.Property<int>("Id").ValueGeneratedOnAdd();
                vob.HasKey("Id");
                vob.OwnsOne<FirstNestedVO>("First", fvo =>
                {
                    fvo.Property(x => x.Stuff);
                    fvo.Property(x => x.Number);
                });
                vob.OwnsOne<SecondNestedVO>("Second", svo => { svo.Property(x => x.Type); });
            });
        });
    }

    // https://learn.microsoft.com/en-us/ef/core/modeling/owned-entities
    private void ConfigureSingleNestedValueObjects(ModelBuilder mBuilder)
    {
        // cannot have nullable?
        mBuilder.Entity<EntityJ>(b =>
        {
            b.HasKey(x => x.Id);
            b.OwnsOne<TopValueObject>("myValue", vob =>
            {
                vob.ToTable("TopValueObjects"); // include this line, if the Value Object must be nullable.

                vob.OwnsOne<FirstNestedVO>("First", fvo =>
                {
                    fvo.Property(x => x.Stuff);
                    fvo.Property(x => x.Number);
                });
                vob.OwnsOne<SecondNestedVO>("Second", svo => { svo.Property(x => x.Type); });
            });
            b.Navigation("myValue"); // add is .required(), if this value is required. Otherwise this line can be deleted.
        });
    }

    private void ConfigureEnumAsClass(ModelBuilder mBuilder)
    {
        mBuilder.Entity<EntityH>(b =>
        {
            b.HasKey(x => x.Id);
            b.OwnsOne<MyStatusEnum>("status", e => { e.Property("backingValue").HasColumnName("status"); });
        });
    }

    private void ConfigureFHasListOfStrongFksReferencingGByAmichai(ModelBuilder mBuilder)
    {
        // This doesn't work. I do not get FK constraints in both directions.

        // I end up having to define an FK on MenuId, but this class is itself the FK.

        // mBuilder.Entity<EntityMenu>(b =>
        // {
        //     b.HasKey(menu => menu.Id);
        //     b.Property(menu => menu.Id)
        //         .ValueGeneratedNever()
        //         .HasConversion(
        //             id => id.Value,
        //             value => MenuId.Create(value)
        //         );
        // });
        //
        // mBuilder.Entity<EntityHost>(b =>
        // {
        //     b.HasKey(host => host.Id);
        //     b.Property(host => host.Id)
        //         .HasConversion(
        //             id => id.Value,
        //             value => HostId.Create(value)
        //         );
        //
        //     b.OwnsMany<MenuId>("menuIds", mib =>
        //     {
        //         mib.ToTable("HostMenuIds");
        //         mib.HasKey("Id");
        //         mib.Property(x => x.Value)
        //             .HasColumnName("EntityMenuId");
        //        
        //         // lastly, create reference to EntityMenu
        //         mib.HasOne<EntityMenu>()
        //             .WithMany()
        //             .HasForeignKey("HostMenuFk");
        //     });
        // });
    }

    private void ConfigureEHasListOfMultiValuedValueObjects(ModelBuilder mBuilder)
    {
        mBuilder.Entity<EntityE>(b =>
        {
            b.HasKey(x => x.Id);
            b.OwnsMany<ValueObjectE>("values", vob =>
            {
                vob.Property<int>("Pk").ValueGeneratedOnAdd();
                vob.HasKey("Pk");
                vob.Property(vo => vo.FirstValue);
                vob.Property(vo => vo.SecondValue);
            });
        });
    }

    private void ConfigureCHasListOfStrongFksReferencingDUsingWrapper(ModelBuilder mBuilder)
    {
        // First Ids on both
        mBuilder.Entity<EntityC>().HasKey(x => x.Id);
        mBuilder.Entity<EntityD>().HasKey(x => x.Id);


        // Then the conversion from strong ID to simple type
        mBuilder.Entity<EntityD>() // here we define the conversion for the ID
            .Property(m => m.Id)
            .HasConversion(
                id => id.Value, // how to convert ID type to simple value, EFC can understand
                value => StrongIdForEntityD.FromGuid(value)); // how to convert simple EFC value to strong ID.

        // Now we configure the join table
        mBuilder.Entity<ReferenceFromCtoD>(x =>
        {
            x.Property<Guid>("FkBackToC");
            x.HasKey("FkBackToC", "FkToD");
            x.HasOne<EntityC>()
                .WithMany("foreignKeysToD")
                .HasForeignKey("FkBackToC");

            x.Property(m => m.FkToD)
                .HasConversion(
                    id => id.Value, // how to convert ID type to simple value, EFC can understand
                    value => StrongIdForEntityD.FromGuid(value)); // how to convert simple EFC value to strong ID.

            x.HasOne<EntityD>()
                .WithMany()
                .HasForeignKey(y => y.FkToD);
        });
    }

    private void ConfigureAHasListOfGuidsReferencingB(ModelBuilder mBuilder)
    {
        // Could not find solution with non-reference type Guid.
        // I introduce a wrapper, value object like class, but it can be simpler.
        // A similar approach will be used for list of strong Id, I guess.
        mBuilder.Entity<EntityA>().HasKey("Id");
        mBuilder.Entity<EntityB>().HasKey("Id");

        mBuilder.Entity<EntityBFk>().Property<Guid>("parentIdFk");
        mBuilder.Entity<EntityBFk>().HasKey("parentIdFk", "FkToB");

        mBuilder.Entity<EntityA>()
            .HasMany<EntityBFk>("foreignKeysToB")
            .WithOne()
            .HasForeignKey("parentIdFk")
            .OnDelete(DeleteBehavior.Cascade);

        mBuilder.Entity<EntityBFk>()
            .HasOne<EntityB>()
            .WithMany()
            .HasForeignKey(x => x.FkToB);

        // TODO can I do this with list of complex type?
    }


    private void ConfigureManyNestedEntitiesWithStrongParentId(ModelBuilder mBuilder)
    {
        mBuilder.Entity<OtherEntity>().HasKey(x => x.Id);

        // map like one to many
        mBuilder.Entity<SecondAggregate>() // start with SecondAggregate
            .HasMany<OtherEntity>("nestedEntities") // Say it has a * relationship to OtherEntity
            .WithOne() // and the other side is 1
            .HasForeignKey("secondParentId"); // and the foreign key is defined on the child, i.e. OtherEntity.
    }

    private void ConfigureSingleNestedEntityWithStrongParentId(ModelBuilder mBuilder)
    {
        mBuilder.Entity<SecondAggregate>()
            .HasOne<SomeEntity>("nestedEntity")
            .WithOne()
            .HasForeignKey<SomeEntity>("secondParentId");
    }

    private void ConfigureManyNestedEntitiesWithGuids(ModelBuilder mBuilder)
    {
        // map like one to many
        mBuilder.Entity<SomeEntity>() // start with SomeEntity
            .HasOne<SeventhAggregate>() // Say it has a 1 relationship to ThirdAggregate
            .WithMany("nestedEntities") // and the other side is many
            .HasForeignKey(
                "seventhParentId"); // and the foreign key is defined on the child, i.e. EntityInThird. It's a shadow prop, called parentId. I.e. it does not exist, but EFC should create it.
    }

    private void ConfigureSingleNestedEntity(ModelBuilder mBuilder)
    {
        mBuilder.Entity<SomeEntity>().HasKey(e => e.Id);

        // map like one to one
        mBuilder.Entity<SomeEntity>() // start with SomeEntity
            .HasOne<ThirdAggregate>() // Say it has a 1 relationship to ThirdAggregate
            .WithOne("nestedEntity") // and the other side is also 1
            .HasForeignKey<
                SomeEntity>("thirdParentId"); // and the foreign key is defined on the child, i.e. EntityInThird. It's a shadow prop, called parentId. I.e. it does not exist, but EFC should create it.
    }

    private void ConfigureForeignKeyConstraintOfOneToOneWithStronglyTypedId(ModelBuilder mBuilder)
    {
        mBuilder.Entity<ThirdAggregate>(b =>
        {
            b.HasOne<SecondAggregate>()
                .WithOne()
                .HasForeignKey<ThirdAggregate>("secondAggregateFk");
        });
    }

    private void ConfigureForeignKeyConstraintOfOneToManyWithStronglyTypedId(ModelBuilder mBuilder)
    {
        // Here FK is added to many side, so each entity has an fk to parent.
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
        // If the same value object instance should be allowed in multiple fields of an entity (maybe even different entities), use Complex Type.
    }

    private static void ConfigureTwoValuedValueObjectAsComplexType(ModelBuilder mBuilder)
    {
        // -- mapping a two valued Value Object as Complex Type--
        // inconveniently, this property cannot be nullable. DaFuq!? And I can't have lists of this type. 
        // It's a half-baked feature. Not super useful for now..
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
                            .HasColumnName(
                                "Amount"); // this just renames the column in the db from "twoValuedValueObject_Amount" to "Amount". Not strictly necessary.
                        propertyBuilder.Property(valueObject => valueObject.Type)
                            .HasColumnName("Type");
                    }
                );
            }
        );
    }

    private void ConfigureListValueObjectsOnSeventhAgg(ModelBuilder mBuilder)
    {
        mBuilder.Entity<SeventhAggregate>()
            .OwnsMany<MyStringValueObject>("values", vo =>
            {
                vo.HasKey("SeventhAggregateId", "Value"); // making composite key af value and fk back to parent
                vo.Property<Guid>("SeventhAggregateId"); // adding shadow property. This works because of naming convention...?
                vo.Property<string>("Value");
            });


        // mBuilder.Entity<SeventhAggregate>()
        // .OwnsMany<MyStringValueObject>("values")
        // .Property(vo => vo.Value);
        // mBuilder.Entity<SecondAggregate>(b =>
        // {
        //     b.
        // });
        // throw new NotImplementedException();
        // Læs her om collection:
        // https://thehonestcoder.com/ddd-ef-core-8/
        // afsnit: "Storing Value Object Collections"
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

        // more about value conversions: https://learn.microsoft.com/en-us/ef/core/modeling/value-conversions?tabs=data-annotations
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

        mBuilder.Entity<SeventhAggregate>()
            .HasKey(x => x.Id);
    }
}