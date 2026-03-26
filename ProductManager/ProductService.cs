using Npgsql;

namespace ProductManager;

public class ProductService
{
    public List<Product> GetProductsByCategory(string category)
    {

        var allProducts = new List<Product>();

        using var connection = new NpgsqlConnection(
            "Host=localhost;Port=5432;Username=postgres;Password=postgres;Database=productsdb");

        connection.Open();

        var command = new NpgsqlCommand(
            "SELECT name, category, price FROM products",
            connection);

        command.Parameters.AddWithValue("@category", category);

        using var reader = command.ExecuteReader();

        while (reader.Read())
        {
            allProducts.Add(new Product
            {
                Name = reader.GetString(0),
                Category = reader.GetString(1),
                Price = reader.GetString(2)
            });
        }
        connection.Close();

        return result;
    }
}