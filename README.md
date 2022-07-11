# A GraphQL API in NET Core using Hot Chocolate (GraphQLHotChocolate Project)

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
  
 10. Once again we have to register our GraphQL in startup, dont forget to set up endpoint "endpoints.MapGraphQL();"
 
 # B GraphQL Client Testing
 
 ### We able to use /graphql interface screen
 ![Test Image 1](https://github.com/khoirmuhammad/GraphQLHotChocolate/blob/master/Images/Run%20graphql.PNG)
 
 
 ### Or use /playground for testing purpose
 ![Test Image 2](https://github.com/khoirmuhammad/GraphQLHotChocolate/blob/master/Images/Run%20playground.PNG)
 
 
 ### Try to get all departments
 ![Test Image 3](https://github.com/khoirmuhammad/GraphQLHotChocolate/blob/master/Images/getalldepartments.PNG)
 
 
 ### Try to get departement data by ID 
 ![Test Image 4](https://github.com/khoirmuhammad/GraphQLHotChocolate/blob/master/Images/getdepartmentbyid.PNG)
 
 
 ### This is a resolver purpose. Once we attempt to get department by id, we also able to get all of employees that in particular department
 ![Test Image 5](https://github.com/khoirmuhammad/GraphQLHotChocolate/blob/master/Images/getdepartmentbyidandemployeeresolver.PNG)
 
 
 ### Once we attempt to get employee info, we also can retreive department info
 ![Test Image 6](https://github.com/khoirmuhammad/GraphQLHotChocolate/blob/master/Images/getemployeebyidanddepartmentresolver.PNG)
 
 
 ### GraphQL able to prevent multiple rounds trip by calling 2 query in single request
 ![Test Image 7](https://github.com/khoirmuhammad/GraphQLHotChocolate/blob/master/Images/singletripcall.PNG)
 
 
 
 ### Department Query Sample
 
```
query{
  departments {
    id,
    name
  }
}
```
```
query{
  department(id:"3f57f5d160924713acac2ccd09d5062d"){
    id,
    name
  }
}
```
```
query{
  department(id:"3f57f5d160924713acac2ccd09d5062d") {
    id,
    name,
    employees{
      id,
      name
    }
  }
}
```
### Employee Query Sample

```
query{
  
  employee(id: "fc5c21790c634980a87a2ae9a3ba475f") {
    id,
    name,
  }

  department(id:"3f57f5d160924713acac2ccd09d5062d"){
    id,
    name
  }
  
}
```

### Department Mutation (Insert, Update, Delete)
```
mutation{
  createDepartment(input: {
    id:"2CED691E-854C-489B-ACD6-765D369BDF5B",
    name:"Risk Management"
  }) {
    id,name
  }
}
```
```
mutation{
  updateDepartment(
  id: "15597C61-C257-4B54-A987-18A0D34A1F86",
  input: {
    name : "Supply Chain Management"
  }) {
    id,
    name
  }
}
```
```
mutation{
  deleteDepartment(id: "2CED691E-854C-489B-ACD6-765D369BDF5B")   
}
```
### Employee  Mutation (Insert, Update)
```
mutation{
  createEmployee(input: {
    name:"Sihombing",
    isSingle:true,
    birthDate:"2005-01-12",
    kpiValue:96.21,
    departmentId:"15597C61-C257-4B54-A987-18A0D34A1F86"
  }) {
    id,
    name
  }
}
```
```
mutation{
  updateEmployee(
    id: "77E29D40-B84B-4524-A7E3-5F0581E1B7BB",
    input: {
      isSingle: false,
      kpiValue: 97.34,
      departmentId: "15597C61-C257-4B54-A987-18A0D34A1F86"
    }) {
    id,
    name,
    isSingle,
    birthDate,
    kpiValue
  }
}
```
# C. GraphQL Client using .NET (GraphQL.NETClient Project)

Install the following packages
1. GraphQL.Client
2. GraphQL.Client.Serializer.Newtonsoft

### Please create Models directory
In order to work with our API endpoint databinding. For example if we need to catch data from swagger, either from query, from body etc.

### Please create Types directory
In order to deal with response data from GraphQL API. We have to follow the naming convention based on GraphQL Schema

![Test Image 8](https://github.com/khoirmuhammad/GraphQLHotChocolate/blob/master/Images/QuerySchema.PNG)

![Test Image 9](https://github.com/khoirmuhammad/GraphQLHotChocolate/blob/master/Images/MutationSchema.PNG)

### Then create Services directory
In order to consume GraphQL directly

### Finally we able to create controller as our endpoint


