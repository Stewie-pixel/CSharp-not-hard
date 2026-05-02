using System;
using System.Collections.Generic;
using System.Linq;

namespace DuplicateCode
{
    /// <summary>
    /// Represents a single task with a description, due date, and importance status.
    /// </summary>
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

        public override string ToString()
        {
            return Description; // For now, just return the description. Will be enhanced later for display.
        }
    }

    /// <summary>
    /// Represents a category that contains a list of tasks.
    /// </summary>
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
                Console.Clear();
                DisplayTasks(categories);
                DisplayMenu();

                Console.Write("\nEnter your choice: ");
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
                            Console.WriteLine("Error: Category not found. This should not happen with validation.");
                        }
                        Console.WriteLine("Press any key to continue...");
                        Console.ReadKey();
                        break;
                    case "2": // Add Category
                        Console.WriteLine("Enter the name for the new category:");
                        Console.Write(">> ");
                        string newCategoryName = Console.ReadLine();
                        if (!string.IsNullOrWhiteSpace(newCategoryName) && !categories.Any(c => c.Name.ToLower() == newCategoryName.ToLower()))
                        {
                            categories.Add(new Category(newCategoryName));
                            Console.WriteLine($"Category '{newCategoryName}' added successfully!");
                        }
                        else
                        {
                            Console.WriteLine("Category name cannot be empty or already exists.");
                        }
                        Console.WriteLine("Press any key to continue...");
                        Console.ReadKey();
                        break;
                    case "3": // Delete Task
                        Console.ResetColor();
                        Console.WriteLine("\n--- Delete Task ---");
                        string deleteCategoryName = GetCategoryChoice(categories);
                        Category categoryToDeleteFrom = categories.Find(c => c.Name.ToLower() == deleteCategoryName);

                        if (categoryToDeleteFrom != null && categoryToDeleteFrom.Tasks.Any())
                        {
                            Console.WriteLine($"Enter the item # of the task to delete from '{categoryToDeleteFrom.Name}':");
                            Console.Write(">> ");
                            if (int.TryParse(Console.ReadLine(), out int taskIndex) && taskIndex >= 0 && taskIndex < categoryToDeleteFrom.Tasks.Count)
                            {
                                string deletedTaskDescription = categoryToDeleteFrom.Tasks[taskIndex].Description;
                                categoryToDeleteFrom.Tasks.RemoveAt(taskIndex);
                                Console.WriteLine($"Task '{deletedTaskDescription}' deleted successfully from '{categoryToDeleteFrom.Name}'.");
                            }
                            else
                            {
                                Console.WriteLine("Invalid task item number.");
                            }
                        }
                        else
                        {
                            Console.WriteLine($"Category '{deleteCategoryName}' not found or contains no tasks.");
                        }
                        Console.WriteLine("Press any key to continue...");
                        Console.ReadKey();
                        break;
                    case "4": // Delete Category
                        Console.ResetColor();
                        Console.WriteLine("\n--- Delete Category ---");
                        Console.WriteLine("Enter the name of the category to delete:");
                        Console.Write(">> ");
                        string categoryToDeleteName = Console.ReadLine().ToLower();

                        Category categoryToDelete = categories.Find(c => c.Name.ToLower() == categoryToDeleteName);
                        if (categoryToDelete != null)
                        {
                            categories.Remove(categoryToDelete);
                            Console.WriteLine($"Category '{categoryToDelete.Name}' and all its tasks deleted successfully.");
                        }
                        else
                        {
                            Console.WriteLine($"Category '{categoryToDeleteName}' not found.");
                        }
                        Console.WriteLine("Press any key to continue...");
                        Console.ReadKey();
                        break;
                    case "5": // Move Task
                        Console.ResetColor();
                        Console.WriteLine("\n--- Move Task ---");
                        Console.WriteLine("Move task within a category (1) or to another category (2)?");
                        Console.Write(">> ");
                        string moveChoice = Console.ReadLine();

                        if (moveChoice == "1") // Move within a category
                        {
                            string sourceCategoryName = GetCategoryChoice(categories);
                            Category sourceCategory = categories.Find(c => c.Name.ToLower() == sourceCategoryName);

                            if (sourceCategory != null && sourceCategory.Tasks.Any())
                            {
                                Console.WriteLine($"Enter the item # of the task to move from '{sourceCategory.Name}':");
                                Console.Write(">> ");
                                if (int.TryParse(Console.ReadLine(), out int oldIndex) && oldIndex >= 0 && oldIndex < sourceCategory.Tasks.Count)
                                {
                                    Console.WriteLine($"Enter the new item # for the task within '{sourceCategory.Name}':");
                                    Console.Write(">> ");
                                    if (int.TryParse(Console.ReadLine(), out int newIndex) && newIndex >= 0 && newIndex < sourceCategory.Tasks.Count)
                                    {
                                        Task taskToMove = sourceCategory.Tasks[oldIndex];
                                        sourceCategory.Tasks.RemoveAt(oldIndex);
                                        sourceCategory.Tasks.Insert(newIndex, taskToMove);
                                        Console.WriteLine($"Task '{taskToMove.Description}' moved successfully within '{sourceCategory.Name}'.");
                                    }
                                    else
                                    {
                                        Console.WriteLine("Invalid new item number.");
                                    }
                                }
                                else
                                {
                                    Console.WriteLine("Invalid old item number.");
                                }
                            }
                            else
                            {
                                Console.WriteLine($"Category '{sourceCategoryName}' not found or contains no tasks.");
                            }
                        }
                        else if (moveChoice == "2") // Move to another category
                        {
                            Console.WriteLine("\n--- Move Task to Another Category ---");
                            string sourceCategoryName = GetCategoryChoice(categories);
                            Category sourceCategory = categories.Find(c => c.Name.ToLower() == sourceCategoryName);

                            if (sourceCategory != null && sourceCategory.Tasks.Any())
                            {
                                Console.WriteLine($"Enter the item # of the task to move from '{sourceCategory.Name}':");
                                Console.Write(">> ");
                                if (int.TryParse(Console.ReadLine(), out int oldIndex) && oldIndex >= 0 && oldIndex < sourceCategory.Tasks.Count)
                                {
                                    Task taskToMove = sourceCategory.Tasks[oldIndex];

                                    Console.WriteLine("Enter the name of the destination category:");
                                    string destinationCategoryName = GetCategoryChoice(categories);
                                    Category destinationCategory = categories.Find(c => c.Name.ToLower() == destinationCategoryName);

                                    if (destinationCategory != null)
                                    {
                                        Console.WriteLine($"Enter the new item # for the task within '{destinationCategory.Name}' (0 to {destinationCategory.Tasks.Count}):");
                                        Console.Write(">> ");
                                        if (int.TryParse(Console.ReadLine(), out int newIndex) && newIndex >= 0 && newIndex <= destinationCategory.Tasks.Count)
                                        {
                                            sourceCategory.Tasks.RemoveAt(oldIndex);
                                            destinationCategory.Tasks.Insert(newIndex, taskToMove);
                                            Console.WriteLine($"Task '{taskToMove.Description}' moved successfully from '{sourceCategory.Name}' to '{destinationCategory.Name}'.");
                                        }
                                        else
                                        {
                                            Console.WriteLine("Invalid new item number in destination category.");
                                        }
                                    }
                                    else
                                    {
                                        Console.WriteLine("Destination category not found.");
                                    }
                                }
                                else
                                {
                                    Console.WriteLine("Invalid task item number in source category.");
                                }
                            }
                            else
                            {
                                Console.WriteLine($"Source category '{sourceCategoryName}' not found or contains no tasks.");
                            }
                        }
                        else
                        {
                            Console.WriteLine("Invalid move choice.");
                        }
                        Console.WriteLine("Press any key to continue...");
                        Console.ReadKey();
                        break;
                    case "6": // Highlight Task
                        Console.ResetColor();
                        Console.WriteLine("\n--- Highlight Task ---");
                        string highlightCategoryName = GetCategoryChoice(categories);
                        Category categoryToHighlightFrom = categories.Find(c => c.Name.ToLower() == highlightCategoryName);

                        if (categoryToHighlightFrom != null && categoryToHighlightFrom.Tasks.Any())
                        {
                            Console.WriteLine($"Enter the item # of the task to highlight/unhighlight from '{categoryToHighlightFrom.Name}':");
                            Console.Write(">> ");
                            if (int.TryParse(Console.ReadLine(), out int taskIndex) && taskIndex >= 0 && taskIndex < categoryToHighlightFrom.Tasks.Count)
                            {
                                categoryToHighlightFrom.Tasks[taskIndex].IsImportant = !categoryToHighlightFrom.Tasks[taskIndex].IsImportant;
                                Console.WriteLine($"Task '{categoryToHighlightFrom.Tasks[taskIndex].Description}' importance toggled to '{categoryToHighlightFrom.Tasks[taskIndex].IsImportant}'.");
                            }
                            else
                            {
                                Console.WriteLine("Invalid task item number.");
                            }
                        }
                        else
                        {
                            Console.WriteLine($"Category '{highlightCategoryName}' not found or contains no tasks.");
                        }
                        Console.WriteLine("Press any key to continue...");
                        Console.ReadKey();
                        break;
                    case "7": // Exit
                        Console.WriteLine("Exiting application. Goodbye!");
                        return;
                    default:
                        Console.WriteLine("Invalid choice. Please try again.");
                        Console.WriteLine("Press any key to continue...");
                        Console.ReadKey();
                        break;
                }
            }
        }

        /// <summary>
        /// Displays the main menu options to the user.
        /// </summary>
        static void DisplayMenu()
        {
            Console.WriteLine("\n--- Main Menu ---");
            Console.WriteLine("1. Add New Task");
            Console.WriteLine("2. Add New Category");
            Console.WriteLine("3. Delete Task");
            Console.WriteLine("4. Delete Category");
            Console.WriteLine("5. Move Task");
            Console.WriteLine("6. Highlight Task");
            Console.WriteLine("7. Exit");
        }



        /// <summary>
        /// Prompts the user to choose a category and returns the validated choice.
        /// </summary>
        /// <param name="categories">The list of available categories.</param>
        /// <returns>The chosen category name (personal, work, or family).</returns>
        static string GetCategoryChoice(List<Category> categories)
        {
            string choice;
            while (true)
            {
                Console.WriteLine("\nWhich category do you want to place a new task? Type one of the existing category names:");
                foreach (var category in categories)
                {
                    Console.Write($"\'{category.Name}\' ");
                }
                Console.WriteLine();
                Console.Write(">> ");
                choice = Console.ReadLine().ToLower();
                if (categories.Any(c => c.Name.ToLower() == choice))
                {
                    return choice;
                }
                else
                {
                    Console.WriteLine("Invalid category. Please type one of the existing category names.");
                }
            }
        }

        /// <summary>
        /// Prompts the user to enter task details (description, due date, importance) and returns a Task object.
        /// </summary>
        /// <returns>A new Task object with user-provided details.</returns>
        static Task GetTaskInput()
        {
            Console.WriteLine("Describe your task below (max. 30 symbols).");
            Console.Write(">> ");
            string description = Console.ReadLine();
            if (description.Length > 30) description = description.Substring(0, 30);

            DateTime dueDate = DateTime.Today;
            Console.WriteLine("Enter due date (YYYY-MM-DD, leave blank for today):");
            Console.Write(">> ");
            string dateInput = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(dateInput) && DateTime.TryParse(dateInput, out DateTime parsedDate))
            {
                dueDate = parsedDate;
            }

            bool isImportant = false;
            Console.WriteLine("Is this task important? (yes/no, default no):");
            Console.Write(">> ");
            string importantInput = Console.ReadLine().ToLower();
            if (importantInput == "yes")
            {
                isImportant = true;
            }

            return new Task(description, dueDate, isImportant);
        }

        /// <summary>
        /// Displays the tasks in a tabular format for all categories.
        /// </summary>
        /// <param name="categories">The list of categories, each containing its tasks.</param>
        static void DisplayTasks(List<Category> categories)
        {
            int max = 0;
            foreach (var category in categories)
            {
                if (category.Tasks.Count > max)
                {
                    max = category.Tasks.Count;
                }
            }

            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine(new string(' ', 12) + "CATEGORIES");
            Console.WriteLine(new string(' ', 10) + new string('-', 108)); // Increased line length for date
            Console.Write("{0,10}|", "item #");
            foreach (var category in categories)
            {
                Console.Write("{0,-36}|", category.Name); // Increased column width
            }
            Console.WriteLine();
            Console.WriteLine(new string(' ', 10) + new string('-', 108)); // Increased line length
            for (int i = 0; i < max; i++)
            {
                Console.Write("{0,10}|", i);

                foreach (var category in categories)
                {
                    if (category.Tasks.Count > i)
                    {
                        Task task = category.Tasks[i];
                        if (task.IsImportant)
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                        }
                        Console.Write("{0,-36}|", $"{task.Description} ({task.DueDate:yyyy-MM-dd})"); // Display description and date
                        Console.ResetColor(); // Reset color after printing
                    }
                    else
                    {
                        Console.Write("{0,-36}|", "N/A"); // Increased column width
                    }
                }
                Console.WriteLine();
            }
            Console.ResetColor(); // Reset color finally
        }
    }
}
