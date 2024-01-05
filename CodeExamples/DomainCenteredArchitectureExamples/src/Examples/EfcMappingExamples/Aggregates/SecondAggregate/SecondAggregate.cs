using EfcMappingExamples.Aggregates.Values;

namespace EfcMappingExamples.Aggregates.SecondAggregate;

public class SecondAggregate
{
    public MyId Id { get; private set; }

    public SecondAggregate(MyId id)
    {
        Id = id;
    }
    
    
}