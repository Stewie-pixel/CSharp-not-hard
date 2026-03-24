# SIT232 Object-Oriented Development: Practical Tasks

This repository contains a comprehensive collection of practical tasks for **SIT232: Object-Oriented Development**, implemented in C#. The project progresses from fundamental control structures to advanced Object-Oriented Programming (OOP) concepts, including class design, exception handling, and automated testing.

## Repository Structure

```text
.
├── 2.1P.sln                 # Root solution file
├── README.md                # Main documentation
├── .vscode/                 # Workspace-specific settings and debug configs
└── src/                     # Source code directory
    ├── selection_and_casting/ # Task 1.1P: Logic and type conversion
    ├── repetition/            # Task 1.2P: Loop structures and games
    ├── classes_and_objects/   # Task 2.1P: Introduction to classes (Mobile, Employee, Car)
    └── the_account_class/     # Task 2.2P: Advanced OOP and Banking System
        ├── Account.cs         # Core business logic for bank accounts
        ├── TestAccount.cs     # Interactive test driver with try-catch logic
        ├── TheAccountClass.csproj
        └── test/              # Automated Test Suite
            ├── Account.Tests.csproj
            └── AccountTests.cs # NUnit tests for banking operations
```

## Key Reminders & Lessons Learned

>[!NOTE]
>**Encapsulation**: The `Account` class uses private fields (`_balance`, `_name`) to ensure data integrity. Only controlled access is allowed through public methods and properties.
>[!IMPORTANT]
>**Defensive Programming**: All critical operations (Deposit/Withdraw) now validate inputs. Never assume a user will provide a positive number or have sufficient funds; always validate before mutating state.
>[!BUG]
>**Silent Failures Fixed**: In early versions, `Withdraw` would simply do nothing if the balance was too low. This was refactored to throw an `InvalidOperationException`, ensuring the caller is aware of the failure and can handle it appropriately using `try-catch` blocks.

## Project Overview

### 1. Fundamentals: Selection, Casting, and Repetition
- **Selection & Casting**: Decision-making using `if-else` and `switch`, plus explicit type casting.
- **Repetition**: Exploration of `for`, `while`, and `do-while` loops for calculations and games.

### 2. Classes and Objects
- **Object Modeling**: Designing real-world entities like Mobiles, Employees, and Cars using C# classes.

### 3. Banking System: The Account Class
- **Exception Handling**: Transitioned from silent failures to explicit error reporting.
- **Automated Testing**: Comprehensive NUnit test suite covering edge cases like insufficient funds and negative input.

## Getting Started

### Prerequisites
- [.NET SDK 8.0+](https://dotnet.microsoft.com/download)
- [Visual Studio Code](https://code.visualstudio.com/) with C# Dev Kit.

### How to Run
```bash
# Run the banking application
cd src/the_account_class
dotnet run
```

### How to Test
```bash
# Run the automated NUnit tests
cd src/the_account_class/test
dotnet test
```

## Engineering Standards
- **Robust Input**: All user inputs are validated using `TryParse` or Exception handling.
- **Clean Code**: Strict adherence to C# naming conventions and modular architectural patterns.
