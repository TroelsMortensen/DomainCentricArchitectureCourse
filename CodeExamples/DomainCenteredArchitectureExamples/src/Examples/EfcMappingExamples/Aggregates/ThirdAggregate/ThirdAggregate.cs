using EfcMappingExamples.Aggregates.Values;

namespace EfcMappingExamples.Aggregates.ThirdAggregate;

public class ThirdAggregate
{
    public Guid Id { get; private set; } // if this has private set, EFC will discover it as Id. If no private set, it must be configured, and must have private constructor

    internal Status currentStatus;

    internal int someNumber = 42;

    internal SecondAggId? secondAggregateFk;

    internal SomeEntity? nestedEntity;

    public ThirdAggregate(Guid id)
    {
        Id = id;
        currentStatus = Status.Draft;
    }

    public void SetStatus(Status status) => currentStatus = status;

    public void SetSecondAggFk(SecondAggId id) => secondAggregateFk = id;

    public void SetNestedEntity(SomeEntity ent) => nestedEntity = ent;
}

public enum Status
{
    Draft = 0,
    Validated = 1,
    Active = 2,
    SoftDeleted = 3
}