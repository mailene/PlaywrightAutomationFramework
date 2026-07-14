# Playwright Automation Framework

A reusable UI automation framework built with **C#**, **.NET 10**, **Microsoft Playwright**, and **NUnit**, following modern software engineering principles and the **Page Object Model (POM)** design pattern.

This project demonstrates how to build a maintainable, scalable, and reusable automation framework rather than simply writing automated UI tests.

---

## Features

- Page Object Model (POM)
- Browser abstraction using BrowserManager
- Centralized configuration
- Reusable BasePage
- Secure handling of sensitive data
- Screenshot capture support
- Centralized test data
- Separation between framework and test projects
- Extensible architecture

---

## Technologies

- C#
- .NET 10
- Microsoft Playwright
- NUnit
- Git
- GitHub

---

## Solution Structure

```text
PlaywrightAutomationFramework
│
├── PlaywrightAutomationFramework
│   ├── Browser
│   ├── Configuration
│   ├── Enums
│   ├── Models
│   ├── Pages
│   ├── TestData
│   └── Utilities
│
├── PlaywrightAutomationTests
│   └── Tests
│
└── PlaywrightAutomationFramework.slnx
```

---

## Framework Architecture

```text
Tests
   │
   ▼
Page Objects
(LoginPage, DashboardPage)
   │
   ▼
BasePage
   │
   ▼
BrowserManager
   │
   ▼
Microsoft Playwright
```

The framework separates responsibilities into dedicated layers to improve maintainability, readability, and scalability.

- **Tests** contain business scenarios.
- **Page Objects** encapsulate UI interactions.
- **BasePage** provides reusable functionality.
- **BrowserManager** manages the browser lifecycle.
- **Configuration** centralizes environment settings.

---

## Current Implementation

### Browser Management

- BrowserManager
- Browser Context
- Browser Page creation
- Automatic resource cleanup
- Configurable browser settings

### Configuration

Centralized configuration for:

- Base URL
- Browser selection
- Headless execution

### Page Objects

Implemented:

- LoginPage
- DashboardPage

### BasePage

Reusable methods include:

- ClickAsync()
- FillAsync()
- FillSensitiveAsync()
- TakeScreenshotAsync()

### Test Data

Centralized login credentials stored separately from test logic.

---

## Engineering Decisions

Several design decisions were intentionally made during development.

- BasePage is abstract to prevent direct instantiation.
- BrowserManager hides Playwright implementation details.
- Base URL is centralized while each Page Object owns its own route.
- Constructors perform initialization only.
- Tests never interact directly with Playwright locators.
- Test data is separated from test logic.
- Screenshot functionality is centralized within BasePage.

---

## Running the Project

Clone the repository

```bash
git clone https://github.com/mailene/PlaywrightAutomationFramework.git
```

Restore packages

```bash
dotnet restore
```

Build

```bash
dotnet build
```

Run tests

```bash
dotnet test
```

---

## Roadmap

### Completed

- Browser abstraction
- Page Object Model
- BasePage
- Configuration
- Login automation
- Dashboard verification
- Test data layer
- Screenshot support

### Planned

- Parallel execution
- HTML reporting
- Logging
- Multiple browser execution
- Data-driven testing
- API testing
- GitHub Actions CI/CD
- Docker support

---

## About This Project

This framework was built as a personal engineering project to strengthen modern automation framework design while demonstrating clean architecture, maintainability, scalability, and software engineering best practices commonly used by enterprise Quality Engineering teams.

---

## Author

**Mailene Mac**

Senior Quality Engineering Manager

GitHub:
https://github.com/mailene

LinkedIn:
https://www.linkedin.com/in/mailene/