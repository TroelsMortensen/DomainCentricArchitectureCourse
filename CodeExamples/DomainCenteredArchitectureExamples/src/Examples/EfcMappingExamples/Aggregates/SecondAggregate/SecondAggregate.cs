using EfcMappingExamples.Aggregates.Values;

namespace EfcMappingExamples.Aggregates.SecondAggregate;

public class SecondAggregate
{
    public MyId Id { get; private set; }

    internal TwoPropsValueObject myTwoValuedValueObject;

    public SecondAggregate(MyId id)
    {
        Id = id;
    }

    public void SetTwoValued(TwoPropsValueObject value) => myTwoValuedValueObject = value;


}