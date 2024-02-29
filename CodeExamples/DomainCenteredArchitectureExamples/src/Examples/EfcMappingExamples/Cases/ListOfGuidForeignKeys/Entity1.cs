namespace EfcMappingExamples.Cases.ListOfGuidForeignKeys;

public class Entity1
{
    public Guid Id { get; }

    internal List<Entity2ForeignKey> foreignKeys = new();

    public Entity1(Guid id)
    {
        Id = id;
    }

    public void AddForeignKey(Guid fk) => foreignKeys.Add(fk);
}

public class Entity2ForeignKey(Guid id)
{
    public Guid Id { get; } = id;

    public static implicit operator Entity2ForeignKey(Guid id)
        => new(id);

    public static implicit operator Guid(Entity2ForeignKey ent) => ent.Id;
}