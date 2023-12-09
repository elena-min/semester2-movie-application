using LogicLayer.Classes;
using LogicLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicLayer.Controllers
{
    public class TrendingController
    {
        private ITrendingDAL itrendingDAL;
        public TrendingController(ITrendingDAL trendingDAL)
        {
            this.itrendingDAL = trendingDAL;
        }

        public void SaveTrendingMonthly(List<MediaItem> monthlyTrendingMedias, DateTime monthYear)
        {
            itrendingDAL.SaveTrendingMonthly(monthlyTrendingMedias, monthYear); 
        }

        public void SaveTrendingWeekly(List<MediaItem> mediaItems, DateTime currentDate)
        {
            itrendingDAL.SaveTrendingWeekly(mediaItems, currentDate);
        }

        public void SaveTrendingDaily(List<MediaItem> dailyTrendingMedias, DateTime dayPicked)
        {
            itrendingDAL.SaveTrendingDaily(dailyTrendingMedias, dayPicked);
        }

        public MediaItem[] GetTrendingDaily(DateTime dayPicked)
        {
            return itrendingDAL.GetTrendingDaily(dayPicked);
        }
        public DateTime GetLastTrendingCalculationTime(DateTime givenDate)
        {
            return itrendingDAL.GetLastTrendingCalculationTime(givenDate);

        }
        public MediaItem[] GetTrendingWeekly(DateTime dayPicked)
        {
            return itrendingDAL.GetTrendingWeekly(dayPicked);

        }

        public MediaItem[] GetTrendingMonthly(DateTime dayPicked)
        {
            return itrendingDAL.GetTrendingMonthly(dayPicked);
        }
    }
}
