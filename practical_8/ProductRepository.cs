using 
Microsoft.Data.SqlClient; 
using InventoryManagement.Models; 
using System.Data; 
namespace InventoryManagement.Data; 
public class ProductRepository 
{ 
private readonly string _connectionString; 
public ProductRepository(IConfiguration configuration) 
{ 
_connectionString = configuration.GetConnectionString("InventoryDb") 
?? throw new InvalidOperationException("Connection string 'InventoryDb' 
was not found."); 
} 
public async Task<List<Product>> GetAllAsync(string
{ var products = new List<Product>(); 
        const string sql = """ 
            SELECT ProductId, ProductName, Category, Quantity, UnitPrice, 
Description, CreatedAt 
            FROM dbo.Products 
            WHERE (@Search IS NULL OR ProductName LIKE '%' + @Search + '%' 
                   OR Category LIKE '%' + @Search + '%') 
            ORDER BY ProductId DESC; 
            """; 
 
        await using var connection = new SqlConnection(_connectionString); 
        await using var command = new SqlCommand(sql, connection); 
        command.Parameters.Add("@Search", SqlDbType.NVarChar, 100).Value = 
            string.IsNullOrWhiteSpace(search) ? DBNull.Value : search.Trim(); 
 
        await connection.OpenAsync(); 
        await using var reader = await command.ExecuteReaderAsync(); 
        while (await reader.ReadAsync()) 
            products.Add(MapProduct(reader)); 
 
        return products; 
    } 
 
    public async Task<Product?> GetByIdAsync(int id) 
    { 
        const string sql = """ 
            SELECT ProductId, ProductName, Category, Quantity, UnitPrice, 
Description, CreatedAt 
            FROM dbo.Products WHERE ProductId = @ProductId; 
            """; 
 
        await using var connection = new SqlConnection(_connectionString); 
        await using var command = new SqlCommand(sql, connection); 
        command.Parameters.Add("@ProductId", SqlDbType.Int).Value = id; 
 
        await connection.OpenAsync(); 
        await using var reader = await command.ExecuteReaderAsync(); 
        return await reader.ReadAsync() ? MapProduct(reader) : null; 
    } 
 
    public async Task<int> CreateAsync(Product product) 
    { 
        const string sql = """ 
            INSERT INTO dbo.Products (ProductName, Category, Quantity, UnitPrice, 
Description) 
            VALUES (@ProductName, @Category, @Quantity, @UnitPrice, @Description); 
            SELECT CAST(SCOPE_IDENTITY() AS int); 
            """; 
 
        await using var connection = new SqlConnection(_connectionString); 
await using var com mand = new SqlCommand(sql, connection); 
        AddProductParameters(command, product); 
        await connection.OpenAsync(); 
        return (int)(await command.ExecuteScalarAsync() 
            ?? throw new InvalidOperationException("Product insert did not return 
an ID.")); 
    } 
 
    public async Task<bool> UpdateAsync(Product product) 
    { 
        const string sql = """ 
            UPDATE dbo.Products 
            SET ProductName = @ProductName, Category = @Category, 
                Quantity = @Quantity, UnitPrice = @UnitPrice, Description = 
@Description 
            WHERE ProductId = @ProductId; 
            """; 
 
        await using var connection = new SqlConnection(_connectionString); 
        await using var command = new SqlCommand(sql, connection); 
        AddProductParameters(command, product); 
        command.Parameters.Add("@ProductId", SqlDbType.Int).Value = 
product.ProductId; 
        await connection.OpenAsync(); 
        return await command.ExecuteNonQueryAsync() == 1; 
    } 
 
    public async Task<bool> DeleteAsync(int id) 
    { 
        const string sql = "DELETE FROM dbo.Products WHERE ProductId = @ProductId;"; 
        await using var connection = new SqlConnection(_connectionString); 
        await using var command = new SqlCommand(sql, connection); 
        command.Parameters.Add("@ProductId", SqlDbType.Int).Value = id; 
        await connection.OpenAsync(); 
        return await command.ExecuteNonQueryAsync() == 1; 
    } 
 
    public async Task<(int TotalProducts, int LowStock)> GetSummaryAsync(int 
lowStockThreshold = 5) 
    { 
        const string sql = """ 
            SELECT COUNT(*) AS TotalProducts, 
                   COALESCE(SUM(CASE WHEN Quantity <= @Threshold THEN 1 ELSE 0 END), 
0) AS LowStock 
            FROM dbo.Products; 
            """; 
        await using var connection = new SqlConnection(_connectionString); 
        await using var command = new SqlCommand(sql, connection); 
        command.Parameters.Add("@Threshold" , SqlDbType.Int).Value = 
lowStockThreshold; 
await connection.OpenAsync(); 
await using var reader = await command.ExecuteReaderAsync(); 
await reader.ReadAsync(); 
return (reader.GetInt32(0), reader.GetInt32(1)); 
} 
private static void AddProductParameters(SqlCommand command, Product product) 
{ 
command.Parameters.Add("@ProductName", SqlDbType.NVarChar, 100).Value = 
product.ProductName.Trim(); 
command.Parameters.Add("@Category"
, SqlDbType.NVarChar, 60).Value = 
product.Category.Trim(); 
command.Parameters.Add("@Quantity", SqlDbType.Int).Value = 
product.Quantity; 
var price = command.Parameters.Add("@UnitPrice", SqlDbType.Decimal); 
price.Precision = 12; 
price.Scale = 2; 
price.Value = product.UnitPrice; 
command.Parameters.Add("@Description", SqlDbType.NVarChar, 500).Value = 
string.IsNullOrWhiteSpace(product.Description) ? DBNull.Value : 
product.Description.Trim(); 
} 
private static Product MapProduct(SqlDataReader reader) => new() 
{ 
ProductId = reader.GetInt32(reader.GetOrdinal("ProductId")), 
ProductName = reader.GetString(reader.GetOrdinal("ProductName")), 
Category = reader.GetString(reader.GetOrdinal("Category")), 
Quantity = reader.GetInt32(reader.GetOrdinal("Quantity")), 
UnitPrice = reader.GetDecimal(reader.GetOrdinal("UnitPrice")), 
Description = reader.IsDBNull(reader.GetOrdinal("Description")) 
? 
null : reader.GetString(reader.GetOrdinal("Description")), 
CreatedAt = reader.GetDateTime(reader.GetOrdinal("CreatedAt")) 
}; 
} 
