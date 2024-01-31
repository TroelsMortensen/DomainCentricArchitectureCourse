namespace EfcMappingExamples.Aggregates.FifthAggregate;

public class FifthAggregate
{
    public Guid Id { get; private set; }

    internal Guid firstAggregateFk;

    public FifthAggregate(Guid id)
    {
        Id = id;
    }

    public void SetFirstAggregateForeignKey(Guid key) => firstAggregateFk = key;
}