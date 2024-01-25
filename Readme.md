# Domain Centered Architecture

This is an elective course available at VIA University College, Horsens, Denmark, for Software Technology Engineering students. Taught by me.

# Course Overview
The course focuses on various approaches to organizing an application. We will throughout the course develop a Web Service, but the theories can be applied to all kinds of systems.

I will introduce:
* Domain Driven Development (DDD)
* Test/Behaviour Driven Development (TDD/BDD)
* Various architectural styles
* Various architectural patterns

The course theories will be applied to create a complete Web Service. Each week a new topic will be introduced and then applied to the course-spanning project.\
We will use a "big-bang" development approach (inside-out when considering hexagonal, onion, clean), due to the nature of the course, and the order of the topics.


# Session Schedule

## [Session 1 - Architectures](Session%201%20-%20Architecture/Session%201.md)

Get an introduction to the course, and an overview of architectural styles.




## [Session 2 - Domain-Driven Design]()

### Topics
* Introduction to DDD
* Ubiquitous language
* Value Objects
* Entities
* Aggregates
* Rich Domain Model

### Preparation before class
* [Gain a basic understanding of generics](https://learn.microsoft.com/en-us/dotnet/csharp/fundamentals/types/generics)

### Extra optional preparation
* [Gain a basic understanding of reflection](https://learn.microsoft.com/en-us/dotnet/framework/reflection-and-codedom/viewing-type-information) <- This should cover how to extract properties of a class. Needed for challange-part of assignment.

### Assignment:
Develop "exploded domain model".\
Define rules and test cases for value objects.


## [Session 3 - Operation Result Pattern]()

### Goal
Implementing Operation Result pattern.

### Topics
* Introduction to Operation Result pattern
* Factory method pattern

### Preparation before class
Again, we'll need to use generics, so make sure you know the basics, see previous session.

### Assignment
Implement the Operation Result pattern, to be used throughout the course project.


## [Session 4 - Test/Behaviour Driven Development]()

### Goal
Use TDD and BDD to implement the domain.

### Topics
* TDD
* BDD
* Introduction to xUnit.NET test framework


### Assignment
Implement the domain model using TDD.


## [Session 5 - Project work]()

### Goal
Mainly project work, a bit about domain services.

### Topics
* What is a service
* Domain services

### Assignment
Continue work on assignment from previous session. Some things needs a domain service to be implemented.


## [Session 6 - Commands and handlers]()

### Goal
Implementing use cases with command objects/handlers and repositories.

### Topics
* Command objects
* Command handler pattern
* Repository pattern lite

### Assignment
Implement use cases as application services using TDD.\
Implement/expand on domain model behaviour if needed.\
Mock data storage for now.

## [Session 7 - Command Dispatcher]()

### Goal
Implement the command dispatcher pattern as a way to interact with the application layer.

### Topics
* Command Dispatcher pattern
* Various implementation strategies
    * Simple, overloaded methods
    * Switch-statement based, manually managing dependincies
    * Map based approach, registering handlers
    * Using .NET's IoC container
* Pipelines

### Assignment
Implement the dispatcher pattern, at least for command handlers. Could be extended to query handlers.

## [Session 8 - Assignment work]()

### Goal
Work on assignment from previous session

### Topics
* Nothing new

### Assignment
* Nothing new

## [Session 9 - Persiting data]()

### Goal
Adding persistent data storage with Entity Framework

### Topics
* Repository pattern from DDD point of view
    * With abstract repository
* Unit of work
* Entity Framework Core brushup
* Handling Value Objects

### Assignment
Implement persistent data storage with EFC and SQLite (or in-memory).

## [Session 10 - Retrieving data]()

### Goal
Introduction of the Command Query Responsibility Separation (CQRS) pattern.

### Topics
* CQRS overview
* The read model
    * Generating the read model from existing storage with EFC

### Assignment
Implement read data use cases based on the generated read model.





## [Session 11 - Presentation layer]() 

### Goal
Implement a Web API. Task/Process/Operation oriented.

### Topics
* The REPR pattern
* Web API refresh
* Bending the Web API standard, i.e. diverting from REST
* Exam info

### Sources
* [Watch 10 minutes video](https://www.youtube.com/watch?v=DjZepWrAKzM)
* [Task based Web API](https://www.youtube.com/watch?v=6XO6vSiioWE)
* [Task based Web API design](https://www.linkedin.com/advice/0/what-some-best-practices-using-restful)
* [Task based better than CRUD](https://betterprogramming.pub/is-task-based-ui-a-better-solution-than-crud-apis-768648fc5161)
* [Task based UI](https://cqrs.wordpress.com/documents/task-based-ui/)
* [Focus on behaviour rather than CRUD entities](https://www.youtube.com/watch?v=v5Fss4fCl8c)

### Assignment
Implement the Web API.


## [Session 12 - Assignment work / Exam]()

### Goal
Work on assignment from previous session

### Topics
* Some exam info

### Assignment
* Nothing new


# Course Sources
This course has been developed based on a considerable collection of various sources, e.g. books, articles, videos.


Below I have attempted to collect all of it in one large list. Each session will also include a subset of sources relevant to that session.\
The sources below are not considered course curriculum, but instead a list of information revelant to the student interested in knowing more.


## Books

### Un-categorized
Patterns of Enterprices Application Architecture - by Martin Fowler

An Atypical ASP.NET Core 5 Design Patterns Guide - by Carl-Hubo Marcotte

### Domain Driven Design

Domain-Driven Design Quickly - by Abel Avram & Floyd Marinescu

Implementing Domain-Driven Design - by Vaugn Vernon

Hands-on Domain-Driven Design with .NET Core - Alexey Zimarev

Learning Domain-Driven Design - by Vlad Khononov

### Architecture
Designing Hexagonal Architecture with Java - by Davi Vieria

Get Your Hands Dirty On Clean Architecture - by Tom Hombergs

Clean Architecture - by Robert C. Martin

### Test
Growing Object-Oriented Software, Guided by Tests - by Steve Freeman, Nat Pryce

BDD in Action, Second Edition - by John Ferguson Smart, Jan Molak

The art of unit testing, second edition - by Roy Osherove

Unit testing. Principles, practices, and patterns - by Vladimir Khorikov

### Entity Framework Core
Entity Framework Core IN ACTION, 2nd edition - by Jon P Smith

### Web API
Building Web APIs with ASP.NET Core - by Valerio de Sanctis

API Design Patterns - By JJ Geewax


## Articles and Videos
... I'm cleaning this up




### Transaction Script
https://java-design-patterns.com/patterns/transaction-script/

### Reaper pattern (REPR)
https://ardalis.com/mvc-controllers-are-dinosaurs-embrace-api-endpoints/

https://garywoodfine.com/implementing-vertical-slice-architecture/?amp

https://deviq.com/design-patterns/repr-design-pattern

https://www.youtube.com/watch?v=layTLQJ5xYw


### Command Dispatcher
https://buildplease.com/pages/fpc-10/

https://blogs.cuttingedge.it/steven/posts/2011/meanwhile-on-the-command-side-of-my-architecture/

https://blogs.cuttingedge.it/steven/posts/2011/meanwhile-on-the-query-side-of-my-architecture/

### Vertical slice 
https://www.youtube.com/watch?v=SUiWfhAhgQw

https://garywoodfine.com/implementing-vertical-slice-architecture/

### Repository pattern
https://www.youtube.com/watch?v=Bz5JCbWnaHo


### CQRS
https://www.youtube.com/watch?v=F3xNCfP3Xew

https://blogs.cuttingedge.it/steven/posts/2011/meanwhile-on-the-query-side-of-my-architecture/

### Test Driven Development
[What is TDD? What is Test Driven Development?](https://www.youtube.com/watch?v=H4Hf3pji7Fw)

[ZOMBIES](http://blog.wingman-sw.com/tdd-guided-by-zombies)

[Unit testing best practices](https://brightsec.com/blog/unit-testing-best-practices/)

[MSDN - Unit testing best practices](https://learn.microsoft.com/en-us/dotnet/core/testing/unit-testing-best-practices)

[TDD, Where Did It All Go Wrong - Ian Cooper](https://www.youtube.com/watch?v=EZ05e7EMOLM)

### Testing
[Writing Highly Maintainable Unit Tests, Pluralsight course](https://app.pluralsight.com/library/courses/writing-highly-maintainable-unit-tests/table-of-contents)

[State vs interaction testing](https://thinkster.io/tutorials/blogs/interaction-vs-state-based-testing)

### Behaviour Driven Design
https://www.youtube.com/watch?v=VS6EEUVZGLE

https://www.youtube.com/watch?v=JwLhR9RI3ew

https://www.youtube.com/watch?v=zYj70EsD7uI

### Task-Based Web API Design
...

### Entity Framework Core
[EF Core 6 and Domain-Driven Design, Pluralsight course](https://app.pluralsight.com/library/courses/ef-core-6-domain-driven-design/table-of-contents)

[EF Core 6 Fundamentals, Pluralsight course](https://app.pluralsight.com/library/courses/ef-core-6-fundamentals/table-of-contents)

[Documentation for LINQ](https://learn.microsoft.com/en-us/dotnet/csharp/linq/)

[Good site for introduction to EFC](https://www.learnentityframeworkcore.com/)

[Visualize the migration with SQL script](https://learn.microsoft.com/en-us/ef/core/managing-schemas/migrations/applying?tabs=dotnet-core-cli)

[Value objects and EFC](https://medium.com/c-sharp-progarmming/value-objects-and-their-usage-with-entity-framework-a434f1414103)

#### EFC Mapping
https://david-masters.medium.com/entity-framework-core-7-strongly-typed-ids-together-with-auto-increment-columns-fd9715e331f3

https://thomaslevesque.com/2020/12/23/csharp-9-records-as-strongly-typed-ids-part-4-entity-framework-core-integration/

https://andrewlock.net/strongly-typed-ids-in-ef-core-using-strongly-typed-entity-ids-to-avoid-primitive-obsession-part-4/

## Sample projects (not mine, but for inspiration to myself)
https://github.com/jasontaylordev/CleanArchitecture

https://github.com/RaythaHQ/raytha