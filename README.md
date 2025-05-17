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

## 📦 **Installation & Setup:**
1. **Clone the repository:**
   ```bash
   git clone https://github.com/username/task-team-management-system.git
   cd task-team-management-system
   ```

2. **Update Connection String:**
   - Update the `appsettings.json` file with your database connection details.

3. **Apply Migrations & Seed Data:**
   ```bash
   cd TaskManagement.DAL
   dotnet ef migrations add InitialCreate
   dotnet ef database update
   ```

4. **Run the Application:**
   ```bash
   cd TaskManagement.API
   dotnet run
   ```

5. **Access API Documentation:**
   - Navigate to `https://localhost:{port}/swagger` to access Swagger UI.

---

## 🔥 **Bonus Implementations:**
- **Docker Setup:** A `Dockerfile` and `docker-compose.yml` are included for containerized deployment.
- **Message Queue:** RabbitMQ setup for task-related events.
- **Real-Time Notifications:** SignalR implementation for live task updates.

---

## 👥 **User Credentials:**
- **Admin:** `admin@demo.com` / `Admin123!`
- **Manager:** `manager@demo.com` / `Manager123!`
- **Employee:** `employee@demo.com` / `Employee123!`

---

## ✅ **License:**
This project is licensed under the MIT License. See the `LICENSE` file for more details.

---

Would you like me to add more details, such as specific endpoints, screenshots, or further instructions?
