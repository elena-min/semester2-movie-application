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
        public int Seasons
        {
            get => seasons;
            private set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("There should be at leats one season.");
                }
                seasons = value;
            }
        }

        public int Episodes
        {
            get => episodes;
            private set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("There should be at leats one episode.");
                }
                episodes = value;
            }
        }
        public Serie(string _title, string _description, DateTime _releaseDate, string _countryOfOrigin, double _rating, int _seasons, int _episodes) : base(_title, _description, _releaseDate, _countryOfOrigin, _rating)
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
