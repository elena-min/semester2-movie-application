using LogicLayer.Controllers;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using LogicLayer.Classes;
using Microsoft.AspNetCore.Authorization;

namespace WebApp.Pages
{
    public class UserProfilePageModel : PageModel
    {
        public User Userr { get; set; }


        private readonly UserController _userController;
        private readonly EmployeeController _empController;

        public UserProfilePageModel(UserController userController, EmployeeController empController)
        {
            _userController = userController;
            _empController = empController;
        }
        public void OnGet(int ID)
        {
            Userr = _userController.GetUserByID(ID);
        }

        [Authorize(Roles = "Employee")]
        public IActionResult OnPostDeleteUser(int ID, string reason)
        {
            try
            {
                // Authorization logic is handled by the [Authorize] attribute
                User selectedUser = _userController.GetUserByID(ID);
                _empController.DeleteUserAccount(selectedUser, reason);
                return RedirectToPage("/Index");
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
