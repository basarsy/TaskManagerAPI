# ✅ TaskManagerAPI

TaskManagerAPI is a simple, modular, and extensible RESTful API built with ASP.NET Core. It provides a structured solution for managing tasks — create, update, list, delete, and mark as completed — with a clean architecture and DTO validation.

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
            TaskController.cs
        Data/
            AppDbContext.cs
        Dtos/
            CreateTaskDto.cs
            UpdateTaskDto.cs
        Models/
            TaskItem.cs

---

## 📡 API Endpoints

| Method | Route                          | Description                     |
|--------|--------------------------------|---------------------------------|
| GET    | `/api/task`                    | Get all tasks                   |
| GET    | `/api/task/{id}`               | Get a task by ID                |
| POST   | `/api/task`                    | Create a new task               |
| PUT    | `/api/task/{id}`               | Update a task                   |
| DELETE | `/api/task/{id}`               | Delete a task                   |
| PATCH  | `/api/task/{id}/complete`      | Mark task as completed          |


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

dotnet run
