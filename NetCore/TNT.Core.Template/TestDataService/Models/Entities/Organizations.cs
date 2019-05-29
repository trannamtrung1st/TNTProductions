using System;
using System.Collections.Generic;

namespace TestDataService.Models.Entities
{
    public partial class Organizations
    {
        public Organizations()
        {
            Projects = new HashSet<Projects>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string CreatedByUserId { get; set; }

        public virtual ICollection<Projects> Projects { get; set; }
    }
}
