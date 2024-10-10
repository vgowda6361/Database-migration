# Database Migration - MS SQL Server to PostgreSQL

This project is a C# Console Application that facilitates the migration of data from an MS SQL Server database to a PostgreSQL database. The tool automates the process of transferring data, schema, and optionally other database objects (like indexes and constraints) from MS SQL Server to PostgreSQL.

## Features

- Migrate table data from MS SQL Server to PostgreSQL
- Migrate database schema (tables, columns, data types)
- Support for data type conversion from SQL Server to PostgreSQL
- Optionally include indexes and constraints
- Configurable source and destination database connections

## Prerequisites

- [.NET Core SDK](https://dotnet.microsoft.com/download) (v6.0 or later)
- MS SQL Server (source database)
- PostgreSQL (destination database)

## Getting Started

### 1. Clone the Repository

```bash
git clone https://github.com/your-username/database-migration.git
cd database-migration
