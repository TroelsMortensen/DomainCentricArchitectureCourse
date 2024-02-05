using EfcMappingExamples.Aggregates.FirstAggregate;
using EfcMappingExamples.Aggregates.ThirdAggregate;

namespace EfcMappingExamples.Aggregates.SeventhAggregate;

public class SeventhAggregate
{
    public Guid Id { get; }

    internal List<SomeEntity> nestedEntities;
    internal List<MyStringValueObject> values;

    public SeventhAggregate(Guid id)
    {
        Id = id;
        nestedEntities = new();
        values = new();
    }

    private SeventhAggregate()
    {
    }

    public void AddEntity(SomeEntity ent) => nestedEntities.Add(ent);
    public void AddValues(params MyStringValueObject[] vals) => values.AddRange(vals);
}