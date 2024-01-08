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
        public string Director
        {
            get => director;
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Director(s) should not be empty!");
                }
                if (!value.Any(char.IsLetter))
                {
                    throw new ArgumentException("The director(s) should contain at least one letter!");
                }
                director = value;
            }
        }
        public string Writer
        {
            get => writer;
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Writer(s) should not be empty!");
                }
                if (!value.Any(char.IsLetter))
                {
                    throw new ArgumentException("The writer(s) should contain at least one letter!");
                }
                writer = value;
            }
        }
        public int Duration
        {
            get => duration;
            private set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Duration should be longer than 0 minutes.");
                }
                duration = value;
            }
        }

        public Movie() { }
        public Movie(string _title, string _description, DateTime _releaseDate, string _countryOfOrigin, double _rating, string _director, string _writer, int _duration) : base(_title, _description, _releaseDate, _countryOfOrigin, _rating)
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
