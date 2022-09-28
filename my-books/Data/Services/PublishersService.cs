using my_books.Data.Models;
using my_books.Data.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace my_books.Data.Services
{
    public class PublishersService
    {
        private AppDbContext _context;
        public PublishersService(AppDbContext context)
        {
            _context = context;
        }

        public List<Publisher> GetAllPublishers() => _context.Publishers.ToList();


        public void AddPublisher(PublisherVM publisher)
        {
            var _publisher = new Publisher()
            {
                Name = publisher.Name
            };
            _context.Publishers.Add(_publisher);
            _context.SaveChanges();
        }        
        
        public PublisherDataVM GetPublisherBooksAndAuthorsById(int publisherId)
        {
            var _publisherWithBooksAndAuthors = _context
                .Publishers
                .Where(n => n.Id == publisherId)
                .Select(n => new PublisherDataVM()
                {
                    Name =n.Name,
                    BookWithAuthors = n.Books
                    .Select(n=> new BookAuthorVM()
                    {
                        BookName = n.Title,
                        BookAuthors = n.Books_Authors.Select(n=>n.Author.Name).ToList()
                    }).ToList()

                }).FirstOrDefault();
            return _publisherWithBooksAndAuthors;
        }

        public void DeletePublisherById(int PublisherId)
        {
            var _publisher = _context.Publishers.FirstOrDefault(n => n.Id == PublisherId);
            if (_publisher != null)
            {
                _context.Publishers.Remove(_publisher);
                _context.SaveChanges();
            }
        }

        /*public List<Book> GetAllBooks() => _context.Books.ToList();
        public Book UpdateBookById(int bookId, BookVM book)
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
