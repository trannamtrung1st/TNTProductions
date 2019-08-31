using System;
using System.Collections.Generic;

namespace TestDataService.Models
{
    public partial class Epics
    {
        public Epics()
        {
            UserStories = new HashSet<UserStories>();
        }

        public string Id { get; set; }
        public string Code { get; set; }
        public string ProductId { get; set; }
        public string Description { get; set; }
        public int? Status { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? FinishedDate { get; set; }
        public string AsA { get; set; }
        public string Iwant { get; set; }
        public string SoThat { get; set; }
        public int? Priority { get; set; }

        public virtual Products Product { get; set; }
        public virtual ICollection<UserStories> UserStories { get; set; }
    }
}
