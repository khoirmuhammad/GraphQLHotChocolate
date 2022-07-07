# GraphQL in NET Core using Hot Chocolate

Hot Chocolate is an open-source GraphQL server built for the Microsoft .NET platform. It removes the complexity of building GraphQL APIs from scratch with built-in features for queries, mutations, and subscriptions

Step by step are the following
1. Create project in Visual Studio (ASP.NET Core Empty as template)

2. Required Packages 
  - Microsoft.EntityFraeworkCore
  - Microsoft.EntityFraeworkCore.SqlServer
  - Microsoft.EntityFraeworkCore.Tools
  - HotChocolate
  - HotChocolate.AspNetCore
  - HotChocolate.AspNetCore.Playground
  - HotChocolate.Types
  - HotChocolate.Types.Filters
  
 3. Create Models and Configuration Model Builders (Within Models Directory)
 
 4. Create Application DBContext (AppDBContext) (Within Root Directory)
 
 5. Create service Extension, In order to register DI such as DBContext, Repository, and also GraphQL. Therefore we able to make Startup.cs keep clean (Within Extensions Directory)
 
 6. Perform Add-Migration & Update-Database in order to apply code first approach
 
 7. Create Contract / Interface (Repository Pattern) (Within Contracts Directory)
 
 8. Create Repository / Implementation (Within Repsitories Directory). Once done, dont forget to register these repositories into service extensions and call it from Startup.cs
 
 9. Create GraphQL Folders
  - Types Folder : since GraphQL isn't bounded with specific programming languange, then we have to map our model. So, GraphQL can recognize our object data
  - Resolver Folder
  - Queries Folder : Since we make single shcema and single endpoint, then we need to split our query by its entity. For example Entities (Department, Employee). For cleaning code design we need to split query into 2 class as well, called DepartmentQuery & EmployeeQuery. So each entity will be proceed by its query respectively.
  - Mutations Folder : In order to give command Insert , Update, Delete via GraphQL
