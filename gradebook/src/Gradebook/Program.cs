using System;
using System.Collections.Generic;

namespace Gradebook
{
    class Program
    {
        static void Main(string[] args)
        {
            Book mathsBook = new Book("Maths");
            bool done = false;
            mathsBook.GradeAdded += OnGradeAdded;
            mathsBook.GradeAdded -= OnGradeAdded;// Removed the previous method.
            mathsBook.GradeAdded += OnGradeAdded;// There is only one subscription now.

            mathsBook.AddGrades(args);

            while(!done)
            {
                Console.WriteLine($"{mathsBook.Grades.Count} Added to {mathsBook.Name} grades book");
                Console.WriteLine("Please enter a new single grade, or single letter grade, or enter \"q\" to exit and compute the statistics.");
                string input = Console.ReadLine();

                if(input.ToUpper() == "Q") done = true;
                else mathsBook.AddGrade(input);
            }
            

            var stats = mathsBook.GetStatistics();

            Console.WriteLine($"Average grade for {mathsBook.Name} is = {stats.Average:N2}");
            Console.WriteLine($"Highest grade in {mathsBook.Name} is = {stats.High:N2}");
            Console.WriteLine($"Lowest grade in {mathsBook.Name} is = {stats.Low:N2}");
            Console.WriteLine($"The letter grade in {mathsBook.Name} is = {stats.Letter}");
        }

        static void OnGradeAdded(object sender, EventArgs e)
        {
            Console.WriteLine("A Graded was added.");
        }
    }
}
