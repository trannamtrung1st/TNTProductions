//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Promoter.DataService.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class PromotionAwardCashback
    {
        public int PromotionAwardId { get; set; }
        public Nullable<int> ForProductId { get; set; }
        public Nullable<int> CustomerCashbackMode { get; set; }
        public Nullable<int> CustomerCashbackAccountType { get; set; }
        public Nullable<double> CustomerCashbackAmount { get; set; }
        public Nullable<double> MaxCustomerCashbackAmount { get; set; }
        public Nullable<int> AffliatorCashbackMode { get; set; }
        public Nullable<int> AffliatorCashbackAccountType { get; set; }
        public Nullable<double> AffliatorCashbackAmount { get; set; }
        public Nullable<double> MaxAffliatorCashbackAmount { get; set; }
        public int PromotionDetailId { get; set; }
        public bool Active { get; set; }
    
        public virtual PromotionDetail PromotionDetail { get; set; }
    }
}
