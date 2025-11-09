
# Smart Clinic Appointment & Prescription API

Smart Clinic is a **RESTful ASP.NET Core Web API** for managing clinic appointments, doctors, patients, medications, and prescriptions. The API supports **CRUD operations**, **authentication**, **authorization**, and **data validation**. It can be consumed by mobile or web front-ends.

---

## Table of Contents

* [Project Overview](#project-overview)
* [Core Functional Requirements](#core-functional-requirements)
* [Key System Modules](#key-system-modules)
* [Validation Rules](#validation-rules)
* [Architecture](#architecture)
* [Technologies](#technologies)
* [Getting Started](#getting-started)
* [Database Setup](#database-setup)
* [Running the API](#running-the-api)
* [API Endpoints](#api-endpoints)
* [Swagger Documentation](#swagger-documentation)
* [Project Structure](#project-structure)
* [License](#license)
* [Author](#author)

---

## Project Overview

Build a RESTful ASP.NET Core Web API for managing clinic appointments, doctors, patients, and prescriptions. The API should support **CRUD operations**, **authentication**, **authorization**, and proper **data validation**. 

The system will be consumed later by mobile or web front-end applications.

---

## Core Functional Requirements

* Support **separate registration & login** for Doctors and Patients.
* **Doctors** can create, update, and cancel appointments.
* **Patients** can book, update, or cancel their own appointments only.
* **Doctors** can create **electronic prescriptions** for attended patients.
* **Patients** can view their own prescriptions.
* **Admin** role manages doctor accounts, patient accounts, medications, and system data.

---

## Key System Modules

### 1. Authentication & Authorization

* JWT-based authentication.
* Roles: **Admin**, **Doctor**, **Patient**.
* Role-based access control on all endpoints.

### 2. Users Module (Admin Only)

* CRUD operations for **Doctor** accounts.
* CRUD operations for **Patient** accounts.
* Strong password policies for account creation.

### 3. Appointments Module

* Create appointment (Patient).
* Approve/Reject appointment (Doctor).
* Reschedule appointment (Doctor/Patient based on rules).
* Cancel appointment (Patient for self, Doctor for their appointments).
* List appointments by **Doctor** or **Patient**.
* Prevent overlapping appointments for the same doctor.

### 4. Prescriptions Module

* Doctor can create prescriptions only for **attended appointments**.
* Prescription contains:
  - Medication list
  - Dosage
  - Instructions
* Patients can view their prescriptions only.

### 5. Medications Module

* CRUD for medications (**Admin only**).
* Medications are referenced in prescriptions.

---

## Validation Rules

* Appointment time must be in the **future**.
* No overlapping appointments for the same doctor at the same time.
* Prescriptions can only be created after a **completed appointment**.
* Strong password rules for account creation.

---

## Architecture

The project follows **Clean Architecture / Layered Architecture**:

* **SmartClinic.Core** – Entities, DTOs, Interfaces.
* **SmartClinic.Infrastructure** – EF Core DbContext, Repositories, Services.
* **SmartClinic.API** – Controllers, Program.cs, Swagger, Authentication.

---

## Technologies

* .NET 8 / ASP.NET Core Web API
* Entity Framework Core 8
* SQL Server (LocalDB)
* JWT Authentication
* Swagger / Swashbuckle
* Repository & Service patterns
* Dependency Injection

---

## Getting Started

1. Clone the repository:

```bash
git clone <your-repo-url>
cd SmartClinic
```

2. Create solution and projects:

```bash
dotnet new sln -n SmartClinic
dotnet new classlib -n SmartClinic.Core
dotnet new classlib -n SmartClinic.Infrastructure
dotnet new webapi -n SmartClinic.API
```

3. Add projects to solution and references:

```bash
dotnet sln add SmartClinic.Core/SmartClinic.Core.csproj
dotnet sln add SmartClinic.Infrastructure/SmartClinic.Infrastructure.csproj
dotnet sln add SmartClinic.API/SmartClinic.API.csproj

cd SmartClinic.Infrastructure
dotnet add reference ../SmartClinic.Core/SmartClinic.Core.csproj
cd ../SmartClinic.API
dotnet add reference ../SmartClinic.Core/SmartClinic.Core.csproj
dotnet add reference ../SmartClinic.Infrastructure/SmartClinic.Infrastructure.csproj
cd ..
```

4. Install NuGet packages:

```bash
# API project
cd SmartClinic.API
dotnet add package Swashbuckle.AspNetCore
dotnet add package Microsoft.EntityFrameworkCore.SqlServer
dotnet add package Microsoft.EntityFrameworkCore.Design
dotnet add package Microsoft.AspNetCore.Authentication.JwtBearer
cd ../SmartClinic.Infrastructure
dotnet add package Microsoft.EntityFrameworkCore
dotnet add package Microsoft.EntityFrameworkCore.SqlServer
cd ..
```

---

## Database Setup

1. Install EF tools (if not installed globally):

```bash
dotnet tool install --global dotnet-ef
```

2. Create initial migration and update database:

```bash
dotnet ef migrations add InitialCreate -p SmartClinic.Infrastructure -s SmartClinic.API
dotnet ef database update -p SmartClinic.Infrastructure -s SmartClinic.API
```

> The database will include **Users (Doctors, Patients, Admin), Appointments, Medications, Prescriptions, PrescriptionItems**.

---

## Running the API

```bash
cd SmartClinic.API
dotnet run
```

* Open Swagger UI: `https://localhost:5001/` or `http://localhost:5000/`
* Explore endpoints for **Doctors, Patients, Appointments, Medications, Prescriptions**.

---

## API Endpoints

### Authentication

* `POST /api/auth/register` – Register a new user (Patient/Doctor)
* `POST /api/auth/login` – Login and receive JWT token

### Doctors (Admin Only)

* `GET /api/doctors`
* `GET /api/doctors/{id}`
* `POST /api/doctors`
* `PUT /api/doctors/{id}`
* `DELETE /api/doctors/{id}`

### Patients (Admin Only)

* `GET /api/patients`
* `GET /api/patients/{id}`
* `POST /api/patients`
* `PUT /api/patients/{id}`
* `DELETE /api/patients/{id}`

### Appointments

* `POST /api/appointments` – Create (Patient)
* `GET /api/appointments/{id}` – Get by id
* `GET /api/appointments/by-doctor/{doctorId}`
* `GET /api/appointments/by-patient/{patientId}`
* `PUT /api/appointments/{id}` – Update
* `POST /api/appointments/{id}/cancel`
* `POST /api/appointments/{id}/approve`
* `POST /api/appointments/{id}/reject`

### Medications (Admin Only)

* `GET /api/medications`
* `GET /api/medications/{id}`
* `POST /api/medications`
* `PUT /api/medications/{id}`
* `DELETE /api/medications/{id}`

### Prescriptions

* `POST /api/prescriptions` – Create (Doctor for attended appointments)
* `GET /api/prescriptions/{id}`
* `GET /api/prescriptions/by-patient/{patientId}`

---

## Swagger Documentation

* Swagger UI is automatically available at `/`
* All endpoints are documented with **XML comments** and **DTO schemas**

---

## Project Structure

```
SmartClinic/
├─ SmartClinic.Core/           # Entities, DTOs, Interfaces
├─ SmartClinic.Infrastructure/ # DbContext, Repositories, Services
├─ SmartClinic.API/            # Controllers, Program.cs, Swagger, Authentication
├─ SmartClinic.sln
```

---

## License

MIT License. See [LICENSE](LICENSE) for details.

---

## Author

Ahmed Elgndy – Backend Developer – Real-time REST API with Clean Architecture
