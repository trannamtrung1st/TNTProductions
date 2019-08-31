using System;
using System.Collections.Generic;

namespace TestDataService.Models
{
    public partial class TaskActivities
    {
        public TaskActivities()
        {
            TaskAttachments = new HashSet<TaskAttachments>();
        }

        public string Id { get; set; }
        public string TaskId { get; set; }
        public int? Type { get; set; }
        public string Detail { get; set; }
        public DateTime? Time { get; set; }

        public virtual Tasks Task { get; set; }
        public virtual ICollection<TaskAttachments> TaskAttachments { get; set; }
    }
}
