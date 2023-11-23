using LogicLayer.Classes;
using LogicLayer.Controllers;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Security.Claims;
using LogicLayer;

namespace WebApp.Pages
{
    public class LoginModel : PageModel
    {
        private readonly UserController _userController;

        [BindProperty(SupportsGet =true)]
        public User User { get; set; }

        public LoginModel(UserController userController)
        {
            _userController = userController;
        }
        public void OnGet()
        {
        }
        public IActionResult OnPost()
        {
            ModelState.Clear();
            if (ModelState.IsValid)
            {
                var user = _userController.GetUserByUsername(User.Username);
                if (user != null)
                {
                    var result = HashPassword.VerifyPassword(User.Password, user.Password, user.Salt);

                    if (result)
                    {
                        string reasonForBanning = _userController.CheckIfUserIsBanned(user.GetId());
                        if (reasonForBanning == null)
                        {
                            List<Claim> claims = new List<Claim>();
                            claims.Add(new Claim(ClaimTypes.Name, user.Username));
                            claims.Add(new Claim("Id", user.GetId().ToString()));
                            claims.Add(new Claim(ClaimTypes.Role, user.Role));
                            var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                            HttpContext.SignInAsync(new ClaimsPrincipal(claimsIdentity));

                            return RedirectToPage("Main");
                        }
                        else{
                            user.SetUserAsBanned(reasonForBanning);
                            TempData["Message"] = "Your account has been banned. Reason: " + user.ReasonForDeleting;
                        }

                    }
                }
                //ModelState.AddModelError("InvalidCredentials", "The supplied username and/or password is invalid");
                TempData["Message"] = "The supplied username and/or password is invalid";
            }
            return Page();
        }

    }
}
