using ProjectForEveryTopic.Domain;

namespace ProjectForEveryTopic.Application.Services;
public interface IBookService
{
    Book AddBook(Book book);
    Book UpdateBook(Book book);
    Book GetBook(int id);
    void DeleteBook(int id);
    IEnumerable<Book> GetAllBooks();
}
