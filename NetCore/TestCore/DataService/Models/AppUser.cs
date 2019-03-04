using System;
using System.Collections.Generic;

namespace DataService.Models
{
    public partial class AppUser
    {
        public AppUser()
        {
            Answer = new HashSet<Answer>();
            Comment = new HashSet<Comment>();
            Interactive = new HashSet<Interactive>();
            Post = new HashSet<Post>();
        }

        public int Id { get; set; }
        public string Username { get; set; }
        public DateTime? DoB { get; set; }
        public bool? Sex { get; set; }
        public string Email { get; set; }
        public bool Active { get; set; }

        public virtual ICollection<Answer> Answer { get; set; }
        public virtual ICollection<Comment> Comment { get; set; }
        public virtual ICollection<Interactive> Interactive { get; set; }
        public virtual ICollection<Post> Post { get; set; }
    }
}
