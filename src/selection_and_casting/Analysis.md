# Analysis of Practical Task 1.1

## Task 3: Debugging Code Snippets

### Snippet 1

```csharp
int number = 50;
if (number == 50) ; {
    Console.WriteLine("Number is 50");
}
```

*   **Issue:** There is a semicolon (`;`) immediately after the `if` condition. This terminates the `if` statement, making it an empty statement. The following block `{ ... }` is treated as a separate, standalone scope and will always execute regardless of the condition.

### Snippet 2

```csharp
int number = 60;
if (number >= 50 and number <= 100) {
    Console.WriteLine("Number is more than or equal to 50 and less than or equal to 100");
}
```

*   **Issue:** The word `and` is used as a logical operator, which is incorrect in C#. The correct logical AND operator is `&&`.

### Snippet 3

```csharp
public class Score {
    public static void main(String[] args) {
        double score = 40;
        if (score > 40{
            Console.WriteLine("You passed the exam!");
        } else score < 40{
            Console.WriteLine("You failed the exam!");
        }
    }
}
```

*   **Issues:**

    1.  The method name `main` must be capitalized to `Main`.
    2.  Missing closing parenthesis `)` for the `if` condition `if (score > 40)`.
    3.  `else score < 40` is incorrect syntax. It should either be `else if (score < 40)` or just `else`.
    4.  If the intention is to catch scores less than 40, `else if` is needed. However, if the score is exactly 40, neither condition would be met.

### Snippet 4

```csharp
Switch (n) {
    case 1: Console.WriteLine("The number is 1");
    case 2: Console.WriteLine("The number is 2"); break;
    default: Console.WriteLine("The number is not 1 or 2");
    break;
}
```

*   **Issues:**

    1.  `Switch` must be lowercase `switch`.
    2.  In C#, you cannot "fall through" from one case to another if the case contains code. `case 1` needs a `break;` statement.

### Snippet 5

```csharp
switch (n) {
    Case 1: Console.WriteLine("A"); break;
    case2: Console.WriteLine("B"); break;
    Default: Console.WriteLine("C"); break;
}
```

*   **Issues:**

    1.  `Case` must be lowercase `case`.
    2.  `case2:` is missing a space between `case` and `2`.
    3.  `Default` must be lowercase `default`.

---

## Task 4: Output of Code Fragments

### Fragment 1

```csharp
int height = 13;
if ( height <= 12 )
    Console.WriteLine("Low bridge: ");
Console.WriteLine ("proceed with caution.");
```

*   **Output:** `proceed with caution.`
*   **Explanation:** `height` is 13, so `height <= 12` is `false`. The statement `Console.WriteLine("Low bridge: ");` is skipped. The next statement `Console.WriteLine ("proceed with caution.");` is not part of the `if` and executes normally.

### Fragment 2

```csharp
int sum = 21;
if ( sum != 20 )
    Console.WriteLine("You win ");
else
    Console.WriteLine("You lose ");
Console.WriteLine ("the prize.");
```

*   **Output:**

    ```
    You win 
    the prize.
    ```

*   **Explanation:** `sum != 20` is `true` (21 != 20). "You win " is printed. The `else` block is skipped. "the prize." is printed after the `if-else` structure.

### Fragment 3

```csharp
int sum = 7;
if ( sum > 20 ) {
    Console.WriteLine("You win ");
} else {
    Console.WriteLine("You lose ");
}
Console.WriteLine ("the prize.");
```

*   **Output:**

    ```
    You lose 
    the prize.
    ```

*   **Explanation:** `sum > 20` is `false` (7 > 20 is false). The `else` block executes, printing "You lose ". "the prize." is printed after.
