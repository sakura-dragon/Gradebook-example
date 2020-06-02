using System;

namespace Gradebook
{
    public abstract class Book : NamedObject
    {
        public Book(string name) : base(name)
        {
            // Do nothing
        }
        public abstract void AddGrade<T>(T newGrade);
    }
}