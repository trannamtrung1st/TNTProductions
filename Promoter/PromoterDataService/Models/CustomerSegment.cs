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
    
    public partial class CustomerSegment
    {
        public int CustomerIID { get; set; }
        public int SegmentIID { get; set; }
        public string CustomerSID { get; set; }
        public string SegmentSID { get; set; }
        public Nullable<bool> Active { get; set; }
    
        public virtual Customer Customer { get; set; }
        public virtual Segment Segment { get; set; }
    }
}
