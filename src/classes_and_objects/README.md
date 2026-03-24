# SIT232 - Practical Task 2.1P: Classes and Objects

This repository contains the source code for Practical Task 2.1P of the SIT232 Object-Oriented Development unit. The goal of this task is to understand and implement fundamental Object-Oriented Programming (OOP) concepts such as classes, objects, constructors, encapsulation, accessor/mutator methods, and operations.

## Project Structure

The solution consists of three separate C# Console Applications, each addressing a specific part of the practical task:

### 1. Task 1: Mobile Phone System (`src/Task1_Mobile`)
A simulation of a mobile phone account system.
- **Key Concepts:** Class definition, private instance variables, public accessors/mutators, custom methods.
- **Features:** 
  - Manage account type, device, and phone number.
  - Track balance.
  - Operations: `addCredit`, `makeCall`, `sendText` (with associated costs).

### 2. Task 2: Employee System (`src/Task2_Employee`)
A system to manage employee details and calculate taxes.
- **Key Concepts:** Constructor logic, tax calculation logic based on salary brackets.
- **Features:**
  - Store employee name and salary.
  - `raiseSalary(percentage)`: Increases salary.
  - `Tax()`: Calculates tax based on progressive tax brackets (e.g., 19% for $18,201–$37,000).

### 3. Task 3: Car System (`src/Task3_Car`)
A simulation of a car's fuel consumption and mileage.
- **Key Concepts:** Complex state management, unit conversion (gallons to litres).
- **Features:**
  - Track fuel efficiency (mpg), fuel in tank, and total miles driven.
  - `addFuel(gallons)`: Refuels the car.
  - `drive(miles)`: Simulates driving, consuming fuel based on efficiency.
  - `calcCost()`: Calculates the cost of fuel used.

## Prerequisites

- [.NET SDK](https://dotnet.microsoft.com/download) (Version 6.0 or later recommended).
- A C# IDE (Visual Studio 2022, VS Code, or JetBrains Rider).

## How to Run

You can run each project individually from the root directory using the .NET CLI:

```bash
# Run Task 1 (Mobile)
dotnet run --project src/Task1_Mobile/Task1_Mobile.csproj

# Run Task 2 (Employee)
dotnet run --project src/Task2_Employee/Task2_Employee.csproj

# Run Task 3 (Car)
dotnet run --project src/Task3_Car/Task3_Car.csproj
```

## Debugging Task 3

This project includes pre-configured launch settings for VS Code.

1. Open the solution folder in VS Code.
2. Go to the **Run and Debug** view (Ctrl+Shift+D).
3. Select **Task3: Car (Debug)** from the dropdown.
4. Press **F5** (Start Debugging).
   - Programmatic breakpoints (`System.Diagnostics.Debugger.Break()`) have been added to the `addFuel` and `drive` methods in `Car.cs` to pause execution for demonstration.
   - You can inspect variables like `fuelInTank` and `totalMilesDriven` in the debug console.

## Compilation

To build the entire solution:

```bash
dotnet build SIT232_Practical_2.1P.slnx
```
