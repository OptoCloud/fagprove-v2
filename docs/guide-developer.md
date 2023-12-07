# Developer Guide

## Technologies

The technologies used for this project are described in the [Technologies](technologies.md) document.

## Infrastructure

The infrastructure used for this project is described in the [Infrastructure](infrastructure.md) document.

## Software Architecture

The software architecture used for this project is described in the [Software Architecture](software_architecture.md) document.

## Frontend documentation

The frontend documentation is located in the [frontend](../frontend) directory.

## Backend documentation

The backend documentation is located in the [backend](../backend) directory.

## Getting started

### Prerequisites

- [Node.js](https://nodejs.org/en/) (v20.9.0 or higher)
- [.NET 7.0 SDK](https://dotnet.microsoft.com/download/dotnet/7.0) (v7.0.14 or higher)
- [Cloudflare account](https://www.cloudflare.com/) (for deployment)
- [Azure account](https://azure.microsoft.com/en-us/free/) (for deployment)

#### Step 1: Clone the repository

```bash
git clone https://github.com/OptoCloud/fagprove-v2.git
```

#### Step 2: Install dependencies

**Backend:**

```bash
cd fagprove-v2/backend
dotnet restore
```

**Frontend:**

```bash
cd fagprove-v2/frontend
npm ci
```

#### Step 3: Configure environment variables

You need to configure the following environment variables:

- In `frontend/.env`:

  - `PUBLIC_BACKEND_API_BASE_URL` - The base url of the backend api

- In `backend/appsettings.Production.json`:

  - `Cors:AllowedOrigins` - The base url of the frontend

- In the user secrets of the backend project ([How to add user secrets](https://learn.microsoft.com/en-us/aspnet/core/security/app-secrets?view=aspnetcore-8.0&tabs=linux)):
  - `ConnectionStrings:Database` - The connection string to the postgresql database

#### Step 4: Build the project

**Backend:**

```bash
cd fagprove-v2/backend
dotnet build
```

**Frontend:**

```bash
cd fagprove-v2/frontend
npm run build
```

## Deploying to Cloudflare

This project is deployed to Cloudflare using the [Cloudflare Pages](https://pages.cloudflare.com/) service.

To deploy the project to Cloudflare, you can follow this guide: [Deploy an Svelte app to Cloudflare](https://developers.cloudflare.com/pages/framework-guides/deploy-a-svelte-site/)

## Deploying to Azure

This project is deployed to Azure using the [Azure App Service](https://azure.microsoft.com/en-us/services/app-service/) service.

To deploy the project to Azure, you can follow this guide: [Deploy an ASP.NET web app to Azure](https://learn.microsoft.com/en-us/azure/app-service/quickstart-dotnetcore?tabs=net70&pivots=development-environment-vs)
