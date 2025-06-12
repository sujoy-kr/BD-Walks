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

├─ Controllers
│  ├─ AuthController.cs
│  ├─ ImagesController.cs
│  ├─ RegionsController.cs
│  └─ WalksController.cs

├─ CustomActionFilters
│  └─ ValidateModelAttribute.cs

├─ Data
│  ├─ BDWalksAuthDbContext.cs
│  └─ BDWalksDbContext.cs

├─ Images
│  └─ .gitkeep

├─ Interfaces
│  ├─ IImageRepository.cs
│  ├─ IRegionRepository.cs
│  ├─ ITokenRepository.cs
│  └─ IWalksRepository.cs

├─ Logs
│  └─ .gitkeep

├─ Mappings
│  └─ AutoMapperProfiles.cs

├─ Middlewares
│  └─ ExceptionHandlerMiddleware.cs

├─ Models
│  ├─ DTO
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
│  └─ Domain
│     ├─ Difficulty.cs
│     ├─ Image.cs
│     ├─ Region.cs
│     └─ Walk.cs

├─ Program.cs
├─ Properties
│  └─ launchSettings.json

├─ Repositories
│  ├─ LocalImageRepository.cs
│  ├─ SQLRegionRepository.cs
│  ├─ SQLWalkRepository.cs
│  └─ TokenRepository.cs

├─ Validators
│  └─ ImageUploadValidator.cs

└─ appsettings.json
```

## Running the Project

1. **Clone the repository:**

   ```bash
   git clone https://github.com/sujoy-kr/BD-Walks.git
   cd BD-Walks
   ```

2. **Add migrations and create both databases:**

   ```bash
   # Create migration and apply for the main application database
   dotnet ef migrations add "init" --context "BDWalksDbContext"
   dotnet ef database update --context "BDWalksDbContext"

   # Create migration and apply for the auth/identity database
   dotnet ef migrations add "init" --context "BDWalksAuthDbContext"
   dotnet ef database update --context "BDWalksAuthDbContext"
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
