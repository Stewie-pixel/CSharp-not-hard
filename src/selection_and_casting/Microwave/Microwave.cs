using System;
using System.Diagnostics;

class Microwave
{
    static void Main(string[] args)
    {
        try
        {
            Debugger.Break(); // Breakpoint at start of execution
            Console.WriteLine("Microwave Time Tracker");
            
            Console.WriteLine("Enter the number of items: ");
            int numberOfItems = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Enter the single-item heating time (in seconds): ");
            double singleItemTime = Convert.ToDouble(Console.ReadLine());

            if (numberOfItems == 1)
            {
                Debugger.Break(); // Breakpoint for 1 item
                Console.WriteLine($"Recommended heating time: {singleItemTime} seconds.");
            }
            else if (numberOfItems == 2)
            {
                Debugger.Break(); // Breakpoint for 2 items
                double recommendedTime = singleItemTime * 1.5;
                Console.WriteLine($"Recommended heating time: {recommendedTime} seconds.");
            }
            else if (numberOfItems == 3)
            {
                Debugger.Break(); // Breakpoint for 3 items
                double recommendedTime = singleItemTime * 2.0;
                Console.WriteLine($"Recommended heating time: {recommendedTime} seconds.");
            }
            else if (numberOfItems > 3)
            {
                Debugger.Break(); // Breakpoint for more than 3 items
                Console.WriteLine("Heating more than 3 items is not recommended.");
            }
            else
            {
                Debugger.Break(); // Breakpoint for invalid number of items
                Console.WriteLine("Error: Invalid number of items.");
            }
        }
        catch (FormatException) // Sb usually mistype
        {
            Debugger.Break(); // Breakpoint for format error
            Console.WriteLine("Error: Please enter valid numbers.");
        }
        catch (OverflowException) // Just to make sure user does not know that a microwave has its limit (Even with a digital one)
        {
            Debugger.Break(); // Breakpoint for overflow error
            Console.WriteLine("Error: Number is too large.");
        }
        Console.ReadLine();
    }
}
