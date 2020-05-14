using System;
using System.Collections.Generic;

namespace Gradebook
{
    class Program
    {
        static void Main(string[] args)
        {
            List<double> grades = new List<double>();
            double SumTotal = 0;

            foreach(string arg in args)
            {
                try
                {
                    grades.Add(Convert.ToDouble(arg));
                }
                catch
                {
                    Console.WriteLine($"Argument {arg}, is not valid.");
                }
            }
            foreach(double number in grades)
            {
                SumTotal += number;
            }

            Console.WriteLine($"Sum is = {SumTotal:N2}");
            Console.WriteLine($"Average is = {SumTotal/grades.Count:N2}");
        }
    }
}
