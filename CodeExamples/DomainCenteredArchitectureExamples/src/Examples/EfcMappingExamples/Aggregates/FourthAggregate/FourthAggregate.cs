namespace EfcMappingExamples.Aggregates.FourthAggregate;

public class FourthAggregate
{
    public Guid Id { get; private set; }

    internal Guid firstAggregateFk;

    public FourthAggregate(Guid id)
    {
        Id = id;
    }

    public void SetFirstAggregateForeignKey(Guid key) => firstAggregateFk = key;
}