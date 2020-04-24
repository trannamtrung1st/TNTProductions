using System;
using System.Collections.Generic;

namespace TestCodeFirst.Models
{
    public partial class SeoKeywords
    {
        public string Value { get; set; }
        public int ProductId { get; set; }

        public virtual Products Product { get; set; }
    }
}
