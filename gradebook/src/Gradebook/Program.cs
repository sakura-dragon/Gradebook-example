using System;
using System.Collections.Generic;

namespace Gradebook
{
    class Program
    {
        static void Main(string[] args)
        {
            Book mathsBook = new Book("Maths");

            mathsBook.AddGrades(args);

            Console.WriteLine($"Average grade for {mathsBook.Name} is = {mathsBook.AverageGrade:N2}");
        }
    }
}
