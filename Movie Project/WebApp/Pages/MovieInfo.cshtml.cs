using LogicLayer.Classes;
using LogicLayer.Controllers;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace WebApp.Pages
{
    public class MovieInfoModel : PageModel
    {
        [BindProperty]
        public MediaItem Movie { get; set; }

        [BindProperty]
        public User Userr { get; set; }

        private readonly UserController _userController;
        private readonly MediaItemController _mediaController;

        public MovieInfoModel(MediaItemController mediaController, UserController userController)
        {
            _mediaController = mediaController;
            _userController = userController;
        }
        public void OnGet(int ID)
        {
            Movie = _mediaController.GetMediaItemById(ID);
            foreach (int rating in _mediaController.GetAllGivenRatings(Movie.GetId()))
            {
                Movie.AddRating(rating);
            }

        }


        public IActionResult OnPostLogout()
        {
            HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToPage("/Index");
        }
    }
}
