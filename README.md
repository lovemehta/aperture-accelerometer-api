
# Aperture Science Wearable Device Backend Service

## Project Overview

This project is a backend service developed for Aperture Science's Antigravity Department. The service is designed to manage test subjects, handle high-fidelity acceleration data ingestion from wearable devices, and ensure data confidentiality, integrity, and availability.

The project uses **ASP.NET Core** and is hosted on **Microsoft Azure**, leveraging modern architecture patterns such as **JWT-based authentication**, **role-based access control**, and **asynchronous data ingestion**. The system is built with scalability, security, and maintainability in mind, making it an ideal solution for IoT-based research experiments.

## Features

- **User Registration and Authentication**
  - Users (test subjects) can register with a valid activation code, email, and password.
  - Secure password storage with ASP.NET Core Identity.
  - JWT-based authentication for stateless, token-based authorization.

- **Role-Based Access Control (RBAC)**
  - Supports administrators and test subjects with different levels of access.
  - Role management is built-in with ASP.NET Core Identity.

- **Secure Activation Code Provisioning**
  - Administrators can generate unique 6-digit activation codes that expire after 60 minutes.
  - Validation ensures only valid codes are used during user registration.

- **High-Performance Data Ingestion**
  - Supports ingestion of acceleration data from wearable devices.
  - Can handle high-throughput ingestion with optimized asynchronous processing.
  
- **Scalable and Resilient Architecture**
  - Deployed on Azure with auto-scaling, load balancing, and background processing using Azure Functions.
  - Built-in monitoring and logging with Azure Application Insights.

## Technologies Used

- **Backend Framework**: ASP.NET Core 5.0 (Web API)
- **Authentication**: ASP.NET Core Identity, JWT Bearer Tokens
- **Database**: Azure SQL Database with Entity Framework Core
- **Caching**: Azure Cache for Redis (for high-performance caching)
- **Messaging**: Azure Service Bus (for asynchronous data processing)
- **Deployment**: Azure App Service, Azure Functions
- **Logging & Monitoring**: Azure Monitor, Application Insights
- **CI/CD Pipeline**: Azure DevOps / GitHub Actions

## Getting Started

### Prerequisites

- **.NET Core SDK 5.0 or later**: You need to have the .NET Core SDK installed. Download it [here](https://dotnet.microsoft.com/download).
- **Azure Account**: If you plan to deploy the application to Azure, you need an Azure account.

### Installation

1. **Clone the repository**:

   ```bash
   git clone https://github.com/yourusername/aperture-science-backend.git
   cd aperture-science-backend
   ```

2. **Install dependencies**:

   Use the .NET CLI to restore the project dependencies:

   ```bash
   dotnet restore
   ```

3. **Set up the database**:

   Make sure you have an SQL Server instance running. Update the connection string in `appsettings.Development.json`:

   ```json
   "ConnectionStrings": {
     "DefaultConnection": "Server=localhost;Database=ApertureScienceDb;User Id=sa;Password=yourpassword;"
   }
   ```

4. **Run database migrations**:

   Apply the Entity Framework Core migrations to create the necessary database tables:

   ```bash
   dotnet ef database update
   ```

5. **Run the application**:

   Start the application locally:

   ```bash
   dotnet run
   ```

   The API will be accessible at `https://localhost:5001`.

## API Documentation

The API endpoints are documented using Swagger. Once the application is running, you can access the Swagger UI at:

```
https://localhost:5001/swagger
```

Here, you'll find detailed descriptions of all available endpoints, including examples of how to register users, log in, ingest acceleration data, and manage activation codes.

### Key Endpoints

- **POST /api/account/register**: Register a new test subject.
- **POST /api/account/login**: Authenticate a user and receive a JWT token.
- **POST /api/activationcodes**: Generate a new activation code (admin only).
- **POST /api/accelerationmeasurements**: Ingest acceleration data (authenticated users only).

## Deployment

The application is designed to be deployed on **Microsoft Azure**. Follow these steps for deployment:

1. **Create Azure Resources**:
   - Set up an **Azure App Service** for hosting the API.
   - Provision an **Azure SQL Database** for the backend data.
   - Use **Azure Service Bus** for asynchronous data processing (optional).

2. **Configure CI/CD Pipeline**:
   - Set up continuous deployment using **Azure DevOps** or **GitHub Actions**.

3. **Deploy to Azure**:
   - Publish the application to Azure using the CLI:

     ```bash
     dotnet publish -c Release
     ```

## Testing

- **Unit Testing**: The project uses **xUnit** for unit tests. Run the tests with:

  ```bash
  dotnet test
  ```

- **Integration Testing**: Integration tests ensure the correctness of API endpoints and database interactions.

## Future Improvements

- **Performance Optimization**: Implement caching strategies to further reduce database load during peak operations.
- **More Role Management**: Implement more granular role management for future use cases.
- **API Rate Limiting**: Add rate limiting to prevent abuse of the API.
- **Cloud Scaling**: Implement auto-scaling on Azure for handling sudden spikes in user activity.

## Author

**Love Mehta**  
[GitHub Profile]([https://github.com/yourusername](https://github.com/lovemehta/))  
[LinkedIn Profile](https://www.linkedin.com/in/lovemehta/)
