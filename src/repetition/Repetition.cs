using System;

class Repetition
{
    static void Main(string[] args)
    {
        Console.WriteLine("--- Task 1: For Loop ---");
        int sum = 0;
        double average;
        int upperbound = 100;

        for (int number = 1; number <= upperbound; number++)
        {
            sum += number;
        }

        average = (double)sum / upperbound;
        Console.WriteLine("The sum is " + sum);
        Console.WriteLine("The average is " + average);

        Console.WriteLine("\n--- Task 2: While Loop ---");
        sum = 0;
        int count = 1;
        while (count <= upperbound)
        {
            sum += count;
            Console.WriteLine("Current number: " + count + " the sum is " + sum);
            count++;
        }
        average = (double)sum / upperbound;
        Console.WriteLine("The sum is " + sum);
        Console.WriteLine("The average is " + average);

        Console.WriteLine("\n--- Task 3: Do-While Loop ---");
        sum = 0;
        count = 1;
        do
        {
            sum += count;
            Console.WriteLine("Current number: " + count + " the sum is " + sum);
            count++;
        } while (count <= upperbound);
        average = (double)sum / upperbound;
        Console.WriteLine("The sum is " + sum);
        Console.WriteLine("The average is " + average);
    }
}
