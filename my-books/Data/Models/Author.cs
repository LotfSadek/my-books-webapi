using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace my_books.Data.Models
{
    public class Author
    {
        public int Id { get; set; }
        public string Name { get; set; }

        // Navigation props
        public List<Book_Author> Books_Authors { get; set; }
    }
}
