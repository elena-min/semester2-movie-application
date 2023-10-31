using LogicLayer.Controllers;
using LogicLayer;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using LogicLayer.Classes;
using System.Reflection;

namespace WebApp.Pages
{
    public class FavoriteMoviesModel : PageModel
    {

        [BindProperty]
        public User Userr { get; set; }

        private readonly UserController _userController;

        public List<MediaItem> FavoriteMovies { get; set; }

        [BindProperty]
        public List<MediaItem> Results { get; set; }
        public int TotalResults { get; set; }
        public int TotalPages { get; set; }
        public int CurrentPage { get; set; }

        public FavoriteMoviesModel(UserController userController)
        {
            this._userController = userController;
            FavoriteMovies = new List<MediaItem>();

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
            
            if (_userController.GetAllFavoriteMovies(Userr.GetId()) != null)
            {
                foreach (MediaItem item in _userController.GetAllFavoriteMovies(Userr.GetId()))
                {
                    if (item is Movie)
                    {
                        FavoriteMovies.Add(item);
                    }
                }
            }

            if (string.IsNullOrEmpty(searchTerm) && !genreSelect.HasValue)
            {
                return Page();
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

            TempData["Message"] = _userController.RemoveFromFavorites(movieId, Int32.Parse(userID));
            return RedirectToPage("/FavoriteMovies");
        }


        public IActionResult OnPostLogout()
        {
            HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToPage("/Index");
        }
    }
}
