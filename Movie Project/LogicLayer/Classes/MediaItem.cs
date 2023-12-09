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

        public string Title
        {
            get => title;
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Title should not be empty!");
                }
                if (!value.Any(char.IsLetter))
                {
                    throw new ArgumentException("Title should contain at least one letter!");
                }
                title = value;
            }
        }
        public string Description
        {
            get => description;
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Description should not be empty!");
                }
                if (!value.Any(char.IsLetter))
                {
                    throw new ArgumentException("Description should contain at least one letter!");
                }
                description = value;
            }
        }
        public DateTime ReleaseDate { get; private set; }
        public double Rating
        {
            get => rating;
            set
            {
                if (value <= 1 || value >= 10)
                {
                    throw new InvalidRatingException();
                }

                rating = value;
            }
        }
        public string CountryOfOrigin
        {
            get => countryOfOrigin;
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Country of origin should not be empty!");
                }
                countryOfOrigin = value;
            }
        }
        public byte[] Picture { get; set; }

        public Dictionary<DateTime, int> ViewsNumberByDate { get;  set; }
        public double PopularityScore{  get;  set; }

        public MediaItem()
        {
            ratings = new List<int>();
            genres = new List<Genre>();
            PopularityScore = 0;
            ViewsNumberByDate = new Dictionary<DateTime, int>();
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
            PopularityScore = 0;
            ViewsNumberByDate = new Dictionary<DateTime, int>();

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
        }
        public int[] GetAllRatings()
        {
            return ratings.ToArray();
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
        public void RecordView(DateTime currentDate)
        {
            //If there is already a key with this date, it adds +1 to its value 
            if (ViewsNumberByDate.ContainsKey(currentDate.Date))
            {
                ViewsNumberByDate[currentDate.Date]++;
            }
            else
            {
                //If there isnt a key with this date, it creates a new one and starts with 1
                ViewsNumberByDate[currentDate.Date] = 1;
            }
        }
        public double CalculatePopularityScore(DateTime dateToCheck, TimePeriod timePeriod)
        {
            double ratingScore = CalculateAverageRating();
            int viewsOnPeriod = 0;

            switch (timePeriod)
            {
                case TimePeriod.Day:
                    //Takes the media item's views for today
                    viewsOnPeriod = ViewsNumberByDate.GetValueOrDefault(dateToCheck.Date);
                    break;

                case TimePeriod.Week:
                    //
                    DateTime startOfWeek = dateToCheck.Date.AddDays(-(int)dateToCheck.DayOfWeek + (int)DayOfWeek.Monday);
                    DateTime endOfWeek = startOfWeek.AddDays(6);

                    //Loop that goes through each day from the begining of the week until the end 
                    for (DateTime date = startOfWeek; date <= endOfWeek; date = date.AddDays(1))
                    {
                        //The visits from each day are being added in the variable 'viewsOnPeriod' in order to get all the views for the current week
                        viewsOnPeriod += ViewsNumberByDate.GetValueOrDefault(date.Date);
                    }
                    break;

                case TimePeriod.Month:
                    // Count views for the current month
                    DateTime startOfMonth = new DateTime(dateToCheck.Year, dateToCheck.Month, 1);
                    DateTime endOfMonth = startOfMonth.AddMonths(1).AddDays(-1);

                    //Loop that goes through each day from the begining of the month until the end 
                    for (DateTime date = startOfMonth; date <= endOfMonth; date = date.AddDays(1))
                    {
                        //The visits from each day are being added in the variable 'viewsOnPeriod' in order to get all the views for the current month
                        viewsOnPeriod += ViewsNumberByDate.GetValueOrDefault(date.Date);
                    }
                    break;

                    //Invalid TimePeriod type gives out an exception
                default:
                    throw new ArgumentException("Invalid time period specified");
            }

            PopularityScore = 0.7 * ratingScore + 0.3 * viewsOnPeriod;
            return PopularityScore;
        }
        public virtual string ToString()
        {
            return $"{GetId()} - {Title} ({ReleaseDate.ToString("dd-MM-yyyy")})";
        }
    }
}
