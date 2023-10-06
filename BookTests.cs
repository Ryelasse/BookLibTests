using Microsoft.VisualStudio.TestTools.UnitTesting;
using BookLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookLib.Tests
{
    [TestClass]
    public class BookTests
    {
       
   
        [TestMethod()]
        public void ToStringTest()
        {
            Book book = new Book(1, "Sample Book", 25.99);
            string result = book.ToString();   
            Assert.AreEqual("{Id=1, Title=Sample Book, Price=25,99}", result);

        }

        [TestMethod]
        public void TestTitleLengthValid()
        {
            // Arrange
            Book book = new Book();

            // Act
            book.Title = "Valid Title";

            // Assert
            Assert.IsTrue(book.Title.Length >= 3);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void TestPricelow()
        {
            Book book = new Book();

            book.Price = -1;

            Assert.IsTrue(book.Price >= 0 && book.Price <= 1200);
        }

        [TestMethod]
        public void TestPriceOK()
        {
            Book book = new Book();

            book.Price = 50;

            Assert.IsTrue(book.Price >= 0);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void TestPricehigh()
        {
            Book book = new Book();

            book.Price = 1300;

            Assert.IsTrue(book.Price >= 0 && book.Price <= 1200);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestTitleLengthTooShort()
        {
            
            Book book = new Book();

            book.Title = "A"; 

            
        }


        
    }
}