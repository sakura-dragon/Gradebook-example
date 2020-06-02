using System;
using System.Collections.Generic;

namespace Gradebook
{
    public interface IBook
    {
        List<double> Grades { get; }
        Statistics GetStatistics();
        string Name { get; }
        event GradeAddedDelegate GradeAdded;
    }
}