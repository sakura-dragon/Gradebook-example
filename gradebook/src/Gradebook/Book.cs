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

        public void AddGrade<T>(T newGrade)
        {
            try
            {
                double tempGrade = Convert.ToDouble(newGrade);
                if(GradeGood(tempGrade)) Grades.Add(tempGrade);
            }
            catch
            {
                Console.WriteLine($"Argument {newGrade}, is not valid.");
            }
        }

        public void AddGrades<T>(List<T> newGrades)
        {
            foreach(T newGrade in newGrades)
            {
                AddGrade(newGrade);
            }
        }

        public void AddGrades<T>(T[] newGrades)
        {
            foreach(T newGrade in newGrades)
            {
                AddGrade(newGrade);
            }
        }

        bool GradeGood(double grade)
        {
            if(grade<0)
            {
                Console.WriteLine("Grade Invalid, grade is less that zero");
                return false;
            }
            else if(grade>100)
            {
                Console.WriteLine("Grade Invalid, grade is greater than 100");
                return false;
            }
            return true;
        }
    }
}