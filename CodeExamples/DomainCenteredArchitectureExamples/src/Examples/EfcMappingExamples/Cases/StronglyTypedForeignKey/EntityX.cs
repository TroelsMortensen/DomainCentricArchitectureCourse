namespace EfcMappingExamples.Cases.StronglyTypedForeignKey;

public class EntityX
{
    public Guid Id { get; }

    internal YId foreignKeyToY;

    public EntityX(Guid id)
    {
        Id = id;
    }

    public void SetFk(YId id) => foreignKeyToY = id;
}