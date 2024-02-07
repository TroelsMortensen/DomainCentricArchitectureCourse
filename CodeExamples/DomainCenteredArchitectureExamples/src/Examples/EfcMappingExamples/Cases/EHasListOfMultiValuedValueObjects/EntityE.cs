namespace EfcMappingExamples.Cases.EHasListOfMultiValuedValueObjects;

public class EntityE
{
    public Guid Id { get; }

    internal List<ValueObjectE> values = new();
    
    public EntityE(Guid id)
    {
        Id = id;
    }

    public void AddValues(params ValueObjectE[] vals) => values.AddRange(vals);

    private EntityE() // EFC
    {
    }
}