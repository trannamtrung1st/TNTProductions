using System;
using System.Collections.Generic;

namespace TestDataService.Models
{
    public partial class UserStoryRequirements
    {
        public string Id { get; set; }
        public string RequirementContent { get; set; }
        public int? Type { get; set; }
        public string StoryId { get; set; }
        public int? Priority { get; set; }

        public virtual UserStories Story { get; set; }
    }
}
