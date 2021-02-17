using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Blog.Models
{
    public class Post
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public int Category_id { get; set; }
        [ForeignKey("Category_id")]
        public Category Category { get; set; }
        public string Description { get; set; }
        public string Text { get; set; }
        public int View { get; set; }
        public DateTime Date { get; set; }
        public string Image { get; set; }
        public bool Secret { get; set; }
        public int Rating { get; set; }
        public int Q_vote { get; set; }
    }
}
