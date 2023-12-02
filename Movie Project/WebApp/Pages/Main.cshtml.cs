using LogicLayer.Classes;
using LogicLayer.Controllers;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using LogicLayer.Strategy;
using LogicLayer;

namespace WebApp.Pages
{
    public class MainModel : PageModel
    {
        private readonly MediaItemController _mediaController;
        private readonly MediaItemViewsController _mediaViewsController;
        private readonly FilterContext _filterContext;

        public int TotalResults { get; set; }
        public int TotalPages { get; set; }
        public int CurrentPage { get; set; }
        public List<MediaItem> Results { get; set; }


        public List<MediaItem> Movies { get; set; }
        public List<MediaItem> Shows { get; set; }
        public List<MediaItem> AllMediaItems { get; set; }


        public MainModel(MediaItemController mediaController, MediaItemViewsController mediaViewsController, FilterContext filterContext)
        {
            _mediaController = mediaController;
            _mediaViewsController = mediaViewsController;
            _filterContext = filterContext;
        }
        public IActionResult OnGet(string searchTerm, Genre? genreSelect, int pageIndex = 1)
        {
            Movies = new List<MediaItem>();
            Shows = new List<MediaItem>();
            AllMediaItems = new List<MediaItem>();


            foreach (MediaItem m in _mediaController.GetAll())
            {
                if (m is Movie)
                {
                    Movies.Add(m);
                    AllMediaItems.Add(m);
                }
                else if (m is Serie)
                {
                    Shows.Add(m);
                    AllMediaItems.Add(m);
                }

            }

            const int pageSize = 4;
            int startIndex = (pageIndex - 1) * pageSize;
            int endIndex = startIndex + pageSize - 1;

            if (string.IsNullOrEmpty(searchTerm) && !genreSelect.HasValue)
            {
                _filterContext.SetFilterStrategy(new ReleaseDateFilterStrategy());

                MediaItem[] recentMediaItems = _filterContext.GetFilteredMediaItems(AllMediaItems);
                Results = recentMediaItems.ToList();

                TotalResults = Results.Count;
                TotalPages = (int)Math.Ceiling((double)TotalResults / (pageSize * 2));
                CurrentPage = pageIndex;

                startIndex = (pageIndex - 1) * (pageSize * 2);
                endIndex = Math.Min(startIndex + (pageSize * 2) - 1, TotalResults - 1);

                Results = Results.GetRange(startIndex, endIndex - startIndex + 1);
                return Page();
            }
            _filterContext.SetFilterStrategy(new SearchFilterStrategy(searchTerm, genreSelect));

            MediaItem[] trendingRecommendations = _filterContext.GetFilteredMediaItems(AllMediaItems);
            Results = trendingRecommendations.ToList();

            TotalResults = Results.Count;
            TotalPages = (int)Math.Ceiling((double)TotalResults / (pageSize * 2));
            CurrentPage = pageIndex;

            startIndex = (pageIndex - 1) * (pageSize * 2);
            endIndex = Math.Min(startIndex + (pageSize * 2) - 1, TotalResults - 1);

            Results = Results.GetRange(startIndex, endIndex - startIndex + 1);
            if (Results.Count == 0)
            {
                TempData["Message"] = "No results.";
            }
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
