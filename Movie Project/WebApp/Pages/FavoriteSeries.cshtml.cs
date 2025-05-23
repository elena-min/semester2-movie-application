using LogicLayer.Classes;
using LogicLayer.Controllers;
using LogicLayer;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using LogicLayer.Strategy;
using Microsoft.AspNetCore.Authorization;

namespace WebApp.Pages
{
    [Authorize]
    public class FavoriteSeriesModel : PageModel
    {
        [BindProperty]
        public User Userr { get; set; }

        private readonly UserController _userController;
        private readonly MediaItemController _mediaItemController;
        private readonly FavoritesController _favoritesController;
        private readonly FilterContext _filterContext;

        public List<MediaItem> FavoriteSeries { get; set; }

        [BindProperty]
        public List<MediaItem> Results { get; set; }
        public int TotalResults { get; set; }
        public int TotalPages { get; set; }
        public int CurrentPage { get; set; }

        public FavoriteSeriesModel(UserController userController, FavoritesController favoritesController, FilterContext filterContext, MediaItemController mediaItemController)
        {
            this._userController = userController;
            this._favoritesController = favoritesController;
            FavoriteSeries = new List<MediaItem>();
            _filterContext = filterContext;
            _mediaItemController = mediaItemController;
        }
        public IActionResult OnGet(string searchTerm, Genre? genreSelect, int pageIndex = 1)
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

                if (_favoritesController.GetAllFavorites(Userr) != null)
                {
                    foreach (MediaItem media in _favoritesController.GetAllFavorites(Userr))
                    {
                        if (media is Serie)
                        {
                            FavoriteSeries.Add(media);
                        }
                    }
                }

                _filterContext.SetFilterStrategy(new SearchFilterStrategy(searchTerm, genreSelect));
                MediaItem[] searchRecommendations = _filterContext.GetFilteredMediaItems(FavoriteSeries);
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
                    TempData["Message"] = "No favorite series.";
                }

                return Page();
            }
            catch (Exception ex)
            {
                TempData["Message"] = ex.Message;
                return RedirectToPage("/Error");
            }
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

                if (Userr == null)
                {
                    return NotFound();
                }
                if (movieId == null)
                {
                    return RedirectToPage("/Login");
                }

                MediaItem serie = _mediaItemController.GetMediaItemById(Int32.Parse(movieId.ToString()));

                if (serie == null)
                {
                    return NotFound();
                }

                TempData["Message"] = _favoritesController.RemoveFromFavorites(serie, Userr);
                return RedirectToPage("/FavoriteSeries");
            }
            catch (Exception ex)
            {
                TempData["Message"] = ex.Message;
                return RedirectToPage("/FavoriteSeries");
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
