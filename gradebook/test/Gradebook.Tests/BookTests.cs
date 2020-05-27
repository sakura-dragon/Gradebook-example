using System;
using System.Collections.Generic;
using Xunit;

namespace Gradebook.Tests
{
    public class BookTests
    {
        [Fact]
        public void StatisticsCalculateCorrectly()
        {
            // arrange
            var book = new Book(" ");
            book.AddGrade(89.1);
            book.AddGrade(90.5);
            book.AddGrade(77.3);

            // act
            var results = book.GetStatistics();

            // assert
            Assert.Equal(85.6, results.Average, 1);
            Assert.Equal(90.5, results.High, 1);
            Assert.Equal(77.3, results.Low, 1);
        }

        [Fact]
        public void IncorrectGradesAreRejected()
        {
            //* Arrange *//
            var book = new Book("Test Book");

            //* Act *//
            // Singles
            book.AddGrade(-0.1);
            book.AddGrade(100.1);
            book.AddGrade("abc");

            // Lists
            book.AddGrades(new List<double>(){-0.1,100.1});
            book.AddGrades(new List<string>(){"a", "b", "c"});

            // Arrays
            book.AddGrades(new double[]{-0.1,100.1});
            book.AddGrades(new string[]{"abc"});

            //* Assert *//
            Assert.Equal(0,book.Grades.Count);
        }

        [Fact]
        public void CorrectSingleGradesAreAdded()
        {
            //* Arrange *//
            var book = new Book("Test Book");

            //* Act *//
            // Doubles
            book.AddGrade(-0.0);
            book.AddGrade(0.0);
            book.AddGrade(100.0);

            // Int
            book.AddGrade(0);
            book.AddGrade(100);

            // String
            book.AddGrade("0");
            book.AddGrade("100");

            //* Assert *//
            Assert.Equal(7,book.Grades.Count);
        }

        [Fact]
        public void CorrectListGradesAreAdded()
        {
            //* Arrange *//
            var book = new Book("Test Book");

            //* Act *//
            // Double
            book.AddGrades(new List<double>(){-0.0, 0.0, 100.0});
            // Int
            book.AddGrades(new List<int>(){-0, 0, 100});
            // String
            book.AddGrades(new List<string>(){"-0.0", "0.0", "100.0"});
            book.AddGrades(new List<string>(){"-0.0", "0", "100.0"});

            //* Assert *//
            Assert.Equal(12,book.Grades.Count);
        }

        [Fact]
        public void CorrectArrayGradesAreAdded()
        {
            //* Arrange *//
            var book = new Book("Test Book");

            //* Act *//
            // Double
            book.AddGrades(new double[]{-0.0, 0.0, 100.0});
            // Int
            book.AddGrades(new int[]{-0, 0, 100});
            // String
            book.AddGrades(new string[]{"-0.0", "0.0", "100.0"});
            book.AddGrades(new string[]{"-0.0", "0", "100.0"});
            

            //* Assert *//
            Assert.Equal(12,book.Grades.Count);
        }
    }
}
