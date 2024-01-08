using LogicLayer.Controllers;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using LogicLayer.Classes;
using Microsoft.AspNetCore.Authorization;
using System;

namespace WebApp.Pages
{
    public class UserProfilePageModel : PageModel
    {
        public User Userr { get; set; }
        public string ReasonForBanning { get; set; }   

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
            if (!string.IsNullOrEmpty(Userr.ReasonForDeleting))
            {
                ReasonForBanning = Userr.ReasonForDeleting;
            }
        }

        [Authorize(Roles = "Employee")]
        public IActionResult OnPostDeleteUser(int ID, string reason)
        {
            if (string.IsNullOrEmpty(reason))
            {
                TempData["Message"] = $"A reason for banning should be filled!";
                return RedirectToPage("/UserProfilePage", new { ID = ID });
            }

            try
            {
                User selectedUser = _userController.GetUserByID(ID);

                                _empController.DeleteUserAccount(selectedUser, reason);
                return RedirectToPage("/Main");
            }
            catch (Exception ex)
            {
                TempData["Message"] = $"An unexpected error occurred: {ex.Message}";
                return RedirectToPage("/UserProfilePage", new { ID = ID });

            }

        }
        public IActionResult OnPostLogout()
        {
            HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            Response.Cookies.Delete("RememberMeCookie");

            return RedirectToPage("/Index");
        }
    }
}
