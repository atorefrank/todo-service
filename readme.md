Part 1

In this project i go over how to build a rest api implement the CQRS pattern. As part of the project we shall leverage the mediator pattern using MediatR. Automapper is often used to translate commands to entities and it usually works well for simple object, but can cause runtime exceptions sometimes in more complex objects (need to validate this claim).

We also use in memory sql server and entity framework (need to check if the in-mem db is actually sql server). 
Need to add user to rest api monolith.


In this chapter we will be implementing an api using the CQRS (Command Query Responsibility Separation). We will have business logic to handle commands and queries separately, and we will use MediatR, to route commands and queries to the appropriate handlers.

CQRS (Explain what it is)

This approach allows separate read (query) and write (command) operations. CQS was created by Bertrand Meyer. We typically would have separate functions for the commands and another for the queries, and there should never be one function that does both of these jobs. As a request comes in, it would be routed to the appropriate handler, this process can be facilitated by the MediatR library. This library is simple implementation of mediator pattern. This pattern allows implement commands/queries and handlers loosely coupled. 

The logic is cohesive and less interrelated, making it easier to create a modular, maintainable applications

The code and architecture are segregated by their business operations, making it easier to focus on the business case. This is due to the application of DDD when using the CQRS pattern

keeping the separation between the write and read logic reduces the chance of ending up with spaghetti code.

As our code is kept in silos, it's easier to fine-tune only one pipeline, leaving the rest untouched. It's easier to focus on the precise optimisations in the places that are business-critical.

Reduced cognitive load
Due to the vertical split, related code is kept together. To modify existing code or create new code, you don't need to understand the whole architecture and business logic. It's easier to focus on a specific task

A command is an instruction, a directive to perform a specific task. It is an intention to change something

A query (function or attribute) returns a result but does not change the state

CQRS was introduced by Greg Young in 2010

Domain Driven Design (DDD) is a method for optimizing a team’s understanding of a problem space, and how to work in that space. It’s about having a ubiquitous language that is used by business users and the development team. This unification of language can be extremely useful when translating the problem concept into functioning software.

MediatR (Explain what it is)

https://dotnetcoretutorials.com/wp-content/uploads/2019/04/MediatorPattern.png?ezimgfmt=ng:webp/ngcb1

https://assets-eu-01.kc-usercontent.com/665ad26e-74b6-0197-a66f-4ff80d2ded6b/b770267d-bba6-4568-a010-00e387fcf103/netcore1.png

https://assets-eu-01.kc-usercontent.com/665ad26e-74b6-0197-a66f-4ff80d2ded6b/2b7e14c9-8aab-4d05-94eb-648360784777/netcore2.png


MediatR is essentially a library that allows in process messaging.
MediatR can be either do “send and receive” type messages, or it can do a “broadcast” type message.

As we made our way through these 3 posts, it’s probably morphed a bit from the “Mediator Pattern” to “In Process Messaging”. But going back to our key bullet points from Part 1 :

It’s an object that encapsulates how objects interact. So it can obviously handle passing on “messages” between objects.
It promotes loose coupling by not having objects refer to each other, but instead to the mediator. So they pass the messages to the mediator, who will pass it on to the right person.
We can see that In Process Messaging is actually just an “implementation” of the mediator pattern. As long as we are promoting loose coupling through a “mediator” class that can pass data back and forth so that the caller doesn’t need to know how things are being handled (By whom and by how many handlers), then we can say we are implementing the Mediator Pattern.


The root level of the project shall be organized into 4 directories (define what each directory does): 

Api
Application
Domain
Infrastructure

code walk-through

Throughout the course of this tutorial, I will be using VsCode and the dotnet cli.

First things first, we shall create a new api using the cli command:

dotnet new webapi -o TodoApi

cd TodoApi

if you run the command

dotnet run

you should be able to hit the /WeatherForecast  endpoint and get a response

We shall then add the following packages. (Explain what each package does)
dotnet add package Microsoft.EntityFrameworkCore.InMemory
dotnet add package MediatR --version 10.0.1
<!-- dotnet add package Microsoft.VisualStudio.Web.CodeGeneration.Design -->
<!-- dotnet add package Microsoft.EntityFrameworkCore.Design -->
dotnet add package Microsoft.EntityFrameworkCore.SqlServer

We shall first implement the controller layer which shall be located in the Api directory







Part 2

Implement Rest to Rest communication, using an adapter layer (ACL). Still sharing db between them


part 3
Implement eventing

Part 4

Move to separate db's. Show data migration# todo-service


docker 5

detail how to setup harness, terraform and github actions

Auto provisioning with harness and terraform

Deployment with kubernetes and harness

Integration with github actions and acr

docker build -t todo:0.1 .
docker run -p 8001:80 todo:0.1 .

curl https://localhost:8001/todo

docker tag todo:0.1 todoservice.azurecr.io/todo:0.1

az acr login --name todoservice
<!-- docker run -p 7184:80 todo:0.1 . -->


<!-- https://localhost:7184/todo -->