using System;
using System.Collections.Generic;

namespace TestCodeFirst.Models
{
    public partial class Product
    {
        public Product()
        {
            SeoKeyword = new HashSet<SeoKeyword>();
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<SeoKeyword> SeoKeyword { get; set; }
    }
}
