using LogicLayer.Classes;
using LogicLayer.Controllers;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using LogicLayer.Strategy;
using Microsoft.AspNetCore.Authorization;
using LogicLayer.SortingStrategy;

namespace WebApp.Pages
{
    [Authorize]
    public class RecommendationPageModel : PageModel
    {
        private readonly UserController _userController;
        private readonly MediaItemController _mediaController;
        private readonly FavoritesController _favController;
        private readonly FilterContext _filterContext;
        private readonly SortingContext _sortingContext;
        public User Userr { get; set; }

        public List<MediaItem> RecentMovies { get; set; }
        public List<MediaItem> RecentShows { get; set; }
        public List<MediaItem> Recommendations { get; set; }
        public List<MediaItem> MediaItems { get; set; }




        public RecommendationPageModel(MediaItemController mediaController, FavoritesController favController, FilterContext filterContext, UserController userController, SortingContext sortingContext)
        {
            _mediaController = mediaController;
            _favController = favController;
            _filterContext = filterContext;
            _userController = userController;
            _sortingContext = sortingContext;
        }
        public IActionResult OnGet()
        {
            if (User.Identity.IsAuthenticated)
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
                FavoriteMediaItem favoriteMediaItem = new FavoriteMediaItem(Userr);

                foreach (MediaItem favMedia in _favController.GetAllFavorites(Userr))
                {
                    favoriteMediaItem.AddToFavorites(favMedia);
                }
            }
            else
            {

            }


            Recommendations = new List<MediaItem>();
            MediaItems  = new List<MediaItem>();
            RecentMovies = new List<MediaItem>();
            RecentShows = new List<MediaItem>();


            foreach (MediaItem mediaItem in _mediaController.GetAll())
            {
                if (mediaItem is Movie)
                {
                    MediaItems.Add((Movie)mediaItem);
                    RecentMovies.Add((Movie)mediaItem);
                }
                if (mediaItem is Serie)
                {
                    MediaItems.Add((Serie)mediaItem);
                    RecentShows.Add((Serie)mediaItem);
                }
            }            

            if (_favController.GetAllFavorites(Userr) != null && _favController.GetAllFavorites(Userr).Length > 0)
            {
                _filterContext.SetFilterStrategy(new RecommendationsFilterStrategy(Userr));
                Recommendations = _filterContext.GetFilteredMediaItems(MediaItems).ToList();
            }

            _sortingContext.SetSortingStrategy(new ReleaseDateSortingStrategy());
            MediaItems = _sortingContext.GetSortedMediaItems(MediaItems).ToList();
            RecentMovies = _sortingContext.GetSortedMediaItems(RecentMovies).Take(10).ToList();
            RecentShows = _sortingContext.GetSortedMediaItems(RecentShows).Take(10).ToList();

            return Page();

        }

        public IActionResult OnPostLogout()
        {
            HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            Response.Cookies.Delete("RememberMeCookie");

            return RedirectToPage("/Index");
        }
    }
}
