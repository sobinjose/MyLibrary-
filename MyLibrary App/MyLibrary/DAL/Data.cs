using MyLibrary.Models;
using System.Collections.Generic;

namespace MyLibrary.DAL
{
    public class Data
    {
        public List<Book> books { get; set; }
        public List<Borrower> brrower { get; set; }

        public Data()
        {
            books = _books;
            brrower = _brrower;

        }

        List<Book> _books = new List<Book>
        {
            new Book {Id=0, Title = "The Lightning Thief", Author ="Rick Riordan" },
            new Book {Id=1, Title = "The Sea of Monsters", Author ="Rick Riordan" },
            new Book {Id=2, Title = "Sophie's World : The Greek Philosophers", Author ="Jostein Gaarder" },
        };


        List<Borrower> _brrower = new List<Borrower>
        {
            new Borrower {Id=0,  FirstName = "Sobin", LastName ="Jose", BooksBrrowed = {
                     new Book() { Title = "Sophie's World : The Greek Philosophers", Author = "Jostein Gaarder" } } },

            new Borrower { Id=1, FirstName = "Jose", LastName ="Jacob", BooksBrrowed = {
                     new Book() { Title = "The Lightning Thief", Author = "Rick Riordan" } } }
        };
    }
}