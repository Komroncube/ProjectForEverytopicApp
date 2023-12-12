using ProjectForEveryTopic.Application.Abstractions;
using ProjectForEveryTopic.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectForEveryTopic.Application.Services;
public class BookService : IBookService
{
    private readonly IBookDbContext _bookDbContext;

    public BookService(IBookDbContext bookDbContext)
    {
        _bookDbContext = bookDbContext;
    }

    public Book AddBook(Book book)
    {
        _bookDbContext.Books.Add(book);
        _bookDbContext.SaveChanges();
        return book;
    }

    public void DeleteBook(int id)
    {
        var book = _bookDbContext.Books.FirstOrDefault(x => x.Id == id);
        if (book != null)
        {
            _bookDbContext.Books.Remove(book);
            _bookDbContext.SaveChanges();
        }
    }

    public IEnumerable<Book> GetAllBooks()
    {
        return _bookDbContext.Books.ToList();
    }

    public Book GetBook(int id)
    {
        return _bookDbContext.Books.FirstOrDefault(x => x.Id == id);
    }

    public Book UpdateBook(Book book)
    {
        var updBook = _bookDbContext.Books.FirstOrDefault(x=>x.Id == book.Id);
        if (updBook != null)
        {
            updBook.Title = book.Title;
            updBook.Description = book.Description;
            _bookDbContext.SaveChanges();
            return updBook;
        }
        return null;
    }
}
