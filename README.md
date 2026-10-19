# Company Employees

An ASP.NET Core and Entity Framework Core project for a company and employee domain. The solution is organized into separate API, application, domain, and infrastructure projects and includes SQL Server persistence, EF Core migrations, seeded sample records, and Serilog logging.

> **Project status:** The solution currently provides the domain model and persistence foundation. Company and employee HTTP endpoints and application-service operations have not been implemented yet. This README describes the current code rather than implying CRUD functionality that is not present.

## Technology

- .NET 10 / ASP.NET Core
- Entity Framework Core 10 with SQL Server
- Serilog console and rolling-file sinks
- Layered solution structure

## Solution structure

| Project | Responsibility |
| --- | --- |
| `Api` | ASP.NET Core host, dependency registration, CORS, and request logging |
| `Application` | Service and repository contracts, service classes, and application dependency registration |
| `Domain` | `Company` and `Employee` entities |
| `Infrastructure` | EF Core context, SQL Server configuration, migrations, seed data, repositories, and unit of work |

The database model relates employees to companies and configures field constraints and cascade deletion. Existing migrations create the schema and seed example companies and employees.

## Requirements

- .NET 10 SDK
- SQL Server, for applying the migrations
- EF Core command-line tools, for database migrations

## Configuration

The SQL Server connection string is provided through the standard .NET configuration environment-variable convention. In PowerShell, set it for the current terminal before running database commands:

```powershell
$env:ConnectionStrings__sqlConnection = "Server=localhost;Database=CompanyEmployees;Trusted_Connection=True;TrustServerCertificate=True"
```

Use a connection string appropriate for your SQL Server installation. Do not commit credentials or machine-specific connection strings to `appsettings*.json`.

## Build and run

From the repository root:

```powershell
dotnet build .\CompanyEmployees.slnx
dotnet run --project .\Api\Api.csproj
```

The supplied launch profiles use `http://localhost:5000` and `https://localhost:5001`. The host starts, but there are no company or employee routes to call yet.

## Database migrations

After setting the connection string and installing the EF Core CLI tool if needed, apply the existing migrations from the repository root:

```powershell
dotnet ef database update --project .\Infrastructure\Infrastructure.csproj --startup-project .\Api\Api.csproj
```

## Logging

Serilog is configured for console output and daily rolling files under `Api/Logs`. Log files are generated at runtime and are excluded from version control.

## CV-ready summary

> Built a .NET 10 solution using a layered architecture, with an EF Core SQL Server data model, migrations and seed data, repository/unit-of-work abstractions, dependency injection, and Serilog logging.

When HTTP endpoints or service operations are implemented, update this summary to describe those behaviors specifically.
