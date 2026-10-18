using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using wt_lab5_5razor_alasevic.Data;
using wt_lab5_5razor_alasevic.Models;

namespace wt_lab5_5razor_alasevic.Pages.Products;

public class CreateModel : PageModel
{
  
    [BindProperty]
    public Product Product { get; set; } = new();

 
    public void OnGet()
    {
    }

    public IActionResult OnPost()
    {
       
        if (!ModelState.IsValid)
        {
            return Page();
        }

        // Вычисляем новый Id
        Product.Id = ProductStore.Products.Any()
            ? ProductStore.Products.Max(p => p.Id) + 1
            : 1;

        ProductStore.Products.Add(Product);

        return RedirectToPage("./Index");
    }
}
