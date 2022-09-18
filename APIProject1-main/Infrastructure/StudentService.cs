namespace Infrastructure;
using Dapper;
using Domain.Models;
using Npgsql;

public class StudentService
{
    private string _connectionString;

    public StudentService()
    {
        _connectionString = "Server=127.0.0.1;Port=5432;Database=FirstHomeTask;User Id=postgres;Password=masik00787737";
    }

     public int AddStudent(Students student)
    {
        using (NpgsqlConnection connection  = new NpgsqlConnection(_connectionString))
        {
            connection.Open();
            string sql = $"insert into students (firstname, lastname, fathername, birthdate) VALUES ('{student.FirstName}', '{student.LastName}', '{student.FatherName}', '{student.BirthDate}')";
            var response  = connection.Execute(sql);
            return response;
        }
    }

    public int UpdateStudent(Students student)
    {
        using(NpgsqlConnection connection = new NpgsqlConnection(_connectionString))
        {
            string sql = $"update students set firstname = '{student.FirstName}', lastname = '{student.LastName}', fathername = '{student.FatherName}', birthdate = '{student.BirthDate}' where Id = {student.Id}";
            var responce = connection.Execute(sql);
            return responce;
        }
    }

     public int DeleteStudent(int id)
    {
        using(NpgsqlConnection connection = new NpgsqlConnection(_connectionString))
        {
            string sql = $"delete from students where Id = {id}";
            var responce = connection.Execute(sql);
            return responce;
        }
    }

     public List<Students> GetStudents()
    {
        using(NpgsqlConnection connection = new NpgsqlConnection(_connectionString))
        {
            var students = connection.Query<Students>("Select * From students").ToList();
            return students;
        }
    }
}

