# Domain Centered Architecture

This is an elective course available at VIA University College, Horsens, Denmark, for Software Technology Engineering students.

# Course Overview
The course focuses on various approaches to organize an application. We will throughout the course develop a Web Service, but the theories can be applied to all kinds of systems.

We will introduce:
* Domain Driven Development (DDD)
* Test/Behaviour Driven Development (TDD/BDD)
* Various architectural styles
* Various architectural patterns

The course theories will be applied to create a complete Web Service. Each week a new topic will be introduced and then applied to the course-spanning project. We will apply a "big-bang" development approach (inside-out when considering hexagonal, onion, clean), due to the nature of the course, and the order of the topics.


# Session Schedule

## [Session 1 - Architectures](Session1)

### Goal
Get an introduction to the course, and an overview of architectural styles.

### Topics
* Course introduction
* Architectural styles
* Markdown
* Course project introduction

### [Sources](/Session1%20-%20Architecture/Session%201%20Sources.md)

### [Assignment](Session1/Assignment%201):
You will be given analysis artifacts of a system to be developed.
* Develop domain model
* Setup project for git


## [Session 2 - Domain Driven Design]()

### Goal
Designing a richer domain model using elements of DDD.

### Topics
* Introduction to DDD
* Ubiquitous language
* Value Objects
* Entities
* Aggregates
* Rich Domain Model

### Preparation before class
* [Gain a basic understanding of generics](https://learn.microsoft.com/en-us/dotnet/csharp/fundamentals/types/generics)
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

## [Session 11 - Assignment work]()

### Goal
Work on assignment from previous session

### Topics
* Nothing new

### Assignment
* Nothing new



## [Session 12 - Presentation layer]() 

### Goal
Implement a Web API (using the REPR pattern?).

### Topics
* The REPR pattern
* Web API refresh
* Bending the Web API standard, i.e. diverting from REST
* Exam info

### Assignment
Implement the Web API, applying the REPR pattern.


# Sources
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

### Architecture
Designing Hexagonal Architecture with Java - by Davi Vieria

Get Your Hands Dirty On Clean Architecture - by Tom Hombergs

Clean Architecture - by Robert C. Martin

### Test
Growing Object-Oriented Software, Guided by Tests - by Steve Freeman, Nat Pryce

BDD in Action, Second Edition - by, John Ferguson Smart, Jan Molak




## Articles and Videos


### Hexagonal Architecture
https://herbertograca.com/2017/11/16/explicit-architecture-01-ddd-hexagonal-onion-clean-cqrs-how-i-put-it-all-together/

### Clean Architecture
https://www.c-sharpcorner.com/article/what-is-clean-architecture/

### Onion Architecture
https://jeffreypalermo.com/2008/07/the-onion-architecture-part-1/

### Transaction Script
https://java-design-patterns.com/patterns/transaction-script/

### Reaper pattern (REPR)
https://ardalis.com/mvc-controllers-are-dinosaurs-embrace-api-endpoints/

https://garywoodfine.com/implementing-vertical-slice-architecture/?amp


### Command Dispatcher
https://buildplease.com/pages/fpc-10/

### Vertical slice 
https://www.youtube.com/watch?v=SUiWfhAhgQw

### Repository pattern
https://www.youtube.com/watch?v=Bz5JCbWnaHo


### CQRS
https://www.youtube.com/watch?v=F3xNCfP3Xew


### Domain Driven Design
[Domain Driven Design example](https://www.youtube.com/watch?v=fO2T5tRu3DE)

[Effective Aggregate Design, part 1](https://www.dddcommunity.org/wp-content/uploads/files/pdf_articles/Vernon_2011_1.pdf)


### Test Driven Development
[What is TDD? What is Test Driven Development?](https://www.youtube.com/watch?v=H4Hf3pji7Fw)

[ZOMBIES](http://blog.wingman-sw.com/tdd-guided-by-zombies)

[Unit testing best practices](https://brightsec.com/blog/unit-testing-best-practices/)

[MSDN - Unit testing best practices](https://learn.microsoft.com/en-us/dotnet/core/testing/unit-testing-best-practices)

[TDD, Where Did It All Go Wrong - Ian Cooper](https://www.youtube.com/watch?v=EZ05e7EMOLM)


### Behaviour Driven Design
https://www.youtube.com/watch?v=VS6EEUVZGLE

https://www.youtube.com/watch?v=JwLhR9RI3ew

https://www.youtube.com/watch?v=zYj70EsD7uI



### Sample projects
https://github.com/jasontaylordev/CleanArchitecture

https://github.com/RaythaHQ/raytha