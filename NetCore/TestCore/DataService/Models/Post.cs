using System;
using System.Collections.Generic;

namespace DataService.Models
{
    public partial class Post
    {
        public Post()
        {
            Answer = new HashSet<Answer>();
            Comment = new HashSet<Comment>();
            Interactive = new HashSet<Interactive>();
            TagsOfPost = new HashSet<TagsOfPost>();
        }

        public int Id { get; set; }
        public string Title { get; set; }
        public string TextContent { get; set; }
        public int? OfUserId { get; set; }
        public DateTime? PostedTime { get; set; }
        public bool Active { get; set; }

        public virtual AppUser OfUser { get; set; }
        public virtual ICollection<Answer> Answer { get; set; }
        public virtual ICollection<Comment> Comment { get; set; }
        public virtual ICollection<Interactive> Interactive { get; set; }
        public virtual ICollection<TagsOfPost> TagsOfPost { get; set; }
    }
}
