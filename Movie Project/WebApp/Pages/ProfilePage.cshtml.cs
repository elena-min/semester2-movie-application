using LogicLayer.Controllers;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using LogicLayer.Classes;
using Microsoft.AspNetCore.Authorization;

namespace WebApp.Pages
{
    [Authorize]
    public class ProfilePageModel : PageModel
    {
        public User Userr { get; set; }
        public string ProfilePicture { get; set; }

        [BindProperty]
        public IFormFile ProfilePicturefile { get; set; }

        private readonly UserController _userController;
        public ProfilePageModel(UserController userController)
        {
            _userController = userController;
        }
        public IActionResult OnGet()
        {
            try
            {
                var userID = User.FindFirst("Id")?.Value;

                if (userID == null)
                {
                    return RedirectToPage("/Login");
                }

                Userr = _userController.GetUserByID(Int32.Parse(userID));

                if (Userr == null)
                {
                    return NotFound();
                }

                string profilePictureBytes = _userController.GetProfilePicByID(Userr);

                if (profilePictureBytes != null)
                {
                    ProfilePicture = profilePictureBytes;
                }

                return Page();
            }
            catch (Exception ex)
            {
                TempData["Message"] = ex.ToString();
                return RedirectToPage("/Error");
            }
            
        }
        public IActionResult OnPost(IFormFile profilePicture)
        {
            try
            {
                var userID = User.FindFirst("Id")?.Value;

                if (userID == null)
                {
                    return RedirectToPage("/Login");
                }

                Userr = _userController.GetUserByID(Int32.Parse(userID));

                if (Userr == null)
                {
                    return NotFound();
                }

                if (profilePicture != null && profilePicture.Length > 0)
                {
                    using (var memoryStream = new MemoryStream())
                    {
                        profilePicture.CopyTo(memoryStream);
                        byte[] imageArray = memoryStream.ToArray();

                        if (_userController.SetProfilePicture(Userr, imageArray))
                        {
                            TempData["Message"] = "Profile Picture successfully changed";

                        }
                        else
                        {
                            TempData["Message"] = "Could not change profile picture.";
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                TempData["Message"] = $"An unexpected error occurred: {ex.Message}";
            }
            return RedirectToPage();

        }

        public IActionResult OnPostLogout()
        {
            HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            Response.Cookies.Delete("RememberMeCookie");

            return RedirectToPage("/Index");
        }

        //private bool IsImageFile(IFormFile file)
        //{
        //    var allowedExtensions = new[] { ".jpg", ".jpeg", ".png", ".gif" };
        //    var fileExtension = Path.GetExtension(file.FileName).ToLowerInvariant();
        //    return allowedExtensions.Contains(fileExtension);
        //}
    }
}
