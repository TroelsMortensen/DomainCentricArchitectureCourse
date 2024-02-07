namespace EfcMappingExamples.Cases.ClassAsEnum;

public class EntityH
{
    public Guid Id { get; }
    internal MyStatusEnum status = MyStatusEnum.First;
    
    public EntityH(Guid id)
    {
        Id = id;
    }

    private EntityH() // EFC
    {
    }
}