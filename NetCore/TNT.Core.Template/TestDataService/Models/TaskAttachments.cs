using System;
using System.Collections.Generic;

namespace TestDataService.Models
{
    public partial class TaskAttachments
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Url { get; set; }
        public string ActivityId { get; set; }

        public virtual TaskActivities Activity { get; set; }
    }
}
