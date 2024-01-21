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
            try
            {
                // Check if the "RememberMeCookie" is present
                //This will assign a value directly to the variable userDate if there is a cookie found
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
            catch (Exception ex)
            {
                TempData["Message"] = ex.ToString();
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
                            if(_userController.CheckIfUserIsBanned(user) == false)
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

                                    // Serialize userID and store it in the cookie
                                    var userData = user.GetId().ToString();

                                    //var userData = JsonConvert.SerializeObject(new { Id = user.GetId() });
                                    Response.Cookies.Append("RememberMeCookie", userData, userCookieOptions);
                                }

                                HttpContext.SignInAsync(new ClaimsPrincipal(claimsIdentity));

                                return RedirectToPage("Main");
                            }
                            else
                            {
                                string reasonForBanning = _userController.GetReasonForBanning(user);
                                if (reasonForBanning != null)
                                {
                                    user.SetUserAsBanned(reasonForBanning);
                                    DateTime? dateOfBanning = _userController.GetDateOfBanning(user);

                                    if (dateOfBanning.HasValue)
                                    {
                                        DateTime banStartDate = dateOfBanning.Value.Date;
                                        DateTime banExpirationDate = banStartDate.AddDays(30);
                                        TimeSpan timeRemaining = banExpirationDate - DateTime.UtcNow.Date;
                                        int daysRemaining = (int)timeRemaining.TotalDays;
                                        if(daysRemaining < 0)
                                        {
                                            _empController.UnBanUserAccount(user);
                                            TempData["Message"] = "Your account has been unbanned. Try again to login:)";
                                        }
                                        else
                                        {
                                            TempData["Message"] = "Your account has been banned. Reason: " + user.ReasonForDeleting + ". Days of ban left: " + daysRemaining;
                                        }
                                    }
                                    else
                                    {
                                        TempData["Message"] = "Your account has been banned. Reason: " + user.ReasonForDeleting;
                                    }
                                    return Page();
                                }
                                else
                                {
                                    TempData["Message"] = "There is a problem with your account. ";
                                    return Page();
                                }
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
