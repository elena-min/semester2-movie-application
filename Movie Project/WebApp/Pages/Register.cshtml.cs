using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;
using LogicLayer.Controllers;
using LogicLayer;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using System.Security.Claims;
using LogicLayer.Classes;

namespace WebApp.Pages
{
    public class RegisterModel : PageModel
    {
        private readonly UserController userController;

        public RegisterModel(UserController userController)
        {
            this.userController = userController;
        }

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
        public IActionResult OnPost()
        {
            if (ModelState.IsValid)
            {
                Gender genderEnum = (Gender)Enum.Parse(typeof(Gender), Gender);

                User user = new User(Firstname, Lastname, Username, Email, Password, genderEnum);

                if (userController.GetUserByUsername(user.Username) == null)
                {
                    userController.InsertUser(user);
                    User someUser = userController.GetUserByUsername(user.Username);
                    user.SetId(someUser.GetId());
                    List<Claim> claims = new List<Claim>();
                    claims.Add(new Claim(ClaimTypes.Name, user.Username));
                    claims.Add(new Claim("Password", user.Password));
                    claims.Add(new Claim("Id", user.GetId().ToString()));

                    var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                    HttpContext.SignInAsync(new ClaimsPrincipal(claimsIdentity));

                    return RedirectToPage("/Main");
                }
                else
                {
                    TempData["Message"] = "This username is taken!";
                }
            }

            return Page();
        }

    }
}
