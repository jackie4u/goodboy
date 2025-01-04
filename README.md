# GoodBoy: Product Catalog Management Application

This repository contains a sample e-commerce application built with ASP.NET Core 9, Blazor WASM, Entity Framework Core, and SQL Server. It demonstrates managing a product catalogue, importing data from an XML file, and enforcing business rules like price change limitations.

**Note:** This application is for educational purposes only. It is designed to showcase ASP.NET Core and Blazor development techniques and is not intended for production use.

## Features

* **Backend**

  * **API:** Provides a REST API for managing products.

    * **Add Product:** Add new products to the catalogue.
    * **Edit Product:** Edit existing product information (with a 12-hour price change limitation).
    * **View Product Detail:** Retrieve details of a specific product.
    * **View Product List:** Retrieve a list of all products.
  * **Database:** Uses Microsoft SQL Server and Entity Framework Core for data persistence.
  * **Background Service:** Automatically imports product data from an XML file once a day.
* **Frontend:** Built with Blazor providing a user-friendly interface for interacting with the API.

## Technologies Used

* ASP.NET 8 (Web API)
* Entity Framework Core
* SQL Server
* FastEndpoint
* MediatR
* Blazor
* MudBlazor component library

## Getting Started

### Prerequisites

* .NET SDK
* SQL Server (with a database created for the application)
* Visual Studio 2022 or later (or your preferred IDE with .NET development support)

### Running the Application Locally

1. Clone the repository: `git clone https://github.com/jackie4u/goodboy.git`
2. Update the connection string in `appsettings.json` to point to your SQL Server database.
3. Run the database migrations: `dotnet ef database update`
4. Run the application: `dotnet run`
5. Open your browser and navigate to the application URL (usually `https://localhost:5001`).

## Project Structure

* **API:** Contains the ASP.NET Web API project with data access and other infrastructure components.
* **Shared:** Contains the core business entities and logic.
* **Client:** Contains the Blazor Server frontend project.

## Educational Purpose

This repository serves as a learning resource for developers interested in:

* Building REST APIs with ASP.NET.
* Implementing background services for scheduled tasks.
* Using Entity Framework Core for database interactions.
* Creating interactive web applications with Blazor.
* Enforcing business rules and constraints.
