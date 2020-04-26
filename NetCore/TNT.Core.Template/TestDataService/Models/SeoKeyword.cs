using System;
using System.Collections.Generic;

namespace TestDataService.Models
{
    public partial class SeoKeyword
    {
        public int Id { get; set; }
        public string Value { get; set; }
        public int ProductId { get; set; }

        public virtual Product Product { get; set; }
    }
}
