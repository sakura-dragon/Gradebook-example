using System;
using System.Collections.Generic;

namespace Gradebook
{

    // Normally stored within it's own file, but being lazy here.
    // object sender, and EventArgs is used so that anything can be sent.
    public delegate void GradeAddedDelegate(object sender, EventArgs args);
    
    public abstract class Book : NamedObject, IBook
    {
        public Book(string name) : base(name)
        {
            Name = name;
            Grades = new List<double>();
        }

        public List<double> Grades {internal set; get;}

        public virtual event GradeAddedDelegate GradeAdded;

        public virtual Statistics GetStatistics()
        {
            throw new NotImplementedException();
        }

        public abstract void AddGrade<T>(T newGrade);
        public virtual void AddGrades<T>(List<T> newGrades)
        {
            throw new NotImplementedException();
        }
        public virtual void AddGrades<T>(T[] newGrades)
        {
            throw new NotImplementedException();
        }

    }
}