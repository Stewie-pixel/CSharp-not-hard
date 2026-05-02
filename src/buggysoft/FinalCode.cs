using System;
using System.Collections.Generic;
using System.Linq;

namespace DuplicateCode
{
    // Represents a task with description, due date, and importance flag.
    public class Task
    {
        public string Description { get; set; }
        public DateTime DueDate { get; set; }
        public bool IsImportant { get; set; }

        public Task(string description, DateTime dueDate, bool isImportant = false)
        {
            Description = description;
            DueDate = dueDate;
            IsImportant = isImportant;
        }

        public override string ToString() => Description;
    }

    // Represents a category containing a list of tasks.
    public class Category
    {
        public string Name { get; set; }
        public List<Task> Tasks { get; set; }

        public Category(string name)
        {
            Name = name;
            Tasks = new List<Task>();
        }
    }

    class DuplicateCode
    {
        static void Main(string[] args)
        {
            List<Category> categories = new List<Category>
            {
                new Category("Personal"),
                new Category("Work"),
                new Category("Family")
            };

            while (true)
            {
                DisplayTasks(categories);
                DisplayMenu();

                Console.Write("Enter your choice: ");
                string choice = Console.ReadLine().ToLower();

                switch (choice)
                {
                    case "1": // Add Task
                        Console.ResetColor();
                        string listName = GetCategoryChoice(categories);
                        Task newTask = GetTaskInput();
                        Category selectedCategory = categories.Find(c => c.Name.ToLower() == listName);

                        if (selectedCategory != null)
                        {
                            selectedCategory.Tasks.Add(newTask);
                            Console.WriteLine("Task added successfully!");
                        }
                        else
                        {
                            Console.WriteLine("Error: Category not found.");
                        }

                        Console.WriteLine("Press any key to continue...");
                        Console.Read();
                        break;

                    case "2": // Add Category
                        Console.WriteLine("Enter the name for the new category:");
                        Console.Write(">> ");
                        string newCategoryName = Console.ReadLine();

                        if (!string.IsNullOrWhiteSpace(newCategoryName) &&
                            !categories.Any(c => c.Name.Equals(newCategoryName, StringComparison.OrdinalIgnoreCase)))
                        {
                            categories.Add(new Category(newCategoryName));
                            Console.WriteLine($"Category '{newCategoryName}' added successfully!");
                        }
                        else
                        {
                            Console.WriteLine("Category name cannot be empty or already exists.");
                        }

                        Console.WriteLine("Press any key to continue...");
                        Console.Read();
                        break;

                    case "3": // Delete Task
                        Console.ResetColor();
                        Console.WriteLine("--- Delete Task ---");

                        string deleteCategoryName = GetCategoryChoice(categories);
                        Category categoryToDeleteFrom = categories.Find(c => c.Name.ToLower() == deleteCategoryName);

                        if (categoryToDeleteFrom != null && categoryToDeleteFrom.Tasks.Any())
                        {
                            Console.WriteLine($"Enter the item # of the task to delete from '{categoryToDeleteFrom.Name}':");
                            Console.Write(">> ");

                            if (int.TryParse(Console.ReadLine(), out int taskIndex) &&
                                taskIndex >= 0 && taskIndex < categoryToDeleteFrom.Tasks.Count)
                            {
                                string deletedTaskDescription = categoryToDeleteFrom.Tasks[taskIndex].Description;
                                categoryToDeleteFrom.Tasks.RemoveAt(taskIndex);
                                Console.WriteLine($"Task '{deletedTaskDescription}' deleted successfully.");
                            }
                            else
                            {
                                Console.WriteLine("Invalid task number.");
                            }
                        }
                        else
                        {
                            Console.WriteLine("Category not found or contains no tasks.");
                        }

                        Console.WriteLine("Press any key to continue...");
                        Console.Read();
                        break;

                    case "4": // Delete Category
                        Console.ResetColor();
                        Console.WriteLine("--- Delete Category ---");
                        Console.Write("Enter the name of the category to delete:\n>> ");

                        string categoryToDeleteName = Console.ReadLine().ToLower();
                        Category categoryToDelete = categories.Find(c => c.Name.ToLower() == categoryToDeleteName);

                        if (categoryToDelete != null)
                        {
                            categories.Remove(categoryToDelete);
                            Console.WriteLine($"Category '{categoryToDelete.Name}' deleted.");
                        }
                        else
                        {
                            Console.WriteLine("Category not found.");
                        }

                        Console.WriteLine("Press any key to continue...");
                        Console.Read();
                        break;

                    case "5": // Move Task
                        Console.ResetColor();
                        Console.WriteLine("--- Move Task ---");
                        Console.WriteLine("Move within category (1) or to another category (2)?");
                        Console.Write(">> ");
                        string moveChoice = Console.ReadLine();

                        if (moveChoice == "1")
                        {
                            MoveTaskWithinCategory(categories);
                        }
                        else if (moveChoice == "2")
                        {
                            MoveTaskToAnotherCategory(categories);
                        }
                        else
                        {
                            Console.WriteLine("Invalid move choice.");
                        }

                        Console.WriteLine("Press any key to continue...");
                        Console.Read();
                        break;

                    case "6": // Highlight Task
                        Console.ResetColor();
                        Console.WriteLine("--- Highlight Task ---");

                        string highlightCategoryName = GetCategoryChoice(categories);
                        Category categoryToHighlightFrom = categories.Find(c => c.Name.ToLower() == highlightCategoryName);

                        if (categoryToHighlightFrom != null && categoryToHighlightFrom.Tasks.Any())
                        {
                            Console.WriteLine($"Enter the item # of the task to toggle importance:");
                            Console.Write(">> ");

                            if (int.TryParse(Console.ReadLine(), out int taskIndex) &&
                                taskIndex >= 0 && taskIndex < categoryToHighlightFrom.Tasks.Count)
                            {
                                Task task = categoryToHighlightFrom.Tasks[taskIndex];
                                task.IsImportant = !task.IsImportant;
                                Console.WriteLine($"Task '{task.Description}' importance set to {task.IsImportant}.");
                            }
                            else
                            {
                                Console.WriteLine("Invalid task number.");
                            }
                        }
                        else
                        {
                            Console.WriteLine("Category not found or contains no tasks.");
                        }

                        Console.WriteLine("Press any key to continue...");
                        Console.Read();
                        break;

                    case "7":
                        Console.WriteLine("Exiting application. Goodbye!");
                        return;

                    default:
                        Console.WriteLine("Invalid choice.");
                        Console.WriteLine("Press any key to continue...");
                        Console.Read();
                        break;
                }
            }
        }

