using System;
using System.Collections.Generic;

namespace Gradebook
{
    public class Book
    {
        #region Constructor
        public Book(string name)
        {
            Name = name;
            Grades = new List<double>();
        }

        public Book(string name, string[] newGrades)
        {
            Name = name;
            Grades = new List<double>();
            AddGrades(newGrades);
        }
        #endregion

        #region PublicProperties
        public List<double> Grades{private set; get;}
        public string Name {get;}
        
        public double AverageGrade
        {
            get
            {
                return SumTotal/Grades.Count;
            }
        }

        public double HighestGrade
        {
            get
            {
                double highGrade = double.MinValue;
                foreach(double num in Grades)
                {
                    highGrade = Math.Max(num, highGrade);
                }
                return highGrade;
            }
        }
        public double LowestGrade
        {
            get
            {
                double lowGrade = double.MaxValue;
                foreach(double num in Grades)
                {
                    lowGrade = Math.Min(num, lowGrade);
                }
                return lowGrade;
            }
        }
        
        #endregion

        #region PrivateProperties
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
        #endregion

        #region PublicMethods
        public void ShowStatistics()
        {
            Console.WriteLine($"Average grade for {Name} is = {AverageGrade:N2}");
            Console.WriteLine($"Highest grade in {Name} is = {HighestGrade:N2}");
            Console.WriteLine($"Lowest grade in {Name} is = {LowestGrade:N2}");
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

        #endregion

        #region PrivateMethods
        private bool GradeGood(double grade)
        {
            if(grade<0)
            {
                Console.WriteLine($"Grade {grade} Invalid, grade is less that zero");
                return false;
            }
            else if(grade>100)
            {
                Console.WriteLine($"Grade {grade} Invalid, grade is greater than 100");
                return false;
            }
            return true;
        }

        #endregion
    }
}