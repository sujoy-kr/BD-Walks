# BDWalks - ASP.NET Core Web API (.NET 9)

**BDWalks** is a simple RESTful Web API built using **ASP.NET Core .NET 9**. This project focuses on implementing a clean and modular API for managing walking tracks and regions in Bangladesh. It includes JWT authentication, image upload, and role-based authorization.

## Features

-   User registration and login with JWT-based authentication
-   Role-based authorization (`Reader`, `Writer`)
-   CRUD operations for:

    -   Regions
    -   Walks
    -   Images

-   Image upload to local storage
-   AutoMapper integration for DTO mapping
-   Custom model validation with action filters
-   Centralized exception handling middleware
-   Swagger UI for API testing

## Technologies Used

-   **ASP.NET Core (.NET 9)**
-   **Entity Framework Core** (SQL Server)
-   **ASP.NET Core Identity**
-   **JWT Authentication**
-   **Serilog** for logging
-   **Swagger / OpenAPI** for API documentation
-   **AutoMapper** for object mapping

## Project Structure

```
BDWalks.API.csproj
BDWalks.API.http
BDWalks.API.sln

├─ Controllers               // Contains API controllers handling HTTP requests ( auth, images, regions, walks)
│  ├─ AuthController.cs
│  ├─ ImagesController.cs
│  ├─ RegionsController.cs
│  └─ WalksController.cs

├─ CustomActionFilters       // Custom filters for model validation
│  └─ ValidateModelAttribute.cs

├─ Data                      // Entity Framework DbContext classes for database access
│  ├─ BDWalksAuthDbContext.cs
│  └─ BDWalksDbContext.cs

├─ Images                   // Directory used to store uploaded image files
│  └─ .gitkeep

├─ Interfaces               // Abstractions for repositories (For dependency injection)
│  ├─ IImageRepository.cs
│  ├─ IRegionRepository.cs
│  ├─ ITokenRepository.cs
│  └─ IWalksRepository.cs

├─ Logs                    // Folder intended for log files
│  └─ .gitkeep

├─ Mappings                // AutoMapper profiles for DTO-to-domain (and reverse too) object mapping
│  └─ AutoMapperProfiles.cs

├─ Middlewares             // Custom middleware components
│  └─ ExceptionHandlerMiddleware.cs

├─ Models
│  ├─ DTO                  // Data Transfer Objects grouped by feature
│  │  ├─ DifficultyDtos
│  │  │  └─ DifficultyDto.cs
│  │  ├─ ImageDtos
│  │  │  └─ UploadImageRequestDto.cs
│  │  ├─ RegionDtos
│  │  │  ├─ CreateRegionRequestDto.cs
│  │  │  ├─ RegionDto.cs
│  │  │  └─ UpdateRegionRequestDto.cs
│  │  ├─ UserDtos
│  │  │  ├─ CreateUserRequestDto.cs
│  │  │  ├─ LoginUserRequestDto.cs
│  │  │  └─ LoginUserResponseDto.cs
│  │  └─ WalkDtos
│  │     ├─ CreateWalkRequestDto.cs
│  │     ├─ CreateWalkResponseDto.cs
│  │     ├─ UpdateWalkRequestDto.cs
│  │     ├─ UpdateWalkResponseDto.cs
│  │     └─ WalkDto.cs
│  └─ Domain               // Core domain entities used throughout the application
│     ├─ Difficulty.cs
│     ├─ Image.cs
│     ├─ Region.cs
│     └─ Walk.cs

├─ Program.cs              // Main entry point
├─ Properties
│  └─ launchSettings.json

├─ Repositories            // implementations of interfaces (DI)
│  ├─ LocalImageRepository.cs
│  ├─ SQLRegionRepository.cs
│  ├─ SQLWalkRepository.cs
│  └─ TokenRepository.cs

├─ Validators              // Validation classes
│  └─ ImageUploadValidator.cs

└─ appsettings.json
```

## Running the Project

1. **Clone the repository:**

    ```bash
    git clone https://github.com/sujoy-kr/BD-Walks.git
    cd BD-Walks
    ```

2. **Apply migrations and create both databases:**

    ```bash
    # Apply migrations for main data (regions, walks, images)
    dotnet ef database update --project BDWalks.API.csproj --context BDWalksDbContext

    # Apply migrations for authentication and identity
    dotnet ef database update --project BDWalks.API.csproj --context BDWalksAuthDbContext
    ```

3. **Run the application:**

    ```bash
    dotnet run --project BDWalks.API.csproj
    ```

4. **Access the Swagger UI at:**

    ```
    https://localhost:7298/swagger/index.html
    ```

## Next Implementation

**API Versioning** with `Microsoft.AspNetCore.Mvc.Versioning`
