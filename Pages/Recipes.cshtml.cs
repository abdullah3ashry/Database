//using Microsoft.AspNetCore.Mvc;
//using Microsoft.AspNetCore.Mvc.RazorPages;
//using Project.Models;
//using System.Data;

//namespace Project.Pages
//{
//    public class RecipesModel : PageModel
//    {
//        public DB db { get; set; }
//        public List<Recipe> Recipes { get; set; }

//        public Recipe recipe { get; set; }

//        private readonly ILogger<RecipesModel> _logger;

//        public RecipesModel(ILogger<RecipesModel> logger, DB db)
//        {
//            _logger = logger;
//            this.db = db;
//        }
//        public void OnGet()
//        {
//            DataTable dt = db.ReadTable("Recipe");
//            Recipes = new List<Recipe>();

//            for (int i = 0; i < dt.Rows.Count; i++)
//            {




//                recipe = new Recipe();
//                recipe.RecipeId = (int)dt.Rows[i]["RecipeId"];
//                recipe.Description = dt.Rows[i]["Description"].ToString();
//                recipe.CreationDate = (DateTime)dt.Rows[i]["CreationDate"];
//                recipe.CookingTime = (int)dt.Rows[i]["CookingTime"];
//                recipe.Servings = (int)dt.Rows[i]["Servings"];
//                recipe.PreparationTime = (int)dt.Rows[i]["PreparationTime"];
//                recipe.Instructions = dt.Rows[i]["Instructions"].ToString();
//                recipe.Ingredients = dt.Rows[i]["Ingredients"].ToString();
//                recipe.DifficultyLevel = dt.Rows[i]["DifficultyLevel"].ToString();
//                //recipe.CategoryName = dt.Rows[i]["CategoryName"].ToString();
//                recipe.CategoryID = (int)dt.Rows[i]["CategoryID"];
//                recipe.Image = dt.Rows[i]["Image"].ToString();
//                Recipes.Add(recipe);
//            }
//        }


//    }
//}



using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Project.Models;
using System.Data;
using System.Xml.Linq;
using static System.Net.Mime.MediaTypeNames;

namespace Project.Pages
{
    public class RecipesModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;

        private DB db { get; set; }
        public Recipe r { get; set; }
        public DataTable dt { get; set; }

        public List<Recipe> Recipes { get; set; } = new List<Recipe>();
        public RecipesModel(ILogger<IndexModel> logger, DB db)
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
            dt = db.ReadTable("Recipe");
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
