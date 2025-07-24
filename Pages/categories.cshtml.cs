using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Project.Models;
using System.Data;
namespace Project.Pages
{
    public class categoriesModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;

        private DB db { get; set; }
        public Recipe r { get; set; }

        public Category c { get; set; }

        public DataTable dt { get; set; }

        public List<Category> categories { get; set; } = new List<Category>();
        public categoriesModel(ILogger<IndexModel> logger, DB db)
        {
            _logger = logger;
            this.db = db;
        }

        public IActionResult OnPost(string description, int cookingTime, string image, string Ingredients, string instructions, int RecipeId, string CategoryName, int Rating, string Name, int CategoryID)
        {
            dt = db.foronecategory(CategoryID);
            r = new Recipe
            {
                Description = description,
                CookingTime = cookingTime,
                Image = image,
                Ingredients = Ingredients,
                Instructions = instructions,
                RecipeId = RecipeId,
                CategoryName = CategoryName,
                Rating = Rating,
                Name = Name,
                CategoryID = CategoryID,
            };


            return RedirectToPage("/one category", new { r.Description, r.CookingTime, r.Ingredients, r.Image, r.Instructions, r.RecipeId, r.CategoryName, r.Rating, r.Name, r.CategoryID });
        }

        public void OnGet()
        {
            dt = db.readtable_category();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                Category c = new Category
                {
                    CategoryId = (int)dt.Rows[i]["CategoryID"],
                    CategoryName = (string)dt.Rows[i]["CategoryName"],
                    Photo = (string)dt.Rows[i]["Photo"]
                };
                categories.Add(c);
            }
        }
    }
}
