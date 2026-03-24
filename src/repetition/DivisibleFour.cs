using System;

class DivisibleFour
{
    static void Main(string[] args)
    {
        Console.Write("Enter an upper limit n: ");
        string input = Console.ReadLine();
        int n;

        if (int.TryParse(input, out n))
        {
            Console.WriteLine("Numbers between 1 and " + n + " divisible by 4 but not 5:");
            for (int i = 1; i <= n; i++)
            {
                if (i % 4 == 0 && i % 5 != 0)
                {
                    Console.WriteLine(i);
                }
            }
        }
        else
        {
            Console.WriteLine("Invalid input! Please enter an integer.");
        }
    }
}
