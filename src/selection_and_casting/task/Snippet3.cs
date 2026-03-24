using System;

class Snippet3
{
    static void Main(string[] args)
    {
        double score = 40;
        if (score > 40)
        {
            Console.WriteLine("You passed the exam!");
        }
        else if (score < 40)
        {
            Console.WriteLine("You failed the exam!");
        }
        else
        {
            Console.WriteLine("Your score is exactly 40.");
        }
    }
}
