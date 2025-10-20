
This repository provides a focused, minimal working example of how to perform basic CRUD (Create, Read, Update, Delete) operations using Dapper in a .NET Webapi application.


🎯 What's Inside?
This project demonstrates the core patterns and approaches of Dapper for data access


🛠️ Getting Started (Quick Setup)
Follow these steps to get this example running on your local machine.

1. Prerequisites
Make sure you have the following installed:
.NET SDK (8.0 or higher)
A SQL Server instance (or LocalDB) running.


2. Database Setup & Configure Connection String
This project uses a simple database with a single table named Employees.<br/>
In the appsettings.json file update the DefaultConnection to match your local SQL Server details.<br/>
Run the Initial Migration: <br/> Navigate to the SSMS, execute the following command to apply the initial schema to your database. This will create the EmployeeDb and the Employees table.<br/>


CREATE DATABASE EmployeeDb;
GO

USE EmployeeDb;
GO

CREATE TABLE Employees (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    Name NVARCHAR(100),
    Department NVARCHAR(100),
    Email NVARCHAR(100),
    Salary DECIMAL(18,2),
    DateOfJoining DATETIME
);



