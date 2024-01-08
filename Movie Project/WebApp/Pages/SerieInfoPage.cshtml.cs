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
        public List<double> PopularityScores { get; set; }

        [BindProperty]
        public User Userr { get; set; }

        private readonly UserController _userController;
        private readonly MediaItemController _mediaController;
        private readonly MediaItemViewsController _mediaViewsController;
        private readonly FavoritesController _favoritesController;

        public SerieInfoPageModel(UserController userController, MediaItemController mediaController, FavoritesController favoritesController, MediaItemViewsController mediaViewsController)
        {
            _userController = userController;
            _mediaController = mediaController;
            _favoritesController = favoritesController;
            _mediaViewsController = mediaViewsController;
        }

        public void OnGet(int id)
        {
            Serie = _mediaController.GetMediaItemById(id);
            foreach (int rating in _mediaController.GetAllGivenRatings(Serie))
            {
                Serie.AddRating(rating);
            }
            Serie.ViewsNumberByDate = _mediaViewsController.GetAllViewsByMediaItem(Serie);
            Serie.RecordView(DateTime.Now);
            _mediaViewsController.UpdateViewsCount(Serie, DateTime.Now);

            DateTime currentDate = DateTime.Now.Date;
            PopularityScores = new List<double>();

            for (int i = 6; i >= 0; i--)
            {
                DateTime dateToCheck = currentDate.AddDays(-i);
                double popularityScore = Serie.CalculatePopularityScore(dateToCheck, LogicLayer.TimePeriod.Week);
                PopularityScores.Add(popularityScore);
            }
        }

        public IActionResult OnPost(int id)
        {
            var serie = _mediaController.GetMediaItemById(id);

            if (serie == null)
            {
                return NotFound();
            }

            var userID = User.FindFirst("Id").Value;
            Userr = _userController.GetUserByID(Int32.Parse(userID.ToString()));

            if (Userr == null)
            {
                return RedirectToPage("/Login");
            }

            if (_favoritesController.CheckIfProductIsInFavorites(serie, Userr) == false)
            {
                _favoritesController.AddProductToFavorite(serie, Userr);
                TempData["Message"] = "Serie added to favorites!";
                return RedirectToPage("/SerieInfoPage", new { id = serie.GetId() });
            }

            TempData["Message"] = "Serie is already in favorites!";
            return RedirectToPage("/SerieInfoPage", new { id = serie.GetId() });
        }
        public IActionResult OnPostLogout()
        {
            HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            Response.Cookies.Delete("RememberMeCookie");

            return RedirectToPage("/Index");
        }
    }
}
