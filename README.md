# 🚗 Car Service Management System

### **One system. Every vehicle. Every service. Total control.**

A backend-focused **Car Service Management System** built with **ASP.NET Core, Entity Framework Core, and SQL Server**.

The system is designed to manage the daily operations of a car service organization — from customers and vehicles to branches, employees, maintenance services, rentals, and emergency assistance.

> **From the customer's first visit to the vehicle's complete service history — everything stays connected.**

---

## ⚡ What is CSMS?

Running a car service business involves much more than repairing cars.

You need to know:

* 👤 Who owns the vehicle?
* 🚘 Which cars belong to each customer?
* 🔧 What services has a car received?
* 👨‍🔧 Which employee performed the service?
* 🏢 Which branch handled it?
* 🚨 Which vehicles and drivers are available for emergencies?
* 🚙 Which cars are currently available for rent?

**CSMS connects all of these operations into one relational system.**

---

# ✨ Main Features

## 👤 Customer Management

Manage customer information and their vehicles in one place.

* Customer registration
* Customer contact information
* Unique email and phone numbers
* Customer → Vehicle relationships
* Customer vehicle history

---

## 🚘 Vehicle Management

Keep detailed information about every registered vehicle.

Each vehicle can contain:

* License plate
* Company
* Model
* Color
* Number of cylinders
* Manufacturing date
* Fuel type
* Engine type
* Customer ownership

### ⛽ Fuel Types

The system supports:

* Gasoline
* Diesel
* Electric
* Hybrid

### ⚙️ Engine Types

The system supports:

* Turbocharged
* Naturally Aspirated
* Supercharged

---

# 🔧 Vehicle Service Management

Track the complete maintenance history of every vehicle.

A service is connected to:

```text
Customer
   │
   └── Vehicle
         │
         └── Service
               ├── Employee
               ├── Branch
               └── Service Date
```

This allows the system to keep track of **who serviced the vehicle, where it was serviced, and when the service happened.**

---

# 🏢 Branch Management

The system supports multiple service branches.

Branches can be connected with:

* Employees
* Managers
* Services
* Emergency requests
* Emergency trucks

This allows the organization to manage operations across different locations.

---

# 👨‍🔧 Employee Management

Employees are assigned to branches and can participate in vehicle services.

The system maintains relationships between:

```text
Branch
   ↓
Employee
   ↓
Vehicle Service
```

This makes it possible to track service responsibility across the organization.

---

# 🚨 Emergency Service

Vehicle problems don't always happen at the service center.

CSMS includes an emergency service system for handling roadside assistance.

### Emergency components

* 🚑 Emergency trucks
* 👨‍✈️ Drivers
* 📍 Branches
* 🚨 Emergency requests
* 🚘 Customer vehicles

The system can manage driver availability and connect emergency requests with the appropriate resources.

---

# 🚙 Car Rental

The system also includes vehicle rental management.

It provides relationships between:

```text
Customer
   ↓
Rental
   ↓
Vehicle
```

This allows rental vehicles and their customers to be tracked within the same system.

---

# 🧠 Database Design

The project uses a relational database designed around the real-world relationships between the main entities.

The core structure includes:

```text
Customer
   │
   ├──────────────► Cars
   │                  │
   │                  └────────► Services
   │                                  │
   │                                  ├── Employee
   │                                  │
   │                                  └── Branch
   │
   └──────────────► Rental
```

Additional relationships handle:

```text
Branch
 ├── Employees
 ├── Manager
 ├── Services
 └── Emergency Requests

Emergency Truck
 ├── Branch
 ├── Driver
 └── Emergency Requests
```

---

# 🛠️ Technology Stack

| Technology                   | Purpose                       |
| ---------------------------- | ----------------------------- |
| 🟣 **C#**                    | Main programming language     |
| 🔵 **ASP.NET Core**          | Backend framework             |
| 🟢 **Entity Framework Core** | ORM / database access         |
| 🗄️ **SQL Server**           | Relational database           |
| 🔍 **LINQ**                  | Data querying                 |
| 🧩 **MVC / Web API**         | Application architecture      |
| 🧪 **Swagger**               | API testing and documentation |
| 💻 **Visual Studio**         | Development environment       |
| 🌱 **Git & GitHub**          | Version control               |

---

# 🏗️ Project Structure

The project follows a structured backend organization:

```text
Car_Service_Management_System
│
├── Data/
│   └── ApplicationDbContext
│
├── Enums/
│   ├── Fuel Type
│   └── Engine Type
│
├── Model/
│   ├── Customer
│   ├── Car
│   ├── Service
│   ├── Employee
│   ├── Branch
│   ├── Driver
│   ├── EmergencyTruck
│   ├── EmergencyRequest
│   └── Rental Models
│
├── Migrations/
│
├── Controllers/
│
├── Program.cs
│
└── appsettings.json
```

---

# 🔗 Entity Relationships

One of the main goals of the project is implementing realistic relational database relationships using Entity Framework Core.

