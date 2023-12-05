using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.PortableExecutable;
using System.Text;
using System.Threading.Tasks;

namespace LogicLayer.Classes
{
    public class Review
    {
        private int id;
        private string title;
        private string reviewContent;
        private int rating;
        private MediaItem pointedTowards;
        private User reviewWriter;
        private DateTime dateOfPublication;
        private bool isDeleted;
        private string reasonForDeleting;

        public string Title
        {
            get => title;
            set
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
        public string ReviewContent
        {
            get => reviewContent;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("The review content should not be empty!");
                }
                if (!value.Any(char.IsLetter))
                {
                    throw new ArgumentException("The review content should contain at least one letter!");
                }
                reviewContent = value;
            }
        }

        public int Rating
        {
            get => rating;
            set
            {
                if (value <= 1 || value >= 5)
                {
                    throw new ArgumentException("The rating should be between 1 and 5!");
                }

                rating = value;
            }
        }
        public MediaItem PointedTowards { get; set; }
        public User ReviewWriter { get; set; }
        public DateTime DateOfPublication
        {
            get => dateOfPublication;
            set
            {
                if (value > DateTime.Now)
                {
                    throw new ArgumentException("Date of publication cannot be in the future.");
                }
                dateOfPublication = value;
            }
        }
        public bool IsDeleted { get; set; }
        public string ReasonForDeleting
        {
            get => reasonForDeleting;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("The reason for deleting should not be empty!");
                }
                if (!value.Any(char.IsLetter))
                {
                    throw new ArgumentException("The reason for deleting should contain at least one letter!");
                }
                reasonForDeleting = value;
            }
        }
        public Review() { }
        public Review(string title, string content, int rating, MediaItem pointedTowards, User reviewWriter)
        {
            Title = title;
            ReviewContent = content;
            Rating = rating;
            PointedTowards = pointedTowards;
            ReviewWriter = reviewWriter;
            DateOfPublication = DateTime.Now;
            IsDeleted = false;
        }
        public Review(string title, string content, int rating, MediaItem pointedTowards, User reviewWriter, DateTime dateOfPublication)
        {
            Title = title;
            ReviewContent = content;
            Rating = rating;
            PointedTowards = pointedTowards;
            ReviewWriter = reviewWriter;
            DateOfPublication = dateOfPublication;
            IsDeleted = false;
        }
        public void SetId(int id)
        {
            this.id = id;
        }
        public int GetId()
        {
            return this.id;
        }

        public void SetReviewAsDeleted(string reason)
        {
            IsDeleted = true;  
            ReasonForDeleting = reason;
        }
        public string GetInfo()
        {
            return $"{GetId()} - {Title} - {Rating}/5";

        }
        public override string ToString()
        {
            return $"{GetId()} - {ReviewWriter.Username}: {Title}({Rating})";
        }
    }
}
