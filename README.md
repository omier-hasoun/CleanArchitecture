# Clean Architecture Template (.NET 10)

A flexible, production-ready **Clean Architecture Template** for building modern .NET 10 applications using Clean Architecture principles, Vertical Slice Architecture, CQRS, MediatR, FluentValidation, EF Core, and architecture tests.

This template is fully **domain-agnostic** — no sample entities or features are included.
You can start every project directly from your domain without being slowed down by repetitive boilerplate setup.

---

## ✨ Key Features

- Clean Architecture structure
- Vertical slice folders (feature-based organization)
- Fully domain-agnostic (no sample entities)
- Generic base entities (ID type selectable per project)
- MediatR configured with validation, logging, and performance behaviors
- FluentValidation pipeline
- Result pattern and error handling built in
- EF Core integration with auditing + soft-delete support
- Serilog structured logging
- Minimal API design with endpoint groups
- API versioning, Swagger/OpenAPI, and global exception handling
- Architecture tests included (layer rules, naming rules, dependency rules)

---

## 🧱 Project Structure

```
📦 CleanArchitectureTemplate
│
├── 📁 Web.Api
│   ├── 📁 Endpoints               # Minimal API endpoints & request/response models
│   └── 📄 DependencyInjection.cs  # API-level DI & pipeline configuration
│
├── 📁 Application
│   ├── 📁 Common
│   │   └── 📁 Abstractions        # Interfaces for services, mapping, caching, etc.
│   ├── 📁 Features                # Each feature slice (CQRS commands, queries, handlers)
│   └── 📄 DependencyInjection.cs  # Application DI (MediatR, Validators, Behaviors)
│
├── 📁 Domain
│   ├── 📁 Common
│   │   └── 📁 Abstractions        # Domain contracts (interfaces that domain *defines*)
│   ├── 📁 Entities                # Each entity slice (aggregate roots, owned types)
│
├── 📁 Infrastructure
│   ├── 📁 Common
│   │   └── 📁 Abstractions        # Infrastructure-specific interfaces (e.g., email provider)
│   ├── 📁 Data
│   │   ├── 📁 Interceptors        # SaveChanges, audit, soft-delete interceptors
│   │   ├── 📁 Migrations          # EF Core migrations
│   │   ├── 📁 Configs             # EF EntityTypeConfiguration files
│   │   └── 📄 AppDbContext.cs     # Main EF DbContext + IdentityDbContext integration
│   ├── 📁 Services                # External integrations (email, storage, cache, etc.)
│   └── 📄 DependencyInjection.cs  # Infrastructure DI (DbContext, Identity, services)
│
└── 📁 Shared
    ├── 📁 Results                 # Result pattern, errors, result markers
    ├── 📁 Constants               # SystemConstants, shared cross-layer constants
    └── 📁 Helpers                 # General-purpose utilities
```

---

## 🧱 Layer Overview

### **Shared**

The Shared layer contains cross-cutting utilities and primitives that are used across multiple projects.
This layer has no dependencies on Domain, Application, Infrastructure, or API — ensuring it remains fully reusable and stable.
All layers can reference this layer.

Included:

🔹 Result pattern

Result<T> as an immutable wrapper for returned values or errors

Provides IResult and IResult<T> interfaces

Supports value and non-value results

Includes predefined markers: Success, Created, Updated, Deleted

Supports implicit conversions from values or errors

Throws InvalidResultAccessException when accessing .Value on a failed result

This pattern ensures clean error handling without relying on exceptions for normal control flow.

🔹 Shared Constants

A collection of cross-project constants, such as:

SystemConstants.SystemId
A predefined Guid used when no user identifier is available.
Automatically applied by Infrastructure for:

Background services

Cron jobs

Seeders

System-triggered events

Auditable entities (CreatedBy, UpdatedBy)

Soft-deletable entities (DeletedBy)

This ensures consistent auditing even when no authenticated user exists.

🔹 Helper Classes

Reusable helpers that do not belong to any specific layer:

No Helper classes implemented yet.

### **Domain**

The Domain layer contains all fundamental building blocks required to model any domain.
It does **not** include any concrete entities — leaving your template clean.
The Domain project has **no dependencies** on any other layer or external library.

Included:

- `BaseEntity<TId>`
  - Generic abstract base class for entities (supports `int`, `Guid`, etc.)
- `AuditableEntity<TId>`
  - Adds `CreatedAtUtc`, `CreatedBy`, `LastModifiedAtUtc`, `LastModifiedBy`
- `SoftDeletableEntity<TId>`
  - Adds `IsDeleted`, `DeletedAtUtc`, `DeletedBy`
- `IDomainEvent`

### **Application**

The Application layer contains all reusable application-level logic and patterns.
No feature folders are included so you can start clean.

Contains:

- CQRS setup using MediatR
- Pipeline behaviors:
  - Validation behavior
  - Logging behavior
  - Performance behavior
- FluentValidation integration
- `Result` and `Error` types
- Interfaces for:
  - Persistence (repositories, unit of work, query services)
  - External services (email, cache, etc.)
- Mapping configuration (Mapster/AutoMapper)

### **Web.Api**

Minimal API setup following modern .NET 10 practices.

Includes:

- Endpoint group structure (vertical slice friendly)
- Global exception middleware
- API versioning
- Swagger/OpenAPI
- Health checks
- Application + Infrastructure bootstrapping

### **Infrastructure**

The Infrastructure layer contains all persistence and external service implementations.
This template uses Entity Framework Core directly — no repository pattern — making Infrastructure intentionally tightly coupled to the ORM for maximum simplicity and maintainability.

Identity integration

Uses IdentityDbContext<AppUser, AppRole, TKey> as the base DbContext

ASP.NET Identity manages users, roles, passwords, tokens, and claims automatically

AppUser (and optional AppRole) reside in Infrastructure for customization

Full Identity: registration, password hashing, email confirmation, refresh tokens (optional)

EF Core DbContext

Unified DbContext for Identity + application tables

Configured auditing (CreatedAt, UpdatedAt, CreatedBy, UpdatedBy)

Configured soft delete (IsDeleted, DeletedAt)

No domain entities included by default—fully domain-agnostic

ORM-centric design

No repository pattern

No UoW abstraction

Application layer interacts directly with EF Core via the DbContext interface

Cleaner and more explicit persistence model

Configuration

Connection string binding

Entity configurations (per entity)

Migration support ready out of the box

Environment-specific appsettings files

Services

Email, file storage, cache, and other external services may be implemented here

Depends on Domain and Application, but never on API.

---

🧪 Architecture Tests

Architecture tests validate:

Layer boundaries (Domain → Application → Infrastructure → API)

No accidental reverse dependencies

No cross-feature coupling in Application

Handlers follow naming conventions

Entities follow your base classes

DTOs and endpoints are placed in the correct layers

---

🏗️ Technologies Used

- .NET 10

- MediatR (12.5.0)

- FluentValidation

- EF Core

- Serilog

- Mapster or AutoMapper (your choice)

- Minimal APIs

- Swagger / OpenAPI

- API Versioning

- HealthChecks

- NetArchTest / ArchUnitNET (architecture testing)

- Docker support (optional)

---

📄 License

This project is free to use for personal and commercial purposes (MIT License).

---
🙌 Contributions

Suggestions and improvements are welcome.
Feel free to open issues or submit PRs.
