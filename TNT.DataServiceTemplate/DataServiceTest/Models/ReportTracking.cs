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
    
    public partial class ReportTracking
    {
        public int Id { get; set; }
        public int StoreId { get; set; }
        public Nullable<System.DateTime> Date { get; set; }
        public Nullable<System.DateTime> DateUpdate { get; set; }
        public string UpdatePerson { get; set; }
        public Nullable<bool> IsUpdate { get; set; }
    
        public virtual Store Store { get; set; }
    }
}
