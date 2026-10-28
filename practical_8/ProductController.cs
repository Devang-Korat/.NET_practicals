using InventoryManagement.Data; 
using InventoryManagement.Models; 
using Microsoft.AspNetCore.Mvc; 
 
namespace InventoryManagement.Controllers; 
 
public class ProductsController : Controller 
{ 
    private readonly ProductRepository _repository; 
 
    public ProductsController(ProductRepository repository) => _repository = 
repository; 
 
    public async Task<IActionResult> Index(string? search) 
    { 
        ViewBag.Search = search; 
        ViewBag.Summary = await _repository.GetSummaryAsync(); 
        return View(await _repository.GetAllAsync(search)); 
    } 
 
    [HttpGet] 
    public IActionResult Create() => View(new Product()); 
 
    [HttpPost] 
    [ValidateAntiForgeryToken] 
    public async Task<IActionResult> Create(Product product) 
    { 
        if (!ModelState.IsValid) return View(product); 
 
        await _repository.CreateAsync(product); 
        TempData["Success"] = "Product created successfully."; 
        return RedirectToAction(nameof(Index)); 
    } 
 
    [HttpGet] 
    public async Task<IActionResult> Edit(int id) 
    { 
        var product = await _repository.GetByIdAsync(id); 
        return product is null ? NotFound() : View(product); 
    } 
 
    [HttpPost] 
    [ValidateAntiForgeryToken] 
    public async Task<IActionResult> Edit(int id, Product product) 
    { 
if (id != product.ProductId) return BadRequest(); 
if (!ModelState.IsValid) return 
View(product); 
if (!await _repository.UpdateAsync(product)) return NotFound(); 
TempData["Success"] = "Product updated successfully."; 
return RedirectToAction(nameof(Index)); 
} 
[HttpGet] 
public async Task<IActionResult> Delete(int id) 
{ 
var product = await _repository.GetByIdAsync(id); 
return product is null ? NotFound() : View(product); 
} 
[HttpPost, ActionName("Delete")] 
[ValidateAntiForgeryToken] 
public async 
{ 
Task<IActionResult> DeleteConfirmed(int id) 
if (!await _repository.DeleteAsync(id)) return NotFound(); 
TempData["Success"] = "Product deleted successfully."; 
return RedirectToAction(nameof(Index)); 
} 
}
