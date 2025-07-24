using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Project.Models;
using System.Data;
using System.Data.SqlClient;
namespace Project.Pages
{
    public class CollectionModel : PageModel
    {
        [BindProperty(SupportsGet =true)]
        public Collection c { get; set; }
        [BindProperty(SupportsGet = true)]

        public Int32 ID { get; set; }

        public DB db { get; set; }

        [BindProperty(SupportsGet = true)]

        public List<Collection> Collections { get; set; } = new List<Collection>();


        private readonly ILogger<CollectionModel> _logger;

        public DataTable dt { get; set; }
        public CollectionModel(ILogger<CollectionModel> logger, DB db)
        {
            _logger = logger;
            this.db = db;
        }

        public void OnGet()
        {
            ID = (Int32)HttpContext.Session.GetInt32("ID")!;
            dt = db.Collections(ID);

            for(int i=0;i<3;i++)
            {
                c=new Collection();
                c.Description = dt.Rows[i]["Description"].ToString();
                c.CreationDate = (DateTime)dt.Rows[i]["CreationDate"];
                c.CollectionId = (Int32)dt.Rows[i]["CollectionID"];
                c.Image = dt.Rows[i]["Image"].ToString();
                Collections.Add(c);
            }
        }

    }
}

