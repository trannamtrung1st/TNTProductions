using System;
using System.Collections.Generic;

namespace TestDataService.Models
{
    public partial class UserStoryAcceptanceCriterias
    {
        public string Id { get; set; }
        public string StoryId { get; set; }
        public DateTime? CreatedTime { get; set; }
        public string GivenStatement { get; set; }
        public string WhenStatement { get; set; }
        public string ThenStatement { get; set; }
        public string Description { get; set; }
        public int? Priority { get; set; }

        public virtual UserStories Story { get; set; }
    }
}
