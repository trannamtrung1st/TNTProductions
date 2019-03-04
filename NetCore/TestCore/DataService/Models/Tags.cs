using System;
using System.Collections.Generic;

namespace DataService.Models
{
    public partial class Tags
    {
        public Tags()
        {
            TagsOfPost = new HashSet<TagsOfPost>();
        }

        public int Id { get; set; }
        public string TagCode { get; set; }
        public string Description { get; set; }
        public bool Active { get; set; }

        public virtual ICollection<TagsOfPost> TagsOfPost { get; set; }
    }
}
