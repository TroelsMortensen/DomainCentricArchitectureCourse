using EfcMappingExamples.Cases.NestedValueObjects;

namespace EfcMappingExamples.Cases.ListOfNestedValueObjects;

public class EntityK
{
    public Guid Id { get; }

    internal List<TopValueObject> values = new();
    
    public EntityK(Guid id)
    {
        Id = id;
    }

    public void AddValues(params TopValueObject[] vs) => values.AddRange(vs);

    private EntityK()
    {
        // EFC
    }
}