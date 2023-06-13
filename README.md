# danica-explorer
App for trip agents in Serbia. (Project for course Human Computer Interaction) 

### Authors
[Nemanja Majstorović](github.com/Nemanja3314)  
[Nemanja Dutina](github.com/eXtremeNemanja)  
[Milica Sladaković](github.com/coma007)

## Prerequisites

Before running the app, make sure you have the following installed on your machine:

- [.NET 6.0 SDK](https://dotnet.microsoft.com/download/dotnet/6.0)
- [PostgreSQL](https://www.postgresql.org/download/)

## Getting Started

1. Clone this repository to your local machine.

   ```shell
   git clone https://github.com/coma007/danica-explorer.git
   ```
2. Open a command prompt or terminal and navigate to the project's root directory.
   ```shell
   cd app
   ```

### Create and populate the database.

1. Open a PostgreSQL management tool (e.g., pgAdmin).  
2. Connect to your local PostgreSQL instance.  
3. Create a new database with the name danica_explorer.
4. Open the app/Database directory.
   ```shell
   cd app/Database
   ```
5. Execute the SQL scripts in the following order to create and populate the database tables:   
        - create-tables.sql    
        - populate-tables.sql
6. Build the project using the .NET CLI.
   ``` shell
   dotnet build
   ```
7. Run the app:
   ```shell
   dotnet run --project App.csproj
   ```
The Avalonia app should now launch on your screen.

## Dependencies

This app relies on the following NuGet packages:

- Avalonia (Version 0.10.21)
- Avalonia.Desktop (Version 0.10.21)
- Avalonia.Diagnostics (Version 0.10.21) (Only included in Debug configuration)
- Avalonia.ReactiveUI (Version 0.10.21)
- XamlNameReferenceGenerator (Version 1.6.1)

These dependencies will be automatically restored when you build the project using the .NET CLI.

### Happy evaluating ! 🌴
