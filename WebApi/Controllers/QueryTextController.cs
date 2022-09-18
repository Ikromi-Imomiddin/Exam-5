using Domain;
using Infrastructura.Services;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;

[ApiController]
[Route("[controller]")]
public class QueryTextController : Microsoft.AspNetCore.Mvc.ControllerBase
{
    private QueryTextServices _querytextservices;
    public QueryTextController()
    {
        _querytextservices = new QueryTextServices();
    }
    [HttpGet]
    public async Task< List<QueryText>> GetQueryText()
    {
        return await _querytextservices.Getquerytext();
    }
    [HttpPost]
    public async Task<int> AddQueryText(QueryText text)
    {
        return await _querytextservices.Addquerytext(text);
    }

    [HttpPut]
    public async Task<int> UpdateQueryText(QueryText text)
    {
        return await _querytextservices.Updatequerytext(text);
    }
    [HttpDelete]
    public async Task<int> GetQueryText(int id)
    {
        return await _querytextservices.Deletequerytext(id);
    }
}
