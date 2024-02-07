namespace EfcMappingExamples.Cases.NestedValueObjects;

public class SecondNestedVO
{
    public string Type { get; }

    public static SecondNestedVO Create(string type) => new(type);
    private SecondNestedVO(string type) => Type = type;

    private SecondNestedVO()
    {
    }
}