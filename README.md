# Javelin: Product Catalog Management Application

This repository contains a sample e-commerce application built with ASP.NET Core 9, Blazor Server, Entity Framework Core, and SQL Server. It demonstrates how to manage a product catalogue, import data from an XML file, and enforce business rules like price change limitations.

**Note:** This application is for educational purposes only. It is designed to showcase ASP.NET Core and Blazor Server development techniques and is not intended for production use.

## Features

* **API Module:** Provides a REST API for managing products.
    * **Add Product:** Add new products to the catalogue.
    * **Edit Product:** Edit existing product information (with a 12-hour price change limitation).
    * **View Product Detail:** Retrieve details of a specific product.
    * **View Product List:** Retrieve a list of all products.
* **Background Service:** Automatically imports product data from an XML file once a day.
* **Database:** Uses Microsoft SQL Server and Entity Framework Core for data persistence.
* **Frontend:** Built with Blazor Server, providing a user-friendly interface for interacting with the API.

## Technologies Used

* ASP.NET Core 9 Web API
* Blazor Server
* Entity Framework Core
* SQL Server
* .NET 9
* C#

## Getting Started

### Prerequisites

* .NET 9 SDK
* SQL Server (with a database created for the application)
* Visual Studio 2022 or later (or your preferred IDE with .NET development support)

### Running the Application Locally

1. Clone the repository: `git clone https://github.com/jackie4u/javelin.git`
2. Update the connection string in `appsettings.json` to point to your SQL Server database.
3. Run the database migrations: `dotnet ef database update`
4. Run the application: `dotnet run`
5. Open your browser and navigate to the application URL (usually `https://localhost:5001`).

## Project Structure

* **API:** Contains the ASP.NET Core Web API project.
* **ApplicationCore:** Contains the core business logic and entities.
* **Infrastructure:** Contains data access and other infrastructure components.
* **BlazorApp:** Contains the Blazor Server frontend project.

## Educational Purpose

This repository serves as a learning resource for developers interested in:

* Building REST APIs with ASP.NET Core.
* Implementing background services for scheduled tasks.
* Using Entity Framework Core for database interactions.
* Creating interactive web applications with Blazor Server.
* Enforcing business rules and constraints.
