using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Project.Models;
using System.Data;
namespace Project.Pages
{
    public class ProfileModel : PageModel
    {
        private readonly ILogger<ProfileModel> _logger;
        private DB db { get; set; }
        [BindProperty(SupportsGet = true)]

        public DataTable dt { get; set; }
        [BindProperty(SupportsGet = true)]

        public User U { get; set; }
        [BindProperty(SupportsGet = true)]

        public List<User> Users { get; set; } = new List<User>();
        [BindProperty(SupportsGet = true)]

        public Int32 ID { get; set; }
        [BindProperty(SupportsGet = true)]
        public string Name { get; set; }
        public ProfileModel(ILogger<ProfileModel> logger, DB db)
        {
            _logger = logger;
            this.db = db;
        }

        public IActionResult OnPost()
        {
            U.ID = (Int32)HttpContext.Session.GetInt32("ID");
            db.Update(U);

            return Page();
        }
        public IActionResult OnPostDelete()
        {
            HttpContext.Session.Remove("ID");
            HttpContext.Session.Remove("Username");
            return RedirectToPage("/Index");
        }
        public IActionResult OnGet()

        {
            Name=(string)HttpContext.Session.GetString("Username")!;
            if (string.IsNullOrEmpty(Name))
            {
                return RedirectToPage("/Login");

            }
            else
            {
                ID = (Int32)HttpContext.Session.GetInt32("ID")!;
                U = db.GetUserInfo((int)ID);
                return Page();
            }



          
        }



        

    }
}
