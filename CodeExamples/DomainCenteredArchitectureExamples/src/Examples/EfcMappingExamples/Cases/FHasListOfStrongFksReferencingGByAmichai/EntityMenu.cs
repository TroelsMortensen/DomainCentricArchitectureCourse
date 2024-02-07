namespace EfcMappingExamples.Cases.FHasListOfStrongFksReferencingGByAmichai;

public class EntityMenu : AggregateRootBase<MenuId, Guid>
{
    private string someOtherValue = "Hello moon";

    public EntityMenu(MenuId id)
    {
        Id = id;
    }

    private EntityMenu() // EFC
    {
    }
}

public class MenuId : IdBase<Guid>
{
    public static MenuId Create(Guid value) => new MenuId(value);

    private MenuId(Guid value)
    {
        Value = value;
    }

    private MenuId() // EFC
    {
    }
}