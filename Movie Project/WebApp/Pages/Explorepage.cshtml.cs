using LogicLayer.Classes;
using LogicLayer.Controllers;
using LogicLayer.Strategy;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using LogicLayer.Interfaces;

namespace WebApp.Pages
{
    public class ExploreModel : PageModel
    {
        private readonly MediaItemController _mediaController;
        private readonly FilterContext _filterContext;

        public List<MediaItem> MoviesTrendingDaily { get; set; }
        //public List<MediaItem> ShowsTrendingDaily { get; set; }
        public List<MediaItem> MoviesTrendingWeekly { get; set; }
        //public List<MediaItem> ShowsTrendingWeekly { get; set; }
        public List<MediaItem> MoviesTrendingMonthly { get; set; }
        //public List<MediaItem> ShowsTrendingMonthly { get; set; }
        public List<MediaItem> Movies { get; set; }
        public List<MediaItem> Series { get; set; }
        public List<MediaItem> MediaItems { get; set; }

        public ExploreModel(MediaItemController mediaController, FilterContext filterContext)
        {
            _mediaController = mediaController;
            _filterContext = filterContext;
        }
        public void OnGet()
        {
            MoviesTrendingDaily = new List<MediaItem>();
          //  ShowsTrendingDaily = new List<MediaItem>();
            MoviesTrendingWeekly = new List<MediaItem>();
          //  ShowsTrendingWeekly = new List<MediaItem>();
            MoviesTrendingMonthly = new List<MediaItem>();
          //  ShowsTrendingMonthly = new List<MediaItem>();
            Movies = new List<MediaItem>();
            Series = new List<MediaItem>();
            MediaItems = new List<MediaItem>();


            foreach (MediaItem mediaItem in _mediaController.GetAll())
            {
                if(mediaItem is Movie)
                {
                    MediaItems.Add((Movie)mediaItem);
                }
                if(mediaItem is Serie)
                {
                    MediaItems.Add((Serie)mediaItem);
                }
            }

            foreach(MediaItem movie in MediaItems)
            {
                foreach (int rating in _mediaController.GetAllGivenRatings(movie.GetId()))
                {
                    movie.AddRating(rating);
                }
            }
            

            _filterContext.SetFilterStrategy(new TrendingFilterStrategy(DateTime.Now, LogicLayer.TimePeriod.Day));
            MoviesTrendingDaily = _filterContext.GetFilteredMediaItems(MediaItems).ToList();
            //ShowsTrendingDaily = _filterContext.GetFilteredMediaItems(Series).ToList();
            _filterContext.SetFilterStrategy(new TrendingFilterStrategy(DateTime.Now, LogicLayer.TimePeriod.Week));
            MoviesTrendingWeekly = _filterContext.GetFilteredMediaItems(MediaItems).ToList();
           // ShowsTrendingWeekly = _filterContext.GetFilteredMediaItems(Series).ToList();
            _filterContext.SetFilterStrategy(new TrendingFilterStrategy(DateTime.Now, LogicLayer.TimePeriod.Month));
            MoviesTrendingMonthly = _filterContext.GetFilteredMediaItems(MediaItems).ToList();
           // ShowsTrendingMonthly = _filterContext.GetFilteredMediaItems(Series).ToList();

            //return Page();

        }

        public IActionResult OnPostLogout()
        {
            HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToPage("/Index");
        }
    }
}
