using System;
using Xunit;

namespace Gradebook.Tests
{

    // This is a variable that I can call like a method, but can call multiple methods i.e. Multi-casting
    public delegate string WriteLogDelegate(string logMessage);

    public class TypeTests
    {

        #region Delegate Test
        int delegateCallCount = 0;
        [Fact]
        public void WriteLogDelegateCanPointToMethod()
        {
            // Arrange
            WriteLogDelegate log = ReturnMessage;
            log += new WriteLogDelegate(ReturnMessage);
            log += IncrementCount; // This is also valid and adds an additional method call.

            // Act
            var result = log("Hello!");

            // Assert
            //Assert.Equal("Hello!", result);
            Assert.Equal(3, delegateCallCount);
        }

        // Method does not have to have any names matching,
        // But in and out variables must match.
        private string ReturnMessage(string message)
        {
            delegateCallCount++;
            return message;
        }

        private string IncrementCount(string message)
        {
            delegateCallCount++;
            return message.ToLower();
        }
        #endregion

        [Fact]
        public void ValueTypeAlsoPassByValue()
        {
            var x = GetInt();
            SetInt(ref x);

            Assert.Equal(42, x);
        }

        private void SetInt(ref int z)
        {
            z = 42;
        }
        private int GetInt()
        {
            return 3;
        }

        [Fact]
        public void CSharpCanPassByReference()
        {
            // arrange
            var book1 = GetBook("Book 1");
            GetBookSetName(ref book1, "New Name");

            // act

            // assert
            Assert.Equal("New Name", book1.Name);
        }

        /// This has a referernce to the memory location passed to the method not a copy of the memory.
        // "out" can be used instead of "ref", but "out" assumes that the input is not initialised.
        // It's like a constructor, writing an object to the memory location referenced in "out".
        // "out" will force you to initialise the initialiser.
        private void GetBookSetName(ref InMemoryBook book, string name)
        {
            book = new InMemoryBook(name);
        }

        [Fact]
        public void CSharpIsPassByValue()
        {
            // arrange
            var book1 = GetBook("Book 1");
            GetBookSetName(book1, "New Name");

            // act

            // assert
            Assert.Equal("Book 1", book1.Name);
        }

        private void GetBookSetName(InMemoryBook book, string name)
        {
            book = new InMemoryBook(name);
        }

        [Fact]
        public void CanSetNameFromReference()
        {
            // arrange
            var book1 = GetBook("Book 1");
            SetName(book1, "New Name");

            // act

            // assert
            Assert.Equal("New Name", book1.Name);
        }

        private void SetName(InMemoryBook book, string name)
        {
            book.SetName(name);
        }

        /// Strings are imutable!
        [Fact]
        public void StringsBehaveLikeValueType()
        {
            string name = "Scott";
            var uppername = MakeUpperCase(name);
            Assert.Equal("Scott", name);
            Assert.Equal("SCOTT", uppername);
        }

        private string MakeUpperCase(string parameter)
        {
            return parameter.ToUpper();
        }

        [Fact]
        public void GetBookReturnsDifferentObjects()
        {
            // arrange
            var book1 = GetBook("Book 1");
            var book2 = GetBook("Book 2");

            // act

            // assert
            Assert.Equal("Book 1", book1.Name);
            Assert.Equal("Book 2", book2.Name);
            Assert.NotSame(book1, book2);
        }

        [Fact]
        public void TwoVariablesCanreferenceSameObject()
        {
            // arrange
            var book1 = GetBook("Book 1");
            var book2 = book1;

            // act

            // assert
            Assert.Same(book1, book2);
            Assert.True(object.ReferenceEquals(book1, book2));
        }

        private InMemoryBook GetBook(string name)
        {
            return new InMemoryBook(name);
        }
    }
}