        // Helper Methods

        static void DisplayMenu()
        {
            Console.WriteLine("--- Main Menu ---");
            Console.WriteLine("1. Add New Task");
            Console.WriteLine("2. Add New Category");
            Console.WriteLine("3. Delete Task");
            Console.WriteLine("4. Delete Category");
            Console.WriteLine("5. Move Task");
            Console.WriteLine("6. Highlight Task");
            Console.WriteLine("7. Exit");
        }

        // Prompts user to choose a valid category.
        static string GetCategoryChoice(List<Category> categories)
        {
            while (true)
            {
                Console.WriteLine("Choose a category:");
                foreach (var category in categories)
                    Console.Write($"'{category.Name}' ");

                Console.Write("\n>> ");
                string choice = Console.ReadLine().ToLower();

                if (categories.Any(c => c.Name.ToLower() == choice))
                    return choice;

                Console.WriteLine("Invalid category. Try again.");
            }
        }

        // Collects task details from user.
        static Task GetTaskInput()
        {
            Console.WriteLine("Enter task description (max 30 chars):");
            Console.Write(">> ");
            string description = Console.ReadLine();
            if (description.Length > 30)
                description = description.Substring(0, 30);

            Console.WriteLine("Enter due date (YYYY-MM-DD, blank = today):");
            Console.Write(">> ");
            string dateInput = Console.ReadLine();

            DateTime dueDate = DateTime.Today;
            if (DateTime.TryParse(dateInput, out DateTime parsed))
                dueDate = parsed;

            Console.WriteLine("Is this task important? (yes/no):");
            Console.Write(">> ");
            bool important = Console.ReadLine().ToLower() == "yes";

            return new Task(description, dueDate, important);
        }

