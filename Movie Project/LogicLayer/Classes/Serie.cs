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

        public Serie(string _title, string _description, DateTime _releaseDate, string _countryOfOrigin, int _rating, int _seasons, int _episodes) : base(_title, _description, _releaseDate, _countryOfOrigin, _rating)
        {
            this.seasons = _seasons;
            this.episodes = _episodes;
        }


        public virtual string ToString()
        {
            return $"Serie: {base.ToString()}";
        }
    }
}
