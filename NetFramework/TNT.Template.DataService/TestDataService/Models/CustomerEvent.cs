//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace TestDataService.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class CustomerEvent
    {
        public int ID { get; set; }
        public string Code { get; set; }
        public string CustomerCode { get; set; }
        public Nullable<int> Type { get; set; }
        public Nullable<System.DateTime> HappenedTime { get; set; }
        public string Creator { get; set; }
        public string BrandCode { get; set; }
        public string Detail_AddedFilterCode { get; set; }
        public string Detail_RemovedFilterCode { get; set; }
        public string Detail_ConfirmedCode { get; set; }
        public Nullable<int> Detail_ConfirmedMediaType { get; set; }
    }
}