using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;
using LogicLayer.Controllers;

namespace WebApp.Pages
{
    public class RegisterModel : PageModel
    {
        //private readonly UserController userController;

        //public RegisterModel(UserController userController)
        //{
        //    this.userController = userController;
        //}

        [BindProperty]
        public string Firstname { get; set; }

        [BindProperty]
        public string Lastname { get; set; }

        [BindProperty]
        [Required, MinLength(3, ErrorMessage = "Please supply a username with atleast 3 characters")]
        public string Username { get; set; }

        [BindProperty]
        [Required(ErrorMessage = "Please enter your email address.")]
        [RegularExpression(@"^[A-Za-z0-9._%+-]+@[A-Za-z0-9.-]+\.[A-Za-z]{2,}$", ErrorMessage = "Please enter a valid email address.")]
        public string Email { get; set; }

        [BindProperty]
        [Required, DataType(DataType.Password)]
        public string Password { get; set; }

        [BindProperty]
        public string Gender { get; set; }
        public void OnGet()
        {
        }
    }
}
