# SauceDemo UI Automation Testing Framework

This repository contains an automated UI testing framework for the [SauceDemo](https://www.saucedemo.com/) e-commerce website. The project is built using C#, Selenium WebDriver, and NUnit, following industry-standard test automation patterns.

## Tech Stack
* **Language:** C#
* **Test Runner:** NUnit
* **Browser Automation:** Selenium WebDriver
* **Configuration Management:** Microsoft.Extensions.Configuration

## Architecture & Best Practices
* **Page Object Model (POM):** UI elements and page interactions are fully encapsulated into separate classes, ensuring clean test files and high maintainability.
* **Data-Driven Testing (DDT):** Test data (credentials, checkout validation errors, valid user inputs) is extracted into a `testdata.json` file. Tests dynamically consume this data using NUnit's `[TestCaseSource]`.
* **Global Configuration:** Environment settings, such as Base URL and Browser options (including Headless mode), are managed via `appsettings.json`.
* **Smart Synchronization:** Strategic use of Explicit Waits (`WebDriverWait`) to handle React page hydration, network latency, and cross-origin navigations without relying on hardcoded delays.
* **Cross-Tab Interactions:** Custom logic to handle dynamic window handles when testing external social media links in the footer.

## Test Coverage
* **Authentication:** Valid/invalid credentials and locked-out user scenarios.
* **Inventory:** Product sorting algorithms (A-Z, Z-A, Low-High, High-Low) and dynamic cart badge updates.
* **Cart & Checkout:** Full end-to-end purchasing flow, mandatory field validations, and verification of generated PDF order receipts.
* **Navigation:** Burger menu state transitions and external redirection verifications.

## How to Run Locally
1. Clone the repository:
   ```
   git clone https://github.com/Volodia4/SauceDemo.UITests.git
   ```
2. Open the solution in Visual Studio or JetBrains Rider.
3. Ensure you have the latest version of Google Chrome installed.
4. Build the solution to restore all NuGet packages.
5. You can configure execution modes in appsettings.json (e.g., setting "Headless": true for faster, background execution).
6. Run the tests via your IDE's Test Explorer or using the .NET CLI:
   ```dotnet test```
