# ✅ TaskManagerAPI

TaskManagerAPI is a simple, modular, and extensible RESTful API built with ASP.NET Core. It provides a structured solution for managing tasks — create, update, list, delete, assign, unassign and mark as completed — and managing users — create, update, delete —  with a clean architecture and DTO validation.

---

## 🚀 Project Vision

In a world where task flow equals team velocity, this API serves as a scalable base for SaaS platforms, productivity tools, or any backend that needs reliable task tracking logic.

---

## 🛠️ Tech Stack

| Layer            | Technology            |
|------------------|-----------------------|
| Backend API      | ASP.NET Core Web API  |
| ORM & Database   | Entity Framework Core |
| Database         | SQL Server            |
| Language         | C#                    |
| Framework        | .NET 7+               |

---

## 📁 Project Structure

    TaskManagerAPI/
        Controllers/
            AssignmentController.cs
            TaskController.cs
            UserController.cs
        Data/
            AppDbContext.cs
        Dtos/
            CreateTaskDto.cs
            CreateUserDto.cs
            TaskDetailsDto.cs
            TaskFilterDto.cs
            UpdateTaskDto.cs
            UpdateTaskPriorityDto.cs
            UpdateUserDto.cs
            UserDetailsDto.cs
            TaskManageDto.cs
        Models/
            TaskItem.cs
            User.cs

---

### 📡 API Endpoints

### 📝 Task Endpoints

| Method | Route                          | Description                             |
|--------|--------------------------------|-----------------------------------------|
| GET    | /api/task                      | Get all tasks                           |
| GET    | /api/task/{id}                 | Get a task by ID                        |
| POST   | /api/task                      | Create a new task                       |
| PUT    | /api/task/{id}                 | Update a task                           |
| DELETE | /api/task/{id}                 | Delete a task                           |
| PATCH  | /api/task/{id}/complete        | Mark task as completed                  |
| PATCH  | /api/task/prio/{id}            | Update task priority                    |
| GET    | /api/task/filter?TaskPriority=1| Filter tasks by priority                |

---

### 👤 User Endpoints
| Method | Route                          | Description                     |
|--------|--------------------------------|---------------------------------|
| GET    | /api/user                      | Get all users                   |
| GET    | /api/user/{id}                 | Get a user by ID                |
| POST   | /api/user                      | Create a new user               |
| PUT    | /api/user/{id}                 | Update a user                   |
| DELETE | /api/user/{id}                 | Delete a user                   |

---

### 🔁 Assignment Endpoints
| Method | Route                             | Description                              |
|--------|-----------------------------------|------------------------------------------|
| PATCH  | /api/assignment/{taskId}/assign   | Assign a task to a user                  |
| DELETE | /api/assignment/{taskId}/unassign | Remove the assigned user from a task     |


---

## 📋 DTO Validation Rules

- `TaskTitle`: required, max length 20
- `TaskDescription`: required, max length 100

---

## 🧪 Getting Started

### 1. Clone the repo:

```bash
git clone https://github.com/yourusername/TaskManagerAPI.git
cd TaskManagerAPI
```
### 2. Add a Migration
```bash
dotnet ef migrations add MigrationName
```
### 3. Update Database
```bash
dotnet ef database update
```
### 4. Build the project
```bash
dotnet build
```

### 5. Start the project
```bash
dotnet run
```