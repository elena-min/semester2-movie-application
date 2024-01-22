using LogicLayer.Classes;
using LogicLayer.Controllers;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.ViewEngines;
using Microsoft.AspNetCore.Authorization;

namespace WebApp.Pages
{
    [Authorize]
    public class ReviewPageModel : PageModel
    {
        private readonly UserController _userController;
        private readonly MediaItemController _mediaController;
        private readonly ReviewController _reviewController;

        public User Userr { get; set; }

        public MediaItem Movie { get; set; }
        public int MovieId { get; set; }

        public MediaItem Serie { get; set; }

        [BindProperty]
        public Review Review { get; set; }

        [BindProperty]
        [Required]
        public string ReviewTitle { get; set; }

        [BindProperty]
        [Required]
        public string ReviewContent { get; set; }
        //public int Rating { get; set; }
        [BindProperty]
        public MediaItem PointedTowards { get; set; }

        public ReviewPageModel(MediaItemController mediaController, ReviewController reviewController, UserController userController)
        {
            _mediaController = mediaController;
            _reviewController = reviewController;
            _userController = userController;
        }

        public IActionResult OnPost(int movieId)
        {
            try
            {
                var userID = User.FindFirst("Id").Value;
                if (userID == null)
                {
                    return RedirectToPage("/Login");
                }
                Userr = _userController.GetUserByID(Int32.Parse(userID.ToString()));

              

                //MediaItem mediaItem = _mediaController.GetMediaItemById(movieId);
                if (_mediaController.GetMediaItemById(movieId) is Movie)
                {
                    Movie = _mediaController.GetMediaItemById(movieId);

                }
                else if (_mediaController.GetMediaItemById(movieId) is Serie)
                {
                    Serie = _mediaController.GetMediaItemById(movieId);
                }
                else
                {
                    RedirectToPage("/Main");
                }

                int rating = 3;
                string ratingString = Request.Form["Rating"];
                if (!string.IsNullOrEmpty(ratingString))
                {
                    rating = Convert.ToInt32(Request.Form["Rating"]);
                    if (rating == 0)
                    {
                        if(Movie != null)
                        {
                            TempData["Message"] = $"The rating should be between 1 and 5!";
                            return RedirectToPage("/ReviewPage", new { movieId = Movie.GetId() });
                        }
                        else if (Serie != null)
                        {
                            TempData["Message"] = $"The rating should be between 1 and 5!";
                            return RedirectToPage("/ReviewPage", new { movieId = Serie.GetId() });

                        }
                    }
                }
                else
                {
                    TempData["Message"] = $"The rating should be between 1 and 5!";
                    return Page();
                }

                if (Movie != null)
                {
                    
                        Review review = new Review { Title = ReviewTitle, ReviewContent = ReviewContent, Rating = rating, PointedTowards = Movie, ReviewWriter = Userr };
                        _reviewController.AddReview(review);
                        return RedirectToPage("/MovieInfoPage", new { id = Movie.GetId() });
                }
                else if (Serie != null)
                {
                      Review review = new Review { Title = ReviewTitle, ReviewContent = ReviewContent, Rating = 2, PointedTowards = Serie, ReviewWriter = Userr };
                        review.Rating = rating;
                        _reviewController.AddReview(review);
                        return RedirectToPage("/SerieInfoPage", new { id = Serie.GetId() });
                
                }

                return RedirectToPage("/Main");
            }
            catch (ArgumentException ex)
            {
                TempData["Message"] = $"{ex.Message}";
                return Page();
            }
            catch (Exception ex)
            {
                TempData["Message"] = $"An unexpected error: {ex.Message}";
                return Page();
            }

        }
        public IActionResult OnPostLogout()
        {
            HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            Response.Cookies.Delete("RememberMeCookie");

            return RedirectToPage("/Index");
        }

        public IActionResult OnGet(int movieId)
        {
            try
            {
                MediaItem mediaItem = _mediaController.GetMediaItemById(movieId);
                if (mediaItem is Movie)
                {
                    Movie = mediaItem;

                }
                else if (mediaItem is Serie)
                {
                    Serie = mediaItem;
                }
                else
                {
                    RedirectToPage("/Index");
                }

                MovieId = movieId;
                return Page();
            }
            catch (ArgumentException ex)
            {
                TempData["Message"] = $"{ex.Message}";
                return Page();
            }
            catch (Exception ex)
            {
                TempData["Message"] = $"An unexpected error: {ex.Message}";
                return Page();
            }

        }
    }
}
