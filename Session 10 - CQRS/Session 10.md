# Session 10 - CQRS

### Topics
* Command Query Responsibility Segregation
* Queries/Answers, handlers, and dispatcher


## Preparation before class

You need to know what a [partial class is](https://learn.microsoft.com/en-us/dotnet/csharp/programming-guide/classes-and-structs/partial-classes-and-methods).

Optionally see 4 minute video with quick overview of the basic idea of CQRS: [Short intro video](https://www.youtube.com/watch?v=cqNGAo-9pUE)

We may be using the `dynamic` keyword, you may [look into it](https://learn.microsoft.com/en-us/dotnet/csharp/advanced-topics/interop/using-type-dynamic).

We will use [records](https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/builtin-types/record) for some data modelling.

We will use [TypedResults](https://learn.microsoft.com/en-us/aspnet/core/fundamentals/minimal-apis/responses?view=aspnetcore-9.0#typedresults-vs-results) for returns from the web api endpoints.

## Material

[Link to today's slides](https://viaucdk-my.sharepoint.com/:p:/g/personal/trmo_viauc_dk/ET_kZuqpinlHpNxWtfd2Li4BFWP7e3t_3YUdN_-JcytbaA?e=RuCbkG)

## Assignment 
[Link to assigment 8](https://viaucdk-my.sharepoint.com/:f:/g/personal/trmo_viauc_dk/Em0kdXyG0c9AhLEOux4x6-sBbQdjPwqCtLZasypyfVp0lw?e=XS2iKW)
For me, this link does not work in Edge. But it works in Chrome.

This time it's a folder, with:
* Assignment description
* Appendix A - UI sketches
* Appendix B - Data descriptions
* Various json data files

## Sources

https://blogs.cuttingedge.it/steven/posts/2011/meanwhile-on-the-query-side-of-my-architecture/

https://www.youtube.com/watch?v=F3xNCfP3Xew

[Why use TypedResult](https://blog.variant.no/better-openapi-in-minimal-api-with-typedresults-f1bf90f029af)

[Reverse engineering in EFC](https://learn.microsoft.com/en-us/ef/core/managing-schemas/scaffolding/?tabs=dotnet-core-cli)
