using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using wt_lab5_5razor_alasevic.Data;
using wt_lab5_5razor_alasevic.Models;

namespace wt_lab5_5razor_alasevic.Pages.Products;

public class DetailsModel : PageModel
{
    public Product? Product { get; set; }

    public IActionResult OnGet(int id)
    {
        Product = ProductStore.Products.FirstOrDefault(p => p.Id == id);

        if (Product == null)
        {
            return NotFound(); // Если товара нет, отдаём 404
        }

        return Page();
    }

    public IActionResult OnPostDelete(int id)
    {
        var product = ProductStore.Products.FirstOrDefault(p => p.Id == id);

        if (product != null)
        {
            ProductStore.Products.Remove(product);
        }

        return RedirectToPage("./Index");
    }
}