using System;

namespace Gradebook
{
    public class Statistics
    {
        #region Internal Numbers
        private double sum;
        private int count;

        #endregion

        public Statistics()
        {
            High = double.MinValue;
            Low = double.MaxValue;
            sum = 0.0;
            count = 0;
        }
        internal void AddGrade(double number)
        {
            count +=1;
            sum += number;
            Low = Math.Min(number, Low);
            High = Math.Max(number, High);
        }
        public double Average {
            get
            {
                return sum/count;
            }
        }
            
        public double High{internal set; get;}
        public double Low{internal set; get;}
        public char Letter{
            get
            {
                    switch(Average)
                    {
                        case var d when d >= 90.0:
                            return 'A';
                        case var d when d >= 80.0:
                            return 'B';
                        case var d when d >= 70.0:
                            return 'C';
                        case var d when d >= 60.0:
                            return 'D';
                        default:
                            return 'F';
                    }
            }
        }

        
    }
}