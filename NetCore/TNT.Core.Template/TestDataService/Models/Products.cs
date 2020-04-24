using System;
using System.Collections.Generic;

namespace TestDataService.Models
{
    public partial class Products
    {
        public Products()
        {
            SeoKeywords = new HashSet<SeoKeywords>();
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<SeoKeywords> SeoKeywords { get; set; }
    }
}
