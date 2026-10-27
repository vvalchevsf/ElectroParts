# ElectroParts

## Overview

ElectroParts is an ASP.NET Core MVC web application for browsing and managing a catalog of electronic devices, spare parts, and manufacturers.

The application uses Entity Framework Core and Microsoft SQL Server for data persistence. ASP.NET Core Identity provides user authentication.

## Technologies

- C# and ASP.NET Core MVC
- Entity Framework Core
- Microsoft SQL Server LocalDB
- ASP.NET Core Identity
- Razor Views
- Bootstrap
- Dependency Injection

## Prerequisites

- Visual Studio with ASP.NET and web development tools
- .NET 8 SDK
- SQL Server LocalDB
- The required NuGet packages restored

## Database Setup

The application uses the `DefaultConnection` connection string in `appsettings.json`.

The default configuration uses SQL Server LocalDB and Windows authentication.

1. Open the solution in Visual Studio.
2. Ensure that `ElectroParts` is selected as the startup project.
3. Open **Tools → NuGet Package Manager → Package Manager Console**.
4. Set **Default project** to `ElectroParts.Data`.
5. Run the following command to apply the existing migrations:

   ```powershell
   Update-Database
   ```

The migrations initialize the database and Identity tables, create the application tables, and seed test data.

For a different environment, update the connection string in the application configuration as needed.

## Running the Application

1. Open the solution in Visual Studio.
2. Restore the NuGet packages.
3. Configure the database and apply the migrations as described above.
4. Set `ElectroParts` as the startup project.
5. Run the application using Visual Studio.

## Main Features

- Browse electronic devices.
- Browse electronic parts and their details.
- Browse manufacturers.
- Add devices, parts, and manufacturers as an authenticated user.
- View detailed information through the application interface.
- Validate submitted data on the server and client.
- Restrict selected pages and actions to authenticated users.

## Project Structure

The solution is organized into the following projects and folders:

- **ElectroParts** — ASP.NET Core MVC web application, including controllers, Razor views, and the `ViewModels` folder.
- **ElectroParts.Common** — shared constants and common definitions.
- **ElectroParts.Data** — Entity Framework Core database context and migrations.
- **ElectroParts.Data.Models** — database entity models.
- **ElectroParts.Services** — application services and service contracts.
- **ElectroParts.Services.DTOs** — data transfer objects used by the services.

The solution groups the Data, Services, and Web projects into Solution Folders in Visual Studio. These Solution Folders are organizational and do not represent physical directories on disk.

## Notes

The default database configuration is intended for local development. Before deploying to another environment, configure an appropriate database connection string and review the authentication and security settings.