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

            mathsBook.ShowStatistics();
        }
    }
}
