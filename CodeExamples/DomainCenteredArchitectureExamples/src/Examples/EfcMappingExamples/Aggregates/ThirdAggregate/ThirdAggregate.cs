namespace EfcMappingExamples.Aggregates.ThirdAggregate;

public class ThirdAggregate
{
    public Guid Id { get; private set; }

    internal Status currentStatus;

    public ThirdAggregate(Guid id)
    {
        Id = id;
        currentStatus = Status.Draft;
    }

    public void SetStatus(Status status) => currentStatus = status;
}

public enum Status
{
    Draft = 0,
    Validated = 1,
    Active = 2,
    SoftDeleted = 3
}