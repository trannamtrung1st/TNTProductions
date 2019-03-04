using System;
using System.Collections.Generic;

namespace DataService.Models
{
    public partial class Comment
    {
        public Comment()
        {
            Interactive = new HashSet<Interactive>();
        }

        public int Id { get; set; }
        public int? ToPostId { get; set; }
        public int? ToAnswerId { get; set; }
        public string TextContent { get; set; }
        public DateTime? PostedTime { get; set; }
        public int? OfUserId { get; set; }
        public bool Active { get; set; }

        public virtual AppUser OfUser { get; set; }
        public virtual Post ToPost { get; set; }
        public virtual ICollection<Interactive> Interactive { get; set; }
    }
}
