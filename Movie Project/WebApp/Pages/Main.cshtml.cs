using LogicLayer.Classes;
using LogicLayer.Controllers;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using LogicLayer.Strategy;
using LogicLayer;
using LogicLayer.SortingStrategy;

namespace WebApp.Pages
{
    public class MainModel : PageModel
    {
        private readonly MediaItemController _mediaController;
        private readonly MediaItemViewsController _mediaViewsController;
        private readonly FilterContext _filterContext;
        private readonly SortingContext _sortingContext;


        public int TotalResults { get; set; }
        public int TotalPages { get; set; }
        public int CurrentPage { get; set; }
        public List<MediaItem> Results { get; set; }


        public List<MediaItem> Movies { get; set; }
        public List<MediaItem> Shows { get; set; }
        public List<MediaItem> AllMediaItems { get; set; }


        public MainModel(MediaItemController mediaController, MediaItemViewsController mediaViewsController, FilterContext filterContext, SortingContext sortingContext)
        {
            _mediaController = mediaController;
            _mediaViewsController = mediaViewsController;
            _filterContext = filterContext;
            _sortingContext = sortingContext;
        }
        public IActionResult OnGet(string searchTerm, Genre? genreSelect, string sortSelect, int pageIndex = 1)
        {
            Movies = new List<MediaItem>();
            Shows = new List<MediaItem>();
            AllMediaItems = new List<MediaItem>();

            //try
            //{
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

                foreach (MediaItem movie in AllMediaItems)
                {
                    foreach (int rating in _mediaController.GetAllGivenRatings(movie))
                    {
                        movie.AddRating(rating);
                    }
                }


                const int pageSize = 5;
                int startIndex = (pageIndex - 1) * pageSize;
                int endIndex = startIndex + pageSize - 1;

                if (string.IsNullOrEmpty(searchTerm) && !genreSelect.HasValue)
                {
                    if (!string.IsNullOrEmpty(sortSelect))
                    {
                        if (sortSelect.Equals("popularity", StringComparison.OrdinalIgnoreCase))
                        {
                            _sortingContext.SetSortingStrategy(new RatingSortingStrategy());
                        }
                        else if (sortSelect.Equals("newest", StringComparison.OrdinalIgnoreCase))
                        {
                            _sortingContext.SetSortingStrategy(new ReleaseDateSortingStrategy(descending: true));
                        }
                        else if (sortSelect.Equals("oldest", StringComparison.OrdinalIgnoreCase))
                        {
                            _sortingContext.SetSortingStrategy(new ReleaseDateSortingStrategy());
                        }
                    }
                    else
                    {
                        _sortingContext.SetSortingStrategy(new ReleaseDateSortingStrategy(descending: true));
                    }
                    MediaItem[] recentMediaItems = _sortingContext.GetSortedMediaItems(AllMediaItems);
                    Results = recentMediaItems.ToList();

                    TotalResults = Results.Count;
                    TotalPages = (int)Math.Ceiling((double)TotalResults / (pageSize * 2));
                    CurrentPage = pageIndex;

                    startIndex = (pageIndex - 1) * (pageSize * 2);
                    endIndex = Math.Min(startIndex + (pageSize * 2) - 1, TotalResults - 1);

                    Results = Results.GetRange(startIndex, endIndex - startIndex + 1);
                //return RedirectToPage("/Main", new { searchTerm = searchTerm, genreSelect = genreSelect, sortSelect = sortSelect });
                return Page();
                }

                _filterContext.SetFilterStrategy(new SearchFilterStrategy(searchTerm, genreSelect));

                MediaItem[] trendingRecommendations = _filterContext.GetFilteredMediaItems(AllMediaItems);

                if (!string.IsNullOrEmpty(sortSelect))
                {
                    if (sortSelect.Equals("popularity", StringComparison.OrdinalIgnoreCase))
                    {
                        _sortingContext.SetSortingStrategy(new RatingSortingStrategy());
                    }
                    else if (sortSelect.Equals("newest", StringComparison.OrdinalIgnoreCase))
                    {
                        _sortingContext.SetSortingStrategy(new ReleaseDateSortingStrategy(descending: true));
                    }
                    else if (sortSelect.Equals("oldest", StringComparison.OrdinalIgnoreCase))
                    {
                        _sortingContext.SetSortingStrategy(new ReleaseDateSortingStrategy());
                    }
                }
                else
                {
                    _sortingContext.SetSortingStrategy(new ReleaseDateSortingStrategy(descending: true));
                }

                MediaItem[] trendingRecommendationsSorted = _sortingContext.GetSortedMediaItems(trendingRecommendations.ToList());
                Results = trendingRecommendationsSorted.ToList();

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
            //}
            //catch (Exception ex) 
            //{
            //    TempData["Message"] = ex.Message;
            //    return RedirectToPage("/Error");
            //}

        }

        public IActionResult OnPostLogout()
        {
            HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            Response.Cookies.Delete("RememberMeCookie");

            return RedirectToPage("/Index");
        }
    }
}
