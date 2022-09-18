using Domain;
using Infrastructura.Services;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;

[ApiController]
[Route("[controller]")]
public class CategoriesController
{
    private CategoriesServices _categoriesservices;
    public CategoriesController()
    {
        _categoriesservices = new CategoriesServices();
    }
    [HttpGet]
    public async Task< List<categories>> GetCategories()
    {
        return await _categoriesservices.Getcategories();
    }
    [HttpPost]
    public async Task<int> AddCategories(categories categories)
    {
        return await _categoriesservices.Addcategories(categories);
    }

    [HttpPut]
    public async Task<int> UpdateCategories(categories categories)
    {
        return await _categoriesservices.Updatecategories(categories);
    }
    [HttpDelete]
    public async Task<int> GetCategories(int id)
    {
        return await _categoriesservices.Deletecategories(id);
    }
}
