using LogicLayer.Controllers;
using LogicLayer;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using LogicLayer.Classes;
using Microsoft.AspNetCore.Authorization;
using Newtonsoft.Json.Linq;

namespace WebApp.Pages
{
    [Authorize]
    public class ProfileChangePageModel : PageModel
    {
        [BindProperty]
        public User Userr { get; set; }

        private readonly UserController _userController;
        public ProfileChangePageModel(UserController userController)
        {
            _userController = userController;
        }

        public IActionResult OnGet()
        {
            var userID = User.FindFirst("Id").Value;

            if (userID == null)
            {
                return RedirectToPage("/Login");
            }

            Userr = _userController.GetUserByID(Int32.Parse(userID.ToString()));

            if (Userr == null)
            {
                return NotFound();
            }

            return Page();
        }
        public IActionResult OnPost(string username, string firstName, string lastName, string gender, string profileDescription)
        {
            var userID = User.FindFirst("Id").Value;
            var existingUser = _userController.GetUserByID(Int32.Parse(userID));
            try
            {             
                //Checks if there is a user with this username already existing.
                //Also check whether the new username is the same as the old one
                if (_userController.GetUserByUsername(username) != null && username != existingUser.Username)
                {
                    TempData["Message"] = "Username is already taken. Please choose a different username.";
                    return Page();
                }

                string user_firstName = existingUser.FirstName;
                string fnameString = Request.Form["firstName"];
                if (!string.IsNullOrEmpty(fnameString) && (fnameString.Any(char.IsLetter)))
                {
                    user_firstName = Request.Form["firstName"];               
                }
                else
                {
                    TempData["Message"] = $"The first name should be filled in and should contain atleast 1 letter!";
                    return Page();
                }

                string user_lasstName = existingUser.LastName;
                string lnameString = Request.Form["lastName"];
                if (string.IsNullOrEmpty(lnameString) && (lnameString.Any(char.IsLetter)))
                {
                    TempData["Message"] = $"The last name should be filled in and should contain atleast 1 letter!";
                    return Page();
                }

                string user_username = existingUser.Username;
                string usernameString = Request.Form["username"];
                if (string.IsNullOrEmpty(usernameString) && (usernameString.Any(char.IsLetter)))
                {
                    TempData["Message"] = $"The username should be filled in and should contain atleast 1 letter!";
                    return Page();
                }


                existingUser.Username = username;
                existingUser.FirstName = firstName;
                existingUser.LastName = lastName;
                existingUser.Gender = (Gender)Enum.Parse(typeof(Gender), gender);
                if (profileDescription != null)
                {
                    existingUser.ProfileDescription = profileDescription;
                }
                else
                {
                    existingUser.ProfileDescription = null;
                }
            }
            catch (ArgumentException ex)
            {
                TempData["Message"] = $"An unexpected error occurred: {ex.Message}";
            }
            catch (ValidationException ex)
            {
                TempData["Message"] = $"{ex.Message}";

            }
            catch (Exception ex)
            {
                TempData["Message"] = $"An unexpected error occurred: {ex.Message}";
            }

            try 
            {
                if (_userController.UpdateUser(existingUser))
                {
                    TempData["Message"] = "Successfully updated!";
                }
                else
                {
                    TempData["Message"] = "Update failed.";
                }
            }
        
            catch (ArgumentException ex)
            {
                TempData["Message"] = $"An unexpected error occurred: {ex.Message}";
            }
            catch (ValidationException ex)
            {
                TempData["Message"] = $"{ex.Message}";

            }
            catch (Exception ex)
            {
                TempData["Message"] = $"An unexpected error occurred: {ex.Message}";
            }
            
            return Page();
        }

        public IActionResult OnPostLogout()
        {
            HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            Response.Cookies.Delete("RememberMeCookie");

            return RedirectToPage("/Index");
        }
    }
}
