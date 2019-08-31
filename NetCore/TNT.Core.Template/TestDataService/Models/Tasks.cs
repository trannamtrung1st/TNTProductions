using System;
using System.Collections.Generic;

namespace TestDataService.Models
{
    public partial class Tasks
    {
        public Tasks()
        {
            TaskActivities = new HashSet<TaskActivities>();
            TaskChecklists = new HashSet<TaskChecklists>();
            TaskMembers = new HashSet<TaskMembers>();
        }

        public string Id { get; set; }
        public string Title { get; set; }
        public int? Status { get; set; }
        public string Tags { get; set; }
        public string Detail { get; set; }
        public DateTime? DueTime { get; set; }
        public DateTime? StartTime { get; set; }
        public DateTime? FinishedTime { get; set; }
        public int? Priority { get; set; }
        public string SprintId { get; set; }
        public string StoryId { get; set; }

        public virtual Sprints Sprint { get; set; }
        public virtual UserStories Story { get; set; }
        public virtual ICollection<TaskActivities> TaskActivities { get; set; }
        public virtual ICollection<TaskChecklists> TaskChecklists { get; set; }
        public virtual ICollection<TaskMembers> TaskMembers { get; set; }
    }
}
