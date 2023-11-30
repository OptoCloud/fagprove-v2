# Planning

This document describes the planning phase for the first sprint of this project.

## Task: Create a Note Keeping and Management Application

The goal of the task is to develop a note-keeping tool that allows users to manage their notes with ease.

### Requirements

The application should be able to:

- Perform CRUD operations on notes
- Organize notes into folders
- Search for notes by title and content

There should be a data model which should at minimum contain the following:

- Note
  - Title
  - Content
  - Created Date

The backend should be secure only allow authenticated users to access their notes.

The frontend should have a clear and intuitive user interface that is easy to use and navigate, and takes accessibility into consideration.

## Process

The process used for this project is the [Agile](https://en.wikipedia.org/wiki/Agile_software_development) methodology.

This means that the project is divided into sprints, and each sprint is divided into tasks.

Code pushed to the `master` branch of github will automatically trigger a build, test, and deploy pipeline.

In the initial phase of the project, git branches will not be used, after the first stable release this will be enforced.

The pipeline will deploy the code to Cloudflare and Azure on success.

This provides Continuous Integration (`CI`) and Continuous Deployment (`CD`) for the project. (`CI/CD`).

The result of this is instant feedback and fast iteration on the source code leading to a more efficient development process.

## Roadmap

The roadmap for this project is as follows (in order):

1. Create initial planning, infratructure, and technology documentation.
2. Configure database with models.
3. Create a backend API with swagger specification.
4. Create a frontend with Svelte.
5. Configure infrastructure (Mentioned in [infrastructure](infrastructure.md)).
6. Create a Continuous Integration, Continuous Deployment (`CI/CD`) pipeline with GitHub Actions.
7. Test the soltuion and fix any bugs.
8. Create a user manual.
9. Create a presentation.
10. Present the project.
11. Review and reflect on project decisions.

## Time management

`[Dev]` means that the task is development related.

`[Doc]` means that the task is documentation related.

|                   | Thursday         | Friday          | Monday           | Tuesday          | Wedensday                          | Thursday         | Friday                |
| :---------------- | ---------------- | --------------- | ---------------- | ---------------- | ---------------------------------- | ---------------- | --------------------- |
| **09:00 - 11:00** | Planning         | `[Dev]` Backend | `[Dev]` Backend  | `[Dev]` Frontend | Infrastructure setup               | `[Doc]` Solution | Presentation & review |
| **11:00 - 13:00** | Planning         | `[Dev]` Backend | `[Dev]` Backend  | `[Dev]` Frontend | Infrastructure setup               | `[Doc]` Solution | Presentation & review |
| **13:00 - 15:00** | `[Doc]` Solution | `[Dev]` Backend | `[Dev]` Frontend | `[Dev]` Frontend | `[Dev]` CI/CD (Backend & Frontend) | `[Doc]` Solution | Presentation & review |
| **15:00 - 17:00** | `[Doc]` Solution | `[Dev]` Backend | `[Dev]` Frontend | `[Dev]` Frontend | `[Dev]` CI/CD (Backend & Frontend) | `[Doc]` Solution | Presentation & review |

## Resources

The resources used for this project are mentioned in the [infrastrucutre](infrastructure.md) document.

## Cost

The cost listed here is the estimated cost for the first month of the project.

They are estimates for a low-traffic application that will work for the purposes of this project, this is not scaled for a high-traffic production environment.

this cost might change depending on the usage and traffic of the application, azure pricing.

According to Azures [pricing calculator](https://azure.microsoft.com/nb-no/pricing/calculator/) we can estimate these costs:

- Azure App Service: **181,58 NOK / month**
- Azure SQL Database: **243,64 NOK / month**

This gives a total of **425,22 NOK / month**.

## Sources

On day 1 I laid out the initial planning for the project, and I got input on the requirements from my colleagues.

Sources are linked in-line in the documentation.
