namespace EfcMappingExamples.Cases.NestedValueObjects;

public class FirstNestedVO
{
    public string Stuff { get; }
    public int Number { get; }

    public static FirstNestedVO Create(string stuff, int number) => new(stuff, number);

    private FirstNestedVO(string stuff, int number)
    {
        Stuff = stuff;
        Number = number;
    }

    private FirstNestedVO()
    {
    }
}