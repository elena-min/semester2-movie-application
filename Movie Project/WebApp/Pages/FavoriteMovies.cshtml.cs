using LogicLayer.Controllers;
using LogicLayer;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using LogicLayer.Classes;
using System.Reflection;
using LogicLayer.Strategy;
using Microsoft.AspNetCore.Authorization;

namespace WebApp.Pages
{
    [Authorize]
    public class FavoriteMoviesModel : PageModel
    {

        [BindProperty]
        public User Userr { get; set; }

        private readonly UserController _userController;
        private readonly FavoritesController _favoritesController;
        private readonly FilterContext _filterContext;

        public List<MediaItem> FavoriteMovies { get; set; }

        [BindProperty]
        public List<MediaItem> Results { get; set; }
        public int TotalResults { get; set; }
        public int TotalPages { get; set; }
        public int CurrentPage { get; set; }

        public FavoriteMoviesModel(UserController userController, FavoritesController favoritesController, FilterContext filterContext)
        {
            this._userController = userController;
            FavoriteMovies = new List<MediaItem>();
            _favoritesController = favoritesController;
            _filterContext = filterContext;
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
                foreach (MediaItem item in _favoritesController.GetAllFavoriteMovies(Userr.GetId()))
                {
                    if (item is Movie)
                    {
                        FavoriteMovies.Add(item);
                    }
                }
            }

            //if (string.IsNullOrEmpty(searchTerm) && !genreSelect.HasValue)
            //{
            //    return Page();
            //}
            _filterContext.SetFilterStrategy(new SearchFilterStrategy(searchTerm, genreSelect));
            MediaItem[] searchRecommendations = _filterContext.GetFilteredMediaItems(FavoriteMovies);
            Results = searchRecommendations.ToList();
            const int pageSize = 8;
            TotalResults = Results.Count;
            TotalPages = (int)Math.Ceiling((double)TotalResults / pageSize);
            pageIndex = Math.Max(1, Math.Min(pageIndex, TotalPages));
            CurrentPage = pageIndex;

            int startIndex = (pageIndex - 1) * pageSize;
            int endIndex = Math.Min(startIndex + pageSize - 1, TotalResults - 1);

            Results = Results.GetRange(startIndex, endIndex - startIndex + 1);

            if (Results.Count == 0)
            {
                TempData["Message"] = "No favorite movies.";
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
            return RedirectToPage("/FavoriteMovies");
        }


        public IActionResult OnPostLogout()
        {
            HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            Response.Cookies.Delete("RememberMeCookie");

            return RedirectToPage("/Index");
        }
    }
}
