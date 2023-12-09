using LogicLayer.Controllers;
using LogicLayer;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using LogicLayer.Classes;
using Microsoft.AspNetCore.Authorization;

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
            try
            {
                var userID = User.FindFirst("Id").Value;
                var existingUser = _userController.GetUserByID(Int32.Parse(userID));

                //Checks if there is a user with this username already existing.
                //Also check whether the new username is the same as the old one
                if (_userController.GetUserByUsername(username) != null && username != existingUser.Username)
                {
                    TempData["Message"] = "Username is already taken. Please choose a different username.";
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
                if (_userController.UpdateUser(existingUser))
                {
                    TempData["Message"] = "Successfully updated!";
                }
                else
                {
                    TempData["Message"] = "Update failed.";
                }
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
