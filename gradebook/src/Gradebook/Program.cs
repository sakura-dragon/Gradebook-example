using System;
using System.Collections.Generic;

namespace Gradebook
{
    class Program
    {
        static void Main(string[] args)
        {
            Book book = new Book("Maths");
            book.GradeAdded += OnGradeAdded;
            book.GradeAdded -= OnGradeAdded;// Removed the previous method.
            book.GradeAdded += OnGradeAdded;// There is only one subscription now.

            book.AddGrades(args);
            EnterGrade(book);

            var stats = book.GetStatistics();

            Console.WriteLine($"Average grade for {book.Name} is = {stats.Average:N2}");
            Console.WriteLine($"Highest grade in {book.Name} is = {stats.High:N2}");
            Console.WriteLine($"Lowest grade in {book.Name} is = {stats.Low:N2}");
            Console.WriteLine($"The letter grade in {book.Name} is = {stats.Letter}");
        }

        private static bool EnterGrade(Book book)
        {
            bool done = false;
            while (!done)
            {
                Console.WriteLine($"{book.Grades.Count} Added to {book.Name} grades book");
                Console.WriteLine("Please enter a new single grade, or single letter grade, or enter \"q\" to exit and compute the statistics.");
                string input = Console.ReadLine();

                if (input.ToUpper() == "Q") done = true;
                else book.AddGrade(input);
            }

            return done;
        }

        static void OnGradeAdded(object sender, EventArgs e)
        {
            Console.WriteLine("A Graded was added.");
        }
    }
}
