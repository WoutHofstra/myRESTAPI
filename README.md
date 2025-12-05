# myRESTAPI 

This in-progress project is going to be a production grade web API. I am trying to follow all the professional rules for the architecture.  
In the end it is going to be able to store tasks, like the typical todo list project.

So far, the API includes:
1. A REST controller (API/Controllers/TasksController.cs)
2. A business logic layer (Application/Services/TaskService.cs)
3. A data access layer (Infrastructure/Repositories/TaskRepository.cs)
4. Database entities (Domain/Entities/TaskEntity.cs)
5. DTO's (Data Transfer Objects) for input and output (Application/DTOs)
6. Dependency injection wiring (API/Program.cs)
7. App config (API/appsettings.json)

## 🏢 Architecture overview

This project will follow a layered architecture:
HTTP-request -> Controller -> Service -> Repository -> Database

This will make the system easily maintainable, scalable and easy to work with.

## ⚒️ What each part does

### API/Program.cs
This file, Program.cs, configures the app and sets everything up. The settings are imported from appsettings.json
**Later on, this will also set up the database**

### API/Controllers
This part will be receiving the actual Http requests. It validates incoming data and maps all of it to the classes I have made.
It then contacts the next layer. The controllers do not do any business logic. It is just a 'dumb' file that moves data.

### Application/Services
This is where all the more complicated logic lives. For example, this part checks whether every task has a title (which is required).
This part also converts DTOs into entities for the database. 

### Application/DTOs
The DTOs define what information the user should receive or input. For example, a CreateTaskDTO only needs the things a user has to input; title, description and deadline. A TaskResponseDTO contains all the information that entities contain as well.  

### Infrastructure/Repositories
This is the part that communicates with the database. There are multiple functions available: CreateTask, GetById, GetAllTasks, DeleteTask. 
Right now this part is ready for implementation, I am going to build the database part later and hook this up to it. 

### Domain/Entities
This part defines what our database entities have to look like. 

### appsettings.json
This file includes:
- Logging settings
- Allowed Hosts
- Connection strings
- App settings
- Cors (Cross origin resource sharing) details  
This file will probably increase as the project goes on and I need more config variables, we'll see

## How to run
Eventually, you will be able to run this by doing: 
``` dotnet run ```
However, it does not work yet at this point.