using Dapper;
using Domain;
using Npgsql;

namespace Infrastructura.Services;

public class QueryTextServices
{
    private string? _conectionString;


    public QueryTextServices()
    {
        _conectionString = " Server=127.0.0.1;Port=5432;Database=Hw;User Id= postgres;Password=Ikromi8008;";
    }
    
    public async Task<List<QueryText>> Getquerytext()
    {
        using (NpgsqlConnection connection = new NpgsqlConnection(_conectionString))
        {
            connection.Open();
            var response =await connection.QueryAsync<QueryText>($"select * from QueryText;");
            return response.ToList();
      }
    }

    public Task<int> Addquerytext(QueryText text)
    {
        throw new NotImplementedException();
    }

    public async Task<int> Addtext(QueryText students)
    {

        using (NpgsqlConnection connection = new NpgsqlConnection(_conectionString))
        {
            connection.Open();
            string? sql = $"Insert into QueryText (text,id) VAlUES ('{students.text}','{students.id}')";
            var response = await connection.ExecuteAsync(sql);
            return response;
        }
    }
    public async Task<int> Deletequerytext(int id)
    {

        using (NpgsqlConnection connection = new NpgsqlConnection(_conectionString))
        {
            connection.Open();
            string sql = $"delete from QueryText where id = {id};";
            var response =await connection.ExecuteAsync(sql);
            return response;
        }
    }
    public async Task<int> Updatequerytext(QueryText students)
    {

        using (NpgsqlConnection connection = new NpgsqlConnection(_conectionString))
        {
            connection.Open();
            string sql = $"update QueryText set text  = '{students.text}' WHERE Id = '{students.id}';";
            var response =await connection.ExecuteAsync(sql);
            return response;
        }
    }
}
