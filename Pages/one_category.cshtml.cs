using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Project.Models;
using System.Data;

namespace Project.Pages
{
    public class one_categoryModel : PageModel
    {

        private readonly ILogger<IndexModel> _logger;

        private DB db { get; set; }
        public Recipe r { get; set; }

        public DataTable dt2 { get; set; }

        public List<Recipe> Recipes { get; set; } = new List<Recipe>();


        public one_categoryModel(ILogger<IndexModel> logger, DB db)
        {
            _logger = logger;
            this.db = db;
        }
        public IActionResult OnPost(string description, int cookingTime, string image, string Ingredients, string instructions, int RecipeId, string CategoryName, int Rating, string Name, int CategoryID)
        {
            dt2 = db.foronecategory(CategoryID);
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


            return RedirectToPage("/OneRecipe", new { r.Description, r.CookingTime, r.Ingredients, r.Image, r.Instructions, r.RecipeId, r.CategoryName, r.Rating, r.Name, r.CategoryID });
        }

        public void OnGet(int CategoryId)
        {
            DataTable dt = db.foronecategory(CategoryId);
            foreach (DataRow row in dt.Rows)
            {
                Recipe r = new Recipe
                {
                    RecipeId = (int)row["RecipeId"],
                    Description = (string)row["Description"],
                    CookingTime = (int)row["CookingTime"],
                    Image = (string)row["Image"],
                    Instructions = (string)row["Instructions"],
                    Ingredients = (string)row["Ingredients"]
                };
                Recipes.Add(r);
            }
        }
    }

}
