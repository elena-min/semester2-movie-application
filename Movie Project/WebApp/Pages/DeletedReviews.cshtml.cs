using LogicLayer.Classes;
using LogicLayer.Controllers;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Authorization;

namespace WebApp.Pages
{
    [Authorize]
    public class DeletedReviewsModel : PageModel
    {
        public User Userr { get; set; }
        public List<Review> Reviews { get; set; }
        private readonly UserController _userController;
        private readonly MediaItemController _mediaController;
        private readonly ReviewController _reviewController;
        public DeletedReviewsModel(UserController userController, MediaItemController mediaController, ReviewController reviewController)
        {
            _userController = userController;
            _mediaController = mediaController;
            _reviewController = reviewController;
        }
        public IActionResult OnGet()
        {
            try
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

                Reviews = _reviewController.GetDeletedReviewsByUser(Userr).ToList();

                return Page();
            }
            catch (Exception ex)
            {
                TempData["Message"] = ex.ToString();
                return RedirectToPage("/Error");
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
