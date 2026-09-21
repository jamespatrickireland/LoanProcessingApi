# LoanProcessingApi

A .NET 8 Web API for evaluating loan applications, storing application data, and generating PDF approval letters.

## Tech Stack

- .NET 8 / ASP.NET Core Web API
- Entity Framework Core
- SQL Server
- QuestPDF
- xUnit
- Swagger / OpenAPI

## Features

- Create and evaluate loan applications
- Approve or reject applications based on loan amount
- Assign interest rates based on approval tiers
- Persist applications with EF Core
- Retrieve applications by ID
- Generate PDF approval letters
- Unit tests for decision logic and PDF generation

## Decision Rules

| Loan Amount | Result | Rate |
|---|---|---|
| Under $10,000 | Rejected | — |
| $10,000–$24,999 | Approved | 9.5% |
| $25,000–$49,999 | Approved | 8.0% |
| $50,000+ | Approved | 6.5% |

## Endpoints

```text
POST /Application/Create
GET  /Application/Get/{id}
POST /Application/GenerateApprovalLetter/{id}
