# LibrarySystem APIs

A basic ASP.NET Core Web API for a library management domain, using Entity Framework Core with SQL Server.

## Tech Stack

- .NET 9 (ASP.NET Core Web API)
- Entity Framework Core 9
- SQL Server / LocalDB
- OpenAPI (development only)

## Project Structure

- `LibrarySystem/Program.cs` – app startup and dependency registration
- `LibrarySystem/Data` – `LibraryDbContext` and EF Core entity configurations
- `LibrarySystem/Models` – domain entities (Books, Authors, Customers, Employees, Operations, etc.)
- `LibrarySystem/Migrations` – EF Core migrations
- `LibrarySystem/Controllers` – API controllers (currently `AuthorController` scaffold)

## Prerequisites

- .NET 9 SDK
- SQL Server instance (default config uses LocalDB)

## Configuration

Connection string is defined in:

- `LibrarySystem/appsettings.json` (`ConnectionStrings:DefaultConnection`)

Default value:

```json
"Server=(localdb)\\MSSQLLocalDB;Database=LibrarySystemDB;Trusted_Connection=True;TrustServerCertificate=True;"
```

Update this for your environment if needed.

## Getting Started

From repository root:

```bash
dotnet restore
dotnet build
```

Apply database migrations:

```bash
dotnet ef database update --project LibrarySystem
```

Run the API:

```bash
dotnet run --project LibrarySystem
```

## API

Current controller route pattern:

- `[Route("api/[controller]/[action]")]`

Example available endpoints (from `AuthorController`):

- `GET /api/Author/Get`
- `GET /api/Author/Get/{id}`
- `POST /api/Author/Post`
- `PUT /api/Author/Put/{id}`
- `DELETE /api/Author/Delete/{id}`

> Note: `AuthorController` is currently scaffolded and returns placeholder values.

## OpenAPI

OpenAPI document is mapped in development environment:

- `GET /openapi/v1.json`

## Database Domain Overview

Main entities represented in the current model:

- `Author`, `Book`, `BookCopy`, `Category`
- `Person` (base), `Customer`, `Employee`, `Address`
- `Operation` (links customer, employee, and book copy transactions)

## Useful Commands

```bash
dotnet build
dotnet test
```