        // Displays tasks in a table layout.
        static void DisplayTasks(List<Category> categories)
        {
            int max = categories.Max(c => c.Tasks.Count);

            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("            CATEGORIES");
            Console.WriteLine("          " + new string('-', 108));

            Console.Write("{0,10}|", "item #");
            foreach (var category in categories)
                Console.Write("{0,-36}|", category.Name);

            Console.WriteLine();
            Console.WriteLine("          " + new string('-', 108));

            for (int i = 0; i < max; i++)
            {
                Console.Write("{0,10}|", i);

                foreach (var category in categories)
                {
                    if (category.Tasks.Count > i)
                    {
                        Task task = category.Tasks[i];
                        if (task.IsImportant)
                            Console.ForegroundColor = ConsoleColor.Red;

                        Console.Write("{0,-36}|", $"{task.Description} ({task.DueDate:yyyy-MM-dd})");
                        Console.ResetColor();
                    }
                    else
                    {
                        Console.Write("{0,-36}|", "N/A");
                    }
                }

                Console.WriteLine();
            }

            Console.ResetColor();
        }

        // Move Task Helpers

        static void MoveTaskWithinCategory(List<Category> categories)
        {
            string sourceName = GetCategoryChoice(categories);
            Category source = categories.Find(c => c.Name.ToLower() == sourceName);

            if (source == null || !source.Tasks.Any())
            {
                Console.WriteLine("Category not found or empty.");
                return;
            }

            Console.WriteLine("Enter task # to move:");
            Console.Write(">> ");

            if (!int.TryParse(Console.ReadLine(), out int oldIndex) ||
                oldIndex < 0 || oldIndex >= source.Tasks.Count)
            {
                Console.WriteLine("Invalid task number.");
                return;
            }

            Console.WriteLine("Enter new position:");
            Console.Write(">> ");

            if (!int.TryParse(Console.ReadLine(), out int newIndex) ||
                newIndex < 0 || newIndex >= source.Tasks.Count)
            {
                Console.WriteLine("Invalid new position.");
                return;
            }

            Task task = source.Tasks[oldIndex];
            source.Tasks.RemoveAt(oldIndex);
            source.Tasks.Insert(newIndex, task);

            Console.WriteLine($"Task '{task.Description}' moved.");
        }

        static void MoveTaskToAnotherCategory(List<Category> categories)
        {
            string sourceName = GetCategoryChoice(categories);
            Category source = categories.Find(c => c.Name.ToLower() == sourceName);

            if (source == null || !source.Tasks.Any())
            {
                Console.WriteLine("Source category not found or empty.");
                return;
            }

            Console.WriteLine("Enter task # to move:");
            Console.Write(">> ");

            if (!int.TryParse(Console.ReadLine(), out int oldIndex) ||
                oldIndex < 0 || oldIndex >= source.Tasks.Count)
            {
                Console.WriteLine("Invalid task number.");
                return;
            }

            Task task = source.Tasks[oldIndex];

            Console.WriteLine("Choose destination category:");
            string destName = GetCategoryChoice(categories);
            Category dest = categories.Find(c => c.Name.ToLower() == destName);

            Console.WriteLine($"Enter new position (0 to {dest.Tasks.Count}):");
            Console.Write(">> ");

            if (!int.TryParse(Console.ReadLine(), out int newIndex) ||
                newIndex < 0 || newIndex > dest.Tasks.Count)
            {
                Console.WriteLine("Invalid position.");
                return;
            }

            source.Tasks.RemoveAt(oldIndex);
            dest.Tasks.Insert(newIndex, task);

            Console.WriteLine($"Task '{task.Description}' moved to '{dest.Name}'.");
        }
    }
}
