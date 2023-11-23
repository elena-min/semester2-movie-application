using DAL;
using LogicLayer.Classes;
using LogicLayer.Controllers;
using LogicLayer.Strategy;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Caching.Memory;

namespace WebApp.Pages
{
    public class TrendingModel : PageModel
    {
        private readonly MediaItemController _mediaController;
        private readonly MediaItemViewsController _mediaViewsController;
        private readonly FilterContext _filterContext;
        private readonly TrendingDAL trendingDAL;

        private List<MediaItem> MoviesTrendingDailyCache;
        public DateTime LastTrendingCalculationTime;

        private readonly IMemoryCache cache;


        public List<MediaItem> MoviesTrendingDaily { get; set; }
        public List<MediaItem> MoviesTrendingWeekly { get; set; }
        public List<MediaItem> MoviesTrendingMonthly { get; set; }
        public List<MediaItem> MediaItems { get; set; }

        public TrendingModel(MediaItemController mediaItemController, MediaItemViewsController mediaItemViewsController, FilterContext filterContext, IMemoryCache _cache, TrendingDAL trendingDAL)
        {
            this._mediaController = mediaItemController;
            this._filterContext = filterContext;
            this._mediaViewsController = mediaItemViewsController;            this.trendingDAL = trendingDAL;

            cache = _cache;
            MoviesTrendingDailyCache = new List<MediaItem>();
        }

        public void OnGet()
        {
            string cacheKey = "MoviesTrendingDaily";

            // Initialize the list to ensure it's not null
            MoviesTrendingDaily = new List<MediaItem>();

            // Attempt to retrieve data from cache
            if (cache.TryGetValue(cacheKey, out List<MediaItem> cachedMovies))
            {
                // Use cached data
                MoviesTrendingDaily = cachedMovies;
            }
            else
            {
                MoviesTrendingDailyCache = new List<MediaItem>();

                // Check if it's a new hour and recalculate if needed
                if (ShouldRecalculateTrending())
                {
                    RecalculateTrending(null); // Pass null as the state for this initial call

                    // Save the calculated data to cache
                    cache.Set(cacheKey, MoviesTrendingDailyCache, TimeSpan.FromHours(1));

                    // Update MoviesTrendingDaily with the calculated data
                    MoviesTrendingDaily = MoviesTrendingDailyCache;
                }
                else
                {
                    // Load trending data from the cache if it's not a new day or a new hour
                    MoviesTrendingDaily = trendingDAL.GetTrendingDaily(DateTime.Today).ToList();

                    // Save the loaded data to cache
                    cache.Set(cacheKey, MoviesTrendingDaily, TimeSpan.FromHours(1));
                }
            }
        }


        //public void OnGet()
        //{
        //    MoviesTrendingDaily = new List<MediaItem>();
        //    MoviesTrendingWeekly = new List<MediaItem>();
        //    MoviesTrendingMonthly = new List<MediaItem>();
        //    MediaItems = new List<MediaItem>();


        //    foreach (MediaItem mediaItem in _mediaController.GetAll())
        //    {
        //        if (mediaItem is Movie)
        //        {
        //            MediaItems.Add((Movie)mediaItem);
        //        }
        //        if (mediaItem is Serie)
        //        {
        //            MediaItems.Add((Serie)mediaItem);
        //        }
        //    }

        //    foreach (MediaItem movie in MediaItems)
        //    {
        //        foreach (int rating in _mediaController.GetAllGivenRatings(movie.GetId()))
        //        {
        //            movie.AddRating(rating);
        //            movie.ViewsNumberByDate = _mediaViewsController.GetAllViewsByMediaItem(movie.GetId());
        //        }

        //    }

        //    _filterContext.SetFilterStrategy(new TrendingFilterStrategy(DateTime.Now, LogicLayer.TimePeriod.Day));
        //    MoviesTrendingDaily = _filterContext.GetFilteredMediaItems(MediaItems).ToList();
        //    _filterContext.SetFilterStrategy(new TrendingFilterStrategy(DateTime.Now, LogicLayer.TimePeriod.Week));
        //    MoviesTrendingWeekly = _filterContext.GetFilteredMediaItems(MediaItems).ToList();
        //    _filterContext.SetFilterStrategy(new TrendingFilterStrategy(DateTime.Now, LogicLayer.TimePeriod.Month));
        //    MoviesTrendingMonthly = _filterContext.GetFilteredMediaItems(MediaItems).ToList();
        //}
        public bool ShouldRecalculateTrending()
        {
            DateTime currentDateTime = DateTime.Now;

            // Check if it's a new hour or a new day
            bool isSameHour = currentDateTime.Hour == LastTrendingCalculationTime.Hour;
            bool isNewDay = currentDateTime.Day > LastTrendingCalculationTime.Day;

            // If it's a new day or a new hour, return true; otherwise, return false
            return isNewDay || !isSameHour;
        }

        private void RecalculateTrending(object state)
        {
            List<MediaItem> updatedMoviesTrendingDailyCache = new List<MediaItem>();

            foreach (MediaItem mediaItem in _mediaController.GetAll())
            {
                if (mediaItem is Movie)
                {
                    updatedMoviesTrendingDailyCache.Add((Movie)mediaItem);
                }
                if (mediaItem is Serie)
                {
                    updatedMoviesTrendingDailyCache.Add((Serie)mediaItem);
                }
            }

            foreach (MediaItem movie in updatedMoviesTrendingDailyCache)
            {
                foreach (int rating in _mediaController.GetAllGivenRatings(movie.GetId()))
                {
                    movie.AddRating(rating);
                    movie.ViewsNumberByDate = _mediaViewsController.GetAllViewsByMediaItem(movie.GetId());
                }
            }

            _filterContext.SetFilterStrategy(new TrendingFilterStrategy(DateTime.Now, LogicLayer.TimePeriod.Day));
            updatedMoviesTrendingDailyCache = _filterContext.GetFilteredMediaItems(updatedMoviesTrendingDailyCache).ToList();
            trendingDAL.SaveTrendingDaily(updatedMoviesTrendingDailyCache.Take(10).ToList(), DateTime.Now);
            LastTrendingCalculationTime = DateTime.Now; // Update the timestamp

            // Replace the original list with the updated one
            MoviesTrendingDailyCache = updatedMoviesTrendingDailyCache;
        }

        public IActionResult OnPostLogout()
        {
            HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToPage("/Index");
        }
    }
}
