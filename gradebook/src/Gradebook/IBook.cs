using System;
using System.Collections.Generic;

namespace Gradebook
{
    public interface IBook
    {
        #region Properties
        List<double> Grades { get; }
        string Name { get; }
        #endregion

        #region Events
        event GradeAddedDelegate GradeAdded;
        #endregion

        #region Methods
        Statistics GetStatistics();
        #endregion

        #region Add grades methods
        void AddGrade<T>(T newGrade);
        void AddGrades<T>(List<T> newGrades);
        void AddGrades<T>(T[] newGrades);
        #endregion
    }
}