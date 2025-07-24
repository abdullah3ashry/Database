using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Project.Models;
using Project.Pages;
using System.Data;

namespace project.Pages
{
    public class Index1Model : PageModel
    {
        private readonly ILogger<IndexModel> _logger;

        private DB db { get; set; }
        public Recipe r { get; set; }

        public DataTable dt2 { get; set; }

        //public string categoryname { get; set; }

        public Index1Model(ILogger<IndexModel> logger, DB db)
        {
            _logger = logger;
            this.db = db;
        }

        public void OnGet(string description, int cookingTime, string image, string Ingredients, string instructions, int RecipeId, string CategoryName, int Rating, string Name)
        {

            dt2 = db.readtable_category(RecipeId);
            foreach (DataRow row in dt2.Rows)
            {
                r = new Recipe
                {
                    CategoryName = (string)row["CategoryName"],
                    RecipeId = (int)row["RecipeId"],
                    Ingredients = (string)row["Ingredients"],
                    Description = (string)row["Description"],
                    CookingTime = (int)row["CookingTime"],
                    Image = (string)row["Image"],
                    Instructions = (string)row["Instructions"],
                    Rating = (int)row["Rating"],
                    Name = (string)row["Name"],

                };
            }


        }


    }
}
