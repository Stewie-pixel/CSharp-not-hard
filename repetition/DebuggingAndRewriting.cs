using System;

class DebuggingAndRewriting
{
    static void Main(string[] args)
    {
        Console.WriteLine("--- Task 4: Debugging Snippets ---");

        // Snippet 1 Fix: Initialize product to 1
        int c1 = 1, product1 = 1; 
        while (c1 <= 5) {
            product1 = product1 * 5;
            c1 = c1 + 1;
        }
        Console.WriteLine("Snippet 1 Fixed: product = " + product1);

        // Snippet 2 Fix: Change condition to avoid infinite loop
        int a2 = 31, b2 = 0, sum2 = 0;
        while (b2 <= a2) { // Changed != to <=
            sum2 = sum2 + a2;
            b2 = b2 + 2;
        }
        Console.WriteLine("Snippet 2 Fixed: sum = " + sum2);

        // Snippet 3 Fix: Initialize total
        int x3 = 1;
        int total3 = 0; // Initialized
        while (x3 <= 10) {
            total3 = total3 + x3;
            x3 = x3 + 1;
        }
        Console.WriteLine("Snippet 3 Fixed: total = " + total3);

        // Snippet 4 Fix: Move y declaration outside
        int y4 = 0;
        while (y4 < 10) {
            Console.WriteLine("Snippet 4 y: " + y4);
            y4 = y4 + 1;
        }

        // Snippet 5 Fix: Change z or condition
        int z5 = 5; // Changed from 0 to 5
        while (z5 > 0) {
            z5 = z5 - 1;
            Console.WriteLine("Snippet 5 z: " + z5);
        }

        // Snippet 6 Fix: Use semicolons in for loop
        for(int count6 = 1; count6 < 5; count6++) { // Using 5 for brevity
            Console.WriteLine("Snippet 6 Hello " + count6);
        }

        // Snippet 7 Fix: Correct for loop condition
        for(int i7 = 1; i7 < 10; i7++) { // Changed > to <
            if (i7 > 2) {
                Console.WriteLine("Snippet 7 Flower " + i7);
            }
        }

        Console.WriteLine("\n--- Task 5: Rewriting While as For ---");

        // Snippet 1 Rewrite
        int sum5_1 = 0;
        for (int j5_1 = -5; sum5_1 <= 350; j5_1 += 5)
        {
            sum5_1 += j5_1;
        }
        Console.WriteLine("Task 5.1 Rewritten Sum: " + sum5_1);

        // Snippet 2 Rewrite
        Console.WriteLine("Task 5.2 Rewritten Sequence:");
        for (int x5_2 = 0; x5_2 < 50; x5_2 += 5) // Using 50 for brevity
        {
            Console.WriteLine(x5_2);
        }
    }
}
