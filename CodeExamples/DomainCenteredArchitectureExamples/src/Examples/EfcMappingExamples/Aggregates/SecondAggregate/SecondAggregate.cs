using EfcMappingExamples.Aggregates.Values;

namespace EfcMappingExamples.Aggregates.SecondAggregate;

public class SecondAggregate
{
    public MyId Id { get; private set; }

    internal TwoPropsValueObject twoValuedValueObject;

    internal OtherTwoPropsValueObject? otherTwoValuedValueObject;

    public SecondAggregate(MyId id)
    {
        Id = id;
    }

    public void SetTwoValued(TwoPropsValueObject value)
        => twoValuedValueObject = value;

    public void SetOtherTwoValued(OtherTwoPropsValueObject value)
        => otherTwoValuedValueObject = value;
}