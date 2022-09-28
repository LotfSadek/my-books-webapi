using my_books.Data.Models;
using my_books.Data.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace my_books.Data.Services
{
    public class AuthorsService
    {
        private AppDbContext _context;
        public AuthorsService(AppDbContext context)
        {
            _context = context;
        }

        public void AddAuthor(AuthorVM author)
        {
            var _author = new Author()
            {
                Name = author.Name
            };
            _context.Authors.Add(_author);
            _context.SaveChanges();
        }
        //public List<Book> GetAllBooks() => _context.Books.ToList();
        public AuthorWithBooksVM GetAuthorsBookById(int authorId) 
        {
            var _booksOfAuthor = _context
                .Authors
                .Where(n => n.Id == authorId)
                .Select(author => new AuthorWithBooksVM()
                {
                    Name = author.Name,
                    ListOfBooks = author.Books_Authors.Select(n => n.Book.Title).ToList()
                }).FirstOrDefault();
            return _booksOfAuthor;
        }
        /*public Book UpdateBookById(int bookId, BookVM book)
        {
            var _book = _context.Books.FirstOrDefault(n => n.Id == bookId);
            if (_book != null)
            {
                _book.Title = book.Title;
                _book.Description = book.Description;
                _book.IsRead = book.IsRead;
                _book.DateRead = book.IsRead ? book.DateRead : null;
                _book.Rate = book.IsRead ? book.Rate : null;
                _book.Genre = book.Genre;
                _book.Author = book.Author;
                _book.CoverURL = book.CoverURL;
                _context.SaveChanges();
            }
            return _book;

        }
        public void DeleteBookById(int bookId)
        {
            var _book = _context.Books.FirstOrDefault(n => n.Id == bookId);
            if (_book != null)
            {
                _context.Books.Remove(_book);
                _context.SaveChanges();
            }


        }*/
    }
}
