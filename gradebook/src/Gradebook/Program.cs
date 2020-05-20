using System;
using System.Collections.Generic;

namespace Gradebook
{
    class Program
    {
        static void Main(string[] args)
        {
            Book mathsBook = new Book("Maths");

            mathsBook.AddGrades(new List<double>{45,23,65,76,21,23,98,34,19,82});
            mathsBook.AddGrades(args);

            Console.WriteLine($"Average grade for {mathsBook.Name} is = {mathsBook.AverageGrade:N2}");
            Console.WriteLine($"Highest grade in {mathsBook.Name} is = {mathsBook.HighestGrade:N2}");
            Console.WriteLine($"Lowest grade in {mathsBook.Name} is = {mathsBook.LowestGrade:N2}");
        }
    }
}
