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
        private readonly TrendingController _trendingController;
        private readonly FilterContext _filterContext;

        private List<MediaItem> MoviesTrendingDailyCache;
        private List<MediaItem> MoviesTrendingWeeklyCache;
        private List<MediaItem> MoviesTrendingMonthlyCache;


        private readonly IMemoryCache cache;
        private Timer hourlyCacheUpdateTimer;
        private Timer dailyCacheUpdateTimer;


        public List<MediaItem> MoviesTrendingDaily { get; set; }
        public List<MediaItem> MoviesTrendingWeekly { get; set; }
        public List<MediaItem> MoviesTrendingMonthly { get; set; }
        public List<MediaItem> MediaItems { get; set; }

        public TrendingModel(MediaItemController mediaItemController, MediaItemViewsController mediaItemViewsController, FilterContext filterContext, IMemoryCache _cache, TrendingController trendingController)
        {
            this._mediaController = mediaItemController;
            this._filterContext = filterContext;
            this._mediaViewsController = mediaItemViewsController;
            this._trendingController = trendingController;

            cache = _cache;
            MoviesTrendingDailyCache = new List<MediaItem>();
            MoviesTrendingWeeklyCache = new List<MediaItem>();
            MoviesTrendingMonthlyCache = new List<MediaItem>();

            var currentTime = DateTime.Now;
            var timeUntilNextHour = TimeSpan.FromHours(1) - TimeSpan.FromMinutes(currentTime.Minute) - TimeSpan.FromSeconds(currentTime.Second);
            var timeUntilMidnight = DateTime.Today.AddDays(1) - currentTime;

            dailyCacheUpdateTimer = new Timer(UpdateDaily, null, timeUntilMidnight, TimeSpan.FromHours(24));
            hourlyCacheUpdateTimer = new Timer(UpdateCache, null, timeUntilNextHour, TimeSpan.FromHours(1));
        }

        public void OnGet()
        {
            string cacheKey = "MoviesTrendingDaily";

            // Attempt to retrieve data from cache
            if (cache.TryGetValue(cacheKey, out List<MediaItem> cachedMovies))
            {
                // Use cached data if available
                MoviesTrendingDaily = cachedMovies;
            }
            else
            {
                // Initialize the list to ensure it's not null
                MoviesTrendingDaily = new List<MediaItem>();
                if(_trendingController.GetTrendingDaily(DateTime.Today).Length > 0)
                {
                    MoviesTrendingDaily = _trendingController.GetTrendingDaily(DateTime.Today).ToList();
                }
                else
                {
                    RecalculateTrending(null);
                    MoviesTrendingDaily = MoviesTrendingDailyCache;
                }
                // Save the loaded data to cache
                cache.Set(cacheKey, MoviesTrendingDaily, TimeSpan.FromHours(1));
            }

            DateTime now = DateTime.Now;
            string cacheKey2 = "MoviesTrendingWeekly";

            if (cache.TryGetValue(cacheKey2, out List<MediaItem> cachedMoviesWeekly))
            {
                MoviesTrendingWeekly = cachedMoviesWeekly;
            }
            else
            {
                MoviesTrendingWeekly = new List<MediaItem>();
                if (_trendingController.GetTrendingWeekly(DateTime.Today).Length > 0)
                {
                    MoviesTrendingWeekly = _trendingController.GetTrendingWeekly(DateTime.Today).ToList();
                }
                else
                {
                    RecalculateWeeklyMonthlyTrending(null);
                    MoviesTrendingWeekly = MoviesTrendingWeeklyCache;
                }
                DateTime midnight = now.Date.AddDays(1);
                TimeSpan timeUntilMidnight = midnight - now;
                cache.Set(cacheKey2, MoviesTrendingWeekly, timeUntilMidnight);
            }

            string cacheKey3 = "MoviesTrendingMonthly";

            if (cache.TryGetValue(cacheKey3, out List<MediaItem> cachedMoviesMonthly))
            {
                MoviesTrendingMonthly = cachedMoviesMonthly;
            }
            else
            {
                MoviesTrendingMonthly = new List<MediaItem>();
                if (_trendingController.GetTrendingMonthly(DateTime.Today).Length > 0)
                {
                    MoviesTrendingMonthly = _trendingController.GetTrendingMonthly(DateTime.Today).ToList();
                }
                else
                {
                    RecalculateWeeklyMonthlyTrending(null);
                    MoviesTrendingMonthly = MoviesTrendingMonthlyCache;
                }
                DateTime midnight = now.Date.AddDays(1);
                TimeSpan timeUntilMidnight = midnight - now;
                cache.Set(cacheKey3, MoviesTrendingMonthly, timeUntilMidnight);
            }
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
            _trendingController.SaveTrendingDaily(updatedMoviesTrendingDailyCache.Take(10).ToList(), DateTime.Now);
            MoviesTrendingDailyCache = updatedMoviesTrendingDailyCache;
        }
        private void RecalculateWeeklyMonthlyTrending(object state)
        {
            List<MediaItem> updatedMoviesTrendingCache = new List<MediaItem>();

            foreach (MediaItem mediaItem in _mediaController.GetAll())
            {
                if (mediaItem is Movie)
                {
                    updatedMoviesTrendingCache.Add((Movie)mediaItem);
                }
                if (mediaItem is Serie)
                {
                    updatedMoviesTrendingCache.Add((Serie)mediaItem);
                }
            }

            foreach (MediaItem movie in updatedMoviesTrendingCache)
            {
                foreach (int rating in _mediaController.GetAllGivenRatings(movie.GetId()))
                {
                    movie.AddRating(rating);
                    movie.ViewsNumberByDate = _mediaViewsController.GetAllViewsByMediaItem(movie.GetId());
                }
            }

            _filterContext.SetFilterStrategy(new TrendingFilterStrategy(DateTime.Now, LogicLayer.TimePeriod.Week));
            updatedMoviesTrendingCache = _filterContext.GetFilteredMediaItems(updatedMoviesTrendingCache).ToList();
            _trendingController.SaveTrendingWeekly(updatedMoviesTrendingCache.Take(10).ToList(), DateTime.Now);
            MoviesTrendingWeeklyCache = updatedMoviesTrendingCache;

            _filterContext.SetFilterStrategy(new TrendingFilterStrategy(DateTime.Now, LogicLayer.TimePeriod.Month));
            updatedMoviesTrendingCache = _filterContext.GetFilteredMediaItems(updatedMoviesTrendingCache).ToList();
            _trendingController.SaveTrendingMonthly(updatedMoviesTrendingCache.Take(10).ToList(), DateTime.Now);
            MoviesTrendingMonthlyCache = updatedMoviesTrendingCache;
        }



        private void UpdateCache(object state)
        {
            RecalculateTrending(null);

            // Save the calculated data to cache
            cache.Set("MoviesTrendingDaily", MoviesTrendingDailyCache, TimeSpan.FromHours(1));
        }
        private void UpdateDaily(object state)
        {
            RecalculateWeeklyMonthlyTrending(null);

            DateTime now = DateTime.Now;
            DateTime midnight = now.Date.AddDays(1);
            TimeSpan timeUntilMidnight = midnight - now;
            cache.Set(MoviesTrendingWeekly, MoviesTrendingMonthlyCache, timeUntilMidnight);
            cache.Set(MoviesTrendingMonthly, MoviesTrendingMonthlyCache, timeUntilMidnight);
        }

        public IActionResult OnPostLogout()
        {
            HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            Response.Cookies.Delete("RememberMeCookie");

            return RedirectToPage("/Index");
        }
    }
}
