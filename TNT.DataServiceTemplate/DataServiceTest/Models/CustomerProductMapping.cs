//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DataServiceTest.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class CustomerProductMapping
    {
        public int ID { get; set; }
        public int CustomerID { get; set; }
        public int ProductID { get; set; }
        public int TotalQuantity { get; set; }
        public System.DateTime UpdateDate { get; set; }
    
        public virtual Customer Customer { get; set; }
        public virtual Product Product { get; set; }
    }
}
