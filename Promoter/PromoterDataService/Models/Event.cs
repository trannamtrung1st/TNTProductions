//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace PromoterDataService.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Event
    {
        public int Id { get; set; }
        public Nullable<System.DateTime> Date { get; set; }
        public Nullable<int> Type { get; set; }
        public Nullable<int> CustomerId { get; set; }
        public string SourceId { get; set; }
        public Nullable<int> SourceIdDataType { get; set; }
        public Nullable<int> SourceType { get; set; }
        public string Description { get; set; }
        public string ContentObject { get; set; }
    
        public virtual Customer Customer { get; set; }
    }
}
