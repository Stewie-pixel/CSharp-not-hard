using System;
using System.Collections.Generic;

namespace ArraysAndLists
{
    class Program
    { 
        static void Main(string[] args)
        {
            Console.WriteLine("--- Task 1: Basic Array Declaration and Manual Initialization ---");
            Task1();

            Console.WriteLine("\n--- Task 2: Array Initialization and Iteration with For Loops ---");
            Task2();

            Console.WriteLine("\n--- Task 3: Array Initializers and Basic Calculations (Sum/Average) ---");
            Task3();

            Console.WriteLine("\n--- Task 4: Collecting User Input into an Array ---");
            Task4();

            Console.WriteLine("\n--- Task 5: Finding Minimum and Maximum Values in an Array ---");
            Task5();

            Console.WriteLine("\n--- Task 6: Working with 2D Arrays (Matrices) ---");
            Task6();

            Console.WriteLine("\n--- Task 7: Using Dynamic Lists (List<T>) and Random Numbers ---");
            Task7();

            Console.WriteLine("\n--- Task 8: Palindrome Check Algorithm ---");
            Task8();

            Console.WriteLine("\n--- Task 9: Merging Two Sorted Lists ---");
            Task9();

            Console.WriteLine("\n--- Task 10: Extracting Odd Numbers from 2D Array (Column-Major) ---");
            Task10();
        }

        static void Task1()
        {
            // STEP 1: Declare a double array capable of holding 10 elements.
            double[] myArray = new double[10];

            // Manually initialize each element by its index (0-based indexing).
            myArray[0] = 1.0;
            myArray[1] = 1.1;
            myArray[2] = 1.2;
            myArray[3] = 1.3;
            myArray[4] = 1.4;
            myArray[5] = 1.5;
            myArray[6] = 1.6;
            myArray[7] = 1.7;
            myArray[8] = 1.8;
            myArray[9] = 1.9;

            // STEP 2: Access and print each element individually using its index.
            Console.WriteLine("The element at index 0 in the array is " + myArray[0]);
            Console.WriteLine("The element at index 1 in the array is " + myArray[1]);
            Console.WriteLine("The element at index 2 in the array is " + myArray[2]);
            Console.WriteLine("The element at index 3 in the array is " + myArray[3]);
            Console.WriteLine("The element at index 4 in the array is " + myArray[4]);
            Console.WriteLine("The element at index 5 in the array is " + myArray[5]);
            Console.WriteLine("The element at index 6 in the array is " + myArray[6]);
            Console.WriteLine("The element at index 7 in the array is " + myArray[7]);
            Console.WriteLine("The element at index 8 in the array is " + myArray[8]);
            Console.WriteLine("The element at index 9 in the array is " + myArray[9]);
        }

        static void Task2()
        {
            // STEP 1: Declare an integer array of size 10.
            int[] myArray = new int[10];

            // Use a for loop to populate the array with values corresponding to their index.
            for (int i = 0; i < 10; i++)
            {
                myArray[i] = i;
            }

            // STEP 2: Use another for loop to iterate through the array and print each value.
            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine("The element at position " + i + " in the array is " + myArray[i]);
            }
        }

        static void Task3()
        {
            // Initialize an array with a set of predefined integer values.
            int[] studentArray = { 87, 68, 94, 100, 83, 78, 85, 91, 76, 87 };
            int total = 0;

            // Iterate through the array to calculate the sum of all elements.
            for (int i = 0; i < studentArray.Length; i++)
            {
                total += studentArray[i];
            }

            // Calculate and display the total and the average mark.
            // Note the cast to (double) to ensure floating-point division.
            Console.WriteLine("The total marks for the student is: " + total);
            Console.WriteLine("This consist of " + studentArray.Length + " marks");
            Console.WriteLine("Therefore the average mark is " + (double)total / studentArray.Length);
        }
        static void Task4()
        {
            string[] studentNames = new string[6];

            // Prompt the user to enter a name for each slot in the array.
            for (int i = 0; i < studentNames.Length; i++)
            {
                Console.Write("Enter name for student " + (i + 1) + ": ");
                // Use the null-coalescing operator to handle potential null inputs.
                studentNames[i] = Console.ReadLine() ?? "";
            }

            // Display all the names collected.
            Console.WriteLine("\nThe entered student names are:");
            for (int i = 0; i < studentNames.Length; i++)
            {
                Console.WriteLine(studentNames[i]);
            }
        }

        static void Task5()
        {
            double[] values = new double[10];
            int currentSize = 0;
            double currentLargest;
            double currentSmallest;

            Console.WriteLine("Please enter 10 double values:");
            for (int i = 0; i < 10; i++)
            {
                Console.Write("Enter value " + (i + 1) + ": ");
                string input = Console.ReadLine() ?? "";
                
                // Safely attempt to parse the input as a double.
                if (double.TryParse(input, out double val))
                {
                    values[i] = val;
                    currentSize++;
                }
            }

            // Ensure we have at least one valid entry before performing comparisons.
            if (currentSize > 0)
            {
                // Initialize markers with the first element of the array.
                currentLargest = values[0];
                currentSmallest = values[0];

                // Iterate through the rest of the array to find true min and max.
                for (int i = 1; i < currentSize; i++)
                {
                    if (values[i] > currentLargest)
                    {
                        currentLargest = values[i];
                    }
                    if (values[i] < currentSmallest)
                    {
                        currentSmallest = values[i];
                    }
                }

                Console.WriteLine("The largest value in the array is: " + currentLargest);
                Console.WriteLine("The smallest value in the array is: " + currentSmallest);
            }
        }

