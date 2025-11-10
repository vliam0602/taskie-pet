# TaskiePet — Virtual Pet Dashboard

TaskiePet is a web application that lets users raise a virtual pet by completing real-life daily tasks (e.g., studying, exercising). Completing tasks makes the pet happier and gain XP; neglecting tasks reduces mood and energy.

---

## 1. Concept

- Users complete real-world daily tasks to improve their pet's happiness and XP.
- Neglecting tasks decreases pet mood and energy.
- Daily reset adjusts hunger and mood.
- ~~Animated pet reactions provide visual feedback (happy, sad, tired).~~ (animated pet reactions may be implemented later; currently static images are used instead.)

---

## 2 Feature

### Authentication

- Login, logout, register
- External login (google)

### Tasks

- Create task
- View task (list, detail)
- Update task detail
- Mark task as completed/uncompleted
- Completing tasks improves pet happiness and XP.

### Pet

- Creating a pet when user first login
- Update pet information (name, detail,...)
- View pet information (name, status,...)
- Play/feed pet (increase hunger & happiness status)

### Gamification

- Completing all daily tasks increases pet XP and level.
- Skipping tasks decreases happiness or hunger.
- Users can view daily pet mood summary.

---

### Daily Reset (Background Job)

Triggered daily at 00:00:

- Reset all tasks to IsCompleted = false
- Decrease pet Happiness and Hunger

---

## 3. Architecture Overview

Overview of the main stacks and project layout.

### Frontend — React 19 + TypeScript

- Framework: React 19 with Vite
- Styling: ...
- State management: React Context + custom hooks
- Data fetching: Axios services
- Architecture: feature-based structure

Frontend folder structure:

```
Frontend (React + TypeScript)
├── src/
│   ├── App.tsx
│   ├── main.tsx
│   ├── routes.tsx
│   ├── index.css
│
│   ├── api/              # Axios instance & interceptors
│   ├── auth/             # Auth context, useAuth, AuthProvider
│   ├── components/       # Reusable UI: Button, Card, Modal, Spinner, etc.
│   ├── layout/           # Layout components (Navbar, Sidebar, etc.)
│   ├── service/          # Business logic: petService, taskService, authService
│   ├── hooks/            # Reusable custom hooks
│   ├── utils/            # Helpers, constants, formatters
│   ├── pages/            # Main pages
│   │   ├── Login.tsx
│   │   ├── Register.tsx
│   │   ├── Dashboard.tsx
│   │   ├── Pet.tsx
│   │   ├── Tasks.tsx
│   │   └── Stats.tsx
│   ├── assets/           # Images, icons, animations
│   ├── styles/           # Global styles (Tailwind or SCSS)
│   └── types/            # TypeScript interfaces & enums
│
├── index.html
└── package.json


```

### Backend — .NET 9 Web API

- Framework: ASP.NET Core 9 Web API
- Data Access: Framework Core (Code-First)
- Architecture: Clean Architecture (Domain / Application / Infrastructure / WebApi)
- BackgroundService: runs daily to reset tasks and adjust pet stats
- Authentication: JWT-based
- Database: SQL Server (in container). Auto-migrations with EF Core

---

## 4. Domain Model (In progress)

### User

|        Field | Type     | Description           |
| -----------: | :------- | :-------------------- |
|           Id | Guid     | Primary key           |
|        Email | string   | User email            |
| PasswordHash | string   | Hashed password       |
|    CreatedAt | DateTime | Account creation date |

### Task

|       Field | Type      | Description             |
| ----------: | :-------- | :---------------------- |
|          Id | Guid      | Primary key             |
|      UserId | Guid      | FK → User               |
|       Title | string    | e.g., "Study English"   |
| Description | string    | Optional                |
| IsCompleted | bool      | Task completion flag    |
| CompletedAt | DateTime? | Timestamp of completion |
|   CreatedAt | DateTime  | Creation date           |
|    TaskDate | DateTime  | Used for daily reset    |

### Pet

