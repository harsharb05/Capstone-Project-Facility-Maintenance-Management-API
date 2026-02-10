# 🏢 Facility Maintenance Management API

![.NET](https://img.shields.io/badge/.NET-ASP.NET%20Core-blueviolet)
![MVC](https://img.shields.io/badge/Architecture-MVC-success)
![REST](https://img.shields.io/badge/API-RESTful-blue)
![Swagger](https://img.shields.io/badge/Docs-Swagger-green)
![Status](https://img.shields.io/badge/Status-Completed-brightgreen)

A RESTful Web API built using ASP.NET Core MVC to manage facilities,
maintenance requests, and technicians efficiently.

------------------------------------------------------------------------

## 📌 Overview

The Facility Maintenance Management API provides a backend solution for
tracking maintenance activities across facilities.

------------------------------------------------------------------------

## 🛠️ Tech Stack

-   C#
-   ASP.NET Core Web API
-   MVC Architecture
-   MySQL
-   REST API
-   Swagger
-   Git

------------------------------------------------------------------------

## ✨ Features

-   CRUD operations
-   Maintenance tracking
-   Technician assignment
-   Status updates
-   RESTful routing

------------------------------------------------------------------------

## 🌐 API Endpoints

### Facility

GET /api/facilities\
GET /api/facilities/{id}\
POST /api/facilities\
PUT /api/facilities/{id}\
DELETE /api/facilities/{id}\

### Requests

GET /api/requests\
GET /api/requests/{id}\
GET /api/facilities/{facilitiyId}/requests\
POST /api/requests\
PUT /api/requests/{id}\
DELETE /api/requests/{id}\

### Technicians

GET /api/technicians\
GET /api/technicians/{id}\
POST /api/technicians\
PUT /api/technicians/{id}\
DELETE /api/technicians/{id}\

------------------------------------------------------------------------


---

## ⚙️ Setup & Run Locally

### Prerequisites
- .NET SDK
- SQL Server
- Visual Studio / VS Code
- Git

### Steps

```bash
git clone https://github.com/your-username/facility-management-api.git
cd facility-management-api
dotnet run


------------------------------------------------------------------------

## 👨‍💻 Author

Harsha Bhatkere

------------------------------------------------------------------------

