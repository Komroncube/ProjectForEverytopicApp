using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProjectForEverytopic.DTOs;
using ProjectForEveryTopic.Application.Services;
using ProjectForEveryTopic.Domain;

namespace ProjectForEverytopic.Controllers;
[Route("api/[controller]")]
[ApiController]
public class BooksController : ControllerBase
{
    private readonly IBookService _bookService;

    public BooksController(IBookService bookService)
    {
        _bookService = bookService;
    }

    [HttpGet]
    public IActionResult GetAllBooks()
    {
        var books = _bookService.GetAllBooks();
        return Ok(books);
    }
    [HttpPost]
    public IActionResult CreateBook(BookDto bookDto)
    {
        var book = new Book(bookDto.Title, bookDto.Description);
        book = _bookService.AddBook(book);
        return Ok(book);
    }
    [HttpDelete]
    [Authorize(Roles = "user")]
    public IActionResult DeleteBook(int id)
    {
        _bookService.DeleteBook(id);
        return Ok();
    }
}
