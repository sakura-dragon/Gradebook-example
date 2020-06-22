using System;
using System.Collections.Generic;

namespace Gradebook
{
    public class InMemoryBook : Book
    {
        #region Constructor
        public InMemoryBook(string name) : base(name)
        {
            category = "Maths"; // only during construction
        }

        public InMemoryBook(string name, string[] newGrades) : base(name)
        {
            Name = name;
            AddGrades(newGrades);
        }
        #endregion

        public override event GradeAddedDelegate GradeAdded;

        readonly string category;
        public const string CATEGORY = "Science"; // Cannot be changed... ever! Often upper case to identify.

        #region PublicMethods
        public void SetName(string name)
        {
            Name = name;
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

        public override Statistics GetStatistics()
        {
            Statistics stats = new Statistics();
            foreach(double grade in Grades)
            {
                stats.AddGrade(grade);
            }
            return stats;
        }

        #endregion
    }
}