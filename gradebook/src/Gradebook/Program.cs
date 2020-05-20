using System;
using System.Collections.Generic;

namespace Gradebook
{
    class Program
    {
        static void Main(string[] args)
        {
            Book gradeBook = new Book();

            gradeBook.AddGrades(args);

            Console.WriteLine($"Average is = {gradeBook.AverageGrade:N2}");
        }
    }
}
