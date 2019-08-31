using System;
using System.Collections.Generic;

namespace TestDataService.Models
{
    public partial class UserStories
    {
        public UserStories()
        {
            Tasks = new HashSet<Tasks>();
            UserStoryAcceptanceCriterias = new HashSet<UserStoryAcceptanceCriterias>();
            UserStoryRequirements = new HashSet<UserStoryRequirements>();
        }

        public string Id { get; set; }
        public string Code { get; set; }
        public string ProductId { get; set; }
        public string SprintId { get; set; }
        public string EpicId { get; set; }
        public string Description { get; set; }
        public int? Status { get; set; }
        public bool? IsDefect { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? FinishedDate { get; set; }
        public string AsA { get; set; }
        public string Iwant { get; set; }
        public string SoThat { get; set; }
        public int? Priority { get; set; }

        public virtual Epics Epic { get; set; }
        public virtual Products Product { get; set; }
        public virtual ICollection<Tasks> Tasks { get; set; }
        public virtual ICollection<UserStoryAcceptanceCriterias> UserStoryAcceptanceCriterias { get; set; }
        public virtual ICollection<UserStoryRequirements> UserStoryRequirements { get; set; }
    }
}