        static void Task6()
        {
            // Initialize a 3x4 integer 2D array with specific values.
            int[,] my2DArray = new int[3, 4] { { 1, 2, 3, 4 }, { 1, 1, 1, 1 }, { 2, 2, 2, 2 } };

            // Use GetLength(0) for rows and GetLength(1) for columns.
            for (int i = 0; i < my2DArray.GetLength(0); i++)
            {
                for (int j = 0; j < my2DArray.GetLength(1); j++)
                {
                    // Print elements with tabs for a grid-like appearance.
                    Console.Write(my2DArray[i, j] + "\t");
                }
                Console.WriteLine(); // New line after each row.
            }
        }

        static void Task7()
        {
            List<string> myStudentList = new List<string>();
            Random randomValue = new Random();
            
            // Generate a random number between 1 and 11 to simulate dynamic class sizes.
            int randomNumber = randomValue.Next(1, 12);

            Console.WriteLine("You now need to add " + randomNumber + " students to your class list");

            // Populating the list based on the random count.
            for (int i = 0; i < randomNumber; i++)
            {
                Console.Write("Please enter the name of Student " + (i + 1) + ": ");
                myStudentList.Add(Console.ReadLine() ?? "");
            }

            // Use a foreach loop to iterate through the list elements easily.
            Console.WriteLine("\nThe student list contains " + myStudentList.Count + " students:");
            foreach (var student in myStudentList)
            {
                Console.WriteLine(student);
            }
        }

        static void Task8()
        {
            int[] testArray1 = { 1, 2, 2, 1 };
            int[] testArray2 = { 1, 2, 3, 2, 1 };
            int[] testArray3 = { 3, 2, 1 };

            Console.WriteLine("Is {1, 2, 2, 1} a palindrome? " + Palindrome(testArray1));
            Console.WriteLine("Is {1, 2, 3, 2, 1} a palindrome? " + Palindrome(testArray2));
            Console.WriteLine("Is {3, 2, 1} a palindrome? " + Palindrome(testArray3));
        }

        static bool Palindrome(int[] array)
        {
            // Only need to iterate through half of the array.
            for (int i = 0; i < array.Length / 2; i++)
            {
                // Compare element at current index with its opposite end.
                if (array[i] != array[array.Length - 1 - i])
                {
                    return false; // Mismatch found, not a palindrome.
                }
            }
            return true; // All pairs matched.
        }

        static void Task9()
        {
            List<int> list1 = new List<int> { 1, 2, 2, 5 };
            List<int> list2 = new List<int> { 1, 2, 3, 4, 5, 7 };
            List<int> merged = Merge(list1, list2);

            Console.Write("Merged list: ");
            foreach (var val in merged)
            {
                Console.Write(val + " ");
            }
            Console.WriteLine();
        }

        static List<int> Merge(List<int> list_a, List<int> list_b)
        {
            List<int> result = new List<int>();
            int i = 0, j = 0;

            // Compare elements from both lists and add the smaller one to the result.
            while (i < list_a.Count && j < list_b.Count)
            {
                if (list_a[i] < list_b[j])
                {
                    result.Add(list_a[i]);
                    i++;
                }
                else if (list_b[j] < list_a[i])
                {
                    result.Add(list_b[j]);
                    j++;
                }
                else
                {
                    // If elements are equal, add both and increment both pointers.
                    result.Add(list_a[i]);
                    result.Add(list_b[j]);
                    i++;
                    j++;
                }
            }

            // Add any remaining elements from list_a.
            while (i < list_a.Count)
            {
                result.Add(list_a[i]);
                i++;
            }

            // Add any remaining elements from list_b.
            while (j < list_b.Count)
            {
                result.Add(list_b[j]);
                j++;
            }

            return result;
        }

        static void Task10()
        {
            int[,] testArray = new int[,]
            {
                {0, 2, 4, 0, 9, 5},
                {7, 1, 3, 3, 2, 1},
                {1, 3, 9, 8, 5, 6},
                {4, 6, 7, 9, 1, 0}
            };

            int[] result = ArrayConversion(testArray);
            Console.Write("ArrayConversion result: {");
            for (int i = 0; i < result.Length; i++)
            {
                Console.Write(result[i] + (i == result.Length - 1 ? "" : ", "));
            }
            Console.WriteLine("}");
        }

        static int[] ArrayConversion(int[,] array)
        {
            List<int> odds = new List<int>();
            int rows = array.GetLength(0);
            int cols = array.GetLength(1);

            // Outer loop iterates through columns first.
            for (int j = 0; j < cols; j++)
            {
                // Inner loop iterates through rows.
                for (int i = 0; i < rows; i++)
                {
                    // Check if the number is odd.
                    if (array[i, j] % 2 != 0)
                    {
                        odds.Add(array[i, j]);
                    }
                }
            }

            // Convert the dynamic list back to a static array as requested by the return type.
            return odds.ToArray();
        }
    }
}
