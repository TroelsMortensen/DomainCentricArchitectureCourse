# Domain Centered Architecture

This is an elective course available at VIA University College, Horsens, Denmark, for Software Technology Engineering students. Taught by me.

I'm still fleshing out the last details of stuff.

# Course Overview
The course focuses on various approaches to organizing an application. We will throughout the course develop a Web Service, but the theories can be applied to all kinds of systems.

I will introduce:
* Domain Driven Development (DDD)
* Test/Behaviour Driven Development (TDD/BDD)
* Various architectural styles
* Various architectural patterns

The course theories will be applied to create a complete Web Service. Each week a new topic will be introduced and then applied to the course-spanning project.\
We will use a "big-bang" development approach (inside-out when considering hexagonal, onion, clean), due to the nature of the course, and the order of the topics.

# Before we start
Install the latest .NET version (.NET8 at the time of writing), along with your preferred IDE.

# Session Schedule
The following is a session plan. Each header links to more details for that specific session.

## [Session 1 - Architectures](Session%2001%20-%20Architecture/Session%201.md)

Get an introduction to the course, and an overview of architectural styles.


## [Session 2 - Domain-Driven Design](Session%2002%20-%20DDD/Session%202.md)

Lite introduction to DDD, focus on tactical patterns.\
How to design a complex domain model.


## [Session 3 - Operation Result Pattern](Session%2003%20-%20Operation%20Result%20Pattern/Session%203.md)

Introduction to the Operation Result pattern.


## [Session 4 - Test Driven Development](Session%2004%20-%20TDD/Session%204.md)

Introduction to TDD, implement the domain model with TDD.


## [Session 5 - Domain Services and Contracts](Session%2005%20-%20Domain%20services,%20contracts/Session%205.md)

Mainly project work, a bit about domain services and contracts.


## [Session 6 - Commands and Handlers pattern](Session%2006%20-%20Application%20ring/Session%206.md)

Implement use cases (application ring/layer) with command objects/handlers (and "placeholder" repositories).


## [Session 7 - Command Dispatcher](Session%2007%20-%20Command%20Dispatcher/Session%207.md)

Implement the command dispatcher pattern as a way to interact with the application layer.



## [Session 8 - EFC, Repository and Unit of Work pattern](Session%2008%20-%20EFC,%20Repository,%20UoW/Session%208.md)

Implement data storage, with Entity Framework Core.


## [Session 9 - Assignment work](Session%2009%20-%20Assignment%20work/Session%209.md)

Just keep working on persistence.

## [Session 10 - CQRS](Session%2010%20-%20CQRS/Session%2010.md)

Introducing the query side of the application. Now we can get data out of the Web Service.



## [Session 11 - Web API, Presentation ring](Session%2011%20-%20Web%20API/Session%2011.md) 

We apply the REPR pattern, implemented with Fluent Interface, and use Object Converter pattern for some convenience.


## [Session 12 - Assignment work / Exam](Session%2012%20-%20Exam/Session%2012.md)

Exam info. Work on assignment from previous session


# Course Sources
This course has been developed based on a considerable collection of various sources, e.g. books, articles, videos.


For each session I have attempted to collect all sources relevant to that session. This may include books, articles, YouTube vidoes, online courses, and more.\
These sources are not considered course curriculum, but instead a list of information revelant to the student interested in knowing more.

Below are more general resources.

## Books

#### Un-categorized
Patterns of Enterprices Application Architecture - by Martin Fowler

An Atypical ASP.NET Core 5 Design Patterns Guide - by Carl-Hubo Marcotte

#### Domain Driven Design

Domain-Driven Design Quickly - by Abel Avram & Floyd Marinescu

Implementing Domain-Driven Design - by Vaugn Vernon

Hands-on Domain-Driven Design with .NET Core - Alexey Zimarev

Learning Domain-Driven Design - by Vlad Khononov

#### Architecture
Designing Hexagonal Architecture with Java - by Davi Vieria

Get Your Hands Dirty On Clean Architecture - by Tom Hombergs

Clean Architecture - by Robert C. Martin

#### Test
Growing Object-Oriented Software, Guided by Tests - by Steve Freeman, Nat Pryce

BDD in Action, Second Edition - by John Ferguson Smart, Jan Molak

The art of unit testing, second edition - by Roy Osherove

Unit testing. Principles, practices, and patterns - by Vladimir Khorikov

#### Entity Framework Core
Entity Framework Core IN ACTION, 2nd edition - by Jon P Smith

#### Web API
Building Web APIs with ASP.NET Core - by Valerio de Sanctis

API Design Patterns - By JJ Geewax


## Online courses

#### Domain-Driven Design
[Domain-Driven Design Fundamentals, Pluralsight course](https://app.pluralsight.com/library/courses/fundamentals-domain-driven-design/table-of-contents)

[Getting Started: Domain-Driven Design, Dometrain course](https://app.dometrain.com/courses/enrolled/2167078)

#### Entity Framework Core
[EF Core 6 and Domain-Driven Design Pluralsight Course](https://app.pluralsight.com/library/courses/ef-core-6-domain-driven-design/table-of-contents)

## Sample projects (not mine, but for inspiration to myself)
https://github.com/jasontaylordev/CleanArchitecture

https://github.com/RaythaHQ/raytha