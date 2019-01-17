using System;
using System.Collections.Generic;

namespace TestDataService.Models
{
    public partial class TagsOfPost
    {
        public int PostId { get; set; }
        public int TagId { get; set; }

        public virtual Post Post { get; set; }
        public virtual Tags Tag { get; set; }
    }
}
