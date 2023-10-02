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

        public Movie(string _title, string _description, DateTime _releaseDate, string _countryOfOrigin, int _rating,  string _director, string _writer, int _duration) : base(_title, _description, _releaseDate, _countryOfOrigin, _rating)
        {
            this.director = _director;
            this.writer = _writer;
            this.duration = _duration;
        }
        public virtual string ToString()
        {
            return $"Movie: {base.ToString()}";
        }
    }
}
