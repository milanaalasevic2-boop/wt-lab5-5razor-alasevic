using Microsoft.AspNetCore.Mvc.RazorPages;
using wt_lab5_5razor_alasevic.Data;
using wt_lab5_5razor_alasevic.Models;

namespace wt_lab5_5razor_alasevic.Pages.Products;

public class IndexModel : PageModel
{
    // Свойство, которое будет доступно во View (.cshtml)
    public List<Product> Products { get; set; } = new();

    // Обработчик GET-запроса
    public void OnGet()
    {
        Products = ProductStore.Products;
    }
}