namespace EfcMappingExamples.Cases.Enums;

public class Entity1
{
    public Guid Id { get; }

    internal MyEnum status = MyEnum.First;
    
    public Entity1(Guid id)
    {
        Id = id;
    }
    
    public void SetStatus(MyEnum newStatus) => status = newStatus;
}

public enum MyEnum
{
    First = 1,
    Second = 2
}