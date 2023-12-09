using LogicLayer.Classes;
using LogicLayer.Controllers;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Security.Claims;
using LogicLayer;
using Newtonsoft.Json;

namespace WebApp.Pages
{
    public class LoginModel : PageModel
    {
        private readonly UserController _userController;
        private readonly EmployeeController _empController;

        [BindProperty(SupportsGet =true)]
        public User User { get; set; }

        [BindProperty]
        public bool RememberMe { get; set; }
        public LoginModel(UserController userController, EmployeeController empController)
        {
            _userController = userController;
            _empController = empController;
        }
        public void OnGet()
        {
            // Check if the "RememberMeCookie" is present
            if (Request.Cookies.TryGetValue("RememberMeCookie", out string userData))
            {
                var userInfo = JsonConvert.DeserializeObject<dynamic>(userData);
                var userId = int.Parse(userData);
                var user = _userController.GetUserByID(userId);
                if (user != null)
                {

                    var claims = new List<Claim>
                     {
                    new Claim(ClaimTypes.Name, user.Username),
                    new Claim("Id", user.GetId().ToString()),
                    new Claim(ClaimTypes.Role, user.Role)
                    };

                    var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                    HttpContext.SignInAsync(new ClaimsPrincipal(claimsIdentity));
                    Response.Redirect("Main");
                }
            }
        }

        public IActionResult OnPost()
        {
            try
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
                            string reasonForBanning = _userController.CheckIfUserIsBanned(user);
                            if (reasonForBanning == null)
                            {
                                List<Claim> claims = new List<Claim>();
                                claims.Add(new Claim(ClaimTypes.Name, user.Username));
                                claims.Add(new Claim("Id", user.GetId().ToString()));
                                claims.Add(new Claim(ClaimTypes.Role, user.Role));
                                var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

                                // Check if "Remember Me" is checked
                                if (RememberMe)
                                {
                                    // Create a cookie with user information
                                    var userCookieOptions = new CookieOptions
                                    {
                                        Expires = DateTime.Now.AddDays(30)
                                    };

                                    // Serialize user information (e.g., user ID) and store it in the cookie
                                    var userData = user.GetId().ToString();

                                    //var userData = JsonConvert.SerializeObject(new { Id = user.GetId() });
                                    Response.Cookies.Append("RememberMeCookie", userData, userCookieOptions);
                                }

                                HttpContext.SignInAsync(new ClaimsPrincipal(claimsIdentity));

                                return RedirectToPage("Main");
                            }
                            else
                            {
                                user.SetUserAsBanned(reasonForBanning);
                                TempData["Message"] = "Your account has been banned. Reason: " + user.ReasonForDeleting;
                                return Page();
                            }
                        }

                    }

                    var emp = _empController.GetEmployeeByUsername(User.Username);
                    if (emp != null)
                    {
                        string pass = User.Password;
                        var result = HashPassword.VerifyPassword(pass, emp.Password, emp.Salt);

                        if (result)
                        {
                            List<Claim> claims = new List<Claim>();
                            claims.Add(new Claim(ClaimTypes.Name, emp.Username));
                            claims.Add(new Claim("Id", emp.GetId().ToString()));
                            claims.Add(new Claim(ClaimTypes.Role, emp.Role));
                            var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                            HttpContext.SignInAsync(new ClaimsPrincipal(claimsIdentity));

                            return RedirectToPage("Main");

                        }
                    }

                    //ModelState.AddModelError("InvalidCredentials", "The supplied username and/or password is invalid");
                    TempData["Message"] = "The supplied username and/or password is invalid";
                }
            }
            catch (Exception ex)
            {
                TempData["Message"] = $"An unexpected error occurred: {ex.Message}";
            }
            return Page();
        }

    }
}
