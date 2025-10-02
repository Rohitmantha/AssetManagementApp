# Asset Management System
A complete enterprise Asset Management System built with .NET 8, Blazor Server, and SQL Server.

Sample Deployed URL : 
https://assetmanagement-rohit-2025-bke0emeqaafefhfg.canadacentral-01.azurewebsites.net/

## Features

- **Authentication & Authorization** - Secure login/registration with ASP.NET Core Identity
- **Dashboard** - Real-time statistics and asset metrics
- **Employee Management** - Complete CRUD operations for employee records
- **Asset Tracking** - Manage all company assets with status tracking
- **Assignment System** - Assign/return assets to employees with full history
- **Search & Filters** - Advanced filtering on assets and employees
- **Responsive UI** - Bootstrap 5 responsive design


## Tech Stack

- .NET 8.0
- Blazor Server
- SQL Server
- Entity Framework Core 8.0
- ASP.NET Core Identity
- Bootstrap 5
- Dapper

## Setup Instructions

### Prerequisites
- .NET 8 SDK
- SQL Server (LocalDB or Full)
- Visual Studio 2022 / VS Code

### Installation

1. **Clone the repository**

``` 
git clone https://github.com/Rohitmantha/AssetManagementApp.git
cd AssetManagementApp
```

2. **Update Connection String**

Open `AssetManagement.UI/appsettings.json` and update:
```
"ConnectionStrings": 
{
    "DefaultConnection": "Server=(localdb)\mssqllocaldb;Database=AssetManagementDB;Trusted_Connection=true;MultipleActiveResultSets=true"
}
```

3. **Run Migrations**
```
dotnet ef database update --project AssetManagement.DataAccess
```

4. **Run the Application**
```
dotnet run --project AssetManagement.UI
```

5. **Open in Browser:**
http://localhost:5264

## Project Structure
```
AssetManagementApp/
├── AssetManagement.Models/ # Domain entities
├── AssetManagement.DataAccess/ # Data access layer
│ ├── Data/ # DbContext
│ ├── Repositories/ # Repository implementations
│ └── Interfaces/ # Repository contracts
├── AssetManagement.Business/ # Business logic layer
│ ├── Services/ # Service implementations
│ └── Interfaces/ # Service contracts
└── AssetManagement.UI/ # Blazor Server UI
├── Components/ # Razor components
└── Pages/ # Application pages
```
## Default Credentials

Register your first user through the registration page. The first registered user will be your admin.

## Database Schema

- **Employees** - Employee master data
- **Assets** - Asset inventory
- **AssetAssignments** - Assignment history
- **AspNetUsers** - Authentication users



## Acknowledgments

- Built with .NET 8 and Blazor
- UI powered by Bootstrap 5
