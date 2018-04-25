
# HKR #
***Project Human Key: Reborn***

----------

## Summary ##
Project human Key: Reborn is a web-based game currently in development.

[Google Drive Folder for documents](https://drive.google.com/drive/folders/0B4zDK5_hmOx4ZG1rQ1lpN1dDYWs?usp=sharing)

So far, the team is composed of 4 developers working on their spare time.

 - BAL-FONTAINE Fabien
 - CAILLOT Tim
 - DUPONT Florent
 - ROS Quentin

## Back-End ##
The back-end is a **REST API** developed with **ASP.NET Core 1.1** *(May be updated to use asp.net core 2.0 during development)*.

[Documentation on RESTful urls and verbs](http://restfulapi.net/http-methods/)
#### Technologies used ####
- C# as the language used.
- Database access is done through [Entity Framework Core](https://docs.microsoft.com/en-us/ef/core/).
- The back-end uses Dependency Injection with [StructureMap](http://structuremap.github.io/) coupled to the basic .NET Core one.
- [Automapper](http://automapper.org/) for entity to dto conversion


## Web Front-End ##
Front-end will send calls to the REST API via ajax to process the game informations.

### Technologies used ###
- [TypeScript](https://www.typescriptlang.org/) as the language because *basic Javascript sucks*.
- [React](https://facebook.github.io/react/) (Or angular?) for navigation on the website.
- [BabylonJS](http://www.babylonjs.com/) for WebGL views of the game.

## Installation ##

- Install **AT LEAST** Visual Studio Community Edition **15.3**
- [Download and install .NET Core 2.0 manually](https://www.microsoft.com/net/core)

- Clone the project in a folder with 

HTTPS:
```git git clone https://github.com/Marsonge/HKR.git```

Or SSH:
```git git clone git@github.com:Marsonge/HKR.git```

- Import the solution file ```HKR.sln``` in Visual Studio 2017

``` CTRL+F5``` to launch the application *without debug*.

``` F5``` to launch the application in *debug mode*.


## Architecture ##

The project is divided in multiple projects to keep it clean.

[**A really cool PDF guide explaining the basic concepts that we will try to respect**](https://www.microsoft.com/net/download/thank-you/aspnet-ebook)
### HKRCore ###
**The Domain/Core of the application.**
- Model
- Services interfaces and implementation
- Domain Exceptions
- DTOs and [Automapper](http://automapper.org/) configuration
- Database context [EF Core](https://docs.microsoft.com/en-us/ef/#pivot=efcore)

Services call entities methods, call HKRContext and transform the result into DTOs

We want to have as much business methods in the entities as possible, **we don't want an [anemic model](https://en.wikipedia.org/wiki/Anemic_domain_model)**.

### HKRWebServices ###
**The entry point of the back-end.**

Here we have Rest Controllers which will make calls to Services.

This is also in this project that starts the application.

We make use of the [Dependency Injection](https://docs.microsoft.com/en-us/aspnet/core/fundamentals/dependency-injection) to inject services into the controllers.

We use [StructureMap](http://structuremap.github.io/) to have a better IoC/DI container

### HKRWebProject ###
**Doesn't exist at the moment.**

Uuuuh... No se, porque no hablo javascripto por el momento.
But Typescript is normally well integrated in Visual Studio as long as Node and npm.
