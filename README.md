# University Project

## Project Description

This project follows a layered architecture to structure different components of the system. Below is an overview of the layers and their roles:

### 1. University.Domain.Layer
- Contains models and enums.
- No database annotations are included here.

### 2. University.Infrastructure.Layer
- Includes `DbContext`, external services, seeding mechanisms, and configuration.
- Uses Fluent API for database models, annotations, and relationships.
- Repository implementations (no interfaces) are defined here.
- Contains extensions for Infrastructure Dependency Injection.

### 3. University.Application.Services
- Holds services and repository interfaces.
- Contains extensions for Services Dependency Injection.

### 4. University.Presentaion.Contracts
- Implements the Mediator design pattern.
- Handles request/response cycles.
- Includes extensions for adding MediatR.
- Call The Application Services
- Handle Validtaions Od DTO (Command Or Query) Using FluentAPI
- Handle MiddleWare Validation
  

### 5. University.Application.Api
- The API layer that sends requests through the IMediator interface.

## Design Pattern
- Apply Generic Design Pattern
- Apply Mediator Design Pattern

## Principles
- persistence ignorance principle



