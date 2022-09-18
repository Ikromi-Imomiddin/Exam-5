using Dapper;
using Domain;
using Npgsql;

namespace Infrastructura.Services;

public class AuthoServices
{
    private string _conectionString;


    public AuthoServices()
    {
        _conectionString = " Server=127.0.0.1;Port=5432;Database=Hw;User Id= postgres;Password=Ikromi8008;";
    }

    public async Task<List<author>> GetAuthors()
    {
        using (NpgsqlConnection connection = new NpgsqlConnection(_conectionString))
        {
            connection.Open();
            var  response = await connection.QueryAsync<author>($"select * from Authors;");
            return response.ToList();
        }
    }

    public async Task<int> AddAuthor(author author)
    {

        using (NpgsqlConnection connection = new NpgsqlConnection(_conectionString))
        {
            connection.Open();
            string? sql =  $"Insert into Authors (name,surname,id) VAlUES ('{author.name}','{author.surname}','{author.id}')";
            var response = await connection.ExecuteAsync(sql);
            return response;
        }
    }
    public async Task<int> DeleteAuthor(int id)
    {

        using (NpgsqlConnection connection = new NpgsqlConnection(_conectionString))
        {
            connection.Open();
            string sql = $"delete from authors where id = {id};";
            var response = await connection.ExecuteAsync(sql);
            return response;
        }
    }
    public async Task<int> UpdateAuthor(author author)
    {

        using (NpgsqlConnection connection = new NpgsqlConnection(_conectionString))
        {
            connection.Open();
            string sql = $"update authors set name  = '{author.name}', surname = '{author.surname}', id = '{author.id}' WHERE Id = '{author.id}';";
            var response = await connection.ExecuteAsync(sql);
            return response;
        }
    }

}
