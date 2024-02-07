namespace EfcMappingExamples.Cases.NestedValueObjects;

public class TopValueObject
{
    public FirstNestedVO First { get; }
    public SecondNestedVO Second { get; }

    public static TopValueObject Create(FirstNestedVO first, SecondNestedVO second) => new(first, second);

    private TopValueObject()
    {
    }

    private TopValueObject(FirstNestedVO first, SecondNestedVO second)
    {
        First = first;
        Second = second;
    }
}