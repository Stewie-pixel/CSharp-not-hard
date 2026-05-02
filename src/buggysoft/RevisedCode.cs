using System;
using System.Collections.Generic;

namespace DuplicateCode
{
    class DuplicateCode
    {
        static void Main(string[] args)
        {
            // Separate lists for each category
            List<string> tasksIndividual = new List<string>();
            List<string> tasksWork = new List<string>();
            List<string> tasksFamilly = new List<string>();

            while (true)
            {
                DisplayTasks(tasksIndividual, tasksWork, tasksFamilly);

                Console.ResetColor();
                string listName = GetCategoryChoice();   // Ask user which category
                string task = GetTaskInput();            // Ask user for task text

                AddTaskToCategory(listName, task, tasksIndividual, tasksWork, tasksFamilly);
            }
        }

        // Adds a task to the correct category list
        static void AddTaskToCategory(string listName, string task,
            List<string> tasksIndividual, List<string> tasksWork, List<string> tasksFamilly)
        {
            if (listName == "personal")
                tasksIndividual.Add(task);
            else if (listName == "work")
                tasksWork.Add(task);
            else if (listName == "family")
                tasksFamilly.Add(task);
        }

        // Asks the user to choose Personal, Work, or Family
        static string GetCategoryChoice()
        {
            while (true)
            {
                Console.WriteLine("Which category? Type 'Personal', 'Work', or 'Family'");
                Console.Write(">> ");
                string choice = Console.ReadLine().ToLower();

                if (choice == "personal" || choice == "work" || choice == "family")
                    return choice;

                Console.WriteLine("Invalid category. Try again.");
            }
        }

        // Gets a task description (max 30 characters)
        static string GetTaskInput()
        {
            Console.WriteLine("Describe your task (max 30 characters):");
            Console.Write(">> ");
            string task = Console.ReadLine();

            if (task.Length > 30)
                task = task.Substring(0, 30);

            return task;
        }

        // Displays tasks in a simple table layout
        static void DisplayTasks(List<string> tasksIndividual, List<string> tasksWork, List<string> tasksFamilly)
        {
            int max = Math.Max(tasksIndividual.Count, Math.Max(tasksWork.Count, tasksFamilly.Count));

            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine(new string(' ', 12) + "CATEGORIES");
            Console.WriteLine(new string(' ', 10) + new string('-', 94));
            Console.WriteLine("{0,10}|{1,30}|{2,30}|{3,30}|", "item #", "Personal", "Work", "Family");
            Console.WriteLine(new string(' ', 10) + new string('-', 94));

            for (int i = 0; i < max; i++)
            {
                Console.Write("{0,10}|", i);

                Console.Write("{0,30}|", tasksIndividual.Count > i ? tasksIndividual[i] : "N/A");
                Console.Write("{0,30}|", tasksWork.Count > i ? tasksWork[i] : "N/A");
                Console.Write("{0,30}|", tasksFamilly.Count > i ? tasksFamilly[i] : "N/A");

                Console.WriteLine();
            }

            Console.ResetColor();
        }
    }
}
