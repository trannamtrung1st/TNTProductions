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
    
    public partial class DeliveryInformation
    {
        public int ID { get; set; }
        public string UserId { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string City { get; set; }
        public string District { get; set; }
        public string Ward { get; set; }
        public Nullable<bool> TypeAddress { get; set; }
        public string Address { get; set; }
        public bool Active { get; set; }
        public Nullable<bool> IsDefault { get; set; }
        public Nullable<int> ProvinceCode { get; set; }
        public Nullable<int> DistrictCode { get; set; }
    
        public virtual AspNetUser AspNetUser { get; set; }
        public virtual AspNetUser AspNetUser1 { get; set; }
        public virtual District District1 { get; set; }
        public virtual Province Province { get; set; }
    }
}
