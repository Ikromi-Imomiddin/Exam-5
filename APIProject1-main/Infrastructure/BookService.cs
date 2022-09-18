namespace Infrastructure;
using Dapper;
using Domain.Models;
using Npgsql;

public class BookService
{
    private string _connectionString;

    public BookService()
    {
        _connectionString = "Server=127.0.0.1;Port=5432;Database=FirstHomeTask;User Id=postgres;Password=masik00787737";
    }

     public int AddBook(Books book)
    {
        using (NpgsqlConnection connection  = new NpgsqlConnection(_connectionString))
        {
            connection.Open();
            string sql = $"insert into books (title) VALUES ('{book.Title}')";
            var response  = connection.Execute(sql);
            return response;
        }
    }

    public int UpdateBook(Books book)
    {
        using(NpgsqlConnection connection = new NpgsqlConnection(_connectionString))
        {
            string sql = $"update books set title = '{book.Title}' where Id = {book.Id}";
            var responce = connection.Execute(sql);
            return responce;
        }
    }

     public int DeleteBook(int id)
    {
        using(NpgsqlConnection connection = new NpgsqlConnection(_connectionString))
        {
            string sql = $"delete from books where Id = {id}";
            var responce = connection.Execute(sql);
            return responce;
        }
    }

     public List<Books> GetBooks()
    {
        using(NpgsqlConnection connection = new NpgsqlConnection(_connectionString))
        {
            var books = connection.Query<Books>("Select * From books").ToList();
            return books;
        }
    }
}
