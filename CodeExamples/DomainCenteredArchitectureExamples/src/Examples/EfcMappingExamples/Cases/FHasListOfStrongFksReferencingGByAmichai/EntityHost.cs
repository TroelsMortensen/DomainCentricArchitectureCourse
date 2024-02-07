namespace EfcMappingExamples.Cases.FHasListOfStrongFksReferencingGByAmichai;

public class EntityHost : AggregateRootBase<HostId, Guid>
{
    private string someValue = "Hello world";

    internal List<MenuId> menuIds = new();

    public void AddFks(params MenuId[] fks) => menuIds.AddRange(fks);

    public EntityHost(HostId id)
    {
        Id = id;
    }

    private EntityHost() // EFC
    {
    }
}

public class HostId : IdBase<Guid>
{
    public static HostId Create(Guid value) => new HostId(value);

    public HostId(Guid value)
    {
        Value = value;
    }

    private HostId() // EFC
    {
    }

}