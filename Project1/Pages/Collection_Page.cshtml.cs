using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Data;
using System.Data.SqlClient;
using Project.Models;


namespace Project.Pages
{
    public class Collection_PageModel : PageModel

    {
      
        [BindProperty(SupportsGet = true)]

        public Int32 ID { get; set; }

        public DB db { get; set; }

        [BindProperty(SupportsGet = true)]


        public string Collectioname { get; set; }

        [BindProperty(SupportsGet = true)]

        
        public Int32 Collectionid { get; set; }
        [BindProperty(SupportsGet = true)]

        public Recipe recipe { get; set; }
        [BindProperty(SupportsGet = true)]
        public List<Recipe> recipes { get; set; }


        private readonly ILogger<Collection_PageModel> _logger;

        public DataTable dt { get; set; }
        public Collection_PageModel(ILogger<Collection_PageModel> logger, DB db)
        {
            _logger = logger;
            this.db = db;
        }
        public void OnGet(int CollectionID,string Description) 
        {
            Collectioname = Description;
            Collectionid = CollectionID;
            ID = (Int32)HttpContext.Session.GetInt32("ID")!;
            dt = new DataTable();
            dt = db.Collection(ID, Collectionid);
            for(int i = 0; i < dt.Rows.Count; i++)
            {
                
                recipe = new Recipe();
                recipe.RecipeId = (int)dt.Rows[i]["RecipeId"];
                recipe.Description = dt.Rows[i]["Description"].ToString();
                recipe.CookingTime = (int)dt.Rows[i]["CookingTime"];
                recipe.Servings = (int)dt.Rows[i]["Servings"];
                recipe.PreparationTime = (int)dt.Rows[i]["PreparationTime"];
                recipe.Instructions = dt.Rows[i]["Instructions"].ToString();
                recipe.Ingredients = dt.Rows[i]["Ingredients"].ToString();
                recipe.DifficultyLevel = dt.Rows[i]["DifficultyLevel"].ToString();
                //recipe.CategoryName = dt.Rows[i]["CategoryName"].ToString();
                recipe.CategoryID = (int)dt.Rows[i]["CategoryID"];
                recipe.Image = dt.Rows[i]["Image"].ToString();
                recipes.Add(recipe);


            }


        }


    }
}

        //public Collection c { get;  set; }
        //List<Collection> collections { get; set; }
        //public Int32 ID { get; set; }

        //public DB db { get; set; }

        //private readonly ILogger<Collection_PageModel> _logger;

        //public DataTable dt { get; set; }
        //public Collection_PageModel(ILogger<Collection_PageModel> logger,DB db)
        //{
        //    _logger = logger;
        //    this.db = db;
        //}

        //public void OnGet( )
        //{
        //    ID = (Int32)HttpContext.Session.GetInt32("ID")!;
        //    dt = db.Collections(ID);
        //}