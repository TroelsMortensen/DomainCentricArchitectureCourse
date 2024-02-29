namespace EfcMappingExamples.Cases.StronglyTypedForeignKey;

public class EntityY
{
    public YId Id { get; }

    public EntityY(YId id) => Id = id;
}

public class YId
{
    public Guid Value { get; }

    public static YId Create()
        => new(Guid.NewGuid());

    public static YId FromGuid(Guid guid)
        => new(guid);

    private YId(Guid guid)
        => Value = guid;
}