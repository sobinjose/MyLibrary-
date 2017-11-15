using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MyLibrary.Controllers;
using MyLibrary.Tests.Fakes;
using MyLibrary.Models;
using MyLibrary.DAL;

namespace MyLibrary.Tests.Controllers
{
    [TestClass]
    public class BookControllerTests
    {
        [TestMethod]
        public void Create_Saves_Book_When_Valid()
        {
            var db = new Data();
            var controller = new BookController(db);
            db.books.Clear();
            controller.Create(new Book());

            Assert.AreEqual(1, db.books.Count);

        }
        [TestMethod]
        public void Create_Does_Not_Save__Book_When_Invalid()
        {
            var db = new Data();
            var controller = new BookController(db);
            controller.ModelState.AddModelError("", "Invalid");
            db.books.Clear();
            controller.Create(new Book());

            Assert.AreEqual(0, db.books.Count);
        }
    }
}
