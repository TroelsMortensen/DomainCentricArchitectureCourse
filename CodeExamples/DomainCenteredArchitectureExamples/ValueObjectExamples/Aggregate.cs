namespace ValueObjectExamples;

public abstract class Aggregate<Tid>
{
    public abstract Tid Id { get; protected set; }
}