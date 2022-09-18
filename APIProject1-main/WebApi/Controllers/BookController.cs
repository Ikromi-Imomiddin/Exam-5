using Microsoft.AspNetCore.Mvc;
using Infrastructure;
using Domain.Models;
namespace WebApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class BookController : ControllerBase
{
    private BookService _bookService;
    public BookController()
    {
        _bookService = new BookService();
    }

    [HttpGet]
    public List<Books> GetBooks()
    {
        return _bookService.GetBooks();
    }

    [HttpPost]
    public int AddBook(Books book)
    {
        return _bookService.AddBook(book);
    }

    [HttpPut]
    public int UpdateBook(Books book)
    {
        return _bookService.UpdateBook(book);
    }

    [HttpDelete]
    public int DeleteBook(int id)
    {
        return _bookService.DeleteBook(id);
    }
}
