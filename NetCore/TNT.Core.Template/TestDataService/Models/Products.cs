using System;
using System.Collections.Generic;

namespace TestDataService.Models
{
    public partial class Products
    {
        public Products()
        {
            Epics = new HashSet<Epics>();
            Sprints = new HashSet<Sprints>();
            UserStories = new HashSet<UserStories>();
        }

        public string Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public int? Status { get; set; }

        public virtual ICollection<Epics> Epics { get; set; }
        public virtual ICollection<Sprints> Sprints { get; set; }
        public virtual ICollection<UserStories> UserStories { get; set; }
    }
}
