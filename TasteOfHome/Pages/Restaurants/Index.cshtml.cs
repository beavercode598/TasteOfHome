using Microsoft.AspNetCore.Mvc.RazorPages;
using TasteOfHome.Models;
using TasteOfHome.Data;
using Microsoft.AspNetCore.Mvc;

namespace TasteOfHome.Pages.Restaurants
{
    public class IndexModel : PageModel
    {
        //Create list of all Restaurants
        public List<Restaurant> Restaurants { get; set; } = new();

        //Set list for the selected dietary filters
        [BindProperty(SupportsGet = true)]
        public List<String> SelectedDietaryFilters{ get; set; } = new();

        //Create another list for the selected location filter
        [BindProperty(SupportsGet = true)]
        public List<String> SelectedCuisineFilter{ get; set; } = new();

        public void OnGet()
        {
            //Stating variables (full list and empty list for filters)
            var allRestaurants = RestaurantSeed.GetRestaurants();
            IEnumerable<Restaurant> filteredRestaurants = allRestaurants;

            //Apply any dietary filters
            if (SelectedDietaryFilters.Any())
            {
                filteredRestaurants = filteredRestaurants.Where(r =>
                    SelectedDietaryFilters.All(filter => r.DietaryTags.Contains(filter)));
            }
            
            //Apply any location filters
            if (SelectedCuisineFilter.Any())
            {
                filteredRestaurants = filteredRestaurants.Where(r =>
                    SelectedCuisineFilter.Contains(r.Cuisine));
            }

            Restaurants = filteredRestaurants.ToList();
        }
    }
}
