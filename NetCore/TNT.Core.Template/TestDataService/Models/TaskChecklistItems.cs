using System;
using System.Collections.Generic;

namespace TestDataService.Models
{
    public partial class TaskChecklistItems
    {
        public string Id { get; set; }
        public string ChecklistId { get; set; }
        public string ItemContent { get; set; }
        public bool? Checked { get; set; }

        public virtual TaskChecklists Checklist { get; set; }
    }
}
