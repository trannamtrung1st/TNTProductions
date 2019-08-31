using System;
using System.Collections.Generic;

namespace TestDataService.Models
{
    public partial class Sprints
    {
        public Sprints()
        {
            Tasks = new HashSet<Tasks>();
        }

        public string Id { get; set; }
        public string Name { get; set; }
        public DateTime? CreatedTime { get; set; }
        public DateTime? FinishedTime { get; set; }
        public string SprintGoal { get; set; }
        public int? Status { get; set; }
        public string ProductId { get; set; }
        public DateTime? PlanningStartTime { get; set; }
        public DateTime? PlanningEndTime { get; set; }

        public virtual Products Product { get; set; }
        public virtual ICollection<Tasks> Tasks { get; set; }
    }
}
