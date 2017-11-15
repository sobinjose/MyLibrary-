using MyLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyLibrary.Tests
{
    class TestData
    {
        public static IQueryable<Book> Books
        {
            get
            {
                var books = new List<Book>();
                //for (int i = 0; i < 100; i++)
                //{
                //    var book = new Book();                    
                //    book.Title = new List<BookReview>()
                //    {
                //        new BookReview { Rating = 4 }
                //    };
                //    books.Add(book);                    
                //}
                return books.AsQueryable();
            }
        }
    }
}
