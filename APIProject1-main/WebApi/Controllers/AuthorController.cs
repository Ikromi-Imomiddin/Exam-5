using Microsoft.AspNetCore.Mvc;
using Infrastructure;
using Domain.Models;
namespace WebApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AuthorController : ControllerBase
{
    private AuthorService _authorService;
    public AuthorController()
    {
        _authorService = new AuthorService();
    }

    [HttpGet]
    public List<Authors> GetAuthors()
    {
        return _authorService.GetAuthors();
    }

    [HttpPost]
    public int AddAuthor(Authors author)
    {
        return _authorService.AddAuthor(author);
    }

    [HttpPut]
    public int  UpdateAuthor(Authors author)
    {
        return _authorService.UpdateAuthor(author);
    }

    [HttpDelete]
    public int DeleteAuthor(int id)
    {
        return _authorService.DeleteAuthor(id);
    }
}
