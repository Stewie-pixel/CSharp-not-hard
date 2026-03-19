# Task 1.2P Analysis: Repetition and Control Structures

## 1. Differences Between Loop Structures

### `for` vs. `while` Loops
*   **`for` loop:** Best used when the number of iterations is known beforehand. It consolidates initialization, condition checking, and the increment/decrement step into a single line, making the code more readable for fixed-count iterations.
*   **`while` loop:** Best used when the number of iterations depends on a condition that is not a simple counter (e.g., waiting for specific user input or a state change). It is a "pre-test" loop, meaning the condition is checked *before* the loop body executes.

### `while` vs. `do...while` Loops
*   **`while` loop:** If the condition is false initially, the loop body will **never** execute.
*   **`do...while` loop:** This is a "post-test" loop. The body executes once *before* the condition is checked. This ensures the loop always runs **at least once**, which is ideal for tasks like input validation where you must prompt the user at least one time.

---

## 2. Debugging Snippets (Task 4) Analysis

### Snippet 1
*   **Issue:** `product` is initialized to `0`. Multiplying `0 * 5` always results in `0`.
*   **Fix:** Initialize `product` to `1`.

### Snippet 2
*   **Issue:** Infinite loop. `a` is 31 (odd) and `b` increments by 2 starting from 0 (even). `b` will jump from 30 to 32, never equaling 31.
*   **Fix:** Changed condition to `while (b <= a)`.

### Snippet 3
*   **Issue:** `total` is declared but not initialized. C# does not allow using unassigned local variables in expressions like `total + x`.
*   **Fix:** Initialize `total = 0`.

### Snippet 4
*   **Issue:** Logical error/Infinite loop. `int y = 0` is inside the loop. Every iteration resets `y` to 0, so `y < 10` remains true forever.
*   **Fix:** Move the declaration of `y` outside the loop.

### Snippet 5
*   **Issue:** Logic error. `z` starts at 0, and the condition is `z > 0`. The loop body never executes.
*   **Fix:** Initialize `z` to a positive value (e.g., `5`).

### Snippet 6
*   **Issue:** Syntax error. The `for` loop uses commas (`,`) instead of semicolons (`;`) to separate parts.
*   **Fix:** Replace commas with semicolons: `for(int count = 1; count < 100; count++)`.

### Snippet 7
*   **Issue:** Logic error. The condition `i > 10` is false immediately since `i` starts at 1. The loop never runs.
*   **Fix:** Change condition to `i < 10` or `i <= 10`.

---

## 3. Rewriting Analysis (Task 5)

When converting `while` to `for` loops:
1.  The **initialization** (e.g., `int j = -5`) moves to the first part of the `for` header.
2.  The **condition** (e.g., `sum <= 350`) stays in the middle.
3.  The **update expression** (e.g., `j += 5`) moves to the final part of the `for` header.

This transformation results in cleaner code by keeping all loop control logic in one place.
