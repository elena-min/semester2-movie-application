using LogicLayer.Classes;
using LogicLayer.Controllers;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using LogicLayer.Strategy;

namespace WebApp.Pages
{
    public class MainModel : PageModel
    {
        private readonly MediaItemController _mediaController;
        private readonly MediaItemViewsController _mediaViewsController;
        private readonly FilterContext _filterContext;

        public List<MediaItem> Movies { get; set; }
        public List<MediaItem> Shows { get; set; }

        public MainModel(MediaItemController mediaController, MediaItemViewsController mediaViewsController, FilterContext filterContext)
        {
            _mediaController = mediaController;
            _mediaViewsController = mediaViewsController;
            _filterContext = filterContext;
        }
        public void OnGet()
        {
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
