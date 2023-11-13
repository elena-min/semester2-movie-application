using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicLayer.Classes
{
    public class Serie : MediaItem
    {
        private int seasons;
        private int episodes;
        public int Seasons { get; private set; }
        public int Episodes { get; private set; }

        public Serie(string _title, string _description, DateTime _releaseDate, string _countryOfOrigin, double _rating, int _numberOfviews, int _seasons, int _episodes) : base(_title, _description, _releaseDate, _countryOfOrigin, _rating, _numberOfviews)
        {
            Seasons = _seasons;
            Episodes = _episodes;
        }


        public override string ToString()
        {
            return $"Serie- {base.ToString()}";
        }
    }
}
