# SIT232 Practical Task 1.2P: Repetition and Control Structures

This project contains the implementation of Practical Task 1.2 for SIT232 (Object-Oriented Development). The focus of this task is on mastering C# repetition structures (`for`, `while`, and `do...while` loops) and understanding their appropriate use cases.

## Project Structure

### Root Directory
- **`Repetition.cs`**: Implements Tasks 1, 2, and 3. It calculates the sum and average of numbers 1 to 100 using all three loop types, including trace statements for observation.
- **`DebuggingAndRewriting.cs`**: Implements the consolidated logic for Task 4 (debugging) and Task 5 (rewriting `while` loops as `for` loops).
- **`GuessingNumber.cs`**: A two-player number guessing game with input validation and range checking (Task 6).
- **`DivisibleFour.cs`**: A program that finds numbers divisible by 4 but not by 5 up to a user-defined limit (Task 7).
- **`analyze.md`**: Contains theoretical answers regarding loop differences and a detailed breakdown of the bugs found in Task 4.
- **`1.2P_request.pdf`**: The original task requirements.

### `task/` Folder
Contains standalone C# files for each debugging snippet from Task 4, fixed and ready for individual execution:
- `Snippet1.cs` to `Snippet7.cs`

## Repository Structure

```text
.
├── 1.2P_request.pdf          # Original task requirements
├── analyze.md                # Detailed loop analysis and debugging fixes
├── DebuggingAndRewriting.cs  # Consolidated logic for Task 4 & 5
├── DivisibleFour.cs          # Task 7 implementation
├── GuessingNumber.cs         # Task 6 implementation
├── README.md                 # Project documentation
├── Repetition.cs             # Tasks 1, 2, & 3 implementations
└── task/                     # Standalone fixed debugging snippets
    ├── Snippet1.cs
    ├── Snippet2.cs
    ├── Snippet3.cs
    ├── Snippet4.cs
    ├── Snippet5.cs
    ├── Snippet6.cs
    └── Snippet7.cs
```

## Highlights & Key Takeaways
> [!NOTE]
> The **`do...while`** loop is used for the user input section in Task 6 because it guarantees that the prompt will be displayed at least once, regardless of the initial condition.

> [!IMPORTANT]
> All user inputs are validated using **`int.TryParse`**. This prevents the application from crashing if a user enters non-numeric text, ensuring a robust and user-friendly experience.

> [!QUESTION]
> **What is the fundamental difference between a `while` and a `for` loop?**
> A `for` loop is most effective when the number of iterations is known (fixed-count), while a `while` loop is better suited for condition-based iterations where the count is not predetermined.

## Implementation Process

1.  **Requirement Analysis**: Analyzed the provided PDF to extract specific logic requirements and output formatting constraints.
2.  **Loop Implementation**: Built the core repetition logic, ensuring `do...while` loops were used correctly for scenarios requiring at least one execution (like input validation).
3.  **Debugging Phase**: Identified common logic errors in provided snippets, such as:
    - Infinite loops caused by parity mismatches.
    - Variable scope issues (internal re-declaration).
    - Uninitialized variables.
    - Syntax errors in `for` loop headers.
4.  **Refactoring**: Demonstrated the conversion of `while` loops into more concise `for` loops where appropriate.
5.  **Validation**: Added input handling (using `int.TryParse`) to ensure the programs are robust against invalid user entries.

## How to Run
To compile and run any of these files, use the .NET CLI:
```bash
csc FileName.cs
.\FileName.exe
```
*(Note: Ensure you have the .NET SDK or Build Tools installed.)*
