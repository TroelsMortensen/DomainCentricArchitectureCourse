﻿using EfcMappingExamples.Aggregates.Values;

namespace EfcMappingExamples.Aggregates.ThirdAggregate;

public class ThirdAggregate
{
    public Guid Id { get; private set; }

    internal Status currentStatus;

    internal SecondAggId? secondAggregateFk;
    public ThirdAggregate(Guid id)
    {
        Id = id;
        currentStatus = Status.Draft;
    }

    public void SetStatus(Status status) => currentStatus = status;

    public void SetSecondAggFk(SecondAggId id) => secondAggregateFk = id;
}

public enum Status
{
    Draft = 0,
    Validated = 1,
    Active = 2,
    SoftDeleted = 3
}