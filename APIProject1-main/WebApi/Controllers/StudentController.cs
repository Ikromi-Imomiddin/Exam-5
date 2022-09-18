using Microsoft.AspNetCore.Mvc;
using Infrastructure;
using Domain.Models;
namespace WebApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class StudentController : ControllerBase
{
    private StudentService _studentService;
    public StudentController()
    {
        _studentService = new StudentService();
    }

    [HttpGet]
    public  List<Students> GetStudents()
    {
        return _studentService.GetStudents();
    }

    [HttpPost]
    public int AddStudent(Students student)
    {
        return _studentService.AddStudent(student);
    }

    [HttpPut]
    public int UpdateStudent(Students student)
    {
        return _studentService.UpdateStudent(student);
    }

    [HttpDelete]
    public int DeleteStudent(int id)
    {
        return _studentService.DeleteStudent(id);
    }
}
