# Elective I – Event Driven Programming (C# & .NET)

This repository contains all projects and practical exercises developed for the  
**Elective I course: Event Driven Programming**, implemented using **C# and .NET**.

The purpose of this repository is to demonstrate **event-driven concepts**, **console applications**, and **Web API development** using both **Minimal API** and **Controller-Based API** architectures in ASP.NET Core.

---

## 📂 Repository Structure

```plaintext
Elective-1/
│
├── ConsoleApps/
│   └── PokemanPractical
│
├── WebAPIs/
│   ├── MinimalAPI/
│   │   └── PokemanMinimalApi
│   │
│   └── ControllerAPI/
│       └──PokemanContrellerApi
│
└── README.md

```
## 🧩 Project Categories

### 1️⃣ Console Applications
📁 **ConsoleApps/**

This folder contains C# console applications focused on **core event-driven programming concepts**, including:

- Events and Delegates  
- Publisher–Subscriber pattern  
- Asynchronous programming (`async` / `await`)  
- Timers and callbacks  

These projects help build a strong foundation in **event-driven logic** without using web frameworks.

---

### 2️⃣ Web APIs
📁 **WebAPIs/**

This folder contains **ASP.NET Core Web API projects**, organized into two main architectural styles.

---

## 🔹 Minimal API Projects
📁 **WebAPIs/MinimalAPI/**

Minimal APIs provide a **lightweight and simplified approach** to building Web APIs in ASP.NET Core.

### Characteristics
- Endpoints defined directly in `Program.cs`
- Minimal boilerplate code
- Faster development and learning curve
- Suitable for small services and learning HTTP fundamentals

### Concepts Covered
- HTTP methods (`GET`, `POST`, `PUT`, `DELETE`)
- Routing and endpoint mapping
- Request and response handling
- Event-driven logic inside API endpoints
- Swagger / OpenAPI integration

---

## 🔹 Controller-Based API Projects
📁 **WebAPIs/ControllerAPI/**

Controller-based APIs follow the **traditional ASP.NET Core Web API architecture**, suitable for larger and more structured applications.

### Characteristics
- Uses Controllers and Models
- Attribute-based routing
- Clear separation of concerns
- More scalable and maintainable structure

### Concepts Covered
- RESTful API design
- Controllers and actions
- Model binding and validation
- HTTP status codes
- Event-driven patterns in Web APIs
- Swagger / OpenAPI integration

---

## 🛠 Technologies Used

- C#
- .NET 8 / .NET 9
- ASP.NET Core
- Console Applications
- Minimal API
- Controller-Based API
- RESTful Web Services
- Swagger / OpenAPI

---

## ▶ How to Run Any Project

Navigate to the specific project directory and run:

```bash
dotnet restore
dotnet run
