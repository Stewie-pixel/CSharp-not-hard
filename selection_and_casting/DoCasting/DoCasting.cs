using System;

class DoCasting
{
    static void Main(string[] args)
    {
        int sum = 17;
        int count = 5;

        // Declare an integer variable called intAverage
        int intAverage;

        // Calculate the integer average
        intAverage = sum / count;

        // Print out the integer average
        Console.WriteLine("intAverage (sum / count): " + intAverage);
        // Is this correct? No, it truncates the decimal part (17 / 5 = 3.4, but intAverage is 3).

        // Declare a double variable called doubleAverage
        double doubleAverage;

        // Now try calculating the double average without casting
        doubleAverage = sum / count;
        Console.WriteLine("doubleAverage without casting (sum / count): " + doubleAverage);
        // Is this result correct? No, it's 3.0 because 'sum / count' is performed as integer division before being assigned to double.

        // Cast the sum variable to a double and divide by count
        doubleAverage = (double)sum / count;
        Console.WriteLine("doubleAverage with casting ((double)sum / count): " + doubleAverage);
        // Is this result correct? Yes, it's 3.4.

        Console.WriteLine("Press any key to exit...");
        Console.ReadKey();
    }
}