Examples include:

### Customer → Cars

```text
One Customer
      │
      ├── Car
      ├── Car
      └── Car
```

### Car → Services

```text
One Car
   │
   ├── Service
   ├── Service
   └── Service
```

### Branch → Employees

```text
One Branch
    │
    ├── Employee
    ├── Employee
    └── Employee
```

These relationships allow the system to represent real-world service-center operations rather than treating each record as isolated data.

---

# 🗄️ Entity Framework Core

Database operations are handled through **Entity Framework Core**.

The project uses:

* `DbContext`
* Entity relationships
* Foreign keys
* Navigation properties
* Fluent API configuration
* Migrations
* LINQ queries
* Constraints
* Delete behaviors

Example relationship configuration:

```csharp
modelBuilder.Entity<Car>()
    .HasOne(c => c.Customer)
    .WithMany(c => c.Cars)
    .HasForeignKey(c => c.CustomerId);
```

---

# 🔎 LINQ

The project uses LINQ for querying and working with relational data.

Examples include:

* Filtering vehicles
* Grouping cars
* Joining customers and vehicles
* Retrieving service history
* Selecting specific data
* Working with related entities

This allows complex database queries to remain readable and strongly typed.

---

# 🌐 API

The project is being developed with backend/API functionality so that the system can expose its data and operations to clients.

API functionality can be tested through:

**Swagger UI**

```text
/swagger
```

or through tools such as:

* Postman
* Swagger
* Frontend applications

---

# 🔐 Data Integrity

The database includes constraints designed to keep the data consistent.

Examples include:

* Unique customer email
* Unique customer phone
* Foreign-key relationships
* Required fields
* Maximum string lengths
* Controlled delete behaviors
* Enum-based vehicle properties

The goal is to make invalid or inconsistent data harder to enter into the system.

---

# 🚀 Getting Started

## 1️⃣ Clone the repository

```bash
git clone https://github.com/hassanm55cs/car_management_service_system.git
```

## 2️⃣ Enter the project

```bash
cd car_management_service_system
```

## 3️⃣ Configure SQL Server

Update the connection string in:

```text
appsettings.json
```

Example:

```json
{
  "ConnectionStrings": {
    "DefaultConnection": "Server=localhost\\SQLEXPRESS;Database=Car_Services;Trusted_Connection=True;TrustServerCertificate=True"
  }
}
```

> Change the connection string according to your local SQL Server configuration.

---

## 4️⃣ Apply migrations

Run:

```bash
dotnet ef database update
```

---

## 5️⃣ Run the project

```bash
dotnet run
```

Then open the Swagger interface provided by the application.

---

# 📊 Example System Flow

A typical vehicle journey through the system looks like this:

```text
👤 Customer
      │
      ▼
🚘 Registers Vehicle
      │
      ▼
🏢 Visits Branch
      │
      ▼
🔧 Vehicle Receives Service
      │
      ▼
👨‍🔧 Employee Performs Service
      │
      ▼
🗓️ Service Is Recorded
      │
      ▼
📚 Vehicle Service History
```

And when something goes wrong on the road:

```text
🚘 Vehicle
      │
      ▼
🚨 Emergency Request
      │
      ▼
🏢 Branch
      │
      ▼
🚑 Emergency Truck
      │
      ▼
👨‍✈️ Available Driver
      │
      ▼
✅ Assistance
```

---

# 🎯 Project Goals

This project was built to practice and demonstrate real backend development concepts including:

* Database design
* Entity relationships
* Entity Framework Core
* SQL Server
* LINQ
* MVC architecture
* REST API development
* CRUD operations
* Foreign keys
* Data validation
* Migrations
* Business rules
* Git & GitHub

---

# 💡 What This Project Demonstrates

**CSMS isn't just a CRUD project.**

It focuses on modeling a real-world business system where multiple entities interact with each other through meaningful relationships.

The project demonstrates how backend development can transform a complex real-world workflow into a structured, maintainable database-driven application.

---

# 📈 Future Improvements

Possible future improvements include:

* 🔐 Authentication & Authorization
* 🎟️ JWT-based authentication
* 👥 Role-based access control
* 📊 Admin dashboard
* 📅 Service scheduling
* 🔔 Maintenance reminders
* 📱 Mobile/client application
* 💳 Payment management
* 📈 Business analytics
* 🌐 Complete frontend interface

---

# 👨‍💻 Developer

**Mostafa Hassan**

Computer Science Student
Backend Developer | .NET

### Connect with me

* 💼 LinkedIn: [Mostafa Hassan](https://linkedin.com/in/hassan55)
* 💻 GitHub: [HassanM55](https://github.com/HassanM55)

---

# ⭐ Project

**Car Service Management System**

> ### 🚗 Manage the cars.
>
> ### 🔧 Track the services.
>
> ### 🏢 Connect the branches.
>
> ### 🚨 Handle emergencies.
>
> ### 📊 Control the operation.

**Built with .NET. Designed around real-world problems.**
