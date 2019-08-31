using System;
using System.Collections.Generic;

namespace TestDataService.Models
{
    public partial class TaskMembers
    {
        public string UserId { get; set; }
        public string TaskId { get; set; }

        public virtual Tasks Task { get; set; }
        public virtual AspNetUsers User { get; set; }
    }
}
