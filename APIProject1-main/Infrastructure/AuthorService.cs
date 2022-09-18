namespace Infrastructure;
using Dapper;
using Domain.Models;
using Npgsql;

public class AuthorService
{
    private string _connectionString;

    public AuthorService()
    {
        _connectionString = "Server=127.0.0.1;Port=5432;Database=FirstHomeTask;User Id=postgres;Password=masik00787737";
    }

     public int AddAuthor(Authors author)
    {
        using (NpgsqlConnection connection  = new NpgsqlConnection(_connectionString))
        {
            connection.Open();
            string sql = $"insert into authors (name, surname) VALUES ('{author.Name}', '{author.Surname}')";
            var response  = connection.Execute(sql);
            return response;
        }
    }

    public int UpdateAuthor(Authors author)
    {
        using(NpgsqlConnection connection = new NpgsqlConnection(_connectionString))
        {
            string sql = $"update authors set name = '{author.Name}', surname = '{author.Surname}' where Id = {author.Id}";
            var responce = connection.Execute(sql);
            return responce;
        }
    }

     public int DeleteAuthor(int id)
    {
        using(NpgsqlConnection connection = new NpgsqlConnection(_connectionString))
        {
            string sql = $"delete from authors where Id = {id}";
            var responce = connection.Execute(sql);
            return responce;
        }
    }

     public List<Authors> GetAuthors()
    {
        using(NpgsqlConnection connection = new NpgsqlConnection(_connectionString))
        {
            var authors = connection.Query<Authors>("Select * From authors").ToList();
            return authors;
        }
    }
}
