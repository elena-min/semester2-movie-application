using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicLayer.Classes
{
    public class Movie : MediaItem
    {
        private string director;
        private string writer;
        private int duration;
        public string Director { get; private set; }
        public string Writer { get; private set; }
        public int Duration { get; private set; }

        public Movie(string _title, string _description, DateTime _releaseDate, string _countryOfOrigin, double _rating, int _numberOfviews, string _director, string _writer, int _duration) : base(_title, _description, _releaseDate, _countryOfOrigin, _rating, _numberOfviews)
        {
            Director = _director;
            Writer = _writer;
            Duration = _duration;
        }
        public override string ToString()
        {
            return $"Movie- {base.ToString()}";
        }
    }
}
