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

        [BindProperty]
        public User Userr { get; set; }

        private readonly UserController _userController;
        private readonly MediaItemController _mediaController;
        private readonly FavoritesController _favoritesController;

        public MovieInfoPageModel(UserController userController, MediaItemController mediaController, FavoritesController favoritesController)
        {
            _userController = userController;
            _mediaController = mediaController;
            _favoritesController = favoritesController;
        }

        public void OnGet(int id)
        {
            Movie = _mediaController.GetMediaItemById(id);
            foreach (int rating in _mediaController.GetAllGivenRatings(Movie.GetId()))
            {
                Movie.AddRating(rating);
            }
            Movie.RecordView();
            _mediaController.RecordView(Movie);
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

            if (_favoritesController.CheckIfProductIsInFavorites(movie.GetId(), Userr.GetId()) == false)
            {
                _favoritesController.AddProductToFavorite(movie.GetId(), Userr.GetId());
                TempData["Message"] = "Movie added to favorites!";
                return RedirectToPage("/MovieInfoPage", new { id = movie.GetId() });
            }

            TempData["Message"] = "Movie is already in favorites!";
            return RedirectToPage("/MovieInfoPage", new { id = movie.GetId() });
        }

        public IActionResult OnPostLogout()
        {
            HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToPage("/Index");
        }
    }
}
