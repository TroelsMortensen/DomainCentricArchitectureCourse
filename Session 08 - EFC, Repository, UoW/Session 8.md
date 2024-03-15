# Session 8 - Data Access

### Topics
* Repository pattern (with DDD focus)
* Unit of Work overview
* Using EFC for data access (with SQLite)

## Preparation before class
We will be using Entity Framework Core. I will give some introduction, but you may want to refresh a few things. You could skim through [this website](https://www.learnentityframeworkcore.com/).

Microsoft has [some information](https://learn.microsoft.com/en-us/dotnet/architecture/microservices/microservice-ddd-cqrs-patterns/infrastructure-persistence-layer-implementation-entity-framework-core) on Repository and Unit of Work. It will not exactly match our approach, but still introduce the idea.

[Is the repository pattern a good idea? Reddit discussion](https://www.reddit.com/r/dotnet/s/yvos61F7ni)

## Material

[Link to today's slides](https://viaucdk-my.sharepoint.com/:p:/g/personal/trmo_viauc_dk/ES3tCcXnLtdCpseWxddJKhoBIXzS_jEvPTzjhnwRgOAm2g?e=eeeTU9)

## Assignment 7

[Link to assignment 7](https://viaucdk-my.sharepoint.com/:w:/g/personal/trmo_viauc_dk/Ecvgs8KOxIdPh18Sdc0kWooBFTjbj-hpWQy4YKsyz8CF4w?e=qegN4Z)



## Sources

[Documentation for LINQ](https://learn.microsoft.com/en-us/dotnet/csharp/linq/)

[Visualize the migration with SQL script](https://learn.microsoft.com/en-us/ef/core/managing-schemas/migrations/applying?tabs=dotnet-core-cli)



#### Repository pattern
https://www.youtube.com/watch?v=Bz5JCbWnaHo

#### Unit of Work


#### EFC Mapping

https://david-masters.medium.com/entity-framework-core-7-strongly-typed-ids-together-with-auto-increment-columns-fd9715e331f3

https://thomaslevesque.com/2020/12/23/csharp-9-records-as-strongly-typed-ids-part-4-entity-framework-core-integration/

https://andrewlock.net/strongly-typed-ids-in-ef-core-using-strongly-typed-entity-ids-to-avoid-primitive-obsession-part-4/


[Persisting private members](https://learn.microsoft.com/en-us/ef/core/modeling/backing-field?tabs=fluent-api)

[Value objects and EFC](https://medium.com/c-sharp-progarmming/value-objects-and-their-usage-with-entity-framework-a434f1414103)

https://thehonestcoder.com/ddd-ef-core-8/

https://www.youtube.com/watch?v=yFPuLp8QX1g
