# LibrarySystem APIs

`LibrarySystem APIs` is an ASP.NET Core Web API project for managing a library domain, including books, authors, categories, physical book copies, people (customers/employees), and operations (borrow/buy/refund/fine flows).

## Tech Stack

- **.NET 9** (`net9.0`)
- **ASP.NET Core Web API**
- **Entity Framework Core 9**
- **SQL Server** (`Microsoft.EntityFrameworkCore.SqlServer`)
- **OpenAPI** (`Microsoft.AspNetCore.OpenApi`)

## Solution Structure

```text
LibrarySystem_APIs/
├── LibrarySystem.slnx
└── LibrarySystem/
    ├── Controllers/            # API endpoints (currently scaffolded AuthorController)
    ├── DTOs/                   # Request/response contracts + DataAnnotations validation
    ├── Data/                   # DbContext + EF Core entity configurations
    ├── Interfaces/             # Service contracts
    ├── Service/                # Business/service implementations (currently Author + Book)
    ├── Models/                 # Domain entities + enums
    ├── Migrations/             # EF Core migration snapshot/history
    ├── Program.cs              # App bootstrap, DI, middleware setup
    ├── appsettings*.json       # Runtime/environment configuration
    └── Properties/launchSettings.json
```

## Current Architecture

The project follows a **layered architecture**:

1. **Presentation Layer**  
   `Controllers/*`
2. **Application/Service Layer**  
   `Interfaces/*` + `Service/*`
3. **Data Access Layer**  
   `Data/LibraryDbContext.cs` + `Data/Configurations/*`
4. **Domain Layer**  
   `Models/*`
5. **Transport Contracts**  
   `DTOs/*`

> Note: The architecture is partially implemented. Service interfaces exist for multiple features, while concrete implementations and controllers are currently incomplete in some areas.

## Domain Overview

### Core Entities

- **Author** (`Models/Books/Author.cs`)
- **Category** (`Models/Books/Category.cs`)
- **Book** (`Models/Books/Book.cs`)
- **BookCopy** (`Models/Books/BookCopy.cs`)
- **Person** (abstract) (`Models/People/Person.cs`)
  - **Customer** (`Models/People/Customer.cs`)
  - **Employee** (`Models/People/Employee.cs`)
- **Address** (`Models/People/Address.cs`)
- **Operation** (`Models/Operation.cs`)

### Key Relationships

- Author `1 -> *` Books
- Category `1 -> *` Books
- Book `1 -> *` BookCopies
- BookCopy `1 -> *` Operations
- Person (TPH) with derived Customer/Employee
- Person `1 -> *` Addresses
- Customer `1 -> *` Operations
- Employee `1 -> *` Operations

All relationship mappings and constraints are configured in:

- `Data/Configurations/*.cs`
- `Migrations/20260714094031_LibraryDb.cs`

## Database

The generated migration currently creates:

- `Person`
- `TbAuthors`
- `TbCategories`
- `TbBooks`
- `TbBooksCopies`
- `TbAddresses`
- `TbOperations`

The inheritance model for `Person/Customer/Employee` uses **TPH (Table-per-Hierarchy)** with a `Discriminator` column.

## Validation

DTOs use **DataAnnotations** for input validation, including:

- `[Required]`
- `[MaxLength]`
- `[Range]`
- `[EmailAddress]`
- `[Phone]`
- `[EnumDataType]`

Examples can be found in:

- `DTOs/BooksDTOs/*`
- `DTOs/PeopleDTOs/*`
- `DTOs/OperationDtos/*`

## Dependency Injection & Middleware

Configured in `Program.cs`:

- `AddControllers()`
- `AddOpenApi()`
- `AddDbContext<LibraryDbContext>(UseSqlServer(...))`

Pipeline:

- Development-only OpenAPI mapping
- HTTPS redirection
- Authorization middleware
- Controller endpoint mapping

> Current status: authentication schemes and custom service registrations are not yet wired.

## API Surface (Current Status)

`Controllers/AuthorController.cs` exists and is scaffolded with placeholder endpoints:

- `GET /api/Author/Get`
- `GET /api/Author/Get/{id}`
- `POST /api/Author/Post`
- `PUT /api/Author/Put/{id}`
- `DELETE /api/Author/Delete/{id}`

Business logic currently implemented in services:

- `Service/BookService/AuthorService.cs`
- `Service/BookService/BookService.cs`

## Configuration

- `appsettings.json`
  - Connection string (`DefaultConnection`)
  - Logging configuration
  - Allowed hosts
- `appsettings.Development.json`
  - Development logging overrides
- `Properties/launchSettings.json`
  - Local run profiles and URLs

Default local connection string targets LocalDB:

```json
"Server=(localdb)\\MSSQLLocalDB;Database=LibrarySystemDB;Trusted_Connection=True;TrustServerCertificate=True;"
```

## Getting Started

### Prerequisites

- .NET SDK 9.0+
- SQL Server / LocalDB (or update connection string for your SQL Server instance)

### Run

From repository root:

```bash
dotnet build
dotnet test
dotnet run --project /home/runner/work/LibrarySystem_APIs/LibrarySystem_APIs/LibrarySystem/LibrarySystem.csproj
```

### OpenAPI

In development environment, OpenAPI is mapped by `Program.cs` via `app.MapOpenApi()`.

## Known Gaps / Next Steps

1. Complete controller implementations and connect to service layer.
2. Register all services in DI.
3. Implement missing service classes for existing interfaces.
4. Add authentication + authorization policies.
5. Add global exception handling and standardized problem responses.
6. Replace plain password storage with secure hashing.
7. Add automated unit/integration tests for service and controller behavior.

## License

No license file is currently present in this repository.
