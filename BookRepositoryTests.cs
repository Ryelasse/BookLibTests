using Microsoft.VisualStudio.TestTools.UnitTesting;
using BookLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookLib.Tests
{
    [TestClass()]
    public class BookRepositoryTests
    {
        private Book book;
        private BookRepository repository;

        [TestInitialize]
        public void BeforeEachTest()
        {
            book = new Book();
            repository = new BookRepository();
        }

        [TestMethod()]
        public void GetTestOk()
        {
            int expectedCount = 5;

            List<Book> actual = repository.GetAllBooks();

            Assert.AreEqual(expectedCount, actual.Count);
        }

        [TestMethod()]
        public void GetByIdTestOK()
        {
            Book expectedBook = new Book(1, "Matematik for idioter", 450);

            Book actualBook = repository.GetById(expectedBook.Id);

            Assert.AreEqual(expectedBook.Id, actualBook.Id);
            Assert.AreEqual(expectedBook.Title, actualBook.Title);
            Assert.AreEqual(expectedBook.Price, actualBook.Price);
        }

        [TestMethod()]
        [ExpectedException(typeof(ArgumentException))]
        public void GetByIdTestException()
        {
            int expectedId = 0;

            Book actualBook = repository.GetById(expectedId);

            
        }

        [TestMethod()]
        public void AddTestOK()
        {
            int firsttCount = repository.GetAllBooks().Count;
            Book newBook = new Book(0, "Ny bog", 300);

            Book addedBook = repository.Add(newBook);

            Assert.IsNotNull(addedBook);
            Assert.IsTrue(addedBook.Id > 0);
            Assert.IsTrue(addedBook.Id == repository.GetAllBooks().Max(b => b.Id));
            Assert.AreEqual("Ny bog", addedBook.Title);
            Assert.AreEqual(300, addedBook.Price);

            int finalCount = repository.GetAllBooks().Count;
            Assert.AreEqual(firsttCount + 1, finalCount);

        }
       



















    }
}