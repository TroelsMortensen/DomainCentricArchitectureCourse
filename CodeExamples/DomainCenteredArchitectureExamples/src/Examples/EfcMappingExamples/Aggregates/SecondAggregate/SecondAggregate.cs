using EfcMappingExamples.Aggregates.Values;

namespace EfcMappingExamples.Aggregates.SecondAggregate;

public class SecondAggregate
{
    public SecondAggId Id { get; private set; }

    internal TwoPropsValueObject twoValuedValueObject;

    internal OtherTwoPropsValueObject? otherTwoValuedValueObject;

    public SecondAggregate(SecondAggId id)
    {
        Id = id;
        twoValuedValueObject = TwoPropsValueObject.Create("", 0); // setting dummy value, because otherwise I have to set this in all test, and it's annoying, and I'm lazy, and it's stupid I can't make it nullable.
    }

    public void SetTwoValued(TwoPropsValueObject value)
        => twoValuedValueObject = value;

    public void SetOtherTwoValued(OtherTwoPropsValueObject value)
        => otherTwoValuedValueObject = value;
}