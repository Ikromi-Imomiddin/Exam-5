using Microsoft.AspNetCore.Mvc;
using Infrastructure;
using Domain.Models;
namespace WebApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CategoryController : ControllerBase
{
    private CategoryService _categoryService;
    public CategoryController()
    {
        _categoryService = new CategoryService();
    }

    [HttpGet]
    public List<Categories> GetCategories()
    {
        return _categoryService.GetCategories();
    }

    [HttpPost]
    public int AddCategory(Categories category)
    {
        return _categoryService.AddCategory(category);
    }

    [HttpPut]
    public int UpdateCategory(Categories category)
    {
        return _categoryService.UpdateCategory(category);
    }

    [HttpDelete]
    public int DeleteCategory(int id)
    {
        return _categoryService.DeleteCategory(id);
    }
}
