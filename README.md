# Clean Architecture Template (.NET 10)

A flexible, production-ready **Clean Architecture Template** for building modern .NET 10 applications using Clean Architecture principles, Vertical Slice Architecture, CQRS, MediatR, FluentValidation, EF Core, and architecture tests.

This template is fully **domain-agnostic** — no sample entities or features are included.
You can start every project directly from your domain without being slowed down by repetitive boilerplate setup.

---

## ✨ Features

- **Clean Architecture**
  - Domain, Application, Infrastructure, and API layers with strict boundaries.

- **Vertical Slice Architecture**
  - Feature-based folder structure with isolated commands, queries, endpoints, and validators.

- **CQRS with MediatR**
  - Clear separation between reads and writes with pipeline behaviors.
  - Validation, logging, and performance behaviors included out of the box.

- **FluentValidation Integration**
  - Automatic validation for all requests.

- **EF Core Persistence Layer**
  - Preconfigured DbContext, migrations setup, and infrastructure abstractions.
  - No domain models — so your project remains domain-driven from the start.

- **Serilog Logging**
  - Structured logging integrated with minimal APIs.

- **Global Error Handling**
  - Consistent error responses and ProblemDetails output.

- **API Versioning & Swagger**
  - Versioned endpoints and automatic OpenAPI documentation.

- **Health Checks**
  - Ready for container environments and service monitoring.

- **Architecture Tests Included**
  - Enforces Clean Architecture rules and prevents accidental boundary violations.

- **Fully Domain-Agnostic**
  - The template is a scaffold — your domain defines the actual application logic.

---

## 🧱 Project Structure

src/
Api/
└── Endpoints/
Application/
├── Behaviors/
├── Common/
├── Interfaces/
└── DependencyInjection.cs
Domain/
├── Common/
└── DependencyInjection.cs
Infrastructure/
├── Persistence/
├── Services/
├── Configurations/
└── DependencyInjection.cs

tests/
UnitTests/
IntegrationTests/
ArchitectureTests/

- **Domain**
  Contains core business rules: entities, value objects, domain events, and interfaces.
  *This layer has no dependencies.*

- **Application**
  Contains commands, queries, handlers, validators, DTOs, and application logic.
  Depends only on **Domain**.

- **Infrastructure**
  Contains EF Core, external service implementations, authentication, persistence.
  Depends on **Application** and **Domain**, but never on **API**.

- **API**
  Contains minimal API endpoints, request/response models, dependency injection, and configuration.

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


📄 License

This project is free to use for personal and commercial purposes.

🙌 Contributions

Suggestions and improvements are welcome.
Feel free to open issues or submit PRs.
