using System;
using System.Collections.Generic;

namespace Gradebook
{

    // Normally stored within it's own file, but being lazy here.
    // object sender, and EventArgs is used so that anything can be sent.
    public delegate void GradeAddedDelegate(object sender, EventArgs args);

    public class InMemoryBook : BookBase
    {
        #region Constructor
        public InMemoryBook(string name) : base(name)
        {
            Name = name;
            Grades = new List<double>();
            category = "Maths"; // only during construction
        }

        public InMemoryBook(string name, string[] newGrades) : base(name)
        {
            Name = name;
            Grades = new List<double>();
            AddGrades(newGrades);
        }
        #endregion

        readonly string category;
        public const string CATEGORY = "Science"; // Cannot be changed... ever! Often upper case to identify.

        public event GradeAddedDelegate GradeAdded;

        #region PublicProperties
        public List<double> Grades{private set; get;}
        
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
        public void SetName(string name)
        {
            Name = name;
        }
        
        public Statistics GetStatistics()
        {
            char letterGrade = new char();
            switch(AverageGrade)
            {
                case var d when d >= 90.0:
                    letterGrade = 'A';
                    break;
                case var d when d >= 80.0:
                    letterGrade = 'B';
                    break;
                case var d when d >= 70.0:
                    letterGrade = 'C';
                    break;
                case var d when d >= 60.0:
                    letterGrade = 'D';
                    break;
                default:
                    letterGrade = 'F';
                    break;
            }

            return new Statistics()
            {
                Average = AverageGrade,
                High = HighestGrade,
                Low = LowestGrade,
                Letter = letterGrade
            };
        }
        
        public void ClearGrades()
        {
            Grades = new List<double>();
        }

        public override void AddGrade<T>(T newGrade)
        {
            try
            {
                double tempGrade = Convert.ToDouble(newGrade);
                if(GradeGood(tempGrade)) Grades.Add(tempGrade);
            }
            catch(InvalidCastException ex)
            {
                if(newGrade.GetType() == typeof(char))
                {
                    AddLetterGrade(Convert.ToChar(newGrade));
                }
                else
                {
                    Console.WriteLine(ex.Message);
                }
            }
            catch(ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch(FormatException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch(Exception ex)
            {
                Console.WriteLine($"Argument {newGrade} caused and exception: {ex.Message}");
                throw ex;
            }
            finally
            {
                if(GradeAdded != null)
                {
                    GradeAdded(this, new EventArgs());
                }
                Console.WriteLine("Thank you for typing.");
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

        private void AddLetterGrade(char letter)
        {
            switch(letter.ToString().ToUpper())
            {
                case "A":
                    AddGrade(90);
                    return;
                case "B":
                    AddGrade(80);
                    return;
                case "C":
                    AddGrade(70);
                    return;
                default:
                    AddGrade(0);
                    return;
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