# GoodBoy: Catalogue with dogs to rent

This repository demonstrates the application built with ASP.NET Core 8 and Blazor WASM.

**Note:** This application is purely for educational purposes. It is designed to showcase modern .NET and Blazor development techniques and is not intended for production use.

The application demonstrates CRUD operations on catalogue renting dogs with special skills (e.g., professional cuddlers, pillow destroyers).

## Live Demo

[Good Boy on Azurewebsites](https://goodboyapp.azurewebsites.net/){:target="_blank"}

## Screenshots

![image](https://github.com/user-attachments/assets/20ec9435-9f19-4374-a8f5-1e36d4e6ee2e)

## Known Todos and Bugs

* Implement categories as a lookup table and relations to products.
* Implement filtering of products based on categories.
* Implement lazy loading for improved performance.
* Implement authentication of API endpoints.
* Improve error handling and messaging.

## Features

* **Product Catalog Management:**
    * Managing a product catalogue: Add, edit, and view products (dogs with special skills).
    * 12-hour price change limitation.
    * Import product data daily from an XML file.
* **API:** Exposes functionality via a REST API using FastEndpoints.
* **Frontend:**
    * Blazor WASM for a user-friendly interface.
    * MudBlazor component library for UI components.
* **Background Service:**
    * Imports product data daily from an XML file using Quartz.NET.

## Architectural Patterns
  * REPR Pattern (Request-Endpoint-Response)
  * Vertical Slice Architecture (VSA)

## How it Works: Request-Endpoint-Response (REPR) Flow

This application demonstrates a typical REPR flow, common in modern web applications:

1. **Razor Page (Client):** A user interacts with a Razor component in the Blazor WASM frontend (e.g., clicks a button to create a new product).
2. **Request (Client):** The component uses an `HttpClient` to send an HTTP request (e.g., a POST request with product data) to the ASP.NET Core Web API.
3. **Endpoint (Server):**  FastEndpoints routes the request to the appropriate endpoint (e.g., the `CreateProduct` endpoint). The endpoint processes the request, interacts with the database (using Entity Framework Core), and applies any business logic (e.g., the 12-hour price change rule).
4. **Response (Server):** The endpoint creates a response object (e.g., `EditProductRequest.Response`) containing the result of the operation (e.g., the ID of the created product) and sends it back to the client as a JSON response.
5. **Razor Page Handling (Client):** The Blazor component receives the response, deserializes the JSON data, and updates the UI accordingly (e.g., displays a success message or redirects to another page).

## Technologies and libraries

* **Backend:**
    * ASP.NET Core 8 Web API
    * Entity Framework Core
    * SQL Server
    * FastEndpoints (for building APIs)
    * Quartz.NET (for scheduling tasks)
* **Frontend:**
    * Blazor WASM (Single Page Application)
    * MudBlazor (UI component library)

## Getting Started

### Prerequisites

* .NET 8 SDK
* SQL Server (with a database created for the application)
* Visual Studio 2022 or later (or your preferred IDE with .NET development support)

### Running the Application Locally

1. Clone the repository: `git clone https://github.com/your-username/goodboy.git`
2. Update the connection string in `appsettings.json` to point to your SQL Server database.
3. Run the database migrations: `dotnet ef database update`
4. Run the application: `dotnet run`
5. Open your browser and navigate to the application URL (usually `https://localhost:5001`).

## Project Structure

* **GoodBoy.Web:** Contains the ASP.NET Core Web API project with FastEndpoints, data access, and Quartz.NET integration.
* **GoodBoy.Core:** Contains core business logic, entities, DTOs, and API request/response models.
* **GoodBoy.Client:** Contains the Blazor WASM frontend project with MudBlazor components.

## Contributing

Contributions are welcome! Feel free to open issues or submit pull requests.

## License
* MIT License
