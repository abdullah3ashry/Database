    using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Project.Models;
using System.Data;
namespace Project.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        [BindProperty(SupportsGet = true)]

        public string username {  get; set; }
        [BindProperty(SupportsGet = true)]

        public int ID { get; set; }
        [BindProperty(SupportsGet = true)]

        public Recipe r { get; set; }

        public DataTable dt { get; set; }

        private DB db { get; set; }

        [BindProperty(SupportsGet = true)]

        public User U {  get; set; }

        public List<Recipe> Recipes { get; set; } = new List<Recipe>();

        public IndexModel(ILogger<IndexModel> logger,DB db)
        {
            _logger = logger;
            this.db = db;
        }

        public IActionResult OnGet()
        {
            if (string.IsNullOrEmpty(HttpContext.Session.GetString("Username")))
                {
                return Page();

            }
            else
            {
                dt = new DataTable();
                  dt= db.readtable("Recipe");
                username = HttpContext.Session.GetString("Username")!;
                ID=(Int32) HttpContext.Session.GetInt32("ID")!;
                for (int i = 0; i < 6; i++)
                {
                    r = new Recipe();
                    r.Description = (string)dt.Rows[i]["Description"];
                    r.CookingTime = (int)dt.Rows[i]["CookingTime"];
                    r.Instructions = (string)dt.Rows[i]["Instructions"];
                    r.Image = (string)dt.Rows[i]["Image"];
                    r.CategoryID = (int)dt.Rows[i]["CategoryID"];
                    r.RecipeId = (int)dt.Rows[i]["RecipeId"];
                    Recipes.Add(r);
                }
                return Page();
            }
                }
    }
}
