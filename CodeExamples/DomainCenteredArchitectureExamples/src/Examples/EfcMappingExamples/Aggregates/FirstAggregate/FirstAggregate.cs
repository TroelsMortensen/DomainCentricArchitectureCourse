namespace EfcMappingExamples.Aggregates.FirstAggregate;

public class FirstAggregate
{
    public Guid Id { get;  }

    public FirstAggregate(Guid id)
    {
        Id = id;
    }

    private FirstAggregate()
    {
        
    }
}