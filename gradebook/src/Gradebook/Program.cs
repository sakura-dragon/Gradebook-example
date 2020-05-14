using System;
using System.Collections;

namespace Gradebook
{
    class Program
    {
        static void Main(string[] args)
        {
            double[] numbers = new double[args.Length];
            double result = 0;

            for(int i = 0; i < args.Length; i++)
            {
                try
                {
                    numbers[i] = Convert.ToDouble(args[i]);
                }
                catch
                {
                    numbers[i] = double.NaN;
                    Console.WriteLine($"Argument {i} = {args[i]}, is not valid.");
                }
            }
            foreach(double number in numbers)
            {
                if(!double.IsNaN(number))
                {
                    result += number;
                }
            }

            Console.WriteLine($"Answer = {result}");
/*
            if(args.Length == 2)
            {
                double a = Convert.ToDouble(args[0]);
                double b = Convert.ToDouble(args[1]);

                Console.WriteLine($"Answer to {a} + {b} = {a+b}");
            }
            else
            {
                Console.WriteLine("Please provide 2 numbers.");
            }*/
        }
    }
}
