using LogicLayer.Classes;
using LogicLayer.Controllers;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace WebApp.Pages
{
    public class SerieInfoPageModel : PageModel
    {
        public MediaItem Serie { get; set; }

        [BindProperty]
        public User Userr { get; set; }

        private readonly UserController _userController;
        private readonly MediaItemController _mediaController;

        public SerieInfoPageModel(UserController userController, MediaItemController mediaController)
        {
            _userController = userController;
            _mediaController = mediaController;
        }

        public void OnGet(int id)
        {
            Serie = _mediaController.GetMediaItemById(id);
            foreach (int rating in _mediaController.GetAllGivenRatings(Serie.GetId()))
            {
                Serie.AddRating(rating);
            }
        }

        public IActionResult OnPostLogout()
        {
            HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToPage("/Index");
        }
    }
}
