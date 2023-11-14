using LogicLayer.Classes;
using LogicLayer.Controllers;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using LogicLayer.Strategy;

namespace WebApp.Pages
{
    public class RecommendationPageModel : PageModel
    {
        private readonly UserController _userController;
        private readonly MediaItemController _mediaController;
        private readonly FavoritesController _favController;
        private readonly FilterContext _filterContext;
        public User Userr { get; set; }

        public List<MediaItem> Movies { get; set; }
        public List<MediaItem> Shows { get; set; }
        public MediaItem[] RecommendationMovies { get; set; }

        public MediaItem[] RecommendationSeries { get; set; }


        public RecommendationPageModel(MediaItemController mediaController, FavoritesController favController, FilterContext filterContext, UserController userController)
        {
            _mediaController = mediaController;
            _favController = favController;
            _filterContext = filterContext;
            _userController = userController;
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

                foreach (MediaItem favMedia in _userController.GetAllFavorites(Userr.GetId()))
                {
                    Userr.FavoriteMediaItem.AddToFavoroites(favMedia);
                }
            }


            Movies = new List<MediaItem>();
            Shows = new List<MediaItem>();

            foreach (MediaItem m in _mediaController.GetAll())
            {
                if (m is Movie)
                {
                    Movies.Add(m);
                }
                else if (m is Serie)
                {
                    Shows.Add(m);
                }

            }
        }

        public IActionResult OnPostLogout()
        {
            HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToPage("/Index");
        }
    }
}
