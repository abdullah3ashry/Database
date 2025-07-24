using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;
using Project.Models;
using Microsoft.AspNetCore.Mvc;

//namespace Project.Pages
//{
//    [BindProperties]
//    public class Index1Model : PageModel
//    {
//        [Required(ErrorMessage = "Please Enter A Name ")]
//        public string FName { get; set; }
//        public string? LName { get; set; }
//        [Required(ErrorMessage = "Please Enter A UserName ")]
//        public string UName { get; set; }
//        [Required]
//        [EmailAddress]
//        public string Email { get; set; }

//        [Required]
//        [MinLength(3, ErrorMessage = "Must Be 3 Or More Characters")]
//        public string Password { get; set; }
//        [Required]
//        public string ConfirmPassword { get; set; }
//        [Required(ErrorMessage = "Please Enter A Birthdate")]
//        [DataType(DataType.Date)]
//        public string Bdate { get; set; }


//        public User U { get; set; }

//        private DB db {  get; set; }

//        private readonly ILogger<Index1Model> _logger;

//        public Index1Model(ILogger<Index1Model> logger, DB db)
//        {
//            _logger = logger;
//            this.db = db;
//        }



//        public IActionResult OnPost()
//        {
//            U= new User()
//            {   
//                FName = FName,
//                LName = LName,
//                UName = UName,
//                Email = Email,
//                Password = Password,
//                Bdate = Bdate
//            };
//            db.SignUp(U);
//            return RedirectToPage("/Index");
//        }
//    }
//}
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;
using Project.Models;
using Microsoft.Extensions.Logging;

namespace Project.Pages
{
    [BindProperties]
    public class Index1Model : PageModel
    {
        [Required(ErrorMessage = "Please Enter A First Name")]
        public string FName { get; set; }

        public string LName { get; set; }

        [Required(ErrorMessage = "Please Enter A UserName")]
        public string UName { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [MinLength(3, ErrorMessage = "Must Be 3 Or More Characters")]
        public string Password { get; set; }

        [Required]
        [Compare("Password", ErrorMessage = "Passwords do not match")]
        public string ConfirmPassword { get; set; }

        [Required(ErrorMessage = "Please Enter A Birthdate")]
        [DataType(DataType.Date)]
        public DateTime Bdate { get; set; }

        public string Phone { get; set; } // Assuming Phone is required; adjust if necessary

        public User U { get; set; }

        private DB db { get; set; }

        private readonly ILogger<Index1Model> _logger;

        public Index1Model(ILogger<Index1Model> logger, DB db)
        {
            _logger = logger;
            this.db = db;
        }

        public IActionResult OnPost()
        {
            if (ModelState.IsValid)
            {
                U = new User
                {
                    FName = FName,
                    LName = LName,
                    UName = UName,
                    Email = Email,
                    Password = Password,
                    Bdate = Bdate,
                    Phone = Phone 
                };

                db.SignUp(U);
                return RedirectToPage("/Index");
            }

            return Page();
        }
    }
}


