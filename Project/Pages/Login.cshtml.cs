
//using Microsoft.AspNetCore.Mvc;
//using Microsoft.AspNetCore.Mvc.RazorPages;
//using Project.Models;

//using System.Data;
//namespace Project.Pages
//{
//	[BindProperties(SupportsGet =true)]
//	public class LoginModel : PageModel
//	{
//		public string Email { get; set; }

//		public string Password { get; set; }

//		public DB db { get; set; }
//		public User U { get; set; }
//		public DataTable dt { get; set; }
//		private readonly ILogger<LoginModel> _logger;
//		public LoginModel(ILogger<LoginModel> logger, DB db)
//		{
//			_logger = logger;
//			this.db = db;
//		}
//		//public IActionResult OnPost()
//		//{
//		//	// Handle login logic here
//		//	 //dt=db.SignIn(Email, Password);

//		//		return RedirectToPage(Page);

//		//	//if(dt==null)
//		//	//{

//		//	//}
//		//	//else
//		//	//{
//		// //                 U = new User();
//		// //                 U.ID = (int)dt.Rows[0]["UserID"];
//		// //                 U.UName = (string)dt.Rows[0]["Username"];
//		// //             U.FName = (string)dt.Rows[0]["Fname"];
//		// //             U.LName = (string)dt.Rows[0]["Lname"];

//		// //             U.Email = (string)dt.Rows[0]["Email"];
//		// //                 U.Phone = (string)dt.Rows[0]["PhoneNumber"];
//		//	//	U.Password = (string)dt.Rows[0]["Password"];

//		// //                 return RedirectToPage("/Index",new {U=this.U});

//		//	//}
//		//}

//	}
//}

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Project.Models;
using System.Data;


namespace Project.Pages
{
    public class LoginModel : PageModel
    {
        [BindProperty(SupportsGet = true)]
        public string Email { get; set; }
        [BindProperty(SupportsGet = true)]
        public string Password { get; set; }
        public DB db { get; set; }
        [BindProperty(SupportsGet = true)]
        public User U { get; set; }
        public DataTable dt { get; set; }
        private readonly ILogger<LoginModel> _logger;

        public LoginModel(ILogger<LoginModel> logger, DB db)
        {
            _logger = logger;
            this.db = db;
        }
        public IActionResult OnGet()
        { 
            string UserName = HttpContext.Session.GetString("Username");
            if(string.IsNullOrEmpty(UserName))
            {
                return Page();
            }
            else
            {
                return RedirectToPage("/Index");
            }


        }
        public IActionResult OnPost()
        {
            // Handle login logic here
            dt = db.SignIn(Email, Password);


            if (dt == null)
            {
                return RedirectToPage(Page);


            }
            else
            {
                U = new User();
                U.ID = (Int32)dt.Rows[0]["UserID"];
                U.UName = (string)dt.Rows[0]["Username"];
                U.FName = (string)dt.Rows[0]["Fname"];
                U.LName = (string)dt.Rows[0]["Lname"];  
                U.Email = (string)dt.Rows[0]["Email"];
                U.Phone = (string)dt.Rows[0]["PhoneNumber"];
                U.Password = (string)dt.Rows[0]["Password"];
                U.Bdate = (DateTime)dt.Rows[0]["Bday"];
                HttpContext.Session.SetString("Username", U.UName);
                HttpContext.Session.SetInt32("ID", U.ID);


                return RedirectToPage("/Index", new { username=this.U.UName });
            }
        }
    }
}

