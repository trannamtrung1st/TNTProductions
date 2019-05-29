using System;
using System.Collections.Generic;

namespace TestDataService.Models.Entities
{
    public partial class Projects
    {
        public Projects()
        {
            VisionAndScopeDocs = new HashSet<VisionAndScopeDocs>();
        }

        public int Id { get; set; }
        public int OrganizationId { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }

        public virtual Organizations Organization { get; set; }
        public virtual ICollection<VisionAndScopeDocs> VisionAndScopeDocs { get; set; }
    }
}
