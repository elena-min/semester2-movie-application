using LogicLayer.Controllers;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using LogicLayer.Classes;
using Microsoft.AspNetCore.Authorization;

namespace WebApp.Pages
{
    public class WrittenReviewsModel : PageModel
    {
        //[Authorize]
        public User Userr { get; set; }
        public List<Review> Reviews {  get; set; }
        private readonly UserController _userController;
        private readonly MediaItemController _mediaController;
        private readonly ReviewController _reviewController;
        public WrittenReviewsModel(UserController userController, MediaItemController mediaController, ReviewController reviewController)
        {
            _userController = userController;
            _mediaController = mediaController;
            _reviewController = reviewController;
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

            Reviews = _reviewController.GetReviewsByUser(Userr.GetId()).ToList();
            
            return Page();
        }
        public IActionResult OnPostDelete(int reviewId)
        {
            var review = _reviewController.GetReviewByID(reviewId);
            if (review != null)
            {
                _reviewController.DeletebyUser(review);
            }
            return RedirectToPage("/WrittenReviews");
        }

        public IActionResult OnPostLogout()
        {
            HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            Response.Cookies.Delete("RememberMeCookie");

            return RedirectToPage("/Index");
        }
    }
}
