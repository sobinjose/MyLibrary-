using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyLibrary.Models
{
    public class Borrower
    {

        public Borrower()
        {
            BooksBrrowed = new List<Book>();
        }
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public virtual ICollection<Book> BooksBrrowed { get; set; }
    }
}