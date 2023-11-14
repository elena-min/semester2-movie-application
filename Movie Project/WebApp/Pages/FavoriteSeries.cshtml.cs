using LogicLayer.Classes;
using LogicLayer.Controllers;
using LogicLayer;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace WebApp.Pages
{
    public class FavoriteSeriesModel : PageModel
    {
        [BindProperty]
        public User Userr { get; set; }

        private readonly UserController _userController;
        private readonly FavoritesController _favoritesController;

        public List<MediaItem> FavoriteSeries { get; set; }

        [BindProperty]
        public List<MediaItem> Results { get; set; }
        public int TotalResults { get; set; }
        public int TotalPages { get; set; }
        public int CurrentPage { get; set; }

        public FavoriteSeriesModel(UserController userController, FavoritesController favoritesController)
        {
            this._userController = userController;
            this._favoritesController = favoritesController;
            FavoriteSeries = new List<MediaItem>();

        }
        public IActionResult OnGet(string searchTerm, Genre? genreSelect, int pageIndex = 1)
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

            if (_favoritesController.GetAllFavoriteMovies(Userr.GetId()) != null)
            {
                foreach (MediaItem media in _favoritesController.GetAllFavorites(Userr.GetId()))
                {
                    if (media is Serie)
                    {
                        FavoriteSeries.Add(media);
                    }
                }
            }


            return Page();
        }
        public IActionResult OnPost(int movieId)
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

            TempData["Message"] = _favoritesController.RemoveFromFavorites(movieId, Int32.Parse(userID));
            return RedirectToPage("/FavoriteSeries");
        }


        public IActionResult OnPostLogout()
        {
            HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToPage("/Index");
        }
    }
}
