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
    public class WrittenReviewsModel : PageModel
    {
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

                Reviews = _reviewController.GetReviewsByUser(Userr).ToList();

                return Page();
            }
            catch (Exception ex)
            {
                TempData["Message"] = ex.ToString();
                return RedirectToPage("/Error");
            }
            
        }
        public IActionResult OnPostDelete(int reviewId)
        {
            try
            {
                //It takes the value of the confirmDelete from the form
                string confirmParam = Request.Form["confirmDelete"];
                //The confirmParam should not be null or empty and the confirmParam should be a bool.
                //If both the conditions are kept and the bool is true, then the review will be deleted
                bool userConfirmed = !string.IsNullOrEmpty(confirmParam) && bool.Parse(confirmParam);

                if(userConfirmed)
                {
                    var review = _reviewController.GetReviewByID(reviewId);
                    if (review != null)
                    {
                        _reviewController.DeletebyUser(review);
                    }
                }
                
                return RedirectToPage("/WrittenReviews");
            }
            catch(Exception ex) 
            {
                TempData["Message"] = $"An unexpected error occurred: {ex.Message}";
                return RedirectToPage("/WrittenReviews");
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
