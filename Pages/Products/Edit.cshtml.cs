using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using wt_lab5_5razor_alasevic.Data;
using wt_lab5_5razor_alasevic.Models;

namespace wt_lab5_5razor_alasevic.Pages.Products;

public class EditModel : PageModel
{
    [BindProperty]
    public Product Product { get; set; } = new();

    public IActionResult OnGet(int id)
    {
        var existing = ProductStore.Products.FirstOrDefault(p => p.Id == id);

        if (existing == null)
            return NotFound();

        Product = existing;
        return Page();
    }

    public IActionResult OnPost()
    {
        if (!ModelState.IsValid)
            return Page();

        var existing = ProductStore.Products.FirstOrDefault(p => p.Id == Product.Id);

        if (existing == null)
            return NotFound();

        existing.Name = Product.Name;
        existing.Category = Product.Category;
        existing.Price = Product.Price;
        existing.IsAvailable = Product.IsAvailable;

        return RedirectToPage("./Index");
    }
}