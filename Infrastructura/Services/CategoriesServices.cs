using Dapper;
using Domain;
using Npgsql;

namespace Infrastructura.Services;

public class CategoriesServices
{
    private string? _conectionString;


    public CategoriesServices()
    {
        _conectionString = " Server=127.0.0.1;Port=5432;Database=Hw;User Id= postgres;Password=Ikromi8008;";
    }

    public async Task<List<categories>> Getcategories()
    {
        using (NpgsqlConnection connection = new NpgsqlConnection(_conectionString))
        {
            connection.Open();
            var response =await connection.QueryAsync<categories>($"select * from categories;");
            return response.ToList();
        }
    }

    public async Task<int> Addcategories(categories categories)
    {

        using (NpgsqlConnection connection = new NpgsqlConnection(_conectionString))
        {
            connection.Open();
            string? sql = $"Insert into categories (id,Name ) VAlUES ('{categories.id}','{categories.Name}')";
            var response =await connection.ExecuteAsync(sql);
            return response;
        }
    }
    public async Task<int> Deletecategories(int id)
    {

        using (NpgsqlConnection connection = new NpgsqlConnection(_conectionString))
        {
            connection.Open();
            string sql = $"delete from categories where id = '{id}';";
            var response =await connection.ExecuteAsync(sql);
            return response;
        }
    }
    public async Task<int> Updatecategories(categories categories)
    {

        using (NpgsqlConnection connection = new NpgsqlConnection(_conectionString))
        {
            connection.Open();
            string sql = $"update categories set Name = '{categories.Name}', id = '{categories.id}' WHERE id = '{categories.id}';";
            var response =await connection.ExecuteAsync(sql);
            return response;
        }
    }
}
