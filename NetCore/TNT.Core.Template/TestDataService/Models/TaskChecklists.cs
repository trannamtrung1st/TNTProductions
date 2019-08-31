using System;
using System.Collections.Generic;

namespace TestDataService.Models
{
    public partial class TaskChecklists
    {
        public TaskChecklists()
        {
            TaskChecklistItems = new HashSet<TaskChecklistItems>();
        }

        public string Id { get; set; }
        public string Name { get; set; }
        public string TaskId { get; set; }

        public virtual Tasks Task { get; set; }
        public virtual ICollection<TaskChecklistItems> TaskChecklistItems { get; set; }
    }
}
