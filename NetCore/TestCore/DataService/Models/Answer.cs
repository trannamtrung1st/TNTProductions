using System;
using System.Collections.Generic;

namespace DataService.Models
{
    public partial class Answer
    {
        public int OfUserId { get; set; }
        public int ToPostId { get; set; }
        public string TextContent { get; set; }
        public DateTime? PostedTime { get; set; }
        public bool Active { get; set; }

        public virtual AppUser OfUser { get; set; }
        public virtual Post ToPost { get; set; }
    }
}
