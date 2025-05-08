# dashboard-api
# Dashboard Solution

A clean architecture based solution for managing customer and invoice data.

## Project Structure

The solution follows clean architecture principles, separating concerns into different projects:

### Core Layer
- **Dashboard.Domain**: Contains business entities and domain logic
  - Entities (Customer, Invoice)
  - Value objects, enums, and exceptions

- **Dashboard.Application**: Contains business use cases and interfaces
  - Service interfaces
  - DTOs and mapping
  - Business logic and validation

### Infrastructure Layer
- **Dashboard.Infrastructure**: Contains implementation of interfaces
  - Service implementations
  - External API integrations
  - Logging, caching, etc.

- **Dashboard.Persistence**: Contains data access code
  - DbContext
  - Repositories
  - Migrations
  - Data configuration

### Presentation Layer
- **Dashboard.API**: Contains the API endpoints
  - Controllers
  - Middleware
  - API configuration

## Dependencies

The project follows the dependency rule of clean architecture:
- Domain has no dependencies
- Application depends only on Domain
- Infrastructure depends on Application
- Persistence depends on Application
- API depends on Application, Infrastructure, and Persistence

## Getting Started

1. Clone the repository
2. Update the connection string in `src/Presentation/Dashboard.API/appsettings.json`
3. Run the following commands:

```bash
dotnet restore
dotnet build
dotnet run --project src/Presentation/Dashboard.API/Dashboard.API.csproj