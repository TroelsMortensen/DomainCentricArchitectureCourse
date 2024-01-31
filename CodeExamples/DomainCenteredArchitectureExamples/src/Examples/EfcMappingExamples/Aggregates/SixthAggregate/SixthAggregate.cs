using EfcMappingExamples.Aggregates.Values;

namespace EfcMappingExamples.Aggregates.SixthAggregate;

public class SixthAggregate
{
    public Guid Id { get; private set; }

    internal SecondAggId secondAggregateFk;

    public SixthAggregate(Guid id)
    {
        Id = id;
    }

    public void SetFirstAggregateForeignKey(SecondAggId key) => secondAggregateFk = key;
}