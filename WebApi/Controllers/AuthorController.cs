using Domain;
using Infrastructura.Services;
using Microsoft.AspNetCore.Mvc;

namespace WebApi;

[ApiController]
[Route("[controller]")]
public class AuthorController : Microsoft.AspNetCore.Mvc.ControllerBase
{
    private AuthoServices _authorservices;
    public AuthorController()
    {
        _authorservices = new AuthoServices();
    }
    [HttpGet]
    public async Task<List<author>> GetAuthors()
    {
        return await _authorservices.GetAuthors();
    }
    [HttpPost]
    public async Task<int> AddAuthor(author author)
    {
        return await _authorservices.AddAuthor(author);
    }

    [HttpPut]
    public async Task<int> UpdateAuthor(author author)
    {
        return await _authorservices.UpdateAuthor(author);
    }
    [HttpDelete]
    public async Task<int> GetAuthors(int id)
    {
        return await _authorservices.DeleteAuthor(id);
    }
}
