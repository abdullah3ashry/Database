using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Project.Models;
using System.Data;
using System.Xml.Linq;


namespace Project.Pages
{
    public class trendy_pagesModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private DB db { get; set; }
        public Recipe r { get; set; }
        public DataTable dt { get; set; }

        public List<Recipe> Recipes { get; set; } = new List<Recipe>();
        public trendy_pagesModel(ILogger<IndexModel> logger, DB db)
        {
            _logger = logger;
            this.db = db;
        }

        public IActionResult OnPost(string description, int cookingTime, string image, string Ingredients, string instructions, int RecipeId, string CategoryName, int Rating, string Name)
        {
            dt = db.readtable_category(RecipeId);
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
            };


            return RedirectToPage("/OneRecipe", new { r.Description, r.CookingTime, r.Ingredients, r.Image, r.Instructions, r.RecipeId, r.CategoryName, r.Rating, r.Name });
        }
        public void OnGet()
        {
            dt = db.trendy_recies();
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
