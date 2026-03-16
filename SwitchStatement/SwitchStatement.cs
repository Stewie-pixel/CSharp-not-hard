using System;

class SwitchStatement
{
    static void Main(string[] args)
    {
        try
        {
            Console.WriteLine("Enter a number (as an integer): ");
            int number = Convert.ToInt32(Console.ReadLine());

            switch (number)
            {
                case 1:
                    Console.WriteLine("ONE");
                    break;
                case 2:
                    Console.WriteLine("TWO");
                    break;
                case 3:
                    Console.WriteLine("THREE");
                    break;
                case 4:
                    Console.WriteLine("FOUR");
                    break;
                case 5:
                    Console.WriteLine("FIVE");
                    break;
                case 6:
                    Console.WriteLine("SIX");
                    break;
                case 7:
                    Console.WriteLine("SEVEN");
                    break;
                case 8:
                    Console.WriteLine("EIGHT");
                    break;
                case 9:
                    Console.WriteLine("NINE");
                    break;
                default:
                    Console.WriteLine("Error: you must enter an integer between 1 and 9");
                    break;
            }
        }
        catch (FormatException)
        {
            Console.WriteLine("Error: Invalid input. Please enter an integer.");
        }
        catch (OverflowException)
        {
            Console.WriteLine("Error: Number is too large or too small.");
        }

        Console.WriteLine("Press any key to exit...");
        Console.ReadKey();
    }
}
