# Backend

This is the backend for the Note Taking App.

## Folder Structure

- `Controllers/` - Contains the controllers for the API, which handles the requests from the frontend
- `DataAnnotations/` - Contains custom data annotations used for validation of incoming requests
- `DataBase/` - Contains the database context and database models used by Entity Framework
- `DTOs/` - Contains the DTOs used for data transfer between both internally and to be exposed by the API
- `Migrations/` - Contains the migrations for the database, these are automatically generated by Entity Framework (DO NOT EDIT)
  - These can be generated by using the Entity Framework CLI tool, see [Entity Framework CLI](https://learn.microsoft.com/en-us/ef/core/cli/powershell)
- `Properties/` - Contains the launch settings for the project
- `Services/` - Contains the services used by the controllers to interact with the database or to perform other complex tasks
- `appsettings.*.json` - Contains the configuration for the project, such as the frontend url. (Do not put any secrets or sensitive information in here, it will be pushed to the repository)
- `Program.cs` - Contains the entry point for the project, here you can configure the startup of the project

## Documentation

The documentation for the backend is all in the form of comments in the code, so you can use the IDE to view that documentation.

Part of this documentation is also generated into a [Swagger](https://swagger.io/) documentation, which can be viewed by running the project.

I also try to keep the swagger specification up to date, which can be found in the `spec/swagger.json` file. ([here](../spec/swagger.json))
