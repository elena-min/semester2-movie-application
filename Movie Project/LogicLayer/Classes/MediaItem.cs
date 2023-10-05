using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicLayer.Classes
{
    public class MediaItem
    {
        protected int id;
        protected string title;
        protected string description;
        protected DateTime releaseDate;
        protected List<Genre> genres;
        protected double rating;
        protected List<int> ratings;
        protected string countryOfOrigin;
        public Cast Cast { get; set; }

        public string Title { get; private set; }
        public string Description { get; private set; }
        public DateTime ReleaseDate { get; private set; }
        public double Rating { get; private set; }
        public string CountryOfOrigin { get; private set; }
        public MediaItem()
        {
            ratings = new List<int>();
            genres = new List<Genre>();
        }

        public MediaItem(string _title, string _description, DateTime _releaseDate, string _countryOfOrigin, double _rating)
        {
            Title = _title;
            Description = _description;
            ReleaseDate = _releaseDate;
            CountryOfOrigin = _countryOfOrigin;
            Rating = _rating;  
            ratings = new List<int>();
            genres = new List<Genre>();
            Cast = new Cast(Title);

        }
        public void SetId(int id)
        {
            this.id = id;
        }
        public int GetId()
        {
            return this.id;
        }

        public void AddRating(int newRating)
        {
            ratings.Add(newRating);
            //int ratingSum = 0;
            //foreach (int rating in ratings)
            //{

            //    ratingSum += rating;
            //}
            //Rating = ratingSum / ratings.Count();
        }
        public virtual double CalculateAverageRating()
        {
            if (ratings == null || ratings.Count == 0)
            {
                return 0.0;
            }

            double sum = 0.0;
            foreach (int rating in ratings)
            {
                sum += rating;
            }

            return sum / ratings.Count;
        }
        public void AddGenre(Genre newgenre)
        {
            if (!genres.Contains(newgenre))
            {
                genres.Add(newgenre);
            }
        }
        public Genre[] GetAllGenres()
        {
            return genres.ToArray();
        }
        public virtual string ToString()
        {
            return $"{GetId()} - {Title} ({ReleaseDate.ToString("dd-MM-yyyy")})";
        }
    }
}
