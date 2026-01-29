# DevLexicon

A technical lexicon for .NET developers, implemented with ASP.NET MVC, Entity Framework Core, and a local SQL database.

## Overview

DevLexicon stores and manages a curated list of technical terms relevant to modern .NET development. It demonstrates a clean MVC architecture with server-side rendering using Razor views, data access via Entity Framework Core, and persistence in a local SQL database. It provides complete CRUD operations, search, and simple category filtering to facilitate efficient retrieval and maintenance of terminology.

## Architecture

- ASP.NET MVC: Controllers coordinate requests, models encapsulate domain data and validation, and Razor views render HTML. Routing maps HTTP endpoints to controller actions.
- Entity Framework Core: EF Core handles object-relational mapping, change tracking, and LINQ-based queries. The application's DbContext exposes a `DbSet<TechTerm>` for data access.
- Local SQL Database: Data is persisted to a local SQL database (e.g., SQL Server LocalDB). EF Core migrations are used to evolve the schema.

## Domain Model: `TechTerm`

The `TechTerm` model represents a single lexicon entry with the following structure and annotations:
- `int Id`: Primary key.
- `string Name`: Required. Max length 100. The canonical term name.
- `string Definition`: Required. The formal definition or explanation of the term.
- `string? DocumentationLink`: Optional. External URL to official documentation or authoritative references. Display name "Documentation Link".
- `string? Category`: Optional. Max length 50. Categorization (e.g., Framework, Language, Tooling).

## Features

- CRUD via EF Core: Create, Read, Update, and Delete operations implemented through MVC controller actions that utilize EF Core for persistence.
- Search: The index view supports case-insensitive search over `Name` and `Category`.
- Category Filtering: Simple filtering by `Category` via the search input.
- Razor Views: Strongly-typed views render model metadata and validation messages.
- Migrations: Schema changes are managed with EF Core migrations.

## Prerequisites

- .NET SDK (matching the project target; e.g., .NET 10 SDK)
- SQL Server LocalDB (or another local SQL provider configured in `appsettings.json`)

## Setup and Installation

1. Clone the repository:
   ```bash
   git clone https://github.com/james-evolution/DevLexicon.git
   cd DevLexicon
   ```
2. Restore dependencies:
   ```bash
   dotnet restore
   ```
3. Apply database migrations and create the local database:
   ```bash
   dotnet ef database update
   ```
   If you make model changes later:
   ```bash
   dotnet ef migrations add <DescriptiveName>
   dotnet ef database update
   ```
4. Configure the connection string in `appsettings.json` if needed (e.g., `DevLexiconContext`).

## Running the Application

- From the project directory, start the app:
  ```bash
  dotnet run
  ```
- Open the browser to the URL printed in the console (typically `https://localhost:5001` or `http://localhost:5000`).

## Project Structure

- `Controllers/`: MVC controllers (`HomeController`, `TechTermsController`).
- `Models/`: Domain models (`TechTerm`, `ErrorViewModel`).
- `Views/`: Razor views, including `Home/Index.cshtml` and `TechTerms` CRUD views.
- `Data/`: EF Core DbContext and configuration (e.g., `DevLexiconContext`).
- `Migrations/`: EF Core migrations.
- `Program.cs`: Application startup, service registrations, and routing configuration.

## Notes

- Nullable reference types are enabled; optional fields use `?`.
- `DocumentationLink` is optional and displayed as a clickable link in the Tech Terms index.
- Searching performs case-insensitive matching on `Name` and `Category`.
