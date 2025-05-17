# Task & Team Management System

## 🚀 Project Overview
The Task & Team Management System is a mini application designed to facilitate task assignment, tracking, and team management with role-based access control. It is built using ASP.NET Core Web API and Entity Framework Core with JWT authentication and CQRS implementation.

---

## ✅ **Features & Functionality:**
- **User Management:** CRUD operations for Admin, Manager, and Employee roles.
- **Team Management:** Create, update, delete, and view teams.
- **Task Management:** Assign tasks, update status, and filter by status, assigned user, team, and due date.
- **Authentication & Authorization:** JWT-based authentication with role-based access control.
- **Logging:** Centralized logging using Serilog.
- **Exception Handling:** Global error handling via middleware.
- **Real-Time Notifications (Optional):** SignalR/WebSockets for task assignment and completion updates.
- **Event-Driven Architecture (Optional):** RabbitMQ integration for task-related events.
- **Docker Support (Optional):** Dockerfile and docker-compose for containerized deployment.

---

## 🛠️ **Technology Stack:**
- .NET Core Web API (Latest LTS)
- Entity Framework Core
- SQL Server (or any other RDBMS)
- MediatR (CQRS Implementation)
- FluentValidation
- JWT Authentication
- Serilog (Logging)
- SignalR / WebSockets (Real-Time Notifications)
- RabbitMQ (Event Messaging)
- Docker & Docker Compose
- xUnit & Moq (Testing)

---

## 👥 **User Credentials:**
- **Admin:** `admin@demo.com` / `Admin123!`
- **Manager:** `manager@demo.com` / `Manager123!`
- **Employee:** `employee@demo.com` / `Employee123!`
