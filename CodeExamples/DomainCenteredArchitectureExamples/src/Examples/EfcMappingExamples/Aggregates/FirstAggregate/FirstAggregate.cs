namespace EfcMappingExamples.Aggregates.FirstAggregate;

public class FirstAggregate
{
    public Guid Id { get; }

    internal string? someStringValue;

    internal MyStringValueObject? firstValueObject;

    public FirstAggregate(Guid id)
    {
        Id = id;
    }

    private FirstAggregate() // for EFC
    {
    }

    public void SetSomeStringValue(string value) => someStringValue = value;

    public void SetFirstVo(MyStringValueObject obj) => firstValueObject = obj;
}