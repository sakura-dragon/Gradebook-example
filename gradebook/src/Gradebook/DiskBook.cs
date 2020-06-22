using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Gradebook
{
    public class DiskBook : Book
    {
        private FileInfo BookDataFile;
        public DiskBook(string name) : base(name)
        {
            BookDataFile = new FileInfo(name + ".txt");
        }

        public override event GradeAddedDelegate GradeAdded;

        public override void AddGrade<T>(T newGrade)
        {
            try
            {
                double tempGrade = Convert.ToDouble(newGrade);
                if(GradeGood(tempGrade))
                {
                    using(StreamWriter writer = BookDataFile.AppendText())
                    {
                        writer.WriteLine(tempGrade);
                    }
                }
            }
            catch(InvalidCastException ex)
            {
                if(newGrade.GetType() == typeof(char))
                {
                    throw new NotImplementedException();
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
            throw new NotImplementedException();
        }
    }
}