|        Field | Type     | Description    |
| -----------: | :------- | :------------- |
|           Id | Guid     | Primary key    |
|       UserId | Guid     | FK → User      |
|         Name | string   | Pet name       |
|        Level | int      | XP-based level |
|       Hunger | int      | 0–100          |
|    Happiness | int      | 0–100          |
|    LastFedAt | DateTime |                |
| LastPlayedAt | DateTime |                |
|    UpdatedAt | DateTime |                |

### PetEventLog (In-progress)

|       Field | Type     | Description                             |
| ----------: | :------- | :-------------------------------------- |
|          Id | Guid     | Primary key                             |
|       PetId | Guid     | FK → Pet                                |
|   EventType | string   | "Feed", "Play", "LevelUp", "MoodChange" |
| Description | string   | Optional description                    |
|   CreatedAt | DateTime | Timestamp                               |

---

## 5. Event Flow

1. User completes a task
2. TaskService marks IsCompleted = true
3. PetService increases Happiness and XP
4. If XP exceeds threshold → LevelUp event
5. Dashboard updates pet animation (happy / excited)

---

## 6. Tech Stack Summary

| Layer    | Technology                                               |
| :------- | :------------------------------------------------------- |
| Frontend | React 19, TypeScript, Vite                               |
| Backend  | .NET 9 Web API, Entity Framework Core, BackgroundService |
| Auth     | JWT                                                      |
| Database | SQL Server                                               |
| Deploy   | Dockerfile                                               |

---

## 7. Development Roadmap

| Week | Goal         | Deliverables                                      |
| ---: | :----------- | :------------------------------------------------ |
|    1 | Setup + Auth | Backend & frontend skeleton, register/login flow  |
|    2 | Task Module  | CRUD operations                                   |
|    3 | Pet Module   | Pet creation, XP & level logic, task-to-pet link  |
|    4 | Polish       | Daily reset job, UI animation, performance tuning |

---

|  **Week**  | **Focus Area**                               | **Goal**                                                            | **Tech & Azure Learning Topics (AZ-204-aligned)**                                                                                                                                     | **Deliverables**                                                                                                                            |
| :--------: | :------------------------------------------- | :------------------------------------------------------------------ | :------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------ | :------------------------------------------------------------------------------------------------------------------------------------------ |
| **Week 1** | 🧱 **Foundation + Auth**                     | Build frontend & backend skeleton and implement register/login flow | - Azure App Service (host Web API)<br>- Azure SQL Database (migrate DB)<br>- Azure Key Vault (store JWT secret)<br>- Managed Identity for secure access                               | ✅ React + .NET project setup<br>✅ JWT auth flow (register/login)<br>✅ Initial backend deployment to Azure App Service                    |
| **Week 2** | ✅ **Task Module + Data Layer**              | Implement CRUD operations for tasks and persist data on Azure SQL   | - EF Core migration to Azure SQL<br>- Azure Storage Account (optional: file logs or uploads)<br>- Azure App Configuration (manage environment variables)                              | ✅ `/api/tasks` CRUD API<br>✅ Frontend Task Dashboard<br>✅ Database migrated and seeded on Azure SQL                                      |
| **Week 3** | 🐾 **Pet Module + Background Jobs**          | Connect Task ↔ Pet logic and create a daily background reset job    | - Azure Functions (timer trigger for daily reset)<br>- Azure Service Bus (optional event queue)<br>- Azure Monitor (track background job logs)                                        | ✅ `/api/pets` CRUD + XP/Hunger logic<br>✅ Azure Function (daily pet/task reset)<br>✅ Event-driven link between Task and Pet updates      |
| **Week 4** | 🌤 **Deployment + Monitoring + Final Polish** | Deploy full system and integrate cloud monitoring + CI/CD           | - Azure Application Insights (telemetry & logging)<br>- Azure Container Registry (Docker build)<br>- Azure Static Web Apps (host React frontend)<br>- GitHub Actions (CI/CD pipeline) | ✅ CI/CD pipeline (GitHub → Azure)<br>✅ Final UI/UX polish (animations, responsive design)<br>✅ Live application accessible via Azure URL |
