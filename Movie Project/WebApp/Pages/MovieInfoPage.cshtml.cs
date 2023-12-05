using LogicLayer.Classes;
using LogicLayer.Controllers;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace WebApp.Pages
{
    public class MovieInfoPageModel : PageModel
    {
        public MediaItem Movie { get; set; }
        public List<double> PopularityScores { get; set; }

        [BindProperty]
        public User Userr { get; set; }

        private readonly UserController _userController;
        private readonly MediaItemController _mediaController;
        private readonly MediaItemViewsController _mediaViewsController;
        private readonly FavoritesController _favoritesController;

        public MovieInfoPageModel(UserController userController, MediaItemController mediaController, FavoritesController favoritesController, MediaItemViewsController mediaViewsController)
        {
            _userController = userController;
            _mediaController = mediaController;
            _favoritesController = favoritesController;
            _mediaViewsController = mediaViewsController;
        }

        public void OnGet(int id)
        {
            Movie = _mediaController.GetMediaItemById(id);
            foreach (int rating in _mediaController.GetAllGivenRatings(Movie))
            {
                Movie.AddRating(rating);
            }
            Movie.ViewsNumberByDate = _mediaViewsController.GetAllViewsByMediaItem(Movie);
            Movie.RecordView(DateTime.Now);
            _mediaViewsController.UpdateViewsCount(Movie, DateTime.Now);
            DateTime currentDate = DateTime.Now.Date;
            PopularityScores = new List<double>();

            for (int i = 6; i >= 0; i--)
            {
                DateTime dateToCheck = currentDate.AddDays(-i);
                double popularityScore = Movie.CalculatePopularityScoreTwo(dateToCheck, LogicLayer.TimePeriod.Day);
                PopularityScores.Add(popularityScore);
            }
        }

        public IActionResult OnPost(int id)
        {
            var movie = _mediaController.GetMediaItemById(id);

            if (movie == null)
            {
                return NotFound();
            }

            var userID = User.FindFirst("Id").Value;
            Userr = _userController.GetUserByID(Int32.Parse(userID.ToString()));

            if (Userr == null)
            {
                return RedirectToPage("/Login");
            }

            if (_favoritesController.CheckIfProductIsInFavorites(movie, Userr) == false)
            {
                _favoritesController.AddProductToFavorite(movie, Userr);
                TempData["Message"] = "Movie added to favorites!";
                return RedirectToPage("/MovieInfoPage", new { id = movie.GetId() });
            }

            TempData["Message"] = "Movie is already in favorites!";
            return RedirectToPage("/MovieInfoPage", new { id = movie.GetId() });
        }

        public IActionResult OnPostLogout()
        {
            HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            Response.Cookies.Delete("RememberMeCookie");

            return RedirectToPage("/Index");
        }
    }
}
