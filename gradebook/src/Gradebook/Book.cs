using System;
using System.Collections.Generic;

namespace Gradebook
{
    public class Book
    {
        public Book()
        {
            Grades = new List<double>();
        }
        public List<double> Grades{private set; get;}
        public double SumTotal
        {
            get
            {
                double sum =0;
                foreach(double num in Grades)
                {
                    sum += num;
                }
                return sum;
            }
        }
        public double AverageGrade
        {
            get
            {
                return SumTotal/Grades.Count;
            }
        }
        public void ClearGrades()
        {
            Grades = new List<double>();
        }
        public void AddGrade(double newGrade)
        {
            Grades.Add(newGrade);
        }
        public void AddGrade(string newGradeString)
        {
            try
            {
                AddGrade(Convert.ToDouble(newGradeString));
            }
            catch
            {
                Console.WriteLine($"Argument {newGradeString}, is not valid.");
            }
        }
        public void AddGrades(List<double> newGrades)
        {
            Grades.AddRange(newGrades);
        }
        public void AddGrades(string[] newGradeStrings)
        {
            foreach(string newGradeString in newGradeStrings)
            {
                AddGrade(newGradeString);
            }
        }
    }
}