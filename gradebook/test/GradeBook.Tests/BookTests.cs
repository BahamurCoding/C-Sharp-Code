using System;
using Xunit;


namespace GradeBook.Tests
{
    public class BookTests
    {
        [Fact]
        public void CheckAverage()
        {

            // Arrange
            var book = new Book("");
            book.AddGrade(89.14);
            book.AddGrade(90.5);
            book.AddGrade(77.3);
            book.AddGrade(55.3);
            //act\
            var result = book.GetStatistics();
            //assert
            Assert.Equal(78.1, result.Average, 1);

        }

        [Fact]
        public void CheckHighValue()
        {

            // Arrange
            var book = new Book("");
            book.AddGrade(89.1);
            book.AddGrade(90.5);
            book.AddGrade(77.3);
            book.AddGrade(55.3);
            
            //act\
            var result = book.GetStatistics();
            //assert
            Assert.Equal(90.5, result.high);

        }

        [Fact]
        public void CheckLowValue()
        {

            // Arrange
            var book = new Book("");
            book.AddGrade(89.1);
            book.AddGrade(90.5);
            book.AddGrade(77.3);
            book.AddGrade(55.3);
            //act
            var result = book.GetStatistics();
            //assert
            Assert.Equal(55.3, result.low);

        }

        [Fact]
        public void CheckLetterGrade()
        {

            // Arrange
            var book = new Book("");
            book.AddGrade(89.1);
            book.AddGrade(90.5);
            book.AddGrade(77.3);
            book.AddGrade(55.3);
            //act
            var result = book.GetStatistics();
            //assert
            Assert.Equal('C', result.letter);

        }

    }
}
