# Database Migration - MS SQL Server to PostgreSQL
[![.NET Foundation](https://img.shields.io/badge/.NET%20Foundation-blueviolet.svg)](https://www.dotnetfoundation.org/)

This project is a C# Console Application that facilitates the migration of data from an MS SQL Server database to a PostgreSQL database.

## Features

- Migrate table data from MS SQL Server to PostgreSQL
- Migrate database schema (tables, columns, data types)
- Support for data type conversion from SQL Server to PostgreSQL
- Optionally include indexes and constraints
- Configurable source and destination database connections

## Prerequisites

- [.NET Core SDK](https://dotnet.microsoft.com/download) (v6.0 or later)
- Nuget Packages ( Npgsql , System.Data.SqlClient )
- Need to create Schema using Entity Framework or SQL Server

## Getting Started

### 1. Clone the Repository

```bash
git clone https://github.com/vgowda6361/Database-migration.git
cd database-migration
