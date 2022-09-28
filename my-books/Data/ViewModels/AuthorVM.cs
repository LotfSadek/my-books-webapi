using my_books.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace my_books.Data.ViewModels
{
    public class AuthorVM
    {
        public string Name { get; set; }
    }

    public class AuthorWithBooksVM
    {
        public string Name { get; set; }
        public List<string> ListOfBooks { get; set; }
    }
}
