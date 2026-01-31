using Microsoft.AspNetCore.Mvc.RazorPages;
using TasteOfHome.Models;
using TasteOfHome.Data;

namespace TasteOfHome.Pages.Restaurants
{
    public class IndexModel : PageModel
    {
        public List<Restaurant> Restaurants { get; set; } = new();

        public void OnGet()
        {
            Restaurants = RestaurantSeed.GetRestaurants();
        }
    }
}
