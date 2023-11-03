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

        public string Title { get; set; }
        public string ReviewContent { get; set; }
        public int Rating { get; set; }
        public MediaItem PointedTowards { get; set; }
        public User ReviewWriter { get; set; }
        public DateTime DateOfPublication { get; set; }
        public bool IsDeleted { get; set; }
        public string ReasonForDeleting { get; set; }
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
