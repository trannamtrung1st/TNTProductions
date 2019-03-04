using System;
using System.Collections.Generic;

namespace DataService.Models
{
    public partial class Interactive
    {
        public int Id { get; set; }
        public int? ToPostId { get; set; }
        public int? ToAnswerId { get; set; }
        public int? ToCommentId { get; set; }
        public bool? IsLike { get; set; }
        public int? OfUserId { get; set; }
        public DateTime? HappenedTime { get; set; }
        public bool Active { get; set; }

        public virtual AppUser OfUser { get; set; }
        public virtual Comment ToComment { get; set; }
        public virtual Post ToPost { get; set; }
    }
}
