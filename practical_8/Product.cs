using System.ComponentModel.DataAnnotations; 
namespace InventoryManagement.Models; 
public class Product 
{ 
public int ProductId { get; set; } 
[Required, StringLength(100)] 
[Display(Name = 
"Product Name")] 
public string ProductName { get; set; } = string.Empty; 
[Required, StringLength(60)] 
public string Category { get; set; } = string.Empty; 
[Range(0, 100000000)] 
public int Quantity { get; set; } 
[Range(typeof(decimal), "0", "999999999")] 
[DataType(DataType.Currency)] 
public decimal UnitPrice { get; set; } 
[StringLength(500)] 
public string? Description { get; set; } 
public DateTime CreatedAt { get; set; } 
}
