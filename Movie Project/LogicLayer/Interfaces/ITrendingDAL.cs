using LogicLayer.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicLayer.Interfaces
{
    public interface ITrendingDAL
    {
        void SaveTrendingMonthly(List<MediaItem> monthlyTrendingMedias, DateTime monthYear);

        void SaveTrendingWeekly(List<MediaItem> mediaItems, DateTime currentDate);

        void SaveTrendingDaily(List<MediaItem> dailyTrendingMedias, DateTime dayPicked);

        MediaItem[] GetTrendingDaily(DateTime dayPicked);
        DateTime GetLastTrendingCalculationTime(DateTime givenDate);

        MediaItem[] GetTrendingWeekly(DateTime dayPicked);

        MediaItem[] GetTrendingMonthly(DateTime dayPicked);
    }
}
