using System;
using System.Collections.Generic;
using System.Linq;
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

        public Review() { }
        public Review(string title, string content, int rating, MediaItem pointedTowards, User reviewWriter)
        {
            this.title = title;
            this.reviewContent = content;
            this.rating = rating;
            this.pointedTowards = pointedTowards;
            this.reviewWriter = reviewWriter;
            this.dateOfPublication = DateTime.Now;
            this.isDeleted = false;
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
            this.isDeleted = true;  
            this.reasonForDeleting = reason;
        }
        public override string ToString()
        {
            return $"{this.reviewWriter.Username}: {this.title}({this.rating})";
        }
    }
}
