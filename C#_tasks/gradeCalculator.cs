using System;
using System.Collections.Generic;

class gradeCalculator
{
    static void Main()
    {
        bool redoProgram = false;
        do
        {
            Console.WriteLine("Student Grade Calculator");
            Console.WriteLine("-----------+------------");

            Console.Write("Enter your name: ");
            string studentName = Console.ReadLine();

            // Input validation for student name
            while (string.IsNullOrWhiteSpace(studentName))
            {
                Console.WriteLine("Student name cannot be empty. Please try again.");
                Console.Write("Enter your name: ");
                studentName = Console.ReadLine();
            }

            Console.Write("Enter the number of courses (maximum 8): ");
            int numberOfCourses;

            while (!int.TryParse(Console.ReadLine(), out numberOfCourses) || numberOfCourses < 1 || numberOfCourses > 8)
            {
                Console.WriteLine("Invalid input. Please enter a number between 1 and 8.");
                Console.Write("Enter the number of courses (maximum 8): ");
            }

            Console.WriteLine();

            Dictionary<string, int> courseGrades = new Dictionary<string, int>();

            for (int i = 0; i < numberOfCourses; i++)
            {
                Console.Write($"Enter the name of course {i + 1}: ");
                string courseName = Console.ReadLine();

                if (string.IsNullOrWhiteSpace(courseName))
                {
                    Console.WriteLine("Course name cannot be empty. Please try again.");
                    i--;
                    continue;
                }

                int grade;

                do
                {
                    Console.Write($"Enter the grade obtained in course {i + 1}: ");
                    string gradeInput = Console.ReadLine();

                    if (string.IsNullOrWhiteSpace(gradeInput))
                    {
                        Console.WriteLine("Grade cannot be empty. Please try again.");
                        continue;
                    }

                    if (!int.TryParse(gradeInput, out grade))
                    {
                        Console.WriteLine("Invalid grade. Please enter a valid integer.");
                    }
                    else if (grade < 0 || grade > 100)
                    {
                        Console.WriteLine("Grade must be between 0 and 100. Please try again.");
                    }
                    else
                    {
                        break;
                    }
                } while (true);

                courseGrades.Add(courseName, grade);

                Console.WriteLine();
            }

            double averageGrade = CalculateAverageGrade(courseGrades);

            Console.WriteLine("------------------------");
            Console.WriteLine($"Student Name: {studentName}");
            Console.WriteLine("Course Grades:");

            // Display individual course grades
            foreach (var courseGrade in courseGrades)
            {
                Console.WriteLine($"{courseGrade.Key}: {courseGrade.Value}");
            }

            Console.WriteLine("------------------------");
            Console.WriteLine($"Average Grade: {averageGrade}");

            Console.WriteLine("Do you want to redo the program? (Y/N)");
            string redoInput = Console.ReadLine();
            redoProgram = redoInput.ToUpper() == "Y";

        } while (redoProgram);

        Console.WriteLine("Program ended.");
    }

    
    // Calculate the average grade
    static double CalculateAverageGrade(Dictionary<string, int> courseGrades)
    {
        int sum = 0;

        foreach (var grade in courseGrades.Values)
        {
            sum += grade;
        }

        return (double)sum / courseGrades.Count;
    }
}